using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateHomework.DBElements
{
    internal class Contract
    {
        public Contract(int clientID, int agentID, int propertyID, float dealPrice, DateTime date, int id = 0)
        {
            this.id = id;
            this.clientID = clientID;
            this.agentID = agentID;
            this.propertyID = propertyID;
            this.dealPrice = dealPrice;
            this.date = date;
        }

        public int id;
        public int clientID;
        public int agentID;
        public int propertyID;
        public float dealPrice;
        public DateTime date;
    }
}
