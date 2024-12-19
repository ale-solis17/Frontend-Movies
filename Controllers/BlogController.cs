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

            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(longValue), Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsync("http://localhost:54579/api/peliculas/especifica", jsonContent);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<ResPeliculaEsp>(responseContent);
                        if (res.respuesta)
                        {
                            //model.pelicula.name = res.pelicula.name;
                            //model.pelicula.director = res.pelicula.director;
                            //model.pelicula.duracion = res.pelicula.duracion;
                            //model.pelicula.creacion = res.pelicula.creacion;
                            //model.pelicula.synopsis = res.pelicula.synopsis;
                            //model.pelicula.generos = res.pelicula.generos;
                            //model.pelicula.URL = res.pelicula.URL;

                            ReqMostrarComentarios reqCom = new ReqMostrarComentarios
                            {
                                Comentario = new Comentario()
                            };
                            //reqCom.Comentario.idPelicula = req.pelicula.id;
                                
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
            return View(model: new BlogModel.PeliculaEspecificaModel());
        }

        //[System.Web.Mvc.HttpPost]
        //public async Task<ActionResult> podcast(BlogModel.PeliculaEspecificaModel model)
        //{
        //    try
        //    {
        //        ReqCrearCom req = new ReqCrearCom
        //        {
        //            comentario = new Comentario()
        //        };
        //        var jsonContent =
        //            new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
        //        using (HttpClient client = new HttpClient())
        //        {
        //            var response = await client.PostAsync("http://localhost:54579/api/comentario/crearr", jsonContent);
        //            //Este if(rating) no sé si funciona
        //            decimal rating = 0;
        //            int idPelicula = 0;
        //            if (rating < 0 || rating > 5)
        //            {
        //                ModelState.AddModelError("", "La puntuación debe estar entre 0 y 5.");
        //                return RedirectToAction("Details", new { id = idPelicula });
        //            }

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var responseContent = await response.Content.ReadAsStringAsync();
        //                var res = JsonConvert.DeserializeObject<ResCrearCom>(responseContent);
        //                if (res.respuesta)
        //                {
        //                    // En lugar de redireccionar, mostramos el mensaje de éxito
        //                    ViewBag.SuccessMessage = "Comentario Publicado";
        //                    ViewBag.ShowSuccess = true;
        //                    return RedirectToAction("blog");
        //                }
        //                else
        //                {
        //                    foreach (var error in res.errores)
        //                    {
        //                        ModelState.AddModelError("", error);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("",
        //                    "Error de comunicación con el servidor. Por favor, intente más tarde.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", "Ha ocurrido un error inesperado. Por favor, intente más tarde.");
        //    }

        //    return View();
        //}
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