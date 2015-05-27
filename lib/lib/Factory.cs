using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Factory : Organization, ICloseOrganization, IMake
    {
        public enum ProductTypes { WhiteBread, BlackBread };

        public readonly int ProductivityWhiteBread;
        public readonly int ProductivityBlackBread;

        public int QuantityWhiteBread { get; private set; }
        public int QuantityBlackBread { get; private set; }


        public Factory(string name, string inn, TaxationSystemType taxationSystem, int productivityWhiteBread, int productivityBlackBread)
            : base(name, inn, taxationSystem)
        {
            ProductivityWhiteBread = productivityWhiteBread;
            ProductivityBlackBread = productivityBlackBread;
        }

        public void Make(ProductTypes type)
        {
            switch (type)
            {
                case ProductTypes.WhiteBread:
                    QuantityWhiteBread += ProductivityWhiteBread;
                    break;
                case ProductTypes.BlackBread:
                    QuantityBlackBread += ProductivityBlackBread;
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
                case ProductTypes.WhiteBread:
                    if (QuantityWhiteBread < number)
                    {
                        throw new IncorectNumberException("Количество меньше запасов");
                    }
                    QuantityWhiteBread -= number;
                    break;
                case ProductTypes.BlackBread:
                    if (QuantityBlackBread < number)
                    {
                        throw new IncorectNumberException("Количество меньше запасов");
                    }
                    QuantityBlackBread -= number;
                    break;
            }
        }
    }
}
