using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Options;
using BCrypt.Net;
using AnalisisProyecto.Models.DTO;
using AnalisisProyecto.Models.Logic;
using System.Web.Http.Results;

namespace AnalisisProyecto.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserrsController : ControllerBase {
        private readonly AnalisisProyectoContext _context;

        public UserrsController(AnalisisProyectoContext context) {
            _context = context;
        }

        //Metodo de obtener todos los usuarios se utiliza DTO para obtener el nombre del rol
        //Ya que el rol es una llave foranea y no se puede obtener directamente
        //Si no se encicla la referencia y se cae el programa
        // GET: api/Userrs
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Userr>>> GetUserrs() {
            var userrs = await _context.Userrs.Include(u => u.Role).ToListAsync();

            if (userrs == null) {
                return NotFound();
            }

            //var jsonOptions = new JsonSerializerOptions {
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //};

            var userDtos = userrs.Select(u => new UserDto {
                Id = u.Id,
                UserId = u.UserId != null ? u.UserId : string.Empty,
                Name = u.Name != null ? u.Name : string.Empty,
                LastName = u.LastName != null ? u.LastName : string.Empty,
                Category = u.Category != null ? u.Category : string.Empty,
                Role = u.Role != null ? u.Role.Name != null ? u.Role.Name : string.Empty : string.Empty,
                Phone = u.Phone != null ? u.Phone : string.Empty,
                Career = u.Career != null ? u.Career : string.Empty,
                Deleted = u.Deleted.GetValueOrDefault(false) ? 1 : 0,
                CreationDate = u.CreationDate.GetValueOrDefault(DateTime.Now)
            }).Where(u => u.Deleted == 0).ToList();

            Thread.Sleep(1000);

            return Ok(userDtos);//Content(JsonSerializer.Serialize(userrs, jsonOptions), "application/json");
        }

        //Metodo de obtener un usuario por id se utiliza DTO para obtener el nombre del rol
        //Ya que el rol es una llave foranea y no se puede obtener directamente
        //Si no se encicla la referencia y se cae el programa
        // GET: api/Userrs/5
        [HttpGet]
        [Route("getUser/{id}")]
        public async Task<ActionResult<Userr>> GetUserr(int id) {
            if (_context.Userrs == null) {
                return NotFound();
            }
            //var userr = await _context.Userrs.FindAsync(id);
            //var userr = await _context.Userrs.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            var userDto = await _context.Userrs.Where(u => u.Id == id).Select(u => new UserDto {
                Id = u.Id,
                UserId = u.UserId != null ? u.UserId : string.Empty,
                Name = u.Name != null ? u.Name : string.Empty,
                LastName = u.LastName != null ? u.LastName : string.Empty,
                Category = u.Category != null ? u.Category : string.Empty,
                Role = u.Role != null ? u.Role.Name != null ? u.Role.Name : string.Empty : string.Empty,
                Phone = u.Phone != null ? u.Phone : string.Empty,
                Career = u.Career != null ? u.Career : string.Empty,
                Deleted = u.Deleted.GetValueOrDefault(false) ? 1 : 0,
                CreationDate = u.CreationDate.GetValueOrDefault(DateTime.Now)
            }).FirstOrDefaultAsync();



            if (userDto == null) {
                return NotFound();
            }

            return Ok(userDto);
        }

        //Metodo para actualizar el cliente, se busca por el id el cliente que se quiere actualizar
        //Para que asi no se pierda la fecha de creacion
        // PUT: api/Userrs/5
        [HttpPut]
        [Route("updateUser")]
        public async Task<IActionResult> PutUserr(Userr userr) {

            if (userr == null) {
                return BadRequest();
            }

            // Carga la entidad original desde la base de datos
            var existingUserr = await _context.Userrs.FindAsync(userr.Id);

            if (existingUserr == null) {
                return NotFound();
            }

            // Copia los valores actualizados a la entidad existente
            existingUserr.UserId = userr.UserId;
            existingUserr.Name = userr.Name;
            existingUserr.LastName = userr.LastName;
            existingUserr.RoleId = userr.RoleId;
            existingUserr.Phone = userr.Phone;
            existingUserr.Career = userr.Career;

            if (!string.IsNullOrEmpty(userr.Password)) {
                existingUserr.Password = BCrypt.Net.BCrypt.HashPassword(userr.Password);
            }

            // Establece la fecha de creación original
            userr.CreationDate = existingUserr.CreationDate;

            // Marca la entidad existente como modificada
            _context.Entry(existingUserr).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!UserrExists(userr.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return Ok(userr.Id);
        }

        // POST: api/Userrs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("createUser")]
        public async Task<ActionResult<Userr>> PostUserr(Userr userr) {

            if (userr.Password == null) {
                return BadRequest();
            }

            var userr2 = await _context.Userrs.FirstOrDefaultAsync(u => u.UserId == userr.UserId);
            if (userr2 != null) {
                return BadRequest("Usuario exitente");
            }


            userr.CreationDate = DateTime.Now;
            userr.Password = BCrypt.Net.BCrypt.HashPassword(userr.Password);
            userr.Deleted = false;
            _context.Userrs.Add(userr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserr", new { id = userr.Id }, userr);
        }

        // DELETE: api/Userrs/5
        [HttpDelete]
        [Route("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUserr(int id) {
            if (_context.Userrs == null) {
                return NotFound();
            }
            var userr = await _context.Userrs.FindAsync(id);
            if (userr == null) {
                return NotFound();
            }

            userr.Deleted = true;
            _context.Entry(userr).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                return NotFound();
            }
            //_context.Userrs.Remove(userr);
            //await _context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserLoginDto>> Login(UserLoginDto userr) {
            if (userr == null) {
                return BadRequest();
            }

            var userr2 = await _context.Userrs.FirstOrDefaultAsync(u => u.UserId == userr.UserId);

            if (userr2 == null) {
                return NotFound();
            }

            if (!BCrypt.Net.BCrypt.Verify(userr.Password, userr2.Password)) {
                return Unauthorized("Bad Password");
            }

            var userDTO = await _context.Userrs.Where(u => u.UserId == userr.UserId)
                .Include(l => l.LibraryUsers)
                .Include(u => u.Role.RolePrivileges)
                .Select(u => new UserDto {
                    Id = u.Id,
                    UserId = u.UserId != null ? u.UserId : string.Empty,
                    Name = u.Name != null ? u.Name : string.Empty,
                    LastName = u.LastName != null ? u.LastName : string.Empty,
                    Category = u.Category != null ? u.Category : string.Empty,
                    Role = u.Role != null ? u.Role.Name != null ? u.Role.Name : string.Empty : string.Empty,
                    Phone = u.Phone != null ? u.Phone : string.Empty,
                    Career = u.Career != null ? u.Career : string.Empty,
                    Deleted = u.Deleted.GetValueOrDefault(false) ? 1 : 0,
                    IdLibraryUser = u.LibraryUsers.FirstOrDefault().Id,
                    CreationDate = u.CreationDate.GetValueOrDefault(DateTime.Now),
                    Privileges = u.Role.RolePrivileges.Select(p => p.Privileges).ToList()
                }).FirstOrDefaultAsync();

            return Ok(userDTO);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserRegisterDTO>> Register([FromBody] UserRegisterDTO userr) {

            Console.WriteLine(userr.UserId);

            if (userr == null) {
                return BadRequest("Usuario invalido");
            }

            var userr2 = await _context.Userrs.FirstOrDefaultAsync(u => u.UserId == userr.UserId);

            if (userr2 != null) {
                return BadRequest("Usuario existente");
            }

            var user = new Userr {
                UserId = userr.UserId,
                Category = "Estudiante",//Estudiante por defecto
                Name = userr.UserName,
                LastName = userr.UserLastName,
                RoleId = 1,//Estudiante por defecto
                Phone = userr.UserPhone,
                Career = userr.UserCareer,
                CreationDate = DateTime.Now,
                Password = BCrypt.Net.BCrypt.HashPassword(userr.UserPass),
                Deleted = false
            };

            _context.Userrs.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user.Id);
        }

        [HttpPost]
        [Route("newLog")]
        public async Task<ActionResult<Log>> NewLog([FromBody] Log log) {

            if (log == null) {
                return BadRequest("Log invalido");
            }
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Userr.log");

            if (log.isError) {
                Logger.LogError(filePath, log.Message);
            } else {
                Logger.LogInfo(filePath, log.Message);
            }

            return Ok();
        }

        private bool UserrExists(int id) {
            return (_context.Userrs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
