using KFC_MGMT.Models.Forms;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using KFC_MGMT.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using ToolBox;
using KFC_MGMT.Models.Forms.Car;
using System.Linq;

namespace KFC_MGMT.Controllers
{
    public class HistoryController : Controller
    {
        public static string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }
        public static async Task<List<GetHistoryForm>> GetHistoryList()
        {
            //chargement de la liste des marques dans une liste pour linq
            List<History> HistoryList = new List<History>();
            IEnumerable<History> histroryList = null;
            List<GetHistoryForm> gethistoryformList = new List<GetHistoryForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("History/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    histroryList = JsonConvert.DeserializeObject<List<History>>(EmpResponse);
                }

                foreach (History history in histroryList)
                {
                    gethistoryformList.Add(AutoMapper<History, GetHistoryForm>.AutoMap(history));
                }
            }
            return gethistoryformList;
        }

        // GET: History
        public async Task<ActionResult> Index()
        {
            IEnumerable<History> historyList = null;
            List<GetHistoryForm> getHistoryformList = new List<GetHistoryForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("History/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    historyList = JsonConvert.DeserializeObject<List<History>>(EmpResponse);
                }
                foreach (History History in historyList)
                {
                    getHistoryformList.Add(AutoMapper<History, GetHistoryForm>.AutoMap(History));
                }
            }

            List<GetCarForm> getcarformList = await CarController.GetCarList();
            List<GetSellerForm> getsellerformList = await SellerController.GetSellerList();
            List<GetBuyerForm> getbuyerformList = await BuyerController.GetBuyerList();


            foreach (var item in getHistoryformList)
            {
                var data = (from b in getcarformList
                            where b.IdCar == item.IdCar
                            select b.ModelName).FirstOrDefault();

                var data2 = (from b in getcarformList
                            where b.IdCar == item.IdCar
                            select b.ChassisNumber).FirstOrDefault();

                item.CarName = data+" - "+data2;
            }

            foreach (var item in getHistoryformList)
            {
                var data = (from b in getsellerformList
                            where b.IdSeller == item.IdSeller
                            select b.Name).FirstOrDefault();

                item.SellerName = data;
            }

            foreach (var item in getHistoryformList)
            {
                var data1 = (from b in getbuyerformList
                            where b.IdBuyer == item.IdBuyer
                            select b.FirstName).FirstOrDefault();
                var data2 = (from b in getbuyerformList
                             where b.IdBuyer == item.IdBuyer
                             select b.LastName).FirstOrDefault();

                item.BuyerName = data1+' '+data2;
            }



            return View(getHistoryformList);

        }

        // GET: History/Details/5
        public async Task<ActionResult> Details(string id)
        {
            History ModelGlobal = default(History);
            GetHistoryForm ModelLocal = default(GetHistoryForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"History/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<History>(EmpResponse);
                    ModelLocal = AutoMapper<History, GetHistoryForm>.AutoMap(ModelGlobal);
                }
            }
            
            List<GetCarForm> getcarformList = await CarController.GetCarList();
            List<GetSellerForm> getsellerformList = await SellerController.GetSellerList();
            List<GetBuyerForm> getbuyerformList = await BuyerController.GetBuyerList();

            var data = (from b in getcarformList
                        where b.IdCar == ModelLocal.IdCar
                        select b.ModelName).FirstOrDefault();

            var data2 = (from b in getcarformList
                         where b.IdCar == ModelLocal.IdCar
                         select b.ChassisNumber).FirstOrDefault();

            ModelLocal.CarName = data + " - " + data2;

            data = (from b in getsellerformList
                        where b.IdSeller == ModelLocal.IdSeller
                        select b.Name).FirstOrDefault();

            ModelLocal.SellerName = data;

            data = (from b in getbuyerformList
                         where b.IdBuyer == ModelLocal.IdBuyer
                         select b.FirstName).FirstOrDefault();
            data2 = (from b in getbuyerformList
                         where b.IdBuyer == ModelLocal.IdBuyer
                         select b.LastName).FirstOrDefault();

            ModelLocal.BuyerName = data + ' ' + data2;

            return View(ModelLocal);

        }

        public async Task<EditHistoryForm> GetDetails(string id)
        {
            History ModelGlobal = default(History);
            EditHistoryForm ModelLocal = default(EditHistoryForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"History/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<History>(EmpResponse);
                    ModelLocal = AutoMapper<History, EditHistoryForm>.AutoMap(ModelGlobal);
                }
            }
            return ModelLocal;
        }

        // GET: History/Create
        public async Task<ActionResult> Create()
        {
            List<Car> carList = null;
            List<SelectListItem> getcarformList = new List<SelectListItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Car/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    carList = JsonConvert.DeserializeObject<List<Car>>(EmpResponse);
                }

                foreach (Car Car in carList)
                {
                    getcarformList.Add(new SelectListItem { Text = Car.ChassisNumber, Value = Car.IdCar.ToString() });
                }
            }

            List<Seller> sellerList = null;
            List<SelectListItem> getsellerformList = new List<SelectListItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Seller/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    sellerList = JsonConvert.DeserializeObject<List<Seller>>(EmpResponse);
                }

                foreach (Seller Seller in sellerList)
                {
                    getsellerformList.Add(new SelectListItem { Text = Seller.Name, Value = Seller.IdSeller.ToString() });
                }
            }

            List<Buyer> buyerList = null;
            List<SelectListItem> getbuyerformList = new List<SelectListItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Buyer/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    buyerList = JsonConvert.DeserializeObject<List<Buyer>>(EmpResponse);
                }

                foreach (Buyer Buyer in buyerList)
                {
                    getbuyerformList.Add(new SelectListItem { Text = Buyer.FirstName+" "+Buyer.LastName, Value = Buyer.IdBuyer.ToString() });
                }
            }

            var model = new AddHistoryForm
            {
                CarList = getcarformList,
                SellerList = getsellerformList,
                BuyerList = getbuyerformList
            };
            return View(model);
        }

        // POST: History/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddHistoryForm formulaire)
        {
            if (ModelState.IsValid)
            {
                History history = new History
                {
                    IdCar = Convert.ToInt32(formulaire.CarName),
                    IdSeller = Convert.ToInt32(formulaire.SellerName),
                    IdBuyer = Convert.ToInt32(formulaire.BuyerName),
                    BuyPrice = formulaire.BuyPrice,
                    SoldPrice = formulaire.SoldPrice,
                    BuyBill = formulaire.BuyBill,
                    SoldBill = formulaire.SoldBill,
                    BuyDate = formulaire.BuyDate,
                    SoldDate = formulaire.SoldDate   
                    
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(history));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"History/Create", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
                
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: History/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            List<Car> carList = null;
            List<SelectListItem> getcarformList = new List<SelectListItem>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Car/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    carList = JsonConvert.DeserializeObject<List<Car>>(EmpResponse);
                }

                
            }

            foreach (Car Car in carList)
            {
                getcarformList.Add(new SelectListItem { Text = Car.ChassisNumber, Value = Car.IdCar.ToString() });
            }

            List<Seller> sellerList = null;
            List<SelectListItem> getsellerformList = new List<SelectListItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Seller/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    sellerList = JsonConvert.DeserializeObject<List<Seller>>(EmpResponse);
                }

                foreach (Seller Seller in sellerList)
                {
                    getsellerformList.Add(new SelectListItem { Text = Seller.Name, Value = Seller.IdSeller.ToString() });
                }
            }

            List<Buyer> buyerList = null;
            List<SelectListItem> getbuyerformList = new List<SelectListItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Buyer/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    buyerList = JsonConvert.DeserializeObject<List<Buyer>>(EmpResponse);
                }

                foreach (Buyer Buyer in buyerList)
                {
                    getbuyerformList.Add(new SelectListItem { Text = Buyer.FirstName + " " + Buyer.LastName, Value = Buyer.IdBuyer.ToString() });
                }
            }

            EditHistoryForm model = new EditHistoryForm();
            model = await GetDetails(id);

            model.CarList = getcarformList;
            model.SellerList = getsellerformList;
            model.BuyerList = getbuyerformList;
            
            return View(model);
        }

        // POST: History/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditHistoryForm formulaire)
        {
            if (ModelState.IsValid)
            {              
                History history = new History
                {
                    IdHistory = id,
                    IdCar = Convert.ToInt32(formulaire.CarName),
                    IdSeller = Convert.ToInt32(formulaire.SellerName),
                    IdBuyer = Convert.ToInt32(formulaire.BuyerName),
                    BuyPrice = formulaire.BuyPrice,
                    SoldPrice = formulaire.SoldPrice,
                    BuyBill = formulaire.BuyBill,
                    SoldBill = formulaire.SoldBill,
                    BuyDate = formulaire.BuyDate,
                    SoldDate = formulaire.SoldDate
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(history));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"History/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: History/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            History ModelGlobal = default(History);
            DeleteHistoryForm ModelLocal = default(DeleteHistoryForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"History/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<History>(EmpResponse);
                    ModelLocal = AutoMapper<History, DeleteHistoryForm>.AutoMap(ModelGlobal);
                }
            }


            List<GetCarForm> getcarformList = await CarController.GetCarList();
            List<GetSellerForm> getsellerformList = await SellerController.GetSellerList();
            List<GetBuyerForm> getbuyerformList = await BuyerController.GetBuyerList();

            var data = (from b in getcarformList
                        where b.IdCar == ModelLocal.IdCar
                        select b.ModelName).FirstOrDefault();

            var data2 = (from b in getcarformList
                         where b.IdCar == ModelLocal.IdCar
                         select b.ChassisNumber).FirstOrDefault();

            ModelLocal.CarName = data + " - " + data2;

            data = (from b in getsellerformList
                    where b.IdSeller == ModelLocal.IdSeller
                    select b.Name).FirstOrDefault();

            ModelLocal.SellerName = data;

            data = (from b in getbuyerformList
                    where b.IdBuyer == ModelLocal.IdBuyer
                    select b.FirstName).FirstOrDefault();
            data2 = (from b in getbuyerformList
                     where b.IdBuyer == ModelLocal.IdBuyer
                     select b.LastName).FirstOrDefault();

            ModelLocal.BuyerName = data + ' ' + data2;

            return View(ModelLocal);
        }

        // POST: History/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, [Bind]DeleteHistoryForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"History/Delete/{id}");

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
