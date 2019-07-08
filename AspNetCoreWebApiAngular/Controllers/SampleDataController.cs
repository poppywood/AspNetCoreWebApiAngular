using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApiAngular.DataContext;
using AspNetCoreWebApiAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiAngular.Controllers
{
    [Route("api/sampledata")]
    [ApiController]
    public class SampleDataController : ControllerBase
    {
        private readonly MonitorContext _context;
        public SampleDataController(MonitorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monitor>>>  MonitoringResults()
        {
            return await _context.Monitors.ToListAsync();
        }

        [HttpPost]  
        public async Task<ActionResult<Monitor>> CreateMonitor(Monitor model)  
        {  
            ModelState.Remove("Id");  
            if (ModelState.IsValid)  
            {  
                _context.Monitors.Add(model);  
                await _context.SaveChangesAsync();  
            }

            return CreatedAtAction(nameof(GetMonitor), new { id = model.Id }, model);
        }

        [HttpPost]
        public async Task<ActionResult<Monitor>>  UpdateMonitor(Monitor model)  
        {
            if (ModelState.IsValid)  
            {  
                _context.Monitors.Update(model);  
                await _context.SaveChangesAsync();  
            }

            return CreatedAtAction(nameof(GetMonitor), new { id = model.Id }, model);
        }  

        [HttpPost]
        public  async Task<IActionResult>  DeleteMonitor(Monitor model)  
        {
            if (ModelState.IsValid)  
            {  
                _context.Monitors.Remove(model);  
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }  

        [HttpGet]  
        public async Task<ActionResult<Monitor>>  GetMonitor(int id)  
        {  
            var monitor = await _context.Monitors.FindAsync(id);

            if (monitor == null)
            {
                return NotFound();
            }

            return monitor;         
        }  

        public IActionResult Delete(int id)  
        {  
            Monitor data = _context.Monitors.FirstOrDefault(p => p.Id == id);   
            if (data != null)  
            {  
                _context.Monitors.Remove(data);  
                _context.SaveChanges();  
            }  
            return RedirectToAction("Index");  
        }  
    }
}
