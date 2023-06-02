using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateHomework.DBElements
{
    internal class Client
    {
        public Client(string username, string password, string name, string phoneNumber, string prefferedPropertyType, string prefferedLocation, string priceRange, string shownPropertyIDs, DateTime created_at, int id = 0)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.prefferedPropertyType = prefferedPropertyType;
            this.prefferedLocation = prefferedLocation;
            this.priceRange = priceRange;
            this.shownPropertyIDs = shownPropertyIDs;
            this.created_at = created_at;
        }

        public int id;
        public string username;
        public string password;
        public string name;
        public string phoneNumber;
        public string prefferedPropertyType;
        public string prefferedLocation;
        public string priceRange;
        public string shownPropertyIDs;
        public DateTime created_at;
    }
}
