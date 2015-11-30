using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Helper;
using IS.Model.Item.Specialty;

namespace IS.Model.Repository.Specialty
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
	ss.specialty SpecId,
	sd.semestr_count SemestrCount,
	sd.training_period TrainingPeriod,
	q.qualification Qual,
	fs.form_study FormStud,
	sd.pay_space PaySpace,
	sd.lowcost_space LowcostSpace
from Specialty.specialty_detail sd
	join Specialty.specialty ss on ss.specialty = sd.specialty
	join Specialty.qualification q on q.qualification = sd.qualification
	join Specialty.form_study fs on fs.form_study = sd.form_study
where sd.specialty_detail = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по учебному курсу.
		/// </summary>
		/// <param name="specialtydetail">Учебный курс.</param>
		public void Update(SpecialtyDetailItem specialtydetail)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Specialty.specialty_detail
set
	specialty_detail = @Id,
	actual_date = @ActualDate,
	specialty = (select top 1 ss.specialty from Specialty.specialty ss where ss.specialty = @SpecId),
	semestr_count = @SemestrCount,
	training_period = @TrainingPeriod,
	lowcost_space = @LowcostSpace,
	qualification = (select top 1 q.qualification from Specialty.qualification q where q.qualification = @Qual),
	form_study = (select top 1 fs.form_study from Specialty.form_study fs where fs.form_study = @FStudy),
	pay_space = @PaySpace,
	lowcost_space = @LowcostSpace
where specialty_detail = @Id", specialtydetail);
			}
		}

		/// <summary>
		/// Создает новую учебный курс.
		/// </summary>
		/// <param name="specialtydetail">Учеьный курс.</param>
		/// <returns>Идентификатор созданного учебного курса.</returns>
		public int Create(SpecialtyDetailItem specialtydetail)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Specialty.specialty_detail
(
	specialty_detail,
	actual_date,
	specialty,
	semestr_count,
	training_period,
	qualification,
	form_study,
	pay_space,
	lowcost_space
)
values
(
	@Id,
	@ActualDate,
	(select top 1 ss.specialty from Specialty.specialty ss where ss.specialty = @SpecId),
	@SemestrCount,
	@TrainingPeriod,
	(select top 1 q.qualification from Specialty.qualification q where q.qualification = @Qual),
	(select top 1 fs.form_study from Specialty.form_study fs where fs.form_study = @FStudy),
	@PaySpace,
	@LowcostSpace
)

select scope_identity()", specialtydetail);
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
	s.specialty SpecId,
	sd.semestr_count SemestrCount,
	sd.training_period TrainingPeriod,
	q.qualification Qual,
	st.form_study FStudy,
	sd.pay_space PaySpace,
	sd.lowcost_space LowcostSpace
from Specialty.specialty_detail sd
	join Specialty.specialty ss on ss.specialty = sd.specialty
	join Specialty.qualification q on q.qualification = sd.qualification
	join Specialty.form_study fs on fs.form_study = sd.form_study");
			}
		}
	} 
}

