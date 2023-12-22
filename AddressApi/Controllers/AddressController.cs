using AddressApi.DataAccess;
using AddressApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly string _addressesFilePath;
        private readonly Serialization _serialization;
        private readonly FileHandler _fileHandler;
        public AddressController(IConfiguration configuration, Serialization serialization, FileHandler fileHandler)
        {
            _addressesFilePath = configuration["AddressFilePath"];
            _serialization = serialization;
            _fileHandler = fileHandler;
        }

        [HttpPost("SaveAddress")]
        public IActionResult SaveAddress([FromForm] string address)
        {
            var addressJson = _serialization.SerilizeToJson(new Address { AddressName = address, AddressID = Guid.NewGuid().ToString() });
            _fileHandler.SaveToFile(addressJson);
            return Ok();
        }

        [HttpGet("GetAddress/{id}")]
        public IActionResult GetAddressById(string id)
        {
            var addressArr = _fileHandler.ReadFile();

            foreach (var address in addressArr)
            {
                var currentAdderss = _serialization.DeserilizeJson(address);
                if (currentAdderss.AddressID == id)
                {
                    return Ok(currentAdderss);
                }
            }
            return NotFound();
        }

    }
}
