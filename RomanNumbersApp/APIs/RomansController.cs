using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanNumbersApp.Logic;

namespace RomanNumbersApp.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class RomansController : ControllerBase
    {
        private IRomanNumInterface romannumerals;
        public RomansController(IRomanNumInterface romannumerals) {
            this.romannumerals = romannumerals;
        }
        [HttpPost]
        public string Add(RomansRequest romansRequest)
        {
            int val1 = 0;
            int val2 = 0;
            var total = 0;
            try
            {
                 val1 = romannumerals.RomanToInt(romansRequest.value1);
                 val2 = romannumerals.RomanToInt(romansRequest.value2);
                 total =val1 + val2;
                
            }
            catch(Exception ex) {
                //throw ex;
            }
            return romannumerals.RomanNumeralFrom(total);
        }


    }

   

}

public class RomansRequest
{
    public string value1 { get; set; }
    public string value2 { get; set; }
}