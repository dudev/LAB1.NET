using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib;

namespace OrganizationWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label_organization_closedate_Click(object sender, EventArgs e)
        {

        }

        private void label_insurer_offices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private lib.Organization _organization;
        private lib.OilGasCompany _oilGasCompany;
        private lib.Insurer _insurer;
        private lib.Factory _factory;

        private void organization_create_Click(object sender, EventArgs e)
        {
            try
            {
                _organization = new Organization(
                    organization_name.Text,
                    organization_inn.Text,
                    organization_taxation_system.Text == "УСНО" ? Organization.TaxationSystemType.Usno : Organization.TaxationSystemType.Osno
                );
                _organization.NewDirector(organization_director.Text);

                DrawOrganization();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void DrawOrganization()
        {
            label_organization_name.Text = _organization.Name;
            label_organization_inn.Text = _organization.Inn;
            label_organization_regdate.Text = _organization.RegDate.ToLongDateString();
            label_organization_taxationsystem.Text = _organization.TaxationSystem ==
                                                     Organization.TaxationSystemType.Usno
                ? "УСНО"
                : "ОСНО";
            label_organization_closedate.Text = _organization.CloseDate.Year == 1
                ? "Дата закрытия"
                : _organization.CloseDate.ToLongDateString();
            organization_directorname.Text = _organization.Director;
        }

        private void organization_close_Click(object sender, EventArgs e)
        {
            try
            {
                _organization.CloseOrganization();

                DrawOrganization();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void organization_newdirector_Click(object sender, EventArgs e)
        {
            try
            {
                _organization.NewDirector(organization_directorname.Text);

                DrawOrganization();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void oilgascompany_create_Click(object sender, EventArgs e)
        {
            try
            {
                _oilGasCompany = new OilGasCompany(
                    oilgascompany_name.Text,
                    oilgascompany_inn.Text,
                    Convert.ToInt32(oilgascompany_productivityoil.Text),
                    Convert.ToInt32(oilgascompany_productivitygas.Text)
                );
                _oilGasCompany.NewDirector(oilgascompany_director.Text);

                DrawOilGasCompany();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void DrawOilGasCompany()
        {
            label_oilgascompany_name.Text = _oilGasCompany.Name;
            label_oilgascompany_inn.Text = _oilGasCompany.Inn;
            label_oilgascompany_regdate.Text = _oilGasCompany.RegDate.ToLongDateString();
            label_oilgascompany_taxationsystem.Text = _oilGasCompany.TaxationSystem ==
                                                     Organization.TaxationSystemType.Usno
                ? "УСНО"
                : "ОСНО";
            label_oilgascompany_closedate.Text = _oilGasCompany.CloseDate.Year == 1
                ? "Дата закрытия"
                : _oilGasCompany.CloseDate.ToLongDateString();
            oilgascompany_directorname.Text = _oilGasCompany.Director;

            label_oilgascompany_productivitygas.Text = _oilGasCompany.ProductivityGas.ToString();
            label_oilgascompany_productivityoil.Text = _oilGasCompany.ProductivityOil.ToString();
            label_oilgascompany_gas.Text = _oilGasCompany.QuantityGas.ToString();
            label_oilgascompany_oil.Text = _oilGasCompany.QuantityOil.ToString();
        }

        private void oilgascompany_close_Click(object sender, EventArgs e)
        {
            try
            {
                _oilGasCompany.CloseOrganization();

                DrawOilGasCompany();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void oilgascompany_newdirector_Click(object sender, EventArgs e)
        {
            try
            {
                _oilGasCompany.NewDirector(oilgascompany_directorname.Text);

                DrawOilGasCompany();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void oilgascompany_extract_Click(object sender, EventArgs e)
        {
            try
            {
                _oilGasCompany.Extract(oilgascompany_type.Text == "Газ" ? OilGasCompany.ProductTypes.Gas : OilGasCompany.ProductTypes.Oil);

                DrawOilGasCompany();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void oilgascompany_ship_Click(object sender, EventArgs e)
        {
            try
            {
                _oilGasCompany.Ship(oilgascompany_type.Text == "Газ"
                        ? OilGasCompany.ProductTypes.Gas
                        : OilGasCompany.ProductTypes.Oil,
                    Convert.ToInt32(oilgascompany_number.Text)
                    );

                DrawOilGasCompany();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void insurer_create_Click(object sender, EventArgs e)
        {
            try
            {
                _insurer = new Insurer(
                    insurer_name.Text,
                    insurer_inn.Text
                    );
                _insurer.NewDirector(insurer_director.Text);
                _insurer.Rate = Convert.ToInt32(insurer_rate.Text);

                DrawInsurer();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void DrawInsurer()
        {
            label_insurer_name.Text = _insurer.Name;
            label_insurer_inn.Text = _insurer.Inn;
            label_insurer_regdate.Text = _insurer.RegDate.ToLongDateString();
            label_insurer_taxationsystem.Text = _insurer.TaxationSystem ==
                                                     Organization.TaxationSystemType.Usno
                ? "УСНО"
                : "ОСНО";
            label_insurer_closedate.Text = _insurer.CloseDate.Year == 1
                ? "Дата закрытия"
                : _insurer.CloseDate.ToLongDateString();
            insurer_directorname.Text = _insurer.Director;
            label_insurer_numberofclients.Text = _insurer.NumbersOfClients.ToString();

            label_insurer_offices.Items.Clear();
            label_insurer_offices.Items.Add("Офисы");
            foreach (var office in _insurer.offices)
            {
                label_insurer_offices.Items.Add(office);
            }

            label_insurer_rate.Text = _insurer.Rate.ToString();
        }

        private void insurer_close_Click(object sender, EventArgs e)
        {
            try
            {
                _insurer.CloseOrganization();

                DrawInsurer();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void insurer_newdirector_Click(object sender, EventArgs e)
        {
            try
            {
                _insurer.NewDirector(insurer_directorname.Text);

                DrawInsurer();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void insurer_newclient_Click(object sender, EventArgs e)
        {
            try
            {
                _insurer.ClientRegister();

                DrawInsurer();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void insurer_openoffice_Click(object sender, EventArgs e)
        {
            try
            {
                _insurer.OpenOffice(insurer_officename.Text);

                DrawInsurer();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void insurer_closeoffice_Click(object sender, EventArgs e)
        {
            try
            {
                _insurer.CloseOffice(insurer_officename.Text);

                DrawInsurer();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void factory_create_Click(object sender, EventArgs e)
        {
            try
            {
                _factory = new Factory(
                factory_name.Text,
                factory_inn.Text,
                organization_taxation_system.Text == "УСНО" ? Organization.TaxationSystemType.Usno : Organization.TaxationSystemType.Osno,
                Convert.ToInt32(factory_productivitywhitebread.Text),
                Convert.ToInt32(factory_productivityblackbread.Text)
                );
                _factory.NewDirector(factory_director.Text);

                DrawFactory();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void DrawFactory()
        {
            label_factory_name.Text = _factory.Name;
            label_factory_inn.Text = _factory.Inn;
            label_factory_regdate.Text = _factory.RegDate.ToLongDateString();
            label_factory_taxationsystem.Text = _factory.TaxationSystem ==
                                                     Organization.TaxationSystemType.Usno
                ? "УСНО"
                : "ОСНО";
            label_factory_closedate.Text = _factory.CloseDate.Year == 1
                ? "Дата закрытия"
                : _factory.CloseDate.ToLongDateString();
            factory_directorname.Text = _factory.Director;

            label_factory_productivitywhitebread.Text = _factory.ProductivityWhiteBread.ToString();
            label_factory_productivityblackbread.Text = _factory.ProductivityBlackBread.ToString();
            label_factory_whitebread.Text = _factory.QuantityWhiteBread.ToString();
            label_factory_blackbread.Text = _factory.QuantityBlackBread.ToString();
        }

        private void factory_close_Click(object sender, EventArgs e)
        {
            try
            {
                _factory.CloseOrganization();

                DrawFactory();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void factory_newdirector_Click(object sender, EventArgs e)
        {
            try
            {
                _factory.NewDirector(factory_directorname.Text);

                DrawFactory();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void factory_make_Click(object sender, EventArgs e)
        {
            try
            {
                _factory.Make(factory_type.Text == "Белый хлеб" ? Factory.ProductTypes.WhiteBread : Factory.ProductTypes.BlackBread);

                DrawFactory();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void factory_ship_Click(object sender, EventArgs e)
        {
            try
            {
                _factory.Ship(
                factory_type.Text == "Белый хлеб" ? Factory.ProductTypes.WhiteBread : Factory.ProductTypes.BlackBread,
                Convert.ToInt32(factory_number.Text)
                );

                DrawFactory();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                CloseOrganizationDelegate del = _organization.CloseOrganization;
                del += _oilGasCompany.CloseOrganization;
                del += _insurer.CloseOrganization;
                del += _factory.CloseOrganization;

                del();

                DrawOrganization();
                DrawOilGasCompany();
                DrawInsurer();
                DrawFactory();
            }
            catch (Exception exception)
            {
                DrawError(exception);
            }
        }

        private void DrawError(Exception exception)
        {
            error.Text = DateTime.Now.ToLongTimeString() + ": " + exception.Message;
        }
    }
}
