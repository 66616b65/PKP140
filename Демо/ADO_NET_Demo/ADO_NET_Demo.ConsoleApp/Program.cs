using ADO_NET_Demo.DAL;
using ADO_NET_Demo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ADO_NET_Demo.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var dbName = "NorthWindConnectionString";
			var connectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;

			var service = new EmployeesService(connectionString);

			Console.WriteLine("Выводим всех работников:");
			var employees = service.GetAll();
			ShowEmployees(employees);

			var employee = service.GetById(1);
			Console.WriteLine("Выводим работника с id = 1:");
			ShowEmployee(employee);

			Console.WriteLine("Создаём нового работника...");
			var newEmployee = new Employee
			{
				LastName = "NewLastName",
				FirstName = "NewFirstName",
				BirthDate = new DateTime(1990, 06, 20),
			};
			var id = service.Insert(newEmployee);
			Console.WriteLine($"Id созданного сотрудника: {id}.");
			var addedEmployee = service.GetById(id);
			Console.WriteLine("Выводим добавленного работника:");
			ShowEmployee(addedEmployee);

			Console.WriteLine("Обновляем этого работника...");
			addedEmployee.LastName = "UpdatedLastName";
			addedEmployee.FirstName = "UpdatedFirstName";
			service.Update(addedEmployee);

			Console.WriteLine("Выводим обновленного работника:");
			var updatedEmployee = service.GetById(addedEmployee.Id);
			ShowEmployee(updatedEmployee);

			Console.WriteLine($"Удаляем работника с Id: {updatedEmployee.Id}:");
			var success = service.Delete(updatedEmployee.Id);
			Console.WriteLine($"Удаление прошло успешно? - {success}.");
		}

		private static void ShowEmployees(IEnumerable<Employee> employees)
		{
			Console.WriteLine("-------------------------------------");
			foreach (var employee in employees)
			{
				ShowEmployee(employee);
			}

			Console.WriteLine("-------------------------------------");
		}

		private static void ShowEmployee(Employee employee)
		{
			var birthdate = employee.BirthDate.HasValue
				? employee.BirthDate.Value.ToString("yyyy-MM-dd")
				: "не указано";
			Console.WriteLine($"Id: {employee.Id}, " +
				$"{employee.FirstName} {employee.LastName}, " +
				$"Birth date: {birthdate}.");
		}
	}
}
