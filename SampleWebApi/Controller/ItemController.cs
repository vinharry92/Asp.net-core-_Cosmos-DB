using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Models;
using todo;

namespace SampleWebApi.Controller
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    public class ItemController : ControllerBase
    {
        private readonly IDocumentDBRepository<SampleWebApi.Models.Item> Respository;
        public ItemController(IDocumentDBRepository<SampleWebApi.Models.Item> Respository)
        {
            this.Respository = Respository;
        }

        [EnableCors("AllowMyOrigin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await Respository.GetItemsAsync(d => !d.Completed);
            return Ok(items);
        }

        [EnableCors("AllowMyOrigin")]
        [Route("editasync")]
        [HttpPost]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Item item = await Respository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        [EnableCors("AllowMyOrigin")]    
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Item item = await Respository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                await Respository.DeleteItemAsync(id);
            }

            return Ok(item);
        }

        [HttpPost]
        [EnableCors("AllowMyOrigin")]
        [Route("createasync")]
        public async Task<IActionResult> CreateAsync(Item item)
        {
            if (ModelState.IsValid)
            {
                await Respository.CreateItemAsync(item);

            }
            return Ok(item);
        }

    }
}