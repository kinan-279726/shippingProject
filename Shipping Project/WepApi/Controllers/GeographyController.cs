using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeographyController : ControllerBase
    {
        private readonly ICountriesServices OcountriesServices;
        private readonly IUsersServices OusersServices;

        public GeographyController(ICountriesServices countriesServices , IUsersServices usersServices)
        {
            OusersServices = usersServices;
            OcountriesServices = countriesServices;
        }
        // GET: api/<GeographyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GeographyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GeographyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GeographyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GeographyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet]
        public IActionResult GetCountry()
        {
            ApiResponseDto response = new ApiResponseDto();
            try
            {
                
                List<CountriesDto> countries = OcountriesServices.GetAll();
                response.Data = countries; 
                response.IsSuccess = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Errors = new List<string> { ex.Message };
                return BadRequest(response);
            }
        }
        [HttpPost]
        public IActionResult AddCountry(CountriesDto model)
        {
            ApiResponseDto response = new ApiResponseDto();
            if (ModelState.IsValid)
            {
                bool result = OcountriesServices.Add(model);
                if(result)
                {
                    response.IsSuccess = true;
                    return Ok(response);
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);
            }
            return BadRequest(response);
        }
    }
}
