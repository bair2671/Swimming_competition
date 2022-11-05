using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Model;
using Model.Wrraper;
using Service;

namespace Networking
{
    public class ServerProxy:IServices
    {   
        private string host;
        private int port;

        private Observer client;

        private NetworkStream stream;
		
        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;
        
        public ServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses=new Queue<Response>();
        }

        public void SetClient(Observer client)
        {
	        this.client = client;
        }
        
        public virtual void Login(Utilizator user, Observer client)
        {
	        initializeConnection();
	        UtilizatorDTO udto = DTOUtils.GetDTO(user);
	        sendRequest(new LoginRequest(udto));
	        Response response =readResponse();
	        if (response is OkResponse)
	        {
		        this.client=client;
		        return;
	        }
	        if (response is ErrorResponse)
	        {
		        ErrorResponse err =(ErrorResponse)response;
		        closeConnection();
		        throw new AppException(err.Message);
	        }
        }

        public virtual void Logout(Observer client)
        {
	        sendRequest(new LogoutRequest());
	        Response response =readResponse();
	        closeConnection();
	        if (response is ErrorResponse)
	        {
		        ErrorResponse err =(ErrorResponse)response;
		        throw new AppException(err.Message);
	        }
        }

        public virtual Proba[] FindAllProbe()
        {
	        sendRequest(new FindAllProbeRequest());
	        Response response =readResponse();
	        if (response is ErrorResponse)
	        {
		        ErrorResponse err =(ErrorResponse)response;
		        throw new AppException(err.Message);
	        }
	        FindAllProbeResponse resp =(FindAllProbeResponse)response;
	        Proba[] probe = resp.Probe;
	        return probe;
        }

        public Proba FindOneProbaByDistanceAndStyle(Proba proba)
        {
	        sendRequest(new FindOneProbaByDistanceAndStyleRequest(proba));
	        Response response =readResponse();
	        if (response is ErrorResponse)
	        {
		        ErrorResponse err =(ErrorResponse)response;
		        throw new AppException(err.Message);
	        }
	        FindOneProbaByDistanceAndStyleResponse resp =(FindOneProbaByDistanceAndStyleResponse)response;
	        proba = resp.Proba;
	        return proba;
        }

        public virtual ProbaWrraper[] FindAllProbaWrrapers()
        {
	        sendRequest(new FindAllProbaWrrapersRequest());
	        Response response =readResponse();
	        if (response is ErrorResponse)
	        {
		        ErrorResponse err =(ErrorResponse)response;
		        throw new AppException(err.Message);
	        }
	        FindAllProbaWrrapersResponse resp =(FindAllProbaWrrapersResponse)response;
	        ProbaWrraper[] probe = resp.Probe;
	        return probe;
        }

        public virtual ParticipantWrraper[] ParticipantWrrapersProba(int id)
        {
	        sendRequest(new ParticipantWrrapersProbaRequest(id));
	        Response response =readResponse();
	        if (response is ErrorResponse)
	        {
		        ErrorResponse err =(ErrorResponse)response;
		        throw new AppException(err.Message);
	        }
	        ParticipantWrrapersProbaResponse resp =(ParticipantWrrapersProbaResponse)response;
	        ParticipantWrraper[] participanti = resp.Participanti;
	        return participanti;
        }

        public virtual void Inscriere(Inscriere[] inscrieri)
        {
	        sendRequest(new InscriereRequest(inscrieri));
	        Response response =readResponse();
	        if (response is ErrorResponse)
	        {
		        ErrorResponse err =(ErrorResponse)response;
		        throw new AppException(err.Message);
	        }
        }
        
        private void closeConnection()
		{
			finished=true;
			try
			{
				stream.Close();
				//output.close();
				connection.Close();
                _waitHandle.Close();
				client=null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void sendRequest(Request request)
		{
			try
			{
                formatter.Serialize(stream, request);
                stream.Flush();
			}
			catch (Exception e)
			{
				throw new AppException("Error sending object "+e);
			}

		}

		private Response readResponse()
		{
			Response response =null;
			try
			{
                _waitHandle.WaitOne();
				lock (responses)
				{
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
			return response;
		}
		
		private void initializeConnection()
		{
			 try
			 {
				connection=new TcpClient(host,port);
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				finished=false;
                _waitHandle = new AutoResetEvent(false);
				startReader();
			}
			catch (Exception e)
			{
                Console.WriteLine(e.StackTrace);
			}
		}
		
		private void startReader()
		{
			Thread tw =new Thread(run);
			tw.Start();
		}
		
		private void handleUpdate(UpdateResponse update)
		{
			if (update is InscriereUpdateResponse)
			{
				Console.WriteLine("InscriereUpdate ");
				try
				{
					client.InscriereUpdate();
				}
				catch (AppException e)
				{
					Console.WriteLine(e.StackTrace); 
				}
			}
		}
		
	    public virtual void run()
	    {
		    while(!finished)
		    {
			    try
			    {
				    object response = formatter.Deserialize(stream);
				    Console.WriteLine("response received "+response);
				    if (response is UpdateResponse)
				    {
					    handleUpdate((UpdateResponse)response);
				    }
				    else
				    {
					    lock (responses)
					    {
						    responses.Enqueue((Response)response);
					    }
					    _waitHandle.Set();
				    }
			    }
			    catch (Exception e)
			    { 
				    Console.WriteLine("Reading error "+e);
			    }
		    }
	    }
	    
    }
}