using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{fistNumber}/{secondNumber}")]
        public IActionResult GetSum(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{fistNumber}/{secondNumber}")]
        public IActionResult GetSub(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {
               
                var sub = ConvertToDecimal(fistNumber) - ConvertToDecimal(secondNumber);

                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{fistNumber}/{secondNumber}")]
        public IActionResult GetDiv(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {

                var div = ConvertToDecimal(fistNumber) / ConvertToDecimal(secondNumber);

                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{fistNumber}/{secondNumber}")]
        public IActionResult GetMult(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {
                
                var mult = ConvertToDecimal(fistNumber) * ConvertToDecimal(secondNumber);

                return Ok(mult.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

       
    }
}