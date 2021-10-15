using System.Collections.Generic;
using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class Country : CoreEntity
    {
        public Country()
        {
            Member = new HashSet<Member>();
        }

        public string name { get; set; }
        public bool status { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}