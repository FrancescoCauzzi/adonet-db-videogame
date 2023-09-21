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
        public long Id {  get; private set; }

        public string Name { get; private set; }

        public string Overview { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public long SoftwareHouseId { get; private set; }

        public Videogame (long id, string name, string overview, DateTime releaseDate, long softwareHouseId)
        {
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }

        // override ToSTring()
        public override string ToString()
        {
            return @$"
Videogame Id: {Id} 
Name: {Name} 
Overview: {Overview} 
ReleaseDate: {ReleaseDate.Day}/{ReleaseDate.Month}/{ReleaseDate.Year} 
SoftwareHouseId: {SoftwareHouseId}";
        }
    }
}
