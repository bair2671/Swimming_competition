using log4net;
using Model;
using Model.Validator;
using System;
using System.Collections.Generic;
using System.Data;

namespace Persistence
{
    public class ParticipantDb : ParticipantRepo
    {
        private ParticipantValidator Validator;
        private static readonly ILog log = LogManager.GetLogger("ParticipantDb");
        public ParticipantDb()
        {
            log.Info("Creating ParticipantDb");
            Validator = new ParticipantValidator();
        }

        public void Delete(int id)
        {
            log.InfoFormat("Deleting with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Participanti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new Exception("No participant deleted!");
                log.InfoFormat("Deleted with value {0}", id);
            }
        }

        public IEnumerable<Participant> FindAll()
        {
            log.Info("Finding all");
            IDbConnection con = DBUtils.getConnection();
            IList<Participant> participanti = new List<Participant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nume, varsta from Participanti";
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
            log.Info("Found all");
            return participanti;
        }

        public Participant FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select nume, varsta from Participanti where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        String nume = dataR.GetString(0);
                        int varsta = dataR.GetInt32(1);

                        Participant participant = new Participant(nume, varsta);
                        participant.SetID(id);
                        log.InfoFormat("Exiting findOne with value {0}", participant);
                        return participant;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public Participant FindOneByName(string nume)
        {
            log.InfoFormat("Entering findOneByName with value {0}", nume);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, varsta from Participanti where nume=@nume";
                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = nume;
                comm.Parameters.Add(paramNume);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        int varsta = dataR.GetInt32(1);

                        Participant participant = new Participant(nume, varsta);
                        participant.SetID(id);
                        log.InfoFormat("Exiting findOneByName with value {0}", participant);
                        return participant;
                    }
                }
            }
            log.InfoFormat("Exiting findOneByName with value {0}", null);
            return null;
        }

        public void Save(Participant entity)
        {
            log.InfoFormat("Adding with value {0}", entity);
            Validator.Validate(entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Participanti(nume, varsta)  values (@nume, @varsta)";

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.GetNume();
                comm.Parameters.Add(paramNume);

                IDbDataParameter paramVarsta = comm.CreateParameter();
                paramVarsta.ParameterName = "@varsta";
                paramVarsta.Value = entity.GetVarsta();
                comm.Parameters.Add(paramVarsta);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No participant added !");
                log.InfoFormat("Added with value {0}", entity);
            }
        }

        public void Update(Participant entity)
        {
            log.InfoFormat("Updating with value {0}", entity);
            Validator.Validate(entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Participanti set nume=@nume, varsta=@varsta where id=@id";

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.GetNume();
                comm.Parameters.Add(paramNume);

                IDbDataParameter paramVarsta = comm.CreateParameter();
                paramVarsta.ParameterName = "@varsta";
                paramVarsta.Value = entity.GetVarsta();
                comm.Parameters.Add(paramVarsta);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.GetID();
                comm.Parameters.Add(paramId);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No participant updated !");
                log.InfoFormat("Updated with value {0}", entity);
            }
        }
    }
}
