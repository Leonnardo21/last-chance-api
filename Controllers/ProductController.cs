using LastChanceAPI.Data;
using LastChanceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastChanceAPI.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        [HttpGet("products")]
        public async Task<IActionResult> Get([FromServices] LastChanceContext context)
        {
            try
            {
                var product = await context.Products.ToListAsync();
                if(product == null)
                    return NotFound();
                return Ok(product);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet("products/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromServices] LastChanceContext context)
        {
            try{
                var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if(product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("products")]
        public async Task<IActionResult> Post([FromBody] Product product, [FromServices] LastChanceContext context) {
            try {
                var model = new Product
                {
                    Description = product.Description,
                    Lot = product.Lot,
                    Expiration = product.Expiration,
                    Quantity = product.Quantity,
                };

                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
                return Created($"{model.Id}", model);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("products/{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id,[FromBody] Product product, [FromServices] LastChanceContext context) {
            try {
                var model = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound("Informação não encontrada");

                model.Description = product.Description;
                model.Lot = product.Lot;
                model.Expiration = product.Expiration;
                model.Quantity = product.Quantity;

                await context.SaveChangesAsync();                

                return Ok(model);
            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("products/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] LastChanceContext context) {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) 
                return NotFound("Informação não encontrada");

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return Ok("Produto excluído");
        }
    }
}