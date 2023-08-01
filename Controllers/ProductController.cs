using LastChance.Data;
using LastChance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastChance.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        [HttpGet("products")]
        public async Task<IActionResult> Get([FromServices] LastChanceContext context) {

            try
            {
                var products = await context.Products.ToListAsync();
                return Ok(products);

            }catch (Exception ex)
            {
               return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("products/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromServices] LastChanceContext context)
        {
            try
            {
                var productId = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (productId == null)
                    return NotFound("Informação não encontrada!");

                return Ok(productId);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("products")]
        public async Task<IActionResult> Post([FromBody] Product product, [FromServices] LastChanceContext context) {
            try
            {
                var model = new Product
                {
                    Description = product.Description,
                    Lot = product.Lot,
                    Expiration = product.Expiration,
                    CodeBar = product.CodeBar,
                    Quantity = product.Quantity,
                };

                await context.Products.AddAsync(model);
                await context.SaveChangesAsync();
                return Created($"{model.Id}", model);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("products/{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id ,[FromBody] Product product, [FromServices] LastChanceContext context)
        {
            try
            {
                var model = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null) return NotFound("Informação não encontrada");

                model.Description = product.Description;
                model.Lot = product.Lot;
                model.Expiration = product.Expiration;
                model.CodeBar = product.CodeBar;
                model.Quantity = product.Quantity;               

                context.Products.Update(model);
                await context.SaveChangesAsync();
                return Ok("Produto atualizado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("products/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] LastChanceContext context) {
            try
            {
                var productId = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (productId == null) return NotFound("Produto não encontrado!");

                context.Products.Remove(productId);
                await context.SaveChangesAsync();

                return Ok("Produto removido");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}