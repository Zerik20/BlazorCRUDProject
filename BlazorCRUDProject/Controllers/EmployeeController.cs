using BlazorCRUDProject.Server.Data;
using BlazorCRUDProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet("ConexionServidor")]
        public async Task<ActionResult<string>> GetEjemplo()
        {
            return "Conectado con el servidor";
        }
        [HttpGet("ConexionEmployees")]
        public async Task<ActionResult<string>> GetConexionEmployees()
        {
            try
            {
                var respuesta = await _context.Employees.ToListAsync();
                return "Conectado con la tabla Employees";
            }
            catch (Exception ex)
            {
                return "Error de conexion con la base de datos";
            }


        }
        [HttpPost("NewEmployee")]
        public async Task<ActionResult<string>> CreateEmployee(Employee objeto)
        {

            _context.Employees.Add(objeto);
            await _context.SaveChangesAsync();
            return "Guardado con Exito";
        }
        [HttpGet("ObtainEmployees")]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(int id)
        {
            var DbObjeto = await _context.Employees.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }
            _context.Employees.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return "Eliminado";
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateEmployee(Employee objeto)
        {

            var DbObjeto = await _context.Employees.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.StartDate = objeto.StartDate;
            DbObjeto.Age = objeto.Age;
            DbObjeto.Position = objeto.Position;
            DbObjeto.Name = objeto.Name;


            await _context.SaveChangesAsync();

            return "Actualizado";

        }


    }
}
