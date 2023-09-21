using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        // properties
        public BigInteger Id {  get; private set; }

        public string Name { get; private set; }

        public string Overview { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public BigInteger SoftwareHouseID { get; private set; }

        public Videogame (BigInteger id, string name, string overview, DateTime releaseDate, BigInteger softwareHouseID)
        {
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseID = softwareHouseID;
        }

        // override ToSTring()
        public override string ToString()
        {
            return $"{Id} {Name} {Overview} {ReleaseDate} {SoftwareHouseID}";
        }
    }
}
