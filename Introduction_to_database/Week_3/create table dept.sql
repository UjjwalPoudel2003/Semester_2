-- this is ddl
create table dept
(dnumber number, dname varchar2(20),
nmae varchar2(20),
post varchar2(15)
);

select * from dept;

Insert into dept values(1, 'cs', 'zak', 'Developer');
Insert into dept values( 3, 'Marketing', 'Ezaco', 'HR manager');
Insert into dept values( 5, 'Electical', 'Suraj', 'Technicia');
Insert into dept values(2, 'God', 'Ujjwal', 'world');

cREATE TABLE Emp (
EMp_id NUMBER,
Emp_name VARCHAR2(100) not null,
city VARCHAR2(30),
Salary number,
bonus number
);

--To insert the values for specific variable, example if we don't want to inset city, we can do with this command
insert into EMp(emp_id,emp_name,city,salary,bonus) values(1, 'sam','Toronto',1500000,120000);
insert into EMp(emp_id,emp_name,city,salary,bonus) values(2, 'abc','Toronto',1500000,2000);
insert into emp(emp_id,emp_name,city,bonus) values(3,'Ujjwal','North York',5000);
select * from Emp;
describe dept;
select dname, dnumber FROM dept;
--sort the tabes in accending order
select dname, nmae, post from dept order by nmae ASC;
select dname, nmae, post from dept order by dnumber ASC;
select dname, nmae, post from dept order by dname DESC;
select dname, nmae from dept order by dname ASC;

select dname, dnumber,dnumber nmae, post from dept where dnumber<5;
select * from dept where dname like 'Et';
select * from dept where nmae like '_za%';
select dnumber as "Department Number" from dept;
--|| will concatinate the column
select dnumber || ', ' || dname "Department Details" from dept;
commit;