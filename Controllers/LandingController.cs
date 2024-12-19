using Newtonsoft.Json;
using Silicon.Models;
using Silicon.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Silicon.Models.Entidades.Request;
using Silicon.Models.Entidades.Response;

namespace Silicon.Controllers
{
    public class LandingController : Controller
    {
        // GET: Landing
        public async Task<ActionResult> blog(String generoFilter)
        {
            LandingModel model = new LandingModel();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:44377/api/generos");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<ResGeneros>(responseContent);

                        if (res.respuesta)
                        {
                            if (res.Generos != null)
                            {
                                model.Mostrar.Generos = res.Generos;
                            }
                            else
                            {
                                ModelState.AddModelError("", "No hay generos por mostrar");
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Ha ocurrido un error. Intente mas tarde \n" + e.Message);
            }

            try
            {
                long longValue = Convert.ToInt64(generoFilter ?? "0");

                var jsonContent = new StringContent("{\"Generos\": {\"IdGenero\":" +longValue+"}}",Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44377/api/generos/filtrar")
                    {
                        Content = jsonContent
                    };
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<ResFiltrarGenero>(responseContent);

                        if (res.respuesta)
                        {
                            if (res.Peliculas != null)
                            {
                                model.filtrar.Peliculas = res.Peliculas;
                            }
                            else
                            {
                                ModelState.AddModelError("", "No hay películas por mostrar");
                            }

                        }
                        else
                        {

                            ModelState.AddModelError("", "Ha ocurrido un error. Intente mas tarde");

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al cargar las películas. Intente más tarde.");
            }

            return View(model);
        }
        public ActionResult conference()
        {
            return View();
        }
        public ActionResult digitalAgency()
        {
            return View();
        }
        public ActionResult financial()
        {
            return View();
        }
        public ActionResult medical()
        {
            return View();
        }
        public ActionResult mobileAppShowcasev1()
        {
            return View();
        }
        public ActionResult mobileAppShowcasev2()
        {
            return View();
        }
        public ActionResult mobileAppShowcasev3()
        {
            return View();
        }
        public ActionResult onlineCourses()
        {
            return View();
        }
        public ActionResult product()
        {
            return View();
        }
        public ActionResult saasv1()
        {
            return View();
        }
        public ActionResult saasv2()
        {
            return View();
        }
        public ActionResult saasv3()
        {
            return View();
        }
        public ActionResult saasv4()
        {
            return View();
        }
        public ActionResult saasv5()
        {
            return View();
        }
        public ActionResult softwareDevAgencyv1()
        {
            return View();
        }
        public ActionResult softwareDevAgencyv2()
        {
            return View();
        }
        public ActionResult softwareDevAgencyv3()
        {
            return View();
        }
        public ActionResult startup()
        {
            return View();
        }
    }
}