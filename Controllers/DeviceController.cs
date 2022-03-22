using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Device> Get()
        {
            // We can use this email address to get basic access to that perticular user to identify him/her to the system access.
            string emailAddress = HttpContext.User.Identity.Name;
            using (var context = new deviceapidbContext())
            {
                return context.Devices.ToList();  
            }
        }
        [HttpGet("{id}")]
        public IEnumerable<Device> Get(string id)
        {
            // We can use this email address to get basic access to that perticular user to identify him/her to the system access.
            string emailAddress = HttpContext.User.Identity.Name;

            using (var context = new deviceapidbContext())
            {
                return context.Devices.Where(d => d.DeviceId.ToString() == id).ToList();
            }
            //using (var context = new deviceapidbContext())
            //{
            //    return context.Devices.ToList();
            //}z
        }


    }
}