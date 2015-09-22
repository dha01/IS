create table Dbo.test_test
(
	test_test int identity(1,1) not null,
	code nvarchar(128) not null,
	mem nvarchar(max) null,
)

select
	dt.test,
	dt.code
from dbo.test dt
	join dbo.test_two tt on	tt.test_two = dt.test_test
where
	dt.test > 0
	and dt.test < 5

