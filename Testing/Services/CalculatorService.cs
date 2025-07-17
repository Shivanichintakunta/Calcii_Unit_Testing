using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testing.Data;
using Testing.Models;

namespace Testing.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly CalculatorDBContext _context;

        public CalculatorService(CalculatorDBContext context)
        {
            _context = context;
        }

        public async Task<CalculatorEntitiy> AddAsync(int operand1, int operand2)
        {
            var entity = new CalculatorEntitiy
            {
                Operand1 = operand1,
                Operand2 = operand2,
                result = operand1 + operand2,
                Operator = "+"
            };

            _context.CalculatorEntitiys.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CalculatorEntitiy> SubAsync(int operand1, int operand2)
        {
            var entity = new CalculatorEntitiy
            {
                Operand1 = operand1,
                Operand2 = operand2,
                result = operand1 - operand2,
                Operator = "-"
            };

            _context.CalculatorEntitiys.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CalculatorEntitiy> MulAsync(int operand1, int operand2)
        {
            var entity = new CalculatorEntitiy
            {
                Operand1 = operand1,
                Operand2 = operand2,
                result = operand1 * operand2,
                Operator = "*"
            };

            _context.CalculatorEntitiys.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CalculatorEntitiy> DivAsync(int operand1, int operand2)
        {
            if (operand2 == 0)
                throw new InvalidOperationException("Division by zero is not allowed.");

            var entity = new CalculatorEntitiy
            {
                Operand1 = operand1,
                Operand2 = operand2,
                result = operand1 / operand2,
                Operator = "/"
            };

            _context.CalculatorEntitiys.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CalculatorEntitiy>> GetAllAsync()
        {
            return await _context.CalculatorEntitiys.ToListAsync();
        }

        public async Task<CalculatorEntitiy?> GetByIdAsync(int id)
        {
            return await _context.CalculatorEntitiys.FindAsync(id);
        }
        public async Task<bool> UpdateAsync(int id, CalculatorEntitiy calculator)
        {
            if (id != calculator.id)
                return false;

            var existing = await _context.CalculatorEntitiys.FindAsync(id);
            if (existing == null)
                return false;

            existing.Operand1 = calculator.Operand1;
            existing.Operand2 = calculator.Operand2;
            existing.Operator = calculator.Operator;

            // Recalculate result based on operator
            switch (existing.Operator)
            {
                case "+":
                    existing.result = existing.Operand1 + existing.Operand2;
                    break;
                case "-":
                    existing.result = existing.Operand1 - existing.Operand2;
                    break;
                case "*":
                    existing.result = existing.Operand1 * existing.Operand2;
                    break;
                case "/":
                    if (existing.Operand2 == 0)
                        throw new InvalidOperationException("Division by zero is not allowed.");
                    existing.result = existing.Operand1 / existing.Operand2;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid operator: {existing.Operator}");
            }

            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CalculatorEntitiys.FindAsync(id);
            if (entity == null)
                return false;

            _context.CalculatorEntitiys.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
