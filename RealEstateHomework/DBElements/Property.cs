using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateHomework.DBElements
{
    internal class Property
    {
        public Property(int price, int roomNumber, string type, string address, DateTime listingDate, float feedbackRating,int id = 0 )
        {
            this.id = id;
            this.price = price;
            this.roomNumber = roomNumber;   
            this.type = type;
            this.address = address; 
            this.listingDate = listingDate;
            this.feedbackRating = feedbackRating;
        }

        public int id;
        public int price;
        public int roomNumber;
        public string type;
        public string address;
        public DateTime listingDate;
        public float feedbackRating;
    }
}
