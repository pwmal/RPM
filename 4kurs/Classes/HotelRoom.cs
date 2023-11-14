using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4kurs.Classes
{
    public class HotelRoom
    {
        public int id { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public double cost { get; set; }

        public HotelRoom(int id, string type, int size, double cost)
        {
            this.id = id;
            this.type = type;
            this.size = size;
            this.cost = cost;
        }

        public HotelRoom()
        {

        }

        public static double CostPerPerson(HotelRoom a)
        {
            double result = a.cost/a.size;
            return result;
        }
    }
}
