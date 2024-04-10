using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDemoPageApp.Models.Domain;

namespace RazorDemoPageApp.Pages.Employees
{
    public class PrimeNumberModel : PageModel
    {
        [BindProperty]
        public PrimeNumberModels PrimeNumber { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPostAdd()
        {
            // Check if model state is valid before processing the form data.
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the page with validation errors.
                return Page();
            }

            // Process the form data and set ViewData message.
            int sum = PrimeNumber.FirstNumber + PrimeNumber.SecondNumber;
            ViewData["Message"] = $"The sum of {PrimeNumber.FirstNumber} and {PrimeNumber.SecondNumber} is {sum}.";
            return Page();
        }

        public IActionResult OnPostPrime()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the page with validation errors.
                return Page();
            }

            string primeNumbers = ""; // Initialize an empty string to store prime numbers

            for (int i = PrimeNumber.FirstNumber; i <= PrimeNumber.SecondNumber; i++)
            {
                if (IsPrime(i))
                {
                    if (primeNumbers != "") // If primeNumbers already contains numbers, add a comma separator
                        primeNumbers += ", ";

                    primeNumbers += i; // Append the prime number to the string
                }
            }

            if (primeNumbers == "")
                ViewData["Message"] = "No prime numbers found.";
            else
                ViewData["Message"] = "Prime numbers are: " + primeNumbers;
            return Page();
        }
        public void OnPostWhole()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the page with validation errors.
                ViewData["Message"] = "Something went wrong";
                return;
            }

            int firstNumber = PrimeNumber.FirstNumber;
            int secondNumber = PrimeNumber.SecondNumber;

            if (firstNumber >= secondNumber)
            {
                ViewData["Message"] = "First number should be less than the second number.";
                return;
            }

            string wholeNumbers = "";
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                if (i != firstNumber) // If wholeNumbers already contains numbers, add a comma separator
                    wholeNumbers += ", ";

                wholeNumbers += i; // Append the whole number to the string
            }

            if (string.IsNullOrEmpty(wholeNumbers))
                ViewData["Message"] = "No whole numbers found.";
            else
                ViewData["Message"] = "Whole numbers are: " + wholeNumbers;
        }
        public IActionResult OnPostFactor()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            int number1 = PrimeNumber.FirstNumber; // Change this to any non-negative integer
            int number2 = PrimeNumber.SecondNumber; // Change this to any non-negative integer
            (long factorial1, long factorial2) = CalculateFactorials(number1, number2);

            if (factorial1 == -1 || factorial2 == -1)
            {
                ViewData["Message"] = "Factorial calculation failed. Make sure the numbers are non-negative.";
            }
            else
            {
                ViewData["Message"] = $"The factorial of {number1} is {factorial1}.<br />" +
                                      $"The factorial of {number2} is {factorial2}.";
            }
            return Page();
        }
        public IActionResult OnPostSquare()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int number1 = PrimeNumber.FirstNumber; // Change this to any non-negative integer
            int number2 = PrimeNumber.SecondNumber; // Change this to any non-negative integer
            (long square1, long square2) = CalculateSqare(number1, number2);

            if (square1 == -1 || square2 == -1)
            {
                ViewData["Message"] = "Factorial calculation failed. Make sure the numbers are non-negative.";
            }
            else
            {
                ViewData["Message"] = $"The square of {number1} is {square1}.<br />" +
                                      $"The square of {number2} is {square2}.";
            }
            return Page();
        }
        public IActionResult OnPostPoewrofTwo()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int number1 = PrimeNumber.FirstNumber; // Change this to any non-negative integer
            int number2 = PrimeNumber.SecondNumber; // Change this to any non-negative integer
            (long square1, long square2) = CalculatePoewrofTwo(number1, number2);

            if (square1 == -1 || square2 == -1)
            {
                ViewData["Message"] = "Factorial calculation failed. Make sure the numbers are non-negative.";
            }
            else
            {
                string str1 = square1!=1? (square1).ToString():"It can not be Power Of Two";
                string str2 = square2!=1? (square2).ToString():"It can not be Power Of Two";

                ViewData["Message"] = $"The power of two  {number1} is {str1}.<br />" +
                                      $"The power of two  {number2} is {str2}.";
            }
            return Page();
        }



        static bool IsPrime(int num)
        {
            if (num <= 1)
                return false;
            if (num == 2)
                return true;
            if (num % 2 == 0)
                return false;

            int boundary = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
        public long CalculateFactorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number should be non-negative.");
            }

            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
        public long CalculateSquare(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number should be non-negative.");
            }

            int sqare = number * number;

            return sqare;
        }
        public long CalculatePoewrofTwo(int number)
        {
            int PoewrofTwo = 1;
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number should be non-negative.");
            }

            for (int i = 1; i <= number / 2; i++)
            {
                if (i * i == number)
                {
                    PoewrofTwo = i;
                    break;
                }
            }

            return PoewrofTwo;
        }

        public (long, long) CalculateFactorials(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
            {
                throw new ArgumentOutOfRangeException("Numbers should be non-negative.");
            }

            long factorial1 = CalculateFactorial(number1);
            long factorial2 = CalculateFactorial(number2);

            return (factorial1, factorial2);
        }
        public (long, long) CalculateSqare(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
            {
                throw new ArgumentOutOfRangeException("Numbers should be non-negative.");
            }

            long Square1 = CalculateSquare(number1);
            long Square2 = CalculateSquare(number2);

            return (Square1, Square2);
        }
        public (long, long) CalculatePoewrofTwo(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
            {
                throw new ArgumentOutOfRangeException("Numbers should be non-negative.");
            }

            long Square1 = CalculatePoewrofTwo(number1);
            long Square2 = CalculatePoewrofTwo(number2);

            return (Square1, Square2);
        }


    }
}
