using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVCApp.Models
{
    public class EmployeeList
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee() {Id = 2, Name = "John", Age = 25, Email = "john@company.com"},
            new Employee() {Id = 3, Name = "Sarah", Age = 30, Email = "sarah@company.com"},
            new Employee() {Id = 4, Name = "Michael", Age = 45, Email = "michael@company.com"},
            new Employee() {Id = 5, Name = "Emily", Age = 22, Email = "emily@company.com"},
            new Employee() {Id = 6, Name = "David", Age = 38, Email = "david@company.com"},
            new Employee() {Id = 7, Name = "Olivia", Age = 27, Email = "olivia@company.com"}

        };
    }
}