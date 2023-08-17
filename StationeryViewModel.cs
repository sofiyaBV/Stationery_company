using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery_company2
{
    class StationeryViewModel
    {
        public List<Stationery> Stationery { get; set; }

        public StationeryViewModel()
        {
            Stationery = new List<Stationery>();
        }


        public void AddStationery(Stationery stationery)
        {
            Stationery.Add(stationery);
        }
        public void RemoveStationery(Stationery stationery)
        {
            Stationery.Remove(stationery);
        }
        public void CliarStationery(Stationery stationery)
        {
            Stationery.Clear();
        }
    }
}
