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

namespace Silicon.Controllers
{
    public class LandingController : Controller
    {
        // GET: Landing
        public ActionResult blog()
        {
                return View();
        }
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> blog(int id)
        {
            LandingModel.FiltrarGeneroModel model = new LandingModel.FiltrarGeneroModel();

            if (model.pelicula == null)
            {
                model.pelicula = new List<Pelicula>();
            }
            
            
            
                try
                {
                    ReqFiltrarGenero req = new ReqFiltrarGenero();
                    req.genero.IdGenero = id;

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PostAsync("http://localhost:54579/api/generos/filtrar", jsonContent);

                    // Filtrar por género si está especificado
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<ResFiltrarGenero>(responseContent);

                        if (res.respuesta)
                        {
                            if (res.Peliculas != null && res.Peliculas.Any())
                            {
                                foreach (var item in res.Peliculas)
                                {
                                    Pelicula pelicula = new Pelicula()
                                    {
                                        id = item.id,
                                        name = item.name,
                                        director = item.director,
                                        duracion = item.duracion,
                                        creacion = item.creacion,
                                        synopsis = item.synopsis,
                                        generos = item.generos,
                                        URL = item.URL
                                    };
                                    model.pelicula.Add(pelicula);
                                }
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