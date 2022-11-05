using log4net;
using Model;
using Model.Validator;
using System;
using System.Collections.Generic;
using System.Data;

namespace Persistence
{
    public class InscriereDb : InscriereRepo
    {
        private InscriereValidator Validator;
        private static readonly ILog log = LogManager.GetLogger("InscriereDb");
        public InscriereDb()
        {
            log.Info("Creating InscriereDb");
            Validator = new InscriereValidator();
        }

        public void Delete(int id)
        {
            log.InfoFormat("Deleting with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Inscrieri where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new Exception("No inscriere deleted!");
                log.InfoFormat("Deleted with value {0}", id);
            }
        }

        public IEnumerable<Inscriere> FindAll()
        {
            log.Info("Finding all");
            IDbConnection con = DBUtils.getConnection();
            IList<Inscriere> inscrieri = new List<Inscriere>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT" +
                    "    Inscrieri.id AS id_inscriere," +
                    "    Participanti.id AS id_participant," +
                    "    Participanti.nume AS nume_participant," +
                    "    Participanti.varsta AS varsta_participant," +
                    "    Probe.id AS id_proba," +
                    "    Probe.stil AS stil_proba," +
                    "    Probe.distanta AS distanta_proba " +
                    "FROM" +
                    "    Participanti" +
                    "    INNER JOIN Inscrieri ON Inscrieri.id_participant = Participanti.id" +
                    "    INNER JOIN Probe ON Probe.id = Inscrieri.id_proba";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        int idParticipant = dataR.GetInt32(1);
                        String numeParticipant = dataR.GetString(2);
                        int varstaParticipant = dataR.GetInt32(3);
                        int idProba = dataR.GetInt32(4);
                        String stilProba = dataR.GetString(5);
                        int distantaProba = dataR.GetInt32(6);

                        Participant participant = new Participant(numeParticipant, varstaParticipant);
                        participant.SetID(idParticipant);
                        Proba proba = new Proba(distantaProba, stilProba);
                        proba.SetID(idProba);
                        Inscriere inscriere = new Inscriere(participant, proba);
                        inscriere.SetID(id);
                        inscrieri.Add(inscriere);
                    }
                }
            }
            log.Info("Found all");
            return inscrieri;
        }

        public Inscriere FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT" +
                    "    Participanti.id AS id_participant," +
                    "    Participanti.nume AS nume_participant," +
                    "    Participanti.varsta AS varsta_participant," +
                    "    Probe.id AS id_proba," +
                    "    Probe.stil AS stil_proba," +
                    "    Probe.distanta AS distanta_proba " +
                    "FROM" +
                    "    Participanti" +
                    "    INNER JOIN Inscrieri ON Inscrieri.id_participant = Participanti.id" +
                    "    INNER JOIN Probe ON Probe.id = Inscrieri.id_proba " +
                    "WHERE Inscrieri.id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idParticipant = dataR.GetInt32(0);
                        String numeParticipant = dataR.GetString(1);
                        int varstaParticipant = dataR.GetInt32(2);
                        int idProba = dataR.GetInt32(3);
                        String stilProba = dataR.GetString(4);
                        int distantaProba = dataR.GetInt32(5);

                        Participant participant = new Participant(numeParticipant, varstaParticipant);
                        participant.SetID(idParticipant);
                        Proba proba = new Proba(distantaProba, stilProba);
                        proba.SetID(idProba);
                        Inscriere inscriere = new Inscriere(participant, proba);
                        inscriere.SetID(id);
                        log.InfoFormat("Exiting findOne with value {0}", inscriere);
                        return inscriere;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public IEnumerable<Participant> ParticipantiProba(int probaId)
        {
            log.Info("Finding participants by proba id");
            IDbConnection con = DBUtils.getConnection();
            IList<Participant> participanti = new List<Participant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT" +
                                   "    Participanti.id AS id_participant," +
                                   "    Participanti.nume AS nume_participant," +
                                   "    Participanti.varsta AS varsta_participant " +
                                   "FROM" +
                                   "    Participanti" +
                                   "    INNER JOIN Inscrieri ON Inscrieri.id_participant = Participanti.id" +
                                   "    INNER JOIN Probe ON Probe.id = Inscrieri.id_proba " +
                                   "WHERE Probe.id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = probaId;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        int varsta = dataR.GetInt32(2);

                        Participant participant = new Participant(nume, varsta);
                        participant.SetID(id);
                        participanti.Add(participant);
                    }
                }
            }
            log.Info("Found participants by proba id");
            return participanti;
        }

        public IEnumerable<Proba> ProbeParticipant(int participantId)
        {
            log.Info("Finding probas by participant id");
            IDbConnection con = DBUtils.getConnection();
            IList<Proba> probe = new List<Proba>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT" +
                                   "    Probe.id AS id_proba," +
                                   "    Probe.stil AS stil_proba," +
                                   "    Probe.distanta AS distanta_proba " +
                                   "FROM" +
                                   "    Probe" +
                                   "    INNER JOIN Inscrieri ON Inscrieri.id_proba = Probe.id " +
                                   "    INNER JOIN Participanti ON Participanti.id = Inscrieri.id_participant " +
                                   "WHERE Participanti.id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = participantId;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String stil = dataR.GetString(1);
                        int distanta = dataR.GetInt32(2);

                        Proba proba = new Proba(distanta, stil);
                        proba.SetID(id);
                        probe.Add(proba);
                    }
                }
            }
            log.Info("Found probas by participant id");
            return probe;
        }

        public void Save(Inscriere entity)
        {
            log.InfoFormat("Adding with value {0}", entity);
            Validator.Validate(entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Inscrieri(id_participant, id_proba)  values (@id_participant, @id_proba)";

                var paramIdParticipant = comm.CreateParameter();
                paramIdParticipant.ParameterName = "@id_participant";
                paramIdParticipant.Value = entity.GetParticipant().GetID();
                comm.Parameters.Add(paramIdParticipant);

                var paramIdProba = comm.CreateParameter();
                paramIdProba.ParameterName = "@id_proba";
                paramIdProba.Value = entity.GetProba().GetID();
                comm.Parameters.Add(paramIdProba);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No inscriere added !");
                log.InfoFormat("Added with value {0}", entity);
            }
        }

        public void Update(Inscriere entity)
        {
            log.InfoFormat("Updating with value {0}", entity);
            Validator.Validate(entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Inscrieri set id_participant=@id_participant, id_proba=@id_proba where id=@id";

                var paramIdParticipant = comm.CreateParameter();
                paramIdParticipant.ParameterName = "@id_participant";
                paramIdParticipant.Value = entity.GetParticipant().GetID();
                comm.Parameters.Add(paramIdParticipant);

                var paramIdProba = comm.CreateParameter();
                paramIdProba.ParameterName = "@id_proba";
                paramIdProba.Value = entity.GetProba().GetID();
                comm.Parameters.Add(paramIdProba);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.GetID();
                comm.Parameters.Add(paramId);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No inscriere updated !");
                log.InfoFormat("Updated with value {0}", entity);
            }
        }
    }
}
