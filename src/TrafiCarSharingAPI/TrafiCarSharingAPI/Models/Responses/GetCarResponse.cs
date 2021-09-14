using System.Collections.Generic;
using TrafiCarSharingAPI.Core.Entities;

namespace TrafiCarSharingAPI.Core.Models.Responses
{
    public sealed class GetCarsResponse
    {
        public IEnumerable<Car> Cars { get; set; }
    }
}
