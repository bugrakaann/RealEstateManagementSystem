using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateHomework.DBElements
{
    internal class Agent
    {
        public Agent(string username, string password, float commissionRate, int phoneNumber, string address, int totalEarnedCommission, DateTime created_at,int id = 0)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.commissionRate = commissionRate;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.totalEarnedCommission = totalEarnedCommission;
            this.created_at = created_at;
        }

        public int id;
        public string username;
        public string password;
        public float commissionRate;
        public int phoneNumber;
        public string address;
        public int totalEarnedCommission;
        public DateTime created_at;
    }
}
