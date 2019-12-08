using PicadoDental.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class ClientController : Controller
    {
        EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();
       
        // GET: Cliente
        public ActionResult NewClient()
        {
            try
            {
                // Dropdown of gender
                var infoClientes = WS.ListaGenero();
                List<MCliente> listaClientes = new List<MCliente>();
                for (int i = 0; i < infoClientes.Length; i++)
                {
                    MCliente genero = new MCliente();
                    genero.GeneroID = infoClientes[i].GeneroID;
                    genero.Genero = infoClientes[i].Genero;
                    listaClientes.Add(genero);
                }
                ViewBag.Genero = new SelectList(listaClientes, "GeneroID", "Genero");

                return View();
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
            catch (Exception exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
        }

        // GET: Cliente
        [HttpPost]
        public ActionResult NewClient(MCliente cliente)
        {
            try
            {
                // Dropdown of gender
                var infoClientes = WS.ListaGenero();
                List<MCliente> listaClientes = new List<MCliente>();
                for (int i = 0; i < infoClientes.Length; i++)
                {
                    MCliente genero = new MCliente();
                    genero.GeneroID = infoClientes[i].GeneroID;
                    genero.Genero = infoClientes[i].Genero;
                    listaClientes.Add(genero);
                }
                ViewBag.Genero = new SelectList(listaClientes, "GeneroID", "Genero");
                WS.NewPerson(cliente.Nombre, cliente.PrimerApellido, cliente.SegundoApellido, cliente.Telefono,
                    cliente.Correo, cliente.GeneroID, cliente.Cedula, 4, "", "");
                return RedirectToAction("ClientList", "Client");
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
            catch (Exception exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
        }
        /// <summary>
        /// New Client Methot in where we add a new client
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="SecondName"></param>
        /// <param name="Id"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <param name="Gender"></param>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="tipoCuentaID"></param>
        /// <returns></returns>
        public ActionResult AddNewClient(
            string FirstName,
            string LastName,
            string SecondName,
            int Id,
            string Phone,
            string Email,
            int Gender,
            string usuario= "",
            string contrasena= "",
            int tipoCuentaID = 4)
        {
            try
            {
                WS.NewPerson(FirstName, LastName, SecondName, Phone, Email, Gender, Id, tipoCuentaID, usuario, contrasena);
                TempData["message"] = "Cliente agregado con exitosamente.";

                return RedirectToAction("NewClient", "Client");
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
            catch (Exception exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
        }
        /// <summary>
        /// List client Method in where we show the list of clients
        /// </summary>
        /// <returns></returns>
        public ActionResult ClientList()
        {
            try
            {
                var info = WS.ClientList();
                List<MCliente> list = new List<MCliente>();
                if (info[0] != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        MCliente model = new MCliente();
                        model.ClienteID = info[i].ClienteID;
                        model.PersonaID = info[i].PersonaID;
                        model.Nombre = info[i].Nombre;
                        model.Apellidos = info[i].Apellidos;
                        model.Cedula = info[i].Cedula;
                        model.Genero = info[i].Genero;
                        list.Add(model);
                    }
                }
                return View(list);
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
            catch (Exception exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
        }
        /// <summary>
        /// Method in were we search clientw by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Client(int id)
        {
            try
            {
                var info = WS.ObtenerInfoCliente(id);
                List<MCliente> list = new List<MCliente>();
                if (info[0] != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        MCliente model = new MCliente();
                        model.ClienteID = info[i].ClienteID;
                        model.PersonaID = info[i].PersonaID;
                        model.Nombre = info[i].Nombre;
                        model.Apellidos = info[i].Apellidos;
                        model.Cedula = info[i].Cedula;
                        model.Genero = info[i].Genero;
                        model.Telefono = info[i].Telefono;
                        model.Correo = info[i].Correo;
                        list.Add(model);
                    }
                }
                return View(list);
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
            catch (Exception exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
        }

        /// <summary>
        /// Method to apply for appointment list of a specific client
        /// </summary>
        /// <returns>All the list of appointments</returns>
        // GET: AppointmentListOfClient
        public ActionResult AppointmentListOfClient(int id)
        {
            try
            {
                EF_PicadoDental_WS.EF_PicadoDentalSoapClient WS = new EF_PicadoDental_WS.EF_PicadoDentalSoapClient();
                var info = WS.CitaList();

                List<MAppointmentList> list = new List<MAppointmentList>();
                if (info[0] != null)
                {
                    for (int i = 0; i < info.Length; i++)
                    {
                        if (info[i].ClienteID == id)
                        {
                            ViewBag.Paciente = info[i].ClienteNombre + " " + info[i].ClienteApellidos;
                            MAppointmentList model = new MAppointmentList();
                            model.Fecha = info[i].Fecha;
                            model.ClienteNombre = info[i].ClienteNombre;
                            model.ClienteApellidos = info[i].ClienteApellidos;
                            model.DoctorNombre = info[i].DoctorNombre;
                            model.DoctorApellidos = info[i].DoctorApellidos;
                            model.Detalles = info[i].Detalles;
                            model.ClienteID = info[i].ClienteID;
                            model.CitaID = info[i].CitaID;
                            list.Add(model);
                        }
                    }
                }
                return View(list);
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
            catch (Exception exception)
            {
                Session["Error"] = exception.ToString();
                return RedirectToAction("Index", "InternalServerError");
            }
        }

        public ActionResult UpdateClient(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateClient(int id, MCliente cliente)
        {
            cliente.PersonaID = id;
            ViewBag.ID = id;
            WS.ModifyClient(id, cliente.Telefono, cliente.Correo);
            return RedirectToAction("ClientList", "Client");
        }
    }
}