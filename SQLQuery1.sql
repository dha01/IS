-- Создает бэкап
backup database [IS]
 to disk = 'K:\SQLServerBackups\IS.bak'
   with format;
go

-- Просмотр файлов бэкапа
restore filelistonly 
   from disk = 'K:\SQLServerBackups\IS.bak'

-- Восстановить бэкап
restore database [IS_backup]
   from disk = 'K:\SQLServerBackups\IS.bak'
   with move 'IS' to 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\IS_backup.mdf',
   move 'IS_log' to 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\IS_backup_log.ldf';
go