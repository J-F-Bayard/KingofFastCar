using KFC_MGMT.Models;
using KFC_MGMT.Models.Forms.Login;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToolBox;

namespace KFC_MGMT.Controllers
{
    public class LoginController : Controller
    {
        public string Baseurl { get { return ConfigurationManager.AppSettings["Baseurl"]; } }

        // GET: Login
        public ActionResult Login()
        {
            ViewBag.Message = "Se connecter";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([Bind]LoginForm formulaire)
        {

            Login ModelGlobal = default(Login);
            LoginForm ModelLocal = default(LoginForm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Login/CheckLogin/{formulaire.Email},{formulaire.Passwd}");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelGlobal = JsonConvert.DeserializeObject<Login>(EmpResponse);
                    ModelLocal = AutoMapper<Login, LoginForm>.AutoMap(ModelGlobal);
                }
                
            }
            if (ModelLocal.Authentified == true)
            {
                //Session["users"] = formulaire.Email;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(ModelLocal);
            }
            //return View(ModelLocal);

            //if (Lf.CheckLogin(formulaire.Email,formulaire.Passwd) )
            //{
            //    Session["users"] = formulaire.Email;
            //    return RedirectToAction("Home", "Index");

            //}
           // return View(formulaire);

        }


    }
}