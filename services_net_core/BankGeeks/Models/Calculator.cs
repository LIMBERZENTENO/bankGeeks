using System.ComponentModel.DataAnnotations.Schema;

namespace BankGeeks.Models
{
    public class Calculator
    {

        public int id { get; set; }    
        public decimal first_value { get; set; }   
        public decimal second_value { get; set; }
        public char operation { get; set; } 
        //public DateTime date_register { get; set; } 

    }
}
