using AdoNetApi.IService;
using AdoNetApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AdoNetApi.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _connectionString;
      
        public EmployeeService(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")!;
        }

        // Get All Employee

        public async Task<List<Employee>> GetAllEmployees()
        {
            var Employee = new List<Employee>();
            using var connection = new SqlConnection(_connectionString);
            using var Command = new SqlCommand("sp_GetAllEmployees", connection);


            Command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            using var reader = await Command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Employee.Add(new Employee
                {
                    Empid = reader.GetInt32("Empid"),
                    Name = reader.GetString("Name"),
                    Department = reader.GetString("Department"),
                    Gender = reader.GetString("Gender"),
                    Salary = reader.GetInt32("Salary")
                });
            }

            return Employee;
        }

        //Get Employee By Id

        public async Task<Employee?> GetEmployeeById(int Empid)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "sp_GetEmployeeById", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Empid", SqlDbType.Int).Value = Empid;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Employee
                {
                    Empid = reader.GetInt32("Empid"),
                    Name = reader.GetString("Name"),
                    Department = reader.GetString("Department"),
                    Gender = reader.GetString("Gender"),
                    Salary = reader.GetInt32("Salary")
                };
            }

            return null;
        }

        // Insert Employee

        public async Task<int> InsertEmployee(Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "sp_InsertEmployee", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Empid", SqlDbType.Int)
                .Value = employee.Empid;

            command.Parameters.Add("@Name", SqlDbType.VarChar, 20)
                .Value = employee.Name;

            command.Parameters.Add("@Department", SqlDbType.VarChar, 30)
                .Value = employee.Department;

            command.Parameters.Add("@Gender", SqlDbType.VarChar, 20)
                .Value = employee.Gender;

            command.Parameters.Add("@Salary", SqlDbType.Int)
                .Value = employee.Salary;

            await connection.OpenAsync();

            var result = await command.ExecuteScalarAsync();

            return Convert.ToInt32(result);
        }

        // Update Employee
        public async Task<bool> UpdateEmployee(int Empid, Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "sp_UpdateEmployee", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Empid", SqlDbType.Int).Value = employee.Empid;

            command.Parameters.Add("@Name", SqlDbType.VarChar, 20)
                .Value = employee.Name;

            command.Parameters.Add("@Department", SqlDbType.VarChar, 30)
                .Value = employee.Department;

            command.Parameters.Add("@Gender", SqlDbType.VarChar, 10)
                .Value = employee.Gender;

            command.Parameters.Add("@Salary", SqlDbType.Int)
                .Value = employee.Salary;

            await connection.OpenAsync();

            var result = await command.ExecuteScalarAsync();

            return Convert.ToInt32(result) > 0;
        }

        // DELETE EMPLOYEE
        public async Task<bool> DeleteEmployee(int Empid)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "sp_DeleteEmployee", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Empid", SqlDbType.Int).Value = Empid;

            await connection.OpenAsync();

            var result = await command.ExecuteScalarAsync();

            return Convert.ToInt32(result) > 0;
        }


    }

}








