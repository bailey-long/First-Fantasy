using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Fantasy.Classes.Charcter_Classes
{
    internal class Party_Factory
    {
        public List<Member> CreateParty()
        {
            //Initialize list
            var Members = new List<Member>();

            //Generate test members
            Member member1 = new Member
            {
                Name = "Gurt",
                Level = 1,
                Race = "Dwarf",
                Class = "Echoblade"
            };
            Member member2 = new Member
            {
				Name = "EMPTY",
				Level = 1,
				Race = "EMPTY",
				Class = "EMPTY"
			};
            Member member3 = new Member
            {
				Name = "EMPTY",
				Level = 1,
				Race = "EMPTY",
				Class = "EMPTY"
			};
            Member member4 = new Member
            {
				Name = "EMPTY",
				Level = 1,
				Race = "EMPTY",
				Class = "EMPTY"
			};

            Members.Add(member1);
            Members.Add(member2);
            Members.Add(member3);
            Members.Add(member4);

            return Members;
        }
    }
}
