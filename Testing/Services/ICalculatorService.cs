using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing.Services
{
    public interface ICalculatorService
    {
        Task<CalculatorEntitiy> AddAsync(int operand1, int operand2);
        Task<CalculatorEntitiy> SubAsync(int operand1, int operand2);
        Task<CalculatorEntitiy> MulAsync(int operand1, int operand2);
        Task<CalculatorEntitiy> DivAsync(int operand1, int operand2);

        Task<IEnumerable<CalculatorEntitiy>> GetAllAsync();
        Task<CalculatorEntitiy?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, CalculatorEntitiy calculator);

        Task<bool> DeleteAsync(int id);
    }
}
