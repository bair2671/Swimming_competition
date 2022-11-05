using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Model;
using Model.Wrraper;
using Service;

namespace Networking
{
    public class ClientWorker: Observer
    {   
        private IServices server;
        private TcpClient connection;

        private NetworkStream stream;

        private IFormatter formatter;
        private volatile bool connected;
        
        public ClientWorker(IServices server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
				
                stream=connection.GetStream();
                formatter = new BinaryFormatter();
                connected=true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run()
        {
            while(connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response!=null)
                    {
                        sendResponse((Response) response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
				
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error "+e);
            }
        }
        
	    public virtual void InscriereUpdate()
	    {
		    Console.WriteLine("Inscriere Update ");
		    try
		    {
			    sendResponse(new InscriereUpdateResponse());
		    }
		    catch (Exception e)
		    {
			    Console.WriteLine(e.StackTrace);
		    }
	    }
         
	    private Response handleRequest(Request request)
	    { 
		    Response response =null; 
		    if (request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest logReq =(LoginRequest)request;
				UtilizatorDTO udto =logReq.User;
				Utilizator user =DTOUtils.GetFromDTO(udto);
				try
                {
                    lock (server)
                    {
                        server.Login(user, this);
                    }
					return new OkResponse();
				}
				catch (AppException e)
				{
					connected=false;
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LogoutRequest)
			{
				Console.WriteLine("Logout request");
				LogoutRequest logReq =(LogoutRequest)request;
				try
				{
                    lock (server)
                    {
	                    server.Logout( this);
                    }
					connected=false;
					return new OkResponse();

				}
				catch (AppException e)
				{
				   return new ErrorResponse(e.Message);
				}
			}
			if (request is InscriereRequest)
			{
				Console.WriteLine("InscriereRequest ...");
				InscriereRequest senReq =(InscriereRequest)request;
				Inscriere[] inscrieri =senReq.Inscrieri;
				try
				{
					lock (server)
					{
						server.Inscriere(inscrieri);
					}
					return new OkResponse();
				}
				catch (AppException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is FindAllProbaWrrapersRequest)
			{
				Console.WriteLine("FindAllProbaWrrapersRequest ...");
				try
				{
					ProbaWrraper[] probe;
					lock (server)
					{ 
						probe = server.FindAllProbaWrrapers();
					}
					return new FindAllProbaWrrapersResponse(probe);
				}
				catch (AppException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is FindAllProbeRequest)
			{
				Console.WriteLine("FindAllProbeRequest ...");
				try
				{
					Proba[] probe;
					lock (server)
					{ 
						probe = server.FindAllProbe();
					}
					return new FindAllProbeResponse(probe);
				}
				catch (AppException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is ParticipantWrrapersProbaRequest)
			{
				Console.WriteLine("ParticipantWrrapersProbaRequest ...");
				try
				{
					ParticipantWrraper[] participanti;
					lock (server)
					{ 
						participanti = server.ParticipantWrrapersProba(((ParticipantWrrapersProbaRequest)request).IdProba);
					}
					return new ParticipantWrrapersProbaResponse(participanti);
				}
				catch (AppException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is FindOneProbaByDistanceAndStyleRequest)
			{
				Console.WriteLine("FindOneProbaByDistanceAndStyleRequest ...");
				try
				{
					Proba proba;
					lock (server)
					{ 
						proba = server.FindOneProbaByDistanceAndStyle(((FindOneProbaByDistanceAndStyleRequest)request).Proba);
					}
					return new FindOneProbaByDistanceAndStyleResponse(proba);
				}
				catch (AppException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			return response;
	    }

		private void sendResponse(Response response)
		{
			Console.WriteLine("sending response "+response);
            formatter.Serialize(stream, response);
            stream.Flush();
		}
		
    }
}