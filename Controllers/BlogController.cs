using System.Web.Mvc;
using Newtonsoft.Json;
using Silicon.Models;
using Silicon.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Silicon.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult gridnosidebar()
        {
            return View();
        }

        public ActionResult gridwithsidebar()
        {
            return View();
        }

        public ActionResult listnosidebar()
        {
            return View();
        }

        public ActionResult listwithsidebar()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public async Task<ActionResult> podcast(string idFilter)
        {
            long longValue = Convert.ToInt64(idFilter ?? "0");

            BlogModel model = new BlogModel();
            model.PeliculaEspecifica.Peliculas.id = longValue;
            try
            {
                var jsonContent = new StringContent("{\"Peliculas\": {\"id\":" +longValue+"}}", Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44377/api/peliculas/especifica")
                    {
                        Content = jsonContent
                    };
                    var response = await client.SendAsync(request);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<ResPeliculaEsp>(responseContent);
                        if (res.respuesta)
                        {
                            model.PeliculaEspecifica.Peliculas = res.Peliculas;

                            ReqMostrarComentarios reqCom = new ReqMostrarComentarios
                            {
                                Comentario = new Comentario()
                            };
                            reqCom.Comentario.idPelicula = longValue;

                            var jsonContentCom = new StringContent(JsonConvert.SerializeObject(reqCom), Encoding.UTF8, "application/json");
                            using (HttpClient clientCom = new HttpClient())
                            {
                                var responseCom = await clientCom.PostAsync("http://localhost:54579/api/comentario/mostrar", jsonContentCom);
                                response.EnsureSuccessStatusCode();

                                if (responseCom.IsSuccessStatusCode)
                                {
                                    var responseContentCom = await responseCom.Content.ReadAsStringAsync();
                                    var resCom = JsonConvert.DeserializeObject<ResMostrarComentarios>(responseContentCom);
                                    if (resCom.respuesta)
                                    {
                                        if (resCom.Comentarios != null)
                                        {
                                            foreach (var item in resCom.Comentarios)
                                            {
                                                Comentario comentario = new Comentario
                                                {
                                                    IdComment = item.IdComment,
                                                    idPelicula = item.idPelicula,
                                                    nickname = item.nickname,
                                                    creationDate = item.creationDate,
                                                    comentario = item.comentario,
                                                    rating = item.rating
                                                };

                                                //model.comentario.Add(comentario);
                                            }
                                        }
                                        else
                                        {
                                            ModelState.AddModelError("", "No hay comentarios disponibles.");
                                        }
                                    }
                                    else
                                    {
                                        foreach (var error in res.errores)
                                        {
                                            ModelState.AddModelError("", error);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "No se pudo obtener la información de la película.");
                            foreach (var error in res.errores)
                            {
                                ModelState.AddModelError("", error);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

                ModelState.AddModelError("", $"Ha ocurrido un error inesperado: {e.Message}");

                Console.WriteLine(e.StackTrace);
            }
            return View(model);
        }
       
            [HttpPost]
            public async Task<ActionResult> CrearComentario()
            {
                BlogModel model = new BlogModel();
           
                if (!Sesion.ComprobarSesion())
                {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("podcast", "Blog", new { idFilter = model.PeliculaEspecifica.Peliculas.id }) });
                }
            

               try
                {
                    var nuevoComentario = new Comentario
                    {
                        idPelicula = model.PeliculaEspecifica.Peliculas.id,
                        idUsuario = Sesion.Id,
                        comentario = model.Comentario.Comentario.comentario,
                        rating = model.Comentario.Comentario.rating,
                    };

                    // Crear el requerimiento para la API
                    var reqCrearComentario = new ReqCrearCom
                    {
                        comentario = nuevoComentario
                    };

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(reqCrearComentario), Encoding.UTF8, "application/json");

                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PostAsync("http://localhost:54579/api/comentario/crear", jsonContent);
                        response.EnsureSuccessStatusCode();

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var resCrearComentario = JsonConvert.DeserializeObject<ResCrearCom>(responseContent);

                        if (resCrearComentario.respuesta)
                        {

                            return RedirectToAction("podcast", new { idFilter = model.PeliculaEspecifica.Peliculas.id });
                        }
                        else
                        {
                            foreach (var error in resCrearComentario.errores)
                            {
                                ModelState.AddModelError("", error);
                            }
                        }
                    }
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", $"Ha ocurrido un error inesperado: {e.Message}");
                    Console.WriteLine(e.StackTrace);
                }

            return RedirectToAction("podcast", new { idFilter = model.PeliculaEspecifica.Peliculas.id });
        }
        public ActionResult simplefeed()
        {
            return View();
        }

        public ActionResult single()
        {
            return View();
        }
    }
}