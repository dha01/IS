using IS.Model.Helper;
using IS.Model.Item.SpecialtyDetail;

namespace IS.Model.Repository.SpecialtyDetail
{
	/// <summary>
	/// Интерфейс репозитория для работы с учебными курсами.
	/// </summary>
	public class SpecialtyDetailRepository : ISpecialtyDetailRepository
	{
		/// <summary>
		/// Получает учебный курс по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Учебный курс.</returns>
		public SpecialtyDetailItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<SpecialtyDetailItem>(@"
select
	sd.specialty_detail Id,
	sd.actual_date ActualDate,
	sd.semestr_count SemestrCount,
	sd.training_period TrainingPeriod,
	sd.pay_space PaySpace,
	sd.lowcost_space LowcostSpace
	q.qualification Qualification,
	st.form_study FormStudy,
from Specialty.specialty_detail sd
	join Specialty.qualification q on q.qualification = sd.qualification
	join Specialty.form_study st on st.form_study = sd.form_study
where sd.specialty_detail = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по учебному курсу.
		/// </summary>
		/// <param name="specialty_detail">Учебный курс.</param>
		public void Update(SpecialtyDetailItem specialty)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Specialty.specialty_detail
set
	specialty_detail = @Id,
	actual_date = @ActualDate,
	semestr_count = @SemestrCount,
	training_period = @TrainingPeriod,
	pay_space = @PaySpace,
	lowcost_space = @LowcostSpace,
	qualification = (select top 1 q.qualification from Specialty.qualification q where q.qualification = @Qualification),
	form_study = (select top 1 st.form_study from Specialty.form_study st where st.form_study = @FormStudy),
where specialty_detail = @Id", specialty_detail);
			}
		}

		/// <summary>
		/// Создает новую учебный курс.
		/// </summary>
		/// <param name="specialty_detail">Учеьный курс.</param>
		/// <returns>Идентификатор созданного учебного курса.</returns>
		public int Create(SpecialtyDetailItem specialty)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Specialty.specialty_detail
(
	specialty_detail,
	actual_date,
	semestr_count,
	training_period,
	pay_space,
	lowcost_space,
	qualification,
	form_study,
)
values
(
	@Id,
	@ActualDate,
	@SemestrCount,
	@TrainingPeriod,
	@PaySpace,
	@LowcostSpace,
	(select top 1 q.qualification from Specialty.qualification q where q.qualification = @Qualification),
	(select top 1 st.form_study from Specialty.form_study st where st.form_study = @FormStudy),
)

select scope_identity()", specialty_detail);
			}
		}

		/// <summary>
		/// Удаляет учебный курс.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Specialty.specialty_detail
where specialty_detail = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех учебных курсов.
		/// </summary>
		/// <returns>Список курсов.</returns>
		public List<SpecialtyDetailItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<SpecialtyDetailItem>(@"
select
	sd.specialty_detail Id,
	sd.actual_date ActualDate,
	sd.semestr_count SemestrCount,
	sd.training_period TrainingPeriod,
	sd.pay_space PaySpace,
	sd.lowcost_space LowcostSpace
	q.qualification Qualification,
	st.form_study FormStudy,
from Specialty.specialty_detail sd
	join Specialty.qualification q on q.qualification = sd.qualification
	join Specialty.form_study st on st.form_study = sd.form_study");
			}
		}
	} 
}

