using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;
using IS.Model.Service;
using IS.Model.Item.Person;

namespace IS.Mvc.Models.Service
{
	public class UserService
	{
		private IUserRepository _userRepository;

		public UserService()
		{
			_userRepository = new UserRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="user_repository">Интерфейс пользовательского репозитория.</param>
		public UserService(IUserRepository user_repository)
		{
			_userRepository = user_repository;
		}
		
		/// <summary>
		/// Создает пользователя.
		/// </summary>
		/// <param name="user">Данные о пользователе.</param>
		/// <returns>Идентификаторо созданного пользователя.</returns>
		public int Create(UserItem user)
		{
			if (string.IsNullOrEmpty(user.Login))
			{
				throw new Exception("Поле 'Login' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(user.Password))
			{
				throw new Exception("Поле 'Password' не должно быть пустым.");
			}
			
			return _userRepository.Create(user);
		}

		public void Update(UserItem user)
		{
			_userRepository.Update(user);
		}

		public void Delete(UserItem user)
		{
			_userRepository.Delete(user.Id);
		}

		public UserItem GetUserByLogin(string login)
		{
			if (string.IsNullOrEmpty(login))
			{
				throw new Exception("Поле 'login' не должно быть пустым.");
			}
			return _userRepository.GetUserByLogin(login);
		}

		/// <summary>
		/// Получение учетной записи пользователя (UserItem) по идентификатору персональных данных(PersonItem).
		/// </summary>
		/// <param name="Id">Идентификатор.</param>
		/// <returns>Учатная запись пользователя.</returns>
		public UserItem GetUserByPersonId(int Id)
		{

			PersonService personService = new PersonService();
			PersonItem personItem = personService.GetById(Id);
			UserItem userItem = _userRepository.Get(personItem.Id);

			return userItem;
		}
	}
}