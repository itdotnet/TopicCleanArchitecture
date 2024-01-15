using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Identity;
using TopicCleanArchitecture.Application.Models.Identity;
using TopicCleanArchitecture.Identity.Models;

namespace TopicCleanArchitecture.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<Employee> GetEmployee(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new Employee {
                Email=employee.Email,
                Id=employee.Id,
                Firstname=employee.FirstName,
                Lastname=employee.LastName
            };
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(employee => new Employee {
                Email = employee.Email,
                Id = employee.Id,
                Firstname = employee.FirstName,
                Lastname = employee.LastName
            }).ToList();
        }
    }
}
