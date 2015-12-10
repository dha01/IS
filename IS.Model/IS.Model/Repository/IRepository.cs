namespace IS.Model.Repository
{
	public interface IRepository<T>
	{
		T Get(int id);
	}
}