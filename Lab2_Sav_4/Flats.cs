using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_4
{
    class Flats
    {
        public int FlatNumber { get; set; }
        public int FlatSpace { get; set; }
        public int RoomsAmount { get; set; }
        public int FlatCost { get; set; }
        public string SellersNumber { get; set; }

        public Flats(int flatNumber, int flatSpace, int roomsAmount, int flatCost, string sellersNumber)
        {
            this.FlatNumber = flatNumber;
            this.FlatSpace = flatSpace;
            this.RoomsAmount = roomsAmount;
            this.FlatCost = flatCost;
            this.SellersNumber = sellersNumber;
        }
        public int FlatFloor
        {
            get
            {
                if (this.FlatNumber % 27 > 0)
                {
                    return (int)Math.Ceiling(Convert.ToDecimal(this.FlatNumber % 27) / 3);
                }
                else
                {
                    return 9;
                }
            }
        }
    }
}
