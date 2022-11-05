using log4net;
using Model;
using Model.Validator;
using System;
using System.Collections.Generic;
using System.Data;

namespace Persistence
{
    public class ProbaDb : ProbaRepo
    {
        private ProbaValidator Validator;
        private static readonly ILog log = LogManager.GetLogger("ProbaDb");
        public ProbaDb()
        {
            log.Info("Creating ProbaDb");
            Validator = new ProbaValidator();
        }

        public void Delete(int id)
        {
            log.InfoFormat("Deleting with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Probe where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new Exception("No proba deleted!");
                log.InfoFormat("Deleted with value {0}", id);
            }
        }

        public IEnumerable<Proba> FindAll()
        {
            log.Info("Finding all");
            IDbConnection con = DBUtils.getConnection();
            IList<Proba> probe = new List<Proba>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, distanta, stil from Probe";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        int distanta = dataR.GetInt32(1);
                        String stil = dataR.GetString(2);

                        Proba proba = new Proba(distanta, stil);
                        proba.SetID(id);
                        probe.Add(proba);
                    }
                }
            }
            log.Info("Found all");
            return probe;
        }

        public Proba FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select distanta, stil from Probe where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int distanta = dataR.GetInt32(0);
                        String stil = dataR.GetString(1);

                        Proba proba = new Proba(distanta, stil);
                        proba.SetID(id);
                        log.InfoFormat("Exiting findOne with value {0}", proba);
                        return proba;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public Proba FindOneByDistanceAndStyle(int distanta, string stil)
        {
            log.InfoFormat("Entering findOneByDistanceAndStyle with value {0}, {1}",distanta,stil);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id from Probe where distanta=@dist and stil=@stil";
                var paramDist = comm.CreateParameter();
                paramDist.ParameterName = "@dist";
                paramDist.Value = distanta;
                comm.Parameters.Add(paramDist);
                var paramStil = comm.CreateParameter();
                paramStil.ParameterName = "@stil";
                paramStil.Value = stil;
                comm.Parameters.Add(paramStil);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);

                        Proba proba = new Proba(distanta, stil);
                        proba.SetID(id);
                        log.InfoFormat("Exiting findOneByDistanceAndStyle with value {0}", proba);
                        return proba;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void Save(Proba entity)
        {
            log.InfoFormat("Adding with value {0}", entity);
            Validator.Validate(entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Probe(distanta, stil)  values (@distanta, @stil)";

                var paramDistanta = comm.CreateParameter();
                paramDistanta.ParameterName = "@distanta";
                paramDistanta.Value = entity.GetDistanta();
                comm.Parameters.Add(paramDistanta);

                var paramStil = comm.CreateParameter();
                paramStil.ParameterName = "@stil";
                paramStil.Value = entity.GetStil();
                comm.Parameters.Add(paramStil);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No proba added !");
                log.InfoFormat("Added with value {0}", entity);
            }
        }

        public void Update(Proba entity)
        {
            log.InfoFormat("Updating with value {0}", entity);
            Validator.Validate(entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Probe set distanta=@distanta, stil=@stil where id=@id";

                var paramDistanta = comm.CreateParameter();
                paramDistanta.ParameterName = "@distanta";
                paramDistanta.Value = entity.GetDistanta();
                comm.Parameters.Add(paramDistanta);

                var paramStil = comm.CreateParameter();
                paramStil.ParameterName = "@stil";
                paramStil.Value = entity.GetStil();
                comm.Parameters.Add(paramStil);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.GetID();
                comm.Parameters.Add(paramId);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No proba updated !");
                log.InfoFormat("Updated with value {0}", entity);
            }
        }
    }
}
