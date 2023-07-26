using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Fantasy.Classes.Charcter_Classes
{
    internal class Party
    {
        public List<Member> Members { get; private set; }
        public Party()
        {
            Members = new List<Member>();
        }

        public void ShowMembers(List<Member> Members)
        {
            foreach (Member member in Members)
            {
                Debug.WriteLine($"Name: {member.Name}, Level: {member.Level}, Class: {member.Class}, Race: {member.Race}");
            }
        }

        public void AssembleParty(IEnumerable<Member> member)
        {
            Members.AddRange(member);
        }

        public void AddMember(Member member, int index)
        {
            Members[index] = member;
            Debug.WriteLine($"{member.Name}, {member.Race}, {member.Class}, {member.Level}");
        }

        public void RemoveMember(Member member)
        {

            member.Name = "EMPTY";
            member.Level = 1;
            member.Race = "EMPTY";
            member.Class = "EMPTY";

        }
    }
}
