﻿using System;

namespace Domain.Entity
{
    // TODO: Name convert Funtion (property)
    public class PersonName : Item
    {
        public PersonName(string first, string last, string middle) : this(first, last)
        {
            this.MiddleName = middle;
        }

        public PersonName(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        protected PersonName()
        {
        }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }

        public string GetFullName()
        {
            throw new NotImplementedException();
        }

        public string GetShortName()
        {
            throw new NotImplementedException();
        }
    }
}