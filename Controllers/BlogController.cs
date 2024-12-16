using System.Web.Mvc;
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
        public ActionResult podcast()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        [Authorize]
        public async Task<ActionResult> potcast(BlogModel.ComentarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ReqCrearCom req = new ReqCrearCom
                    {
                        comentario = new Comentario
                        {
                            idPelicula = model.MovieId,
                            idUsuario = model.UserId,
                            comentario = model.Comment,
                            creationDate = DateTime.Now,
                            rating = model.Rating
                            

                        }
                    };
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PostAsync("http://localhost:54579/api/comentario/crearr", jsonContent);
                        //Este if(rating) no sé si funciona
                        decimal rating = 0;
                        int idPelicula = 0;
                        if (rating < 0 || rating > 5)
                        {
                            ModelState.AddModelError("", "La puntuación debe estar entre 0 y 5.");
                            return RedirectToAction("Details", new { id = idPelicula });
                        }

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var res = JsonConvert.DeserializeObject<ResCrearCom>(responseContent);
                            if (res.respuesta)
                            {
                                // En lugar de redireccionar, mostramos el mensaje de éxito
                                ViewBag.SuccessMessage = "Comentario Publicado";
                                ViewBag.ShowSuccess = true;
                                return RedirectToAction("blog");
                            }
                            else
                            {
                                foreach (var error in res.errores)
                                {
                                    ModelState.AddModelError("", error);
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Error de comunicación con el servidor. Por favor, intente más tarde.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado. Por favor, intente más tarde.");
                }
            }
            return View(model);
        }

        //[HttpPost]
        //[Authorize] // Solo permite acceso a usuarios autenticados
        //public async Task<ActionResult> AddComment(int idPelicula, string comentario, decimal rating)
        //{

        //    if (rating < 0 || rating > 5)
        //    {
        //        ModelState.AddModelError("", "La puntuación debe estar entre 0 y 5.");
        //        return RedirectToAction("Details", new { id = idPelicula });
        //    }

        //    // Crear el objeto para enviar a la API
        //    var commentData = new
        //    {
        //        idUsuario = User.Identity.GetUserId(), // ID del usuario autenticado
        //        idPelicula = idPelicula,
        //        creationDate = DateTime.Now,
        //        comentario = comentario,
        //        rating = rating
        //    };

        //    // Serializar el objeto a JSON
        //    var json = JsonConvert.SerializeObject(commentData);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    // Hacer la llamada POST a la API
        //    var response = await _httpClient.PostAsync("comentario", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Redirige a la página de detalles si el comentario se guarda correctamente
        //        return RedirectToAction("Details", new { id = idPelicula });
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Error al guardar el comentario.");
        //        return RedirectToAction("Details", new { id = idPelicula });
        //    }
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