using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3AdoDA
{
    public class DAEngine
    {
        static string connectionstring =
            ConfigurationManager.ConnectionStrings["Myconnectionstring"].ToString();

        public static List<Engine> GetAllEngines()
        {
            List<Engine> Engines = new List<Engine>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select * from Engine");

                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Engine temp = new Engine();
                    temp.DbId = reader.GetInt32(0);
                    temp.Displacement = reader.GetInt32(1);
                    temp.CylinderCount = reader.GetInt32(2);
                    temp.Name = reader.GetString(3);
                    temp.Make = reader.GetString(4);
                    Engines.Add(temp);
                }
            }
            return Engines;
        }

        public static Engine GetEngineById(int id)
        {
            Engine foundEngine = null;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"Select * from Engine where Id = {id}");
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundEngine = new Engine();
                    foundEngine.DbId = reader.GetInt32(0);
                    foundEngine.Displacement = reader.GetInt32(1);
                    foundEngine.CylinderCount = reader.GetInt32(2);
                    foundEngine.Name = reader.GetString(3);
                    foundEngine.Make = reader.GetString(4);
                }
            }
            return foundEngine;
        }

        public static Engine GetEngineByName(string name)
        {
            Engine foundEngine = null;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"Select * from Engine where EngName = '{name}'");
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundEngine = new Engine();
                    foundEngine.DbId = reader.GetInt32(0);
                    foundEngine.Displacement = reader.GetInt32(1);
                    foundEngine.CylinderCount = reader.GetInt32(2);
                    foundEngine.Name = reader.GetString(3);
                    foundEngine.Make = reader.GetString(4);
                }
            }
            return foundEngine;
        }

        public static int CreateEngine(Models.Engine Vparam)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"insert into Engine (Id,Displacement,CylCnt,EngName,EngMake) values('{Vparam.DbId}','{Vparam.Displacement}','{Vparam.CylinderCount}','{Vparam.Name}','{Vparam.Make}')");
                command.Connection = conn;
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public static int UpdateEngine(Models.Engine Vparam)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"update Engine set Displacement = '{Vparam.Displacement}', CylCnt = '{Vparam.CylinderCount}', EngName = '{Vparam.Name}', EngMake= '{Vparam.Make}' where Id = {Vparam.DbId}");
                command.Connection = conn;
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public static int DeleteEngine(int id)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"Delete from Engine where Id = {id}");
                command.Connection = conn;
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
