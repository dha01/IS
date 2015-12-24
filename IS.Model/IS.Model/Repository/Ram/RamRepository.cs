using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Helper;
using IS.Model.Item.Ram;

namespace IS.Model.Repository.Ram
{
	/// <summary>
	/// Интерфейс репозитория для работы с оперативной памятью.
	/// </summary>
	public class RamRepository : IRamRepository
	{
		/// <summary>
		/// Получает оперативную память по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Оперативная память.</returns>
		public RamItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<RamItem>(@"
select
	rr.id Id,
	rr.name Name,
	rt.ram_type RamType,
	rm.manufacturer Manufacturer,
	rr.capacity Capacity,
	rr.voltage Voltage,
	rr.frequency Frequency,
	rr.throughput Throughput,
from Ram.ram rr
	join Ram.ram_type rt on rt.ram_type = rr.ram_type
	join Ram.manufacturer rm on rm.manufacturer = rr.manufacturer
where rr.id = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по оперативной памяти.
		/// </summary>
		/// <param name="ram">Оперативная память.</param>
		public void Update(RamItem ram)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Ram.ram
set
	name = @Name,
	ram_type = (select top 1 rt.ram_type from Ram.ram_type rt where rt.ram_type = @RamType),
	manufacturer = (select top 1 rm.manufacturer from Ram.manufacturer rm where rm.manufacturer = @Manufacturer),
	capacity = @Capacity,
	voltage = @Voltage,
	frequency = @Frequency,
	throughput = @Throughput,
where id = @Id", ram);
			}
		}

		/// <summary>
		/// Создает новую оперативную память.
		/// </summary>
		/// <param name="ram">Оперативная память.</param>
		/// <returns>Идентификатор созданной оперативной памяти.</returns>
		public int Create(RamItem ram)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Ram.ram
(
	name,
	ram_type,
	manufacturer,
	capacity,
	voltage,
	frequency,
	throughput
)
values
(
	@Name,
	(select top 1 rt.ram_type from Ram.ram_type rt where rt.ram_type = @RamType),
	(select top 1 rm.manufacturer from Ram.manufacturer rm where rm.manufacturer = @Manufacturer),
	@Capacity,
	@Voltage,
	@Frequency,
	@Throughput
)

select scope_identity()", ram);
			}
		}

		/// <summary>
		/// Удаляет оперативную память.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Ram.ram
where id = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех единиц оперативной памяти.
		/// </summary>
		/// <returns>Список единиц оперативной памяти.</returns>
		public List<RamItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<RamItem>(@"
select
	rr.id Id,
	rr.name Name,
	rt.ram_type RamType,
	rm.manufacturer Manufacturer,
	rr.capacity Capacity,
	rr.voltage Voltage,
	rr.frequency Frequency,
	rr.throughput Throughput,
from Ram.ram rr
	join Ram.ram_type rt on rt.ram_type = rr.ram_type
	join Ram.manufacturer rm on rm.manufacturer = rr.manufacturer");
			}
		}
	} 
}

