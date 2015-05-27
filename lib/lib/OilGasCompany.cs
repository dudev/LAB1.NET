using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class OilGasCompany : Organization, ICloseOrganization
    {

        public OilGasCompany(string name, string inn, int productivityOil, int productivityGas)
            : base(name, inn, Organization.TaxationSystemType.Osno)
        {
            ProductivityOil = productivityOil;
            ProductivityGas = productivityGas;
        }

        public enum ProductTypes { Oil, Gas };

        public readonly int ProductivityOil;
        public readonly int ProductivityGas;
        
        public int QuantityOil { get; private set; }
        public int QuantityGas { get; private set; }

        public void Extract(ProductTypes type)
        {
            switch (type)
            {
                case ProductTypes.Oil:
                    QuantityOil += ProductivityOil;
                    break;
                case ProductTypes.Gas:
                    QuantityGas += ProductivityGas;
                    break;
            }
        }
        public void Ship(ProductTypes type, int number)
        {
            if (number <= 0)
            {
                throw new IncorectNumberException("Количество меньше 0");
            }
            switch (type)
            {
                case ProductTypes.Oil:
                    if (QuantityOil < number)
                    {
                        throw new IncorectNumberException("Количество меньше запасов");
                    }
                    QuantityOil -= number;
                    break;
                case ProductTypes.Gas:
                    if (QuantityGas < number)
                    {
                        throw new IncorectNumberException("Количество меньше запасов");
                    }
                    QuantityGas -= number;
                    break;
            }
        }
    }
}
