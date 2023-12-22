using AddressApi.Entities;
using Newtonsoft.Json;

namespace AddressApi.DataAccess
{
    public class Serialization
    {
        public string SerilizeToJson(Address address)
        {
            return JsonConvert.SerializeObject(address);
        }
        public Address DeserilizeJson(string json)
        {
            return JsonConvert.DeserializeObject<Address>(json);
        }
    }
}
