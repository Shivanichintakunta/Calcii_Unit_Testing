using System.ComponentModel.DataAnnotations;

namespace Testing.Models
{
    public class CalculatorEntitiy
    {
        [Key]

        public int id { get; set; }
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Operator { get; set; }
        public int result { get; set; }
    }
}
