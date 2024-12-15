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
{//Espñana
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
        [System.Web.Mvc.HttpGet]
        public ActionResult signin()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> signin(AccountModel.signupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ReqLogin req = new ReqLogin();
                    req.usuario = new Usuario();

                    req.usuario.name = null;
                    req.usuario.lastName = null;
                    req.usuario.mail = model.Email;
                    req.usuario.password = model.Password;

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PostAsync("https://localhost:54579/api/usuario/login", jsonContent);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            ResLogin res = new ResLogin();
                            res.usuario = new Usuario();
                            res = JsonConvert.DeserializeObject<ResLogin>(responseContent);
                            if (res.resultado)
                            {


                                Sesion.Id = res.usuario.id;
                                Sesion.name = res.usuario.name;
                                Sesion.lastName = res.usuario.lastName;
                                Sesion.email = model.Email.ToString();
                                Sesion.fechaDeInicio = DateTime.Now;

                                return RedirectToAction("index", "Dashboard");

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
            return View();
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult signup()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> signup(AccountModel.signupModel model)
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
                            nickname = model.NickName,
                            password = model.Password
                            //pollo
                        }
                    };
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PostAsync("https://localhost:54579/api/usuario/crear", jsonContent);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var res = JsonConvert.DeserializeObject < ResRegistrar >(responseContent);
                            if (res.resultado)
                            {
                                // En lugar de redireccionar, mostramos el mensaje de éxito
                                ViewBag.SuccessMessage = "Usuario registrado exitosamente";
                                ViewBag.ShowSuccess = true;
                                return RedirectToAction("signin");
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