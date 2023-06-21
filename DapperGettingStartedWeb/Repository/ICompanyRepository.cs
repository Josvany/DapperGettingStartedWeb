using DapperGettingStartedWeb.Models;
using System.Collections.Generic;

namespace DapperGettingStartedWeb.Repository
{
    public interface ICompanyRepository
    {
        Company Find(int id);

        List<Company> GetAll();

        Company Add(Company company);

        Company Update(Company company);

        void Remove(int id);
    }
}