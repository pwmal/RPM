using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4kurs.Classes
{
    public class Booking
    {
        public int id { get; set; }
        public int duration { get; set; }
        public int room_id { get; set; }

        public Booking(int id, int duration, int room_id)
        {
            this.id= id;
            this.duration = duration;
            this.room_id = room_id;
        }

        //public static double BookingCost(Booking a)
        //{
        //    double result = a.cost * a.duration;
        //    return result;
        //}

        //public static double BookingCostPerPerson(Booking a)
        //{
        //    double result = (a.cost*a.duration) / a.size;
        //    return result;
        //}
    }
}
