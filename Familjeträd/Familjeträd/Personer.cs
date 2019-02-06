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
        private List<int> childId = new List<int>();
        public int PartnerId = -1;
        public int[] ParentId = {-1, -1};
        public List<int> SiblingIdList = new List<int>();

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
            if (PartnerId == -1)
            {
                Print.PrMsg("No partner present, partner is necessary to assign a child");
                Console.WriteLine("Person was added, to assign a partner and a child, use the 'Add' command");
                Print.PrDb();
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Person child = Generate.GenChildPerson(("Input the details for the child of " + Name), Surname, Birthyear, Name);

                    child.ParentId[0] = Id;
                    child.ParentId[1] = PartnerId;

                    childId.Add(child.Id);

                    PersonDB.Add(child);
                }
            }

        }

        public void AssignSibling(int count)
        {
            Person[] siblingArr = new Person[count];

            List<int> tmpIdList = new List<int>();

            tmpIdList.Add(Id);

            for (int i = 0; i < count; i++)
            {
                siblingArr[i] = Generate.GenSiblingPerson(("Input the details for the sibling of " + Name), Surname, ParentId, Name);

                tmpIdList.Add(siblingArr[i].Id);
                SiblingIdList.Add(siblingArr[i].Id);
            }

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < tmpIdList.Count; j++)
                {
                    if (tmpIdList[j] != siblingArr[i].Id)
                    {
                        siblingArr[i].SiblingIdList.Add(tmpIdList[j]);
                    }
                }

                PersonDB.Add(siblingArr[i]);
            }

        }

        public Person AssignPartner(Person partner, bool partnerExist)
        {
            if (!partnerExist)
            {
                partner = Generate.GenPerson("Type in details for the partner");

                PersonDB.Add(partner);

                PartnerId = partner.Id;
                partner.PartnerId = Id; 
                return partner;
            }

            if (PersonDB.CheckPartner(partner.PartnerId))
            {
                Print.PrMsg("Person already has partner");
                return null;
            }

            PartnerId = partner.Id;
            Id = partner.PartnerId;
            return partner;

        }

        public Person[] AssignParents()
        {
            Person[] parents = null;

            if (ParentId == null)
            {

            }
            else
            {
                parents = Generate.GenParents("Please input the credentials for this persons parents", Surname, Name, Birthyear, Id, SiblingIdList);

                for (int i = 0; i < parents.Length; i++)
                {
                    PersonDB.Add(parents[i]);
                }
            }

            return parents;

        }

    }
}
