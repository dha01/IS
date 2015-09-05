namespace IS.Model.Repository
{
	public interface IRepository<T>
	{
		T Get(int id);

		void Update(T item);

		int Create(T item);

		void Delete(int id);
	}
}