using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shan.Api.Data;
using Shan.Api.Model;

namespace Shan.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbcontext _dbContext;

        public ValuesController(ApplicationDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]

        public ActionResult Create([FromBody] Category values)
        {
            _dbContext.Category.Add(values);
            _dbContext.SaveChanges();
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]

        public ActionResult Get()     // All record 
        {
            var Categories = _dbContext.Category.ToList();
            return Ok(Categories);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("Details")]

        public ActionResult Get(int id)   //Specific record
        {
            var Category = _dbContext.Category.FirstOrDefault(x=>x.Id == id);
            if(Category == null)
            {
                return NotFound();
            }          
            return Ok(Category);
        }

        [HttpPut]

        public ActionResult Update([FromBody] Category values)
        {
            _dbContext.Category.Update(values);
            _dbContext.SaveChanges();
            return Ok();
        }


        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]

        public ActionResult Delete(int id)
        {
            if(id== 0)
            {
                return BadRequest();
            }

            var category = _dbContext.Category.FirstOrDefault(x=>x.Id==id);
            if(category == null)
            {
                return NotFound();
            }

            _dbContext.Category.Remove(category);
            _dbContext.SaveChanges();
            return Ok();

        }

    }
}
