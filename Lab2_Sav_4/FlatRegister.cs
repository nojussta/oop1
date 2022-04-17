using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_4
{
    class FlatRegister
    {
        private List<Flats> AllFlats;
        public FlatRegister()
        {
            this.AllFlats = new List<Flats>();
        }
        public void Add(Flats flat)
        {
            this.AllFlats.Add(flat);
        }
        public FlatRegister FilterFlats(int[] filter)
        {
            FlatRegister filteredFlats = new FlatRegister();
            if (filter.Length == 4)
            {
                foreach (Flats flat in this.AllFlats)
                {
                    if (flat.RoomsAmount == filter[0] && flat.FlatFloor >= filter[1] && flat.FlatFloor <= filter[2] && flat.FlatCost <= filter[3])
                    {
                        filteredFlats.Add(flat);
                    }
                }
            }
            return filteredFlats;
        }
        public Flats TakeByIndex(int index)
        {
            return this.AllFlats[index];
        }

        public int FlatsCount()
        {
            return this.AllFlats.Count;
        }
    }
}
