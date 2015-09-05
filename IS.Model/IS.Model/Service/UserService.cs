using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;

namespace IS.Mvc.Models.Service
{
	public class UserService
	{
		private IUserRepository _userRepository;

		public UserService()
		{
			_userRepository = new UserRepository();
		}
		
		public UserService(IUserRepository user_repository)
		{
			_userRepository = user_repository;
		}
		
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
	}
}