using MySql.Data.MySqlClient;
using Sensors.Entiteis;
using Sensors.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensors.Serveces;

namespace Sensors.Data
{
    internal class DalAgents
    {
        DbConnection dbConnection = new DbConnection();

        public List<IranianAgent> RetriveAllAgents()
        {
            List<IranianAgent> allAgents = new List<IranianAgent>();
            try
            {
                dbConnection.OpenConnection();
                string Query = "SELECT * FROM agents";

                using (var cmd = new MySqlCommand(Query, dbConnection.Get_conn()))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string type = reader.GetString("type");
                        allAgents.Add(IranianAigentFactory.CreateAgentOfType(type, Rand._random));
                    }
                }
            }
            catch (MySqlException ex)
            {
                Printer.LogError($"my sql exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Printer.LogError($"exception: {ex.Message}");
            }
            dbConnection.CloseConnection();
            return allAgents;
        }
        public int InsertAgent(IranianAgent agent)
        {
            int newId = 0;
            try
            {
                dbConnection.OpenConnection();
                string Query = @"
                                INSERT INTO agents (type)
                                VALUES (@type);
                                SELECT SCOPE_IDENTITY();";
                using (var cmd = new MySqlCommand(Query, dbConnection.Get_conn()))
                {
                    cmd.Parameters.AddWithValue("@type", agent.Type);
                    newId = Convert.ToInt32(cmd.ExecuteScalar());

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
            return newId;
        }
    }
}
