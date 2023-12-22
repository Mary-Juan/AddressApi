using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly string _addressesFilePath;
        public AddressController(IConfiguration configuration)
        {
            _addressesFilePath = configuration["AddressFilePath"];
        }


    }
}
