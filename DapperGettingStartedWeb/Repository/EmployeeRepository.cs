using Dapper;
using DapperGettingStartedWeb.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperGettingStartedWeb.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _connection;

        public EmployeeRepository(IConfiguration configuration)
        {
            this._connection = new SqlConnection(configuration.GetConnectionString("DataBaseCon"));
        }

        public async Task<Employee> Add(Employee employee)
        {
            const string sql = "INSERT INTO Employees (Name, Title, Email, Phone, CompanyId) VALUES(@Name, @Title, @Email, @Phone, @CompanyId);"
                        + "SELECT CAST(SCOPE_IDENTITY() as int); ";
            var id = await _connection.QueryFirstAsync<int>(sql, employee);
            employee.EmployeeId = id;
            return employee;
        }

        public async Task<Employee> Find(int id)
        {
            const string sql = "SELECT * FROM Employees WHERE EmployeeId = @Id";
            return await _connection.QueryFirstAsync<Employee>(sql, new { @Id = id });
        }

        public async Task<List<Employee>> GetAll()
        {
            const string sql = "SELECT * FROM Employees";
            return (await _connection.QueryAsync<Employee>(sql)).ToList();
        }

        public void Remove(int id)
        {
            const string sql = "DELETE FROM Employees WHERE EmployeeId = @Id";
            _connection.Execute(sql, new { id });
        }

        public async Task<Employee> Update(Employee employee)
        {
            const string sql = "UPDATE Employees SET Name = @Name, Title = @Title, Email = @Email, Phone = @Phone, CompanyId = @CompanyId WHERE EmployeeId = @EmployeeId";
            await _connection.ExecuteAsync(sql, employee);
            return employee;
        }
    }
}