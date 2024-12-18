using Newtonsoft.Json;
using Silicon.Models;
using Silicon.Models.Entidades;
using Silicon.Models.Entidades.Request;
using Silicon.Models.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Silicon.Models.BlogModel;

namespace Silicon.Controllers
{
    public class LandingController : Controller
    {

        [HttpGet]
        public async Task<ActionResult> blog()
        {
            var model = new BlogModel.PeliculaInicioModel
            {
                pelicula = new Pelicula(),
                comentario = new List<Comentario>()
            };

            try
            {

                ReqPeliculaInicio req = new ReqPeliculaInicio();
                req.Pelicula = new Pelicula()
                {
                    id = 1,
                };
                var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsync("http://localhost:54579/api/peliculas/inicio", jsonContent);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<ResPeliculaInicio>(responseContent);

                        if (res.respuesta)
                        {
                            if (res.Comentarios != null)
                            {
                                foreach (var Item in res.Comentarios)
                                {
                                    Comentario comentario = new Comentario
                                    {
                                        IdComment = Item.IdComment,
                                        idPelicula = Item.idPelicula,
                                        nickname = Item.nickname,
                                        creationDate = Item.creationDate,
                                        comentario = Item.comentario,
                                        rating = Item.rating,
                                    };
                                    model.comentario.Add(comentario);
                                }

                            }
                            else
                            {
                                ModelState.AddModelError("", "No hay comentarios disponibles.");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al cargar los datos: {ex.Message}");
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