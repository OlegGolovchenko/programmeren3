using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Models;

namespace P3AdoDA
{
    public class DAVehicule
    {
        static string connectionstring =
            ConfigurationManager.ConnectionStrings["Myconnectionstring"].ToString();

        public static List<Vehicule> GetAllVehicules()
        {
            List<Vehicule> vehicules = new List<Vehicule>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select * from Vehicule");

                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Vehicule temp = new Vehicule();
                    temp.Dbid = reader.GetInt32(0);
                    temp.Vin = reader.GetString(1);
                    temp.Make = reader.GetString(2);
                    temp.Model = reader.GetString(3);
                    temp.Ename = reader.GetString(4);
                    vehicules.Add(temp);
                }
            }
            return vehicules;
        }

        public static Vehicule GetVehiculeById(int id)
        {
           Vehicule foundVehicule = null;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"Select * from Vehicule where Id = {id}");
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundVehicule = new Vehicule();
                    foundVehicule.Dbid = reader.GetInt32(0);
                    foundVehicule.Vin = reader.GetString(1);
                    foundVehicule.Make = reader.GetString(2);
                    foundVehicule.Model = reader.GetString(3);
                    foundVehicule.Ename = reader.GetString(4);
                }
            }
            return foundVehicule;
        }

        public static int CreateVehicule(Models.Vehicule Vparam)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"insert into Vehicule (Vin,Make,Model,EngName) values('{Vparam.Vin}','{Vparam.Make}','{Vparam.Model}','{Vparam.Ename}')");
                command.Connection = conn;
                 rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public static int UpdateVehicule(Models.Vehicule Vparam)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"update Vehicule set Vin = '{Vparam.Vin}', Make = '{Vparam.Make}', Model = '{Vparam.Model}', EngName'{Vparam.Ename}' where Id = {Vparam.Dbid}");
                command.Connection = conn;
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public static int DeleteVehicule(int id)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"Delete from Vehicule where Id = {id}");
                command.Connection = conn;
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
