using MySql.Data.MySqlClient;
using RealEstateHomework.DBElements;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RealEstateHomework
{
    internal class DBManager
    {
        private static DBManager instance;
        private string connectionString = "server=localhost;database=realestateproject;user=root;password=root;";
        private DBManager()
        {
            // Private constructor to prevent instantiation
        }

        public static DBManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBManager();
                }
                return instance;
            }
        }

        public Agent GetAgent(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM agents WHERE id={id};";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Agent agent = new Agent
                            (
                                reader.GetString("username"),
                                reader.GetString("password"),
                                reader.GetFloat("commissionRate"),
                                reader.GetInt32("phoneNumber"),
                                reader.GetString("address"),
                                reader.GetInt32("totalEarnedCommission"),
                                reader.GetDateTime("created_at"),
                                reader.GetInt32("id")
                            );

                            return agent;
                        }
                    }
                }
            }

            return null;
        }
        public void InsertAgent(Agent agent)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO agents (username, password, commissionRate, phoneNumber, address, totalEarnedCommission, created_at) VALUES (@username, @password, @commissionRate, @phoneNumber, @address, @totalEarnedCommission, @created_at);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", agent.username);
                    command.Parameters.AddWithValue("@password", agent.password);
                    command.Parameters.AddWithValue("@commissionRate", agent.commissionRate);
                    command.Parameters.AddWithValue("@phoneNumber", agent.phoneNumber);
                    command.Parameters.AddWithValue("@address", agent.address);
                    command.Parameters.AddWithValue("@totalEarnedCommission", agent.totalEarnedCommission);
                    command.Parameters.AddWithValue("@created_at", agent.created_at);

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Agent> GetAgents(int startIndex, int count)
        {
            List<Agent> agents = new List<Agent>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM agents ORDER BY id LIMIT {startIndex}, {count};";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Agent agent = new Agent
                            (
                                reader.GetString("username"),
                                reader.GetString("password"),
                                reader.GetFloat("commissionRate"),
                                reader.GetInt32("phoneNumber"),
                                reader.GetString("address"),
                                reader.GetInt32("totalEarnedCommission"),
                                reader.GetDateTime("created_at"),
                                reader.GetInt32("id")
                            );

                            agents.Add(agent);
                        }
                    }
                }
            }

            return agents;
        }

        public Client GetClient(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM clients WHERE id={id};";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Client client = new Client
                            (
                                reader.GetString("username"),
                                reader.GetString("password"),
                                reader.GetString("name"),
                                reader.GetString("phoneNumber"),
                                reader.GetString("preferredPropertyType"),
                                reader.GetString("prefferedLocation"),
                                reader.GetString("priceRange"),
                                reader.GetString("shownPropertyIDs"),
                                reader.GetDateTime("created_at"),
                                reader.GetInt32("id")
                            );

                            return client;
                        }
                    }
                }
            }

            return null;
        }
        public List<Client> GetClients(int startIndex, int count)
        {
            List<Client> clients = new List<Client>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM clients ORDER BY id LIMIT {startIndex}, {count};";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Client client = new Client
                            (
                                reader.GetString("username"),
                                reader.GetString("password"),
                                reader.GetString("name"),
                                reader.GetString("phoneNumber"),
                                reader.GetString("preferredPropertyType"),
                                reader.GetString("prefferedLocation"),
                                reader.GetString("priceRange"),
                                reader.GetString("shownPropertyIDs"),
                                reader.GetDateTime("created_at"),
                                reader.GetInt32("id")
                            );

                            clients.Add(client);
                        }
                    }
                }
            }

            return clients;
        }

        public void InsertClient(Client client)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO clients (username, password, name, phoneNumber, preferredPropertyType, prefferedLocation, priceRange, shownPropertyIDs, created_at) VALUES (@username, @password, @name, @phoneNumber, @preferredPropertyType, @prefferedLocation, @priceRange, @shownPropertyIDs, @created_at);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", client.username);
                    command.Parameters.AddWithValue("@password", client.password);
                    command.Parameters.AddWithValue("@name", client.name);
                    command.Parameters.AddWithValue("@phoneNumber", client.phoneNumber);
                    command.Parameters.AddWithValue("@preferredPropertyType", client.prefferedPropertyType);
                    command.Parameters.AddWithValue("@prefferedLocation", client.prefferedLocation);
                    command.Parameters.AddWithValue("@priceRange", client.priceRange);
                    command.Parameters.AddWithValue("@shownPropertyIDs", client.shownPropertyIDs);
                    command.Parameters.AddWithValue("@created_at", client.created_at);

                    command.ExecuteNonQuery();
                }
            }
        }
        public Contract GetContract(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM contracts WHERE id={id};";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Contract contract = new Contract
                            (
                                reader.GetInt32("clientID"),
                                reader.GetInt32("agentID"),
                                reader.GetInt32("propertyID"),
                                reader.GetFloat("dealPrice"),
                                reader.GetDateTime("date"),
                                reader.GetInt32("id")
                            );

                            return contract;
                        }
                    }
                }
            }

            return null;
        }

        public void InsertContract(Contract contract)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO contracts (agentID, clientID, propertyID, date, dealPrice) VALUES (@agentID, @clientID, @propertyID, @date, @dealPrice);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@clientID", contract.clientID);
                    command.Parameters.AddWithValue("@agentID", contract.agentID);
                    command.Parameters.AddWithValue("@propertyID", contract.propertyID);
                    command.Parameters.AddWithValue("@dealPrice", contract.dealPrice);
                    command.Parameters.AddWithValue("@date", contract.date);

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Contract> GetContracts(int startIndex, int count)
        {
            List<Contract> contracts = new List<Contract>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM contracts ORDER BY id LIMIT {startIndex}, {count};";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contract contract = new Contract
                            (
                                reader.GetInt32("clientID"),
                                reader.GetInt32("agentID"),
                                reader.GetInt32("propertyID"),
                                reader.GetFloat("dealPrice"),
                                reader.GetDateTime("date"),
                                reader.GetInt32("id")
                            );

                            contracts.Add(contract);
                        }
                    }
                }
            }

            return contracts;
        }

        public Property GetProperty(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM properties WHERE id={id};";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Property property = new Property
                            (
                                reader.GetInt32("price"),
                                reader.GetInt32("roomNumber"),
                                reader.GetString("type"),
                                reader.GetString("address"),
                                reader.GetDateTime("listingDate"),
                                reader.GetFloat("feedbackRating"),
                                reader.GetInt32("id")
                            );

                            return property;
                        }
                    }
                }
            }

            return null;
        }
        public void InsertProperty(Property property)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO properties (type, address, roomNumber ,price, listingDate, feedbackRating) VALUES (@type, @address,@roomNumber,@price, @listingDate, @feedbackRating);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@price", property.price);
                    command.Parameters.AddWithValue("@roomNumber", property.roomNumber);
                    command.Parameters.AddWithValue("@type", property.type);
                    command.Parameters.AddWithValue("@address", property.address);
                    command.Parameters.AddWithValue("@listingDate", DateTime.Now);
                    command.Parameters.AddWithValue("@feedbackRating", property.feedbackRating);

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Property> GetProperties(int startIndex, int count)
        {
            List<Property> properties = new List<Property>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM properties ORDER BY id LIMIT {startIndex}, {count};";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Property property = new Property
                            (
                                reader.GetInt32("price"),
                                reader.GetInt32("roomNumber"),
                                reader.GetString("type"),
                                reader.GetString("address"),
                                reader.GetDateTime("listingDate"),
                                reader.GetFloat("feedbackRating"),
                                reader.GetInt32("id")
                            );

                            properties.Add(property);
                        }
                    }
                }
            }

            return properties;
        }
        public List<Property> GetUnderratedProperties()
        {
            List<Property> properties = new List<Property>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM properties WHERE DATEDIFF(CURDATE(), listingDate) > 90 ORDER BY id LIMIT 0, 11;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Property property = new Property
                            (
                                reader.GetInt32("price"),
                                reader.GetInt32("roomNumber"),
                                reader.GetString("type"),
                                reader.GetString("address"),
                                reader.GetDateTime("listingDate"),
                                reader.GetFloat("feedbackRating"),
                                reader.GetInt32("id")
                            );

                            properties.Add(property);
                        }
                    }
                }
            }

            return properties;
        }
        public List<Property> SearchProperty(int minPrice, int maxPrice)
        {
            List<Property> properties = new List<Property>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM properties WHERE price >= @MinPrice AND price <= @MaxPrice ORDER BY id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MinPrice", minPrice);
                    command.Parameters.AddWithValue("@MaxPrice", maxPrice);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Property property = new Property
                            (
                                reader.GetInt32("price"),
                                reader.GetInt32("roomNumber"),
                                reader.GetString("type"),
                                reader.GetString("address"),
                                reader.GetDateTime("listingDate"),
                                reader.GetFloat("feedbackRating"),
                                reader.GetInt32("id")
                            );

                            properties.Add(property);
                        }
                    }
                }
            }

            return properties;
        }
        public int GetTotalCommissionEarned()
        {
            int totalCommission = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SUM(totalEarnedCommission) AS totalCommission FROM agents";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        totalCommission = Convert.ToInt32(result);
                    }
                }
            }

            return totalCommission;
        }

    }
}
