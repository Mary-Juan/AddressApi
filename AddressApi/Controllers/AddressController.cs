using AddressApi.DataAccess;
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


    }
}
