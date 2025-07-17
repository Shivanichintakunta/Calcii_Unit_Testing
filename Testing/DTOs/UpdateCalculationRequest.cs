namespace Testing.DTOs
{
    public class UpdateCalculationRequest
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string? Operator { get; set; }  // optional: if not supplied, use existing
    }
}
