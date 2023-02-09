using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicesEmpresaX.Model.Request;
using WebServicesEmpresaX.Model;
using WebServicesEmpresaX.Model.Response;
using Microsoft.EntityFrameworkCore;

namespace WebServicesEmpresaX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class ClientesController : ControllerBase
    {
        [HttpGet("/Clientes")]
        public IActionResult GetCliente()
        {
            Respuesta Orespuesta = new Respuesta();

            try
            {
                using (EmpresaXContext db = new EmpresaXContext())
                {
                    var lst = from c in db.Clientes.ToList()
                              join d in db.Direcciones.ToList()
                              on c.ClienteId equals d.ClienteId
                              select new { 
                                          c.Nombres,
                                          c.Apellidos,
                                          d.Calle,
                                          d.Sector,
                                          d.Ciudad
                                          };

                    Orespuesta.Exito = 1;
                    Orespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                Orespuesta.Mensaje = ex.Message;
            }

            return Ok(Orespuesta);
        }

        [HttpGet("/Direcciones")]
        public IActionResult GetDirecciones()
        {
            Respuesta Orespuesta = new Respuesta();

            try
            {
                using (EmpresaXContext db = new EmpresaXContext())
                {
                    var lst = db.Direcciones.ToList();
                    Orespuesta.Exito = 1;
                    Orespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                Orespuesta.Mensaje = ex.Message;
            }

            return Ok(Orespuesta);
        }

        [HttpPost("/Clientes")]
        public IActionResult AddCliente(ClienteRequest model)
        {
            Respuesta Orespuesta = new Respuesta();
            DireccionRequest model2 = new DireccionRequest();

            try
            {
                using (EmpresaXContext db = new EmpresaXContext())
                {
                    Cliente cliente = new Cliente();
                    cliente.ClienteId = model.ClienteID;
                    cliente.Nombres = model.Nombres;
                    cliente.Apellidos = model.Apellidos;
                    cliente.Telefono = model.Telefono;
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    Orespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                Orespuesta.Mensaje = ex.Message;
            }

            return Ok(Orespuesta);
        }

        [HttpPost("/Direcciones")]
        public IActionResult AddDirrecion(DireccionRequest model)
        {
            Respuesta Orespuesta = new Respuesta();

            try
            {
                using (EmpresaXContext db = new EmpresaXContext())
                {

                    Direccione direccion = new Direccione();
                    direccion.Calle = model.Calle;
                    direccion.Sector = model.Sector;
                    direccion.Ciudad = model.Ciudad;
                    direccion.ClienteId = model.ClienteID;
                    db.Direcciones.Add(direccion);
                    db.SaveChanges();
                    Orespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                Orespuesta.Mensaje = ex.Message;
            }

            return Ok(Orespuesta);
        }


        [HttpPut("/Clientes")]
        public IActionResult EditClientes(ClienteRequest model)
        {
            Respuesta Orespuesta = new Respuesta();

            try
            {
                using (EmpresaXContext db = new  EmpresaXContext())
                {
                    Cliente cliente = db.Clientes.Find(model.ClienteID);
                    cliente.Nombres = model.Nombres;
                    cliente.Apellidos = model.Apellidos;
                    cliente.Telefono = model.Telefono;
                    db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    Orespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                Orespuesta.Mensaje = ex.Message;
            }

            return Ok(Orespuesta);
        }

        [HttpPut("/Direcciones")]
        public IActionResult EditDirecciones(DireccionRequest model)
        {
            Respuesta Orespuesta = new Respuesta();

            try
            {
                using (EmpresaXContext db = new EmpresaXContext())
                {
                    Direccione direccion = db.Direcciones.Find(model.DireccionID);
                    direccion.Calle = model.Calle;
                    direccion.Sector = model.Sector;
                    direccion.Ciudad = model.Ciudad;
                    direccion.ClienteId = model.ClienteID;
                    db.Entry(direccion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    Orespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                Orespuesta.Mensaje = ex.Message;
            }

            return Ok(Orespuesta);
        }

        [HttpDelete("Clientes/{ClienteID}")]
        public IActionResult DeleteClientes(int ClienteID)
        {
            Respuesta Orespuesta = new Respuesta();

            try
            {
                using (EmpresaXContext db = new EmpresaXContext())
                {
                    Cliente cliente = db.Clientes.Find(ClienteID);
                    db.Remove(cliente);
                    db.SaveChanges();
                    Orespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                Orespuesta.Mensaje = ex.Message;
            }

            return Ok(Orespuesta);
        }
        [HttpDelete("Direcciones/{DireccionID}")]
        public IActionResult DeleteDirecciones(int DireccionID)
        {
            Respuesta Orespuesta = new Respuesta();

            try
            {
                using (EmpresaXContext db = new EmpresaXContext())
                {
                    Direccione direccione = db.Direcciones.Find(DireccionID);
                    db.Remove(direccione);
                    db.SaveChanges();
                    Orespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                Orespuesta.Mensaje = ex.Message;
            }

            return Ok(Orespuesta);
        }
    }
}
