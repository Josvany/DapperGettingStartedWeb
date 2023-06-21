using DapperGettingStartedWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperGettingStartedWeb.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> Find(int id);

        Task<List<Employee>> GetAll();

        Task<Employee> Add(Employee employee);

        Task<Employee> Update(Employee employee);

        void Remove(int id);
    }
}