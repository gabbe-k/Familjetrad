using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Person
    {
        public readonly string Name;
        public string Surname;
        public int Id;
        public readonly int Birthyear;
        public readonly bool Sex;
        private List<int> childId;
        private int[] parentId;
        public int partnerId = -1;

        public Person(string name, string surname, int birthyear, bool sex)
        {
            Name = name;
            Surname = surname;
            Birthyear = birthyear;
            Sex = sex;

            bool validId = false;

            while (!validId)
            {
                Random rnd = new Random();
                int id = rnd.Next(0, 1000);

                if (!PersonDB.CheckDupe(id))
                {
                    Id = id;
                    validId = true;
                }
            }

        }

        public void AssignChild(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Person child = Generate.GenChildPerson(("Input the details for the child of " + Name), Surname, Birthyear);

                child.parentId[0] = Id;

                childId.Add(child.Id);

                if (partnerId == -1)
                {
                    child.parentId[1] = partnerId;
                }

                PersonDB.Add(child);
            }

        }

        public void AssignSibling(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Person sibling = Generate.GenSiblingPerson(("Input the details for the child of " + Name), Surname, parentId[0]);

                PersonDB.Add(sibling);
            }
        }

        public Person AssignPartner(Person partner, bool partnerExist)
        {
            if (!partnerExist)
            {
                partner = Generate.GenPerson("Type in details for the partner");

                partnerId = partner.Id;
                Id = partner.partnerId;
                return partner;
            }
            else
            {
                if (PersonDB.CheckPartner(partner.partnerId))
                {
                    Console.WriteLine("Person already has partner");
                    return null;
                }

                partnerId = partner.Id;
                Id = partner.partnerId;
                return partner;
            }

        }

    }
}
