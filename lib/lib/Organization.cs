using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Organization : ICloseOrganization
    {
        public enum TaxationSystemType { Usno, Osno };

        public readonly string Name;
        public readonly string Inn;
        public readonly DateTime RegDate;

        public Organization(string name, string inn, TaxationSystemType taxationSystem)
        {
            Name = name;
            Inn = inn;
            RegDate = DateTime.Now;
            TaxationSystem = taxationSystem;
        }

        //система налогообложения
        public readonly TaxationSystemType TaxationSystem;
        public string Director { get; private set; }
        public DateTime CloseDate { get; protected set; }

        public void NewDirector(string name)
        {
            Director = name;
        }

        public virtual void CloseOrganization()
        {
            CloseDate = DateTime.Now;
        }
    }
}
