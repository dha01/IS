using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using System.Data;

namespace IS.Helper
{
	/// <summary>
	/// Позволяет обращаться к базе данных более простым и наглядным образом
	/// </summary>
	public class SqlHelper : IDisposable
	{
		/// <summary>
		/// Подключение к базе данных
		/// </summary>
		private SqlConnection dbase;

		/// <summary>
		/// Команда для исполнения
		/// </summary>
		private SqlCommand _command;

		/// <summary>
		/// Конструктор класс
		/// </summary>
		/// <param name="command">Запрос</param>
		public SqlHelper(string command)
		{
			//string user_name = HttpContext.Current.User.Identity.Name;

			ConnectionStringSettings settings =	ConfigurationManager.ConnectionStrings["DefaultConnection"];			
					
			if (settings == null)
				dbase = new SqlConnection("Data Source=DHA-PC\\SQLEXPRESS;Initial Catalog=IS; User Id=is; Password=12345");
			else
				dbase = new SqlConnection(settings.ConnectionString);
			dbase.Open();	

			NewCommand(command);
		}

		/// <summary>
		/// Задает новый запрос, при этом все предыдущие заданные параметры удаляютсся
		/// </summary>
		/// <param name="command">Запрос</param>
		public void NewCommand(string command)
		{
			_command = new SqlCommand(command, dbase);
		}

		/// <summary>
		/// Исполняет запрос с возвращением таблицы
		/// </summary>
		/// <returns>Таблица с результатами запроса</returns>
		public DataTable ExecTable()
		{
			SqlDataAdapter dbAdapter = new SqlDataAdapter(_command);
			DataTable dataTable = new DataTable();
			dbAdapter.Fill(dataTable);
			return dataTable;
		}

		/// <summary>
		/// Исполняет запрос с возвращением скалярного значение
		/// </summary>
		/// <returns>Скалярный результат выполнения запроса</returns>
		public object ExecScalar()
		{
			return _command.ExecuteScalar();
		}

		/// <summary>
		/// Исполняет запрос без возвращения результата
		/// </summary>
		public void ExecNoQuery()
		{
			_command.ExecuteNonQuery();
		}

		/// <summary>
		/// Добавляет параметр использмый в запросе
		/// </summary>
		/// <param name="parameter_name">Имя параметра в запросе</param>
		/// <param name="value">Значение параметра</param>
		public void AddWithValue(string parameter_name, object value)
		{
			if (value == null)
				_command.Parameters.AddWithValue(parameter_name, DBNull.Value);
			else
				_command.Parameters.AddWithValue(parameter_name, value);
		}

		/// <summary>
		/// Преобразует объект в nullable значение
		/// </summary>
		/// <typeparam name="T">Тип передаваемого объекта</typeparam>
		/// <param name="value">Передаваемый объект</param>
		/// <returns>Преобразованный в nullable объект</returns>
		public static Nullable<T> CastNull<T>(object value)
			where T : struct
		{
			if (value == null || value == DBNull.Value)
			{
				return null;
			}
			return (T)value;
		}

		/// <summary>
		/// Преобразует класс в nullable значение
		/// </summary>
		/// <typeparam name="T">Класса передаваемого объекта</typeparam>
		/// <param name="value">Передаваемый объект</param>
		/// <returns>Преобразованный в nullable объект</returns>
		public static T CastNullClass<T>(object value)
			where T : class
		{
			if (value == null || value == DBNull.Value)
			{
				return null;
			}
			return (T)value;
		}

		/// <summary>
		/// Отчиска ресурсов системы
		/// </summary>
		public virtual void Dispose()
		{
			this.dbase.Close();
			this.dbase.Dispose();
		}
	}
}
