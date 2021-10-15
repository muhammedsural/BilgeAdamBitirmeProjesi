using System.Collections.Generic;
using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class Location : CoreEntity
    {
        public Location()
        {
            Member = new HashSet<Member>();
        }

        public string name { get; set; }
        public bool status { get; set; }
        public int countryid { get; set; }
        public Country Country { get; set; }
        public int regionid { get; set; }
        public Region Region { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}