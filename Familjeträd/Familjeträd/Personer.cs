﻿using System;
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
        public int PartnerId = -1;

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
                    Console.WriteLine("u have id" + Id);
                }
            }

        }

        public void AssignChild(int count)
        {
            if (PartnerId == -1)
            {
                Console.WriteLine("No partner present, partner is necessary to assign a child");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Person child = Generate.GenChildPerson(("Input the details for the child of " + Name), Surname, Birthyear, Name);

                    child.parentId[0] = Id;
                    child.parentId[1] = PartnerId;

                    childId.Add(child.Id);

                    PersonDB.Add(child);
                }
            }

        }

        public void AssignSibling(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Person sibling = Generate.GenSiblingPerson(("Input the details for the sibling of " + Name), Surname, parentId[0], Name);

                PersonDB.Add(sibling);
            }
        }

        public Person AssignPartner(Person partner, bool partnerExist)
        {
            if (!partnerExist)
            {
                partner = Generate.GenPerson("Type in details for the partner");

                PersonDB.Add(partner);

                PartnerId = partner.Id;
                Id = partner.PartnerId;
                return partner;
            }

            if (PersonDB.CheckPartner(partner.PartnerId))
            {
                Console.WriteLine("Person already has partner");
                return null;
            }

            PartnerId = partner.Id;
            Id = partner.PartnerId;
            return partner;

        }

    }
}
