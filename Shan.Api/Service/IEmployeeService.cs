using AdoNetApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoNetApi.IService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int Empid);
        Task<int> InsertEmployee(Employee employee);
        Task<bool> UpdateEmployee(int Empid, Employee employee);

        Task<bool> DeleteEmployee(int Empid);
            
    }
}