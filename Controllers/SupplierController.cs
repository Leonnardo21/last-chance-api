using LastChance.Data;
using LastChance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastChance.Controllers
{
    [ApiController]
    [Route("v1")]
    public class SupplierController : ControllerBase
    {

        [HttpGet("supplier")]
        public async Task<IActionResult> Get([FromServices] LastChanceContext context)
        {
            try
            {
                var supplier = await context.Suppliers.ToListAsync();
                return Ok(supplier);

            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("supplier/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromServices] LastChanceContext context)
        {
            try
            {
                var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("supplier")]
        public async Task<IActionResult> Post([FromBody] Supplier supplier, [FromServices] LastChanceContext context)
        {
            try
            {
                var model = new Supplier
                {
                    Name = supplier.Name,
                };

                await context.Suppliers.AddAsync(model);
                await context.SaveChangesAsync();
                return Ok(model);

            }catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPut("supplier/{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Supplier supplier,[FromServices] LastChanceContext context)
        {
            try
            {
                var model = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound("Informação não encontrada");

                model.Name = supplier.Name;

                context.Suppliers.Update(model);
                await context.SaveChangesAsync();

                return Ok(supplier);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("supplier/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] LastChanceContext context) {
            try
            {
                var supplierId = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
                if (supplierId == null)
                    return NotFound("Informação não encontrada!");
                
                context.Suppliers.Remove(supplierId);
                await context.SaveChangesAsync();

                return Ok("Fornecedor removido");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
