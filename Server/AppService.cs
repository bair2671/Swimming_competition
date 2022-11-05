using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using Model.Wrraper;
using Persistence;
using Service;

namespace Server
{
    public class AppService : IServices
    { 
        UtilizatorRepo UtilizatorRepo;
        ParticipantRepo ParticipantRepo;
        ProbaRepo ProbaRepo;
        InscriereRepo InscriereRepo;
        private readonly BlockingCollection<Observer> LoggedClients;

        public AppService(UtilizatorRepo utilizatorRepo, ProbaRepo probaRepo,ParticipantRepo participantRepo, InscriereRepo inscriereRepo)
        {
            this.UtilizatorRepo = utilizatorRepo;
            this.ParticipantRepo = participantRepo;
            this.ProbaRepo = probaRepo;
            this.InscriereRepo = inscriereRepo;
            LoggedClients = new BlockingCollection<Observer>();
        }

        public void Login(Utilizator user, Observer client)
        {
            Utilizator utilizator=UtilizatorRepo.FindOneByUsername(user.GetUsername());
            if (utilizator!=null){
                if(utilizator.GetPassword()!=user.GetPassword())
                    throw new AppException("Parola incorecta!");
                else if(LoggedClients.Contains(client)) { 
                    throw new AppException("Client deja conectat!");
                }
                LoggedClients.Add(client);
            }
            else
                throw new AppException("Nu exista utilizator cu acest username!");
        }

        public void Logout(Observer client)
        {
            if (!LoggedClients.TryTake(out client))
                throw new AppException("Clientul nu este logat in aplicatie!");
        }

        public Proba[] FindAllProbe()
        {
            IEnumerable<Proba> probe=ProbaRepo.FindAll();
            List<Proba> result = new List<Proba>();
            Console.WriteLine("Find all probe");
            foreach (Proba proba in probe){
                result.Add(proba);
                Console.WriteLine("Proba with id +"+proba.GetID());
            }
            Console.WriteLine("Size "+result.Count);
            return result.ToArray();
        }

        public Proba FindOneProbaByDistanceAndStyle(Proba proba)
        {
            Console.WriteLine("Find proba by distance: "+proba.GetDistanta()+" , and style: "+proba.GetStil());
            proba= ProbaRepo.FindOneByDistanceAndStyle(proba.GetDistanta(),proba.GetStil());
            Console.WriteLine("Proba with id +"+proba.GetID());
            return proba;
        }

        public ProbaWrraper[] FindAllProbaWrrapers()
        {
            IEnumerable probe=ProbaRepo.FindAll();
            List<ProbaWrraper> result=new List<ProbaWrraper>();
            Console.WriteLine("Find all probaWrrapers");
            foreach (Proba proba in probe){
                result.Add(new ProbaWrraper(proba,((List<Participant>)InscriereRepo.ParticipantiProba(proba.GetID())).Count));
                Console.WriteLine("ProbaWrraper with id +"+proba.GetID());
            }
            Console.WriteLine("Size "+result.Count);
            return result.ToArray();
        }

        public ParticipantWrraper[] ParticipantWrrapersProba(int id)
        {
            IEnumerable<Participant> participanti=InscriereRepo.ParticipantiProba(id);
            List<ParticipantWrraper> result=new List<ParticipantWrraper>();
            Console.WriteLine("Find participanti for proba with id "+id);
            foreach (Participant participant in participanti){
                String probe = "";
                foreach(Proba proba in InscriereRepo.ProbeParticipant(participant.GetID())){
                    probe += proba.GetDistanta() + "m " + proba.GetStil()+" \n";
                }
                result.Add(new ParticipantWrraper(participant,probe));
                Console.WriteLine("Participant with id +"+participant.GetID());
            }
            Console.WriteLine("Size "+result.Count);
            return result.ToArray();
        }

        public void Inscriere(Inscriere[] inscrieri)
        {
            Participant participant = ParticipantRepo.FindOneByName(inscrieri[0].GetParticipant().GetNume());
            if(participant==null) {
                ParticipantRepo.Save(inscrieri[0].GetParticipant());
                participant = ParticipantRepo.FindOneByName(inscrieri[0].GetParticipant().GetNume());
            }
            foreach(Inscriere inscriere in inscrieri)
            {
                Proba proba = ProbaRepo.FindOneByDistanceAndStyle(inscriere.GetProba().GetDistanta(), inscriere.GetProba().GetStil());
                InscriereRepo.Save(new Inscriere(participant,proba));
            }
            NotifyInscriereUpdate();
        }

        private void NotifyInscriereUpdate()
        {
            foreach (Observer obs in LoggedClients)
            {
                Console.WriteLine("Notifying [" + obs + "] [ new Inscriere.");
                obs.InscriereUpdate();
            }
        }
    }
}