﻿using Newtonsoft.Json;
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

namespace Silicon.Controllers
{
    public class AccountController : Controller
    {
        // Usa System.Web.Mvc.HttpGetAttribute, no System.Web.Http.HttpGetAttribute
        // GET: Account
        public ActionResult collections()
        {
            return View();
        }
        public ActionResult details()
        {
            return View();
        }
        public ActionResult messages()
        {
            return View();
        }
        public ActionResult notifications()
        {
            return View();
        }
        public ActionResult payment()
        {
            return View();
        }
        public ActionResult saveditems()
        {
            return View();
        }
        public ActionResult security()
        {
            return View();
        }
        public ActionResult signin()
        {
            return View();
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult signup()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountModel.RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ReqRegistrar req = new ReqRegistrar
                    {
                        usuario = new Usuario
                        {
                            name = model.Name,
                            lastName = model.LastName,
                            mail = model.Email,
                            password = model.Password
                        }
                    };
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PostAsync("https://localhost:44363/api/usuario/insertar", jsonContent);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var res = JsonConvert.DeserializeObject < ResRegistrar >(responseContent);
                            if (res.resultado)
                            {
                                // En lugar de redireccionar, mostramos el mensaje de éxito
                                ViewBag.SuccessMessage = "Usuario registrado exitosamente";
                                ViewBag.ShowSuccess = true;
                                TempData["SuccessMessage"] = "Registro exitoso. Por favor revise su correo electrónico para confirmar su cuenta.";
                                return RedirectToAction("Login");
                            }
                            else
                            {
                                foreach (var error in res.errores)
                                {
                                    ModelState.AddModelError("", error.error);
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
        public ActionResult Logout()
        {
            Sesion.cerrarSesion();
            return RedirectToAction("Login");
        }
    }
}