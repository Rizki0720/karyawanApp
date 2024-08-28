using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using karyawanApp.Models;

namespace karyawanApp.services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> AddEmployee(Employee payload);
        Task Delete(string id);
        Task<Employee> EmployeeById(string id);
        Task<Employee> Update(Employee payload);

    }
}