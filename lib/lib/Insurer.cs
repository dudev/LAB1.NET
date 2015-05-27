using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    //страховая компания
    public class Insurer : Organization, ICloseOrganization
    {
        public Insurer(string name, string inn)
            : base(name, inn, Organization.TaxationSystemType.Osno)
        {
        }

        public int NumbersOfClients;
        public List<string> offices = new List<string> () ;
        
        //ставка
        public int Rate { get; set; }

        public void ClientRegister()
        {
            NumbersOfClients++;
        }
        public void OpenOffice(string name)
        {
            offices.Add(name);
        }

        public void CloseOffice(string name)
        {
            offices.Remove(name);
        }

        public override void CloseOrganization()
        {
            while (offices.Count > 0)
            {
                CloseOffice(offices[0]);
            }
            CloseDate = DateTime.Now;
        }
    }
}
