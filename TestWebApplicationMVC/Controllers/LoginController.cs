using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestWebApplicationMVC.Models;

namespace TestWebApplicationMVC.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index(User log)
        {
            var user = db.Users.Where(x => x.username == log.username && x.password == log.password).Count();
            if (user > 0)
            {
                //return RedirectToAction("Index", "Movies");
                //return RedirectToAction("Dashbord");
                return RedirectToAction("Indexapi");

            }
            else
            {

                return View();
            }

        }
        string Baseurl = "https://localhost:44385/";
        public async Task<ActionResult> Indexapi()
        {
            List<User> UserInfo = new List<User>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Users");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    UserInfo = JsonConvert.DeserializeObject<List<User>>(UserResponse);

                }
                //returning the employee list to view  
                return View(UserInfo);
            }
        }

        public ActionResult Userlist()
        {
            return View(db.Users.ToList());
        }
        private MovieDBContext db = new MovieDBContext();

    }
}