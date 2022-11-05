using log4net;
using Model;
using Model.Validator;
using System;
using System.Collections.Generic;
using System.Data;

namespace Persistence
{
    public class UtilizatorDb : UtilizatorRepo
    {
        private UtilizatorValidator Validator;
        private static readonly ILog log = LogManager.GetLogger("UtilizatorDb");
        public UtilizatorDb()
        {
            log.Info("Creating UtilizatorDb");
            Validator = new UtilizatorValidator();
        }

        public void Delete(int id)
        {
            log.InfoFormat("Deleting with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Utilizatori where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new Exception("No utilizator deleted!");
                log.InfoFormat("Deleted with value {0}", id);
            }
        }

        public IEnumerable<Utilizator> FindAll()
        {
            log.Info("Finding all");
            IDbConnection con = DBUtils.getConnection();
            IList<Utilizator> utilizatori = new List<Utilizator>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nume, prenume, username, password from Utilizatori";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String prenume = dataR.GetString(2);
                        String username = dataR.GetString(3);
                        String password = dataR.GetString(4);

                        Utilizator utilizator = new Utilizator(nume, prenume, username, password);
                        utilizator.SetID(id);
                        utilizatori.Add(utilizator);
                    }
                }
            }
            log.Info("Found all");
            return utilizatori;
        }

        public Utilizator FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select nume, prenume, username, password from Utilizatori where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        String nume = dataR.GetString(0);
                        String prenume = dataR.GetString(1);
                        String username = dataR.GetString(2);
                        String password = dataR.GetString(3);

                        Utilizator utilizator = new Utilizator(nume, prenume, username, password);
                        utilizator.SetID(id);
                        log.InfoFormat("Exiting findOne with value {0}", utilizator);
                        return utilizator;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public Utilizator FindOneByUsername(string username)
        {
            log.InfoFormat("Entering findOneByUsername with value {0}", username);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nume, prenume, password from Utilizatori where username=@username";
                var paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = username;
                comm.Parameters.Add(paramUsername);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String prenume = dataR.GetString(2);
                        String password = dataR.GetString(3);

                        Utilizator utilizator = new Utilizator(nume, prenume, username, password);
                        utilizator.SetID(id);
                        log.InfoFormat("Exiting findOneByUsername with value {0}", username);
                        return utilizator;
                    }
                }
            }
            log.InfoFormat("Exiting findOneByUserName with value {0}", null);
            return null;
        }

        public void Save(Utilizator entity)
        {
            log.InfoFormat("Adding with value {0}", entity);
            Validator.Validate(entity);
            if (FindOneByUsername(entity.GetUsername()) != null)
                throw new ExistentObjectException("Exista deja un utlizator cu acest username!");
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Utilizatori(nume,prenume,username,password)  values (@nume, @prenume, @username, @password)";

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.GetNume();
                comm.Parameters.Add(paramNume);

                var paramPrenume = comm.CreateParameter();
                paramPrenume.ParameterName = "@prenume";
                paramPrenume.Value = entity.GetPrenume();
                comm.Parameters.Add(paramPrenume);

                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = entity.GetUsername();
                comm.Parameters.Add(paramUsername);

                IDbDataParameter paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = entity.GetPassword();
                comm.Parameters.Add(paramPassword);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No utilizator added !");
                log.InfoFormat("Added with value {0}", entity);
            }
        }

        public void Update(Utilizator entity)
        {
            log.InfoFormat("Updating with value {0}", entity);
            Validator.Validate(entity);
            Utilizator user = FindOneByUsername(entity.GetUsername());
            if (user != null && user.GetID()!=entity.GetID())
                throw new ExistentObjectException("Exista deja un utlizator cu acest username!");
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Utilizatori set nume=@nume, prenume=@prenume, username=@username, password=@password where id=@id";

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.GetNume();
                comm.Parameters.Add(paramNume);

                var paramPrenume = comm.CreateParameter();
                paramPrenume.ParameterName = "@prenume";
                paramPrenume.Value = entity.GetPrenume();
                comm.Parameters.Add(paramPrenume);

                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = entity.GetUsername();
                comm.Parameters.Add(paramUsername);

                IDbDataParameter paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = entity.GetPassword();
                comm.Parameters.Add(paramPassword);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.GetID();
                comm.Parameters.Add(paramId);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No utilizator updated !");
                log.InfoFormat("Updated with value {0}", entity);
            }
        }
    }
}
