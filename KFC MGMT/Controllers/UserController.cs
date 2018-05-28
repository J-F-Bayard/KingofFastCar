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

namespace KFC_MGMT.Controllers
{
    public class UserController : Controller
    {
        public string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        // GET: User
        public async Task<ActionResult> Index()
        {
            IEnumerable<User> userList = null;
            List<GetUserForm> getUserformList = new List<GetUserForm>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("User/Get");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userList = JsonConvert.DeserializeObject<List<User>>(EmpResponse);
                }
                foreach (User User in userList)
                {
                    getUserformList.Add(AutoMapper<User, GetUserForm>.AutoMap(User));
                }
            }
            return View(getUserformList);

        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            User ModelGlobal = default(User);
            GetUserForm ModelLocal = default(GetUserForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"User/Get/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<User>(EmpResponse);
                    ModelLocal = AutoMapper<User, GetUserForm>.AutoMap(ModelGlobal);
                }
                
            }
            return View(ModelLocal);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind]AddUserForm formulaire)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    LastName = formulaire.LastName,
                    FirstName=formulaire.FirstName,
                    Email=formulaire.Email,
                    Password=formulaire.Password
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync($"User/Create", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind]EditUserForm formulaire)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    LastName = formulaire.LastName,
                    FirstName = formulaire.FirstName,
                    Email = formulaire.Email,
                    Password = formulaire.Password
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(user));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PutAsync($"User/Update", content);

                    if (!Res.IsSuccessStatusCode) { /*error handling*/ }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(formulaire);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, [Bind]DeleteUserForm formulaire)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.DeleteAsync($"User/Delete/{id}");

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
