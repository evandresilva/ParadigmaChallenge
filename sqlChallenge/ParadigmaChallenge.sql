create database hr;
use hr;

create table department(id int primary key identity(1,1), name varchar(32) not null);

create table employee(id int primary key identity(1,1), name  varchar(64) not null,
                        salary money,
						departmentId int foreign key references department(id)
						);

						



insert into department(name) values ('TI'),('Vendas');

insert into employee(name, salary, departmentId) values 
	('Joe', 70000 ,1),
	('Henry', 80000, 2),
	('Sam', 60000, 2),
	('Max', 90000, 1);



select emp.name Departamento, emp.name Pessoa, emp.salary Salario
from employee emp 
inner join department dp on emp.departmentId = dp.id
where emp.salary = (select max(salary) from employee where departmentId = emp.departmentId);


