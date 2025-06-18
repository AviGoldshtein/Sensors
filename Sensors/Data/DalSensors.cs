using MySql.Data.MySqlClient;
using Sensors.Entiteis;
using Sensors.Factorys;
using Sensors.Serveces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Data
{
    internal class DalSensors
    {
        DbConnection dbConnection = new DbConnection();

        public List<BaseSensor> RetriveAllSensors()
        {
            List<BaseSensor> allSensors = new List<BaseSensor>();
            try
            {
                dbConnection.OpenConnection();
                string Query = "SELECT * FROM sensors";

                using (var cmd = new MySqlCommand(Query, dbConnection.Get_conn()))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string type = reader.GetString("name");
                        allSensors.Add(SensorFactory.CreateSensorByType(type));
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"my sql exception: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"exception: {ex.Message}");
            }
            dbConnection.CloseConnection();
            return allSensors;
        }
        public int InsertSensor(BaseSensor sensor)
        {
            int newId = 0;
            try
            {
                dbConnection.OpenConnection();
                string Query = @"
                                INSERT INTO sensors (name)
                                VALUES (@name);
                                SELECT SCOPE_IDENTITY();";

                using (var cmd = new MySqlCommand(Query, dbConnection.Get_conn()))
                {
                    cmd.Parameters.AddWithValue("@name", sensor.Name);
                    newId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"my sql exeption {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"exeption: {ex.Message}");
            }
            dbConnection.CloseConnection();
            return newId;
        }
    }
}
