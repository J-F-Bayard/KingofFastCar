using KFCapi.Models;
using KFCapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DbContact;
using ToolBox.DesignPatterns.Locator;
using ToolBox.DesignPatterns.Repository;

namespace KFCapi.Services
{
    public class ServicesLocator : LocatorBase
    {

        public static Connection GetConnection()
        {
            if (Environment.MachineName.Contains("1614"))
                return new Connection(ConnectionStrings.GetSqlConnectionString(@"FORMA-VDI1614\TFTIC", "KFC", "sa", "tftic@2012"), ConnectionStrings.GetSqlConnectionInvariantName());
            else
                return new Connection(ConnectionStrings.GetSqlConnectionString(@"(localdb)\MSSQLLocalDB", "KFC"), ConnectionStrings.GetSqlConnectionInvariantName());

        }

        private static ServicesLocator _Instance;

        public static ServicesLocator Instance
        {
            get
            {
                return _Instance ?? (_Instance = new ServicesLocator());
            }
        }

        private ServicesLocator()
        {

            Container.Register<IBrandService, BrandService>();
            Container.Register<IBuyerService, BuyerService>();
            Container.Register<ICarService, CarService>();
            Container.Register<IChargeService, ChargeService>();
            Container.Register<IEquipmentService, EquipmentService>();
            Container.Register<IInstalledEquipmentService, InstalledEquipmentService>();
            Container.Register<IHistoryService, HistoryService>();
            Container.Register<IModelService, ModelService>();
            Container.Register<IProviderService, ProviderService>();
            Container.Register<ISellerService, SellerService>();
            Container.Register<IUserService, UserService>();
            Container.Register<ILoginService, LoginService>();

        }

        public IBrandService BrandService { get { return Container.GetInstance<IBrandService>(); } }
        public IBuyerService BuyerService { get { return Container.GetInstance<IBuyerService>(); } }
        public ICarService CarService { get { return Container.GetInstance<ICarService>(); } }
        public IChargeService ChargeService { get { return Container.GetInstance<IChargeService>(); } }
        public IEquipmentService EquipmentService { get { return Container.GetInstance<IEquipmentService>(); } }
        public IInstalledEquipmentService InstalledEquipmentService { get { return Container.GetInstance<IInstalledEquipmentService>(); } }
        public IHistoryService HistoryService { get { return Container.GetInstance<IHistoryService>(); } }
        public IModelService ModelService { get { return Container.GetInstance<IModelService>(); } }
        public IProviderService ProviderService { get { return Container.GetInstance<IProviderService>(); } }
        public ISellerService SellerService { get { return Container.GetInstance<ISellerService>(); } }
        public IUserService UserService { get { return Container.GetInstance<IUserService>(); } }
        public ILoginService LoginService { get { return Container.GetInstance<ILoginService>(); } }

    }
}
