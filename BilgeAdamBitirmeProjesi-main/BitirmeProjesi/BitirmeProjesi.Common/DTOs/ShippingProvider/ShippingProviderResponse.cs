using BitirmeProjesi.Common.DTOs.Base;
using System;
namespace BitirmeProjesi.Common.DTOs.ShippingProvider
{
    public class ShippingProviderResponse : BaseDto
    {
        public string code { get; set; }
        public string name { get; set; }
    }
}
