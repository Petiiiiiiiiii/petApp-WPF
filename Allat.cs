using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petApp
{
    internal class Allat
    {
        public string Fajta { get; set; }
        public int Eves { get; set; }
        public string Szine { get; set; }
        public string ImageUrl { get; set; }

        public Allat(string sor)
        {
            var atmeneti = sor.Split(';');
            Fajta = atmeneti[0];
            Eves = Convert.ToInt32(atmeneti[1]);
            Szine = atmeneti[2];
            ImageUrl = atmeneti[3];
        }

        public override string ToString()
        {
            return $"Fajta: {this.Fajta}\nKora: {this.Eves}\nSzíne: {this.Szine}";
        }
    }
}
