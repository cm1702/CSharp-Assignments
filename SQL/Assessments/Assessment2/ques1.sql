use assessment2sqlserver

--question 1

declare @dob 
date = '2002-02-17' 
select datename(weekday,@dob) as DayOfWeek