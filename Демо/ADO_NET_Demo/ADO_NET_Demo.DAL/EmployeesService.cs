using ADO_NET_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET_Demo.DAL
{
	public class EmployeesService
	{
		private string connectionString;

		public EmployeesService(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public IEnumerable<Employee> GetAll()
		{
			var employees = new List<Employee>();
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Инициализируем объект команды
				using (var command = connection.CreateCommand())
				{
					// заполняем объект команды данными для запроса
					command.CommandText = @"SELECT EmployeeID, LastName, FirstName, BirthDate
											FROM Employees";

					// выполняем запрос
					using (var reader = command.ExecuteReader())
					{
						// убеждаемся, что получили какие-то строки
						if (reader.HasRows)
						{
							// обрабатываем результат
							while (reader.Read())
							{
								var employee = CreateFromDataReader(reader);
								employees.Add(employee);
							}
						}

						// для выполнения множественных SELECT 
						// reader.NextResult(); 
					}
				}

				//connection.Close();
			}

			return employees;
		}

		public Employee GetById(int id)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Инициализируем объект команды
				using (var command = connection.CreateCommand())
				{
					// заполняем объект команды данными для запроса
					command.CommandText = $@"SELECT EmployeeID, LastName, FirstName, BirthDate
											 FROM Employees
											 WHERE EmployeeID = @id";

					var parameter = command.CreateParameter();
					parameter.ParameterName = "@id";
					parameter.Value = id;
					parameter.SqlDbType = SqlDbType.Int;
					command.Parameters.Add(parameter);

					//command.Parameters.AddWithValue("@id", id);

					// выполняем запрос
					using (var reader = command.ExecuteReader())
					{
						// убеждаемся, что получили какие-то строки
						if (reader.HasRows)
						{
							// обрабатываем результат
							reader.Read();
							return CreateFromDataReader(reader);
						}
					}
				}
			}

			return null;
		}

		public int Insert(Employee employee)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Инициализируем объект команды
				using (var command = connection.CreateCommand())
				{
					// заполняем объект команды данными для запроса
					command.CommandType = CommandType.StoredProcedure;
					command.CommandText = "InsertEmployee";

					// создание и заполнение входного параметра
					var inputParameter1 = command.CreateParameter();
					inputParameter1.ParameterName = "@LastName";
					inputParameter1.Value = employee.LastName;
					inputParameter1.Direction = ParameterDirection.Input;
					inputParameter1.DbType = DbType.String;

					// создание и заполнение входного параметра
					var inputParameter2 = command.Parameters.Add("@FirstName", SqlDbType.NVarChar);
					inputParameter2.Value = employee.FirstName;

					// создание и заполнение выходного параметра
					var outParameter = command.CreateParameter();
					outParameter.ParameterName = "@outParameter";
					outParameter.Direction = ParameterDirection.Output;
					outParameter.DbType = DbType.Int32;

					command.Parameters.Add(inputParameter1);
					// command.Parameters.Add(inputParameter2)
					command.Parameters.Add(outParameter);

					// выполняем запрос
					command.ExecuteNonQuery();
					if (outParameter.Value == null)
						throw new Exception("Не удалось добавить строку.");

					return (int)outParameter.Value;
				}
			}
		}

		public void Update (Employee employee)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Инициализируем объект команды
				using (var command = connection.CreateCommand())
				{
					// заполняем объект команды данными для запроса
					command.CommandText = @"UPDATE Employees
											SET LastName = @lastName, FirstName = @firstName
											WHERE EmployeeID = @id";
					// Ещё одна необходимость использовать SQL Parameter заключается в том,
					// что при обычной конкатенации строк мы создаём потенциальную уязвимость
					// для SQL инъекции. Никогда не доверяйте пользователям вашей программы,
					// так как они могут ввести вместо ожидаемых значений всё что угодно
					// в том числе вредоносные команды, например "Иванов'; DROP Table Employees;"
					command.Parameters.AddWithValue("@id", employee.Id);
					command.Parameters.AddWithValue("@lastName", employee.LastName);
					command.Parameters.AddWithValue("@firstName", employee.FirstName);

					// выполняем запрос
					command.ExecuteNonQuery();
				}
			}
		}

		public bool Delete(int id)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Инициализируем объект команды
				using (var command = connection.CreateCommand())
				{
					// заполняем объект команды данными для запроса
					command.CommandText = @"DELETE FROM Employees
											WHERE EmployeeID = @id";

					command.Parameters.AddWithValue("@id", id);
					// выполняем запрос
					return command.ExecuteNonQuery() > 0;
				}
			}
		}

		private Employee CreateFromDataReader(SqlDataReader reader)
		{
			var id = reader.GetInt32(0);
			var lastName = reader.GetString(1);
			var firstName = reader.GetString(2);
			// Тип DateTime не может быть равен null в C#, а в нашей базе данных колонка с датой может иметь NULL значения
			// Чтобы не было ошибки, мы должны проверить является ли значение NULL и только если нет,
			// считать его и сохранить. В противном случае мы будем использовать специальный NULLABLE тип DateTime?
			var birthDate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);

			//var firstName = reader.GetString(2);
			//var lastName = reader.GetString(1);

			return new Employee
			{
				Id = id,
				LastName = lastName,
				FirstName = firstName,
				BirthDate = birthDate,
			};
		}
	}
}
