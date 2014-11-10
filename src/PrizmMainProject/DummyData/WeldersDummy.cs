﻿using System.Collections.Generic;
using System.ComponentModel;

namespace PrizmMain.DummyData
{
    public class WeldersDummy
    {
        public BindingList<weldHistory> GetCmpDummy()
        {
            var welders = new List<Welders>();
            welders.Add(new Welders {Name = "Ivan", LastName = "Ivanov"});
            welders.Add(new Welders {Name = "Peter", LastName = "Petrov"});
            var weldHistory = new BindingList<weldHistory>
            {
                new weldHistory {Date = "04.11.2014", Welders = welders}
            };
            return weldHistory;
        }
    }

    public class weldHistory
    {
        public string Date { get; set; }
        public List<Welders> Welders { get; set; }
    }

    public class Welders
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}