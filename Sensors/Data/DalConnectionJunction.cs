using MySql.Data.MySqlClient;
using Sensors.Serveces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Data
{
    internal class DalConnectionJunction
    {
        DbConnection dbConnection = new DbConnection();

        public void InsertConnJanction(int sensorId, int agentId)
        {
            try
            {
                dbConnection.OpenConnection();
                string Query = @"
                                INSERT INTO ConnectionJunction (sensor_id, agent_id)
                                VALUES (@sensor_id, @agent_id);";
                using (var cmd = new MySqlCommand(Query, dbConnection.Get_conn()))
                {
                    cmd.Parameters.AddWithValue("@sensor_id", sensorId);
                    cmd.Parameters.AddWithValue("@agent_id", agentId);
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        Debuger.LogDebugMessage($"sensor id: {sensorId} has been attached to agent id: {agentId}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Printer.LogError($"my sql exeption {ex.Message}");
            }
            catch (Exception ex)
            {
                Printer.LogError($"exeption: {ex.Message}");
            }
            dbConnection.CloseConnection();
        }
    }
}
