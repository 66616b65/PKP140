using System;

namespace ADO_NET_Demo.Models
{
	public class Employee
	{
		public int Id { get; set; }

		public string LastName { get; set; }

		public string FirstName { get; set; }

		// Не просто DateTime, а DateTime?, так как
		// в базе данных колонка BirthDate это NULLABLE колонка.
		// Тип DateTime не может иметь NULL значений, поэтому мы
		// Используем специальный NULLABLE DateTime тип,
		// который в C# можно указать знаком вопроса в конце имени типа.
		public DateTime? BirthDate { get; set; }
	}
}
