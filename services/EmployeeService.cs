using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using karyawanApp.Models;
using karyawanApp.Repositories;

namespace karyawanApp.services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IPersistance _persistance;
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IPersistance persistance, IRepository<Employee> employeeRepository)
        {
            _persistance = persistance;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _employeeRepository.FindAllAsync();
            return employees;
        }

        public async Task<Employee> AddEmployee(Employee payload)
        {
            var employee = await _employeeRepository.SaveAsync(payload);
            await _persistance.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> EmployeeById(string id)
        {
            var employee = await _employeeRepository.FindByIdAsync(Guid.Parse(id));
            return employee;
        }

        public async Task Delete(string id)
        {
            var employee = await EmployeeById(id);
            _employeeRepository.Delete(employee);
            await _persistance.SaveChangesAsync();
        }

        public async Task<Employee> Update(Employee payload)
        {
            var employee = _employeeRepository.Update(payload);
            await _persistance.SaveChangesAsync();
            return employee;
        }
    }
}