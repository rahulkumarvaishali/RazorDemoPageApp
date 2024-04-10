using System.ComponentModel.DataAnnotations;

namespace RazorDemoPageApp.Models.Domain
{
    public class PrimeNumberModels
    {

        //[Required(ErrorMessage = "Please enter a number.")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid integer.")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter a non-negative integer.")]
        public int FirstNumber { get; set; }

        //[Required(ErrorMessage = "Please enter a number.")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid integer.")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter a non-negative integer.")]
        public int SecondNumber { get; set; }
    }
}
