--statement for create database TrinityMusicSchool
create database Tmusics;
Use Tmusics
--statement for create student table
create table Studenttable
(
studentid int primary key,
fullname varchar(50),
dob datetime,
address varchar(50),
program varchar(50),
classtype varchar(50),
registerdate datetime,
)

insert into Studenttable
Values (3,'Makija Kugan','1998-07-12','Erlalai West','Keyboard','full time','2022-12-09'),
	   (4,'Thiva Nada','2002-10-12','Nunavil West','Violin','Part time','2022-12-10');
select * from Studenttable

--statement for create teacherdetails
create table teacherdetails
(
teacherid int primary key,
fullname varchar(50),
dob datetime,
address varchar(50),
program varchar(50),
classtype varchar(50),
registerdate datetime,
phonenumber varchar(50),
contractperiod varchar(50),
)

insert into teacherdetails
Values (1,'Siva Kavinaja','1980-05-12','Kondavil West','Keyboard','full time','2022-12-09','0773456789','2 Years'),
	   (2,'Vaishnavy Thayalan','1990-10-13','Nunavil East','Violin','Part time','2022-12-10','0773367789','1 Years');
select * from teacherdetails
--statement for Login
create table login
(
username varchar(50),
password varchar(50),
)
insert into login
Values ('admin1','admin1'),
       ('admin2','admin2');
select * from login
--statement for instruments Details
create table instruments
(
instrumentid int primary key,
instrumentname varchar(50),
purchasedate datetime,
phonenumber varchar(50),
warrantyperiod varchar(50),
)
insert into instruments
Values (1,'Violin','2022-10-10','0773456129','2 Years'),
       (2,'Keybooard','2022-10-09','0773434289','1 Years');
select * from instruments
--statement for class Details
create table classdetails
(
classid int primary key,
startdate datetime,
classperiod varchar(50),
teacherid int,
foreign key(teacherid) references teacherdetails(teacherid)
)
insert into classdetails
Values (1,'2022-10-10','2 Years',1),
       (2,'2022-10-09','1 Years',1);
select * from classdetails
--statement for class Admission
create table classadmission
(
classid int,
joindate datetime,
studentid int,
admissionfees varchar(50),
foreign key(classid) references classdetails(classid),
foreign key(studentid) references studenttable(studentid)
)
insert into classadmission
Values (1,'2022-10-10',3,'Rs.500'),
       (2,'2022-10-09',4,'Rs.500');
select * from classadmission
--statement for instrumentrent Details
create table instrumentrentdetails
(
instrumentid int,
instrumenttype varchar(50),
renteddate datetime,
classid int,
renterrole varchar(50),
renterid int primary key,
foreign key(classid) references classdetails(classid),
foreign key(instrumentid) references instruments(instrumentid)
)
insert into instrumentrentdetails
Values (1,'Violin','2022-10-23',1,'Student',1),
       (2,'Keybooard','2022-11-01',1,'Student',2),
	   (3,'Violin','2022-11-01',1,'Student',2),
	   (4,'Keybooard','2022-11-01',1,'Student',2),
	   (5,'Dambura','2022-11-01',1,'Student',2),
	   (6,'Keybooard','2022-11-01',1,'Student',2);
select * from instrumentrentdetails
create table admission
(
admissionid int primary key,
classid int,
joindate datetime,
studentid int,
admissionfees varchar(50),
foreign key(classid) references classdetails(classid),
foreign key(studentid) references studenttable(studentid)
)
insert into admission
Values (1,1,'2022-10-10',3,'Rs.500'),
       (2,1,'2022-10-09',4,'Rs.500'),
	   (3,1,'2022-10-09',4,'Rs.500'),
	   (4,1,'2022-10-09',4,'Rs.500'),
	   (5,2,'2022-10-09',4,'Rs.500'),
	   (6,2,'2022-10-09',4,'Rs.500');
select * from admission

create table Student
(
studentid int primary key,
fullname varchar(50),
dob datetime,
address varchar(50),
program varchar(50),
classtype varchar(50),
registerdate datetime,
)
insert into Student
Values (3,'Makija Kugan','1998-07-12','Erlalai West','Keyboard','full time','2022-12-09'),
	   (4,'Thiva Nada','2002-10-12','Nunavil West','Violin','Part time','2022-12-10'),
	   (5,'Kavi Shakthi','2008-08-15','Inuvil West','Western','full time','2022-12-12'),
	   (6,'Thiva Nada','2004-06-12','Kokuvil West','Keyboard','full time','2022-12-03'),
	   (7,'Thiva Nada','2005-07-13','Thavady North','Karnatic','Evening','2022-12-11'),
	   (8,'Thiva Nada','2006-10-15','Inuvil North','Violin','Evening','2022-12-11'),
	   (9,'Thiva Nada','2000-09-12','Jaffna West','Western','Evening','2022-12-12');
select * from Student

SELECT *  
FROM Studenttable  
WHERE studentid IN   
(select studentid  FROM Studenttable  
WHERE Month(registerdate)=12 )  

SELECT DISTINCT studentid  FROM student  
WHERE studentid IN  
(SELECT studentid  FROM student  WHERE classtype='Part Time') 
 
 --Student Details with Palying Instruments
 SELECT studentid,  
fullname,  
classtype,  
program
FROM student INNER JOIN instrumentrentdetails on renterid = renterid ORDER BY fullname  

create table payment
(
paymentid int primary key,
studentid int,
admissionid int,
Fees varchar(50),
Month varchar(50),
date datetime,
foreign key(studentid) references student(studentid),
foreign key(admissionid) references admission(admissionid)
)
insert into payment
Values (1,3,1,'800','December','2022-12-10'),
       (2,3,2,'800','December','2022-12-12'),
	   (3,4,1,'800','December','2022-12-12'),
	   (4,5,1,'800','December','2022-12-13'),
	   (5,3,1,'800','January','2022-01-01'),
	   (6,4,1,'800','January','2022-01-01');
select * from payment

SELECT (fees)   
FROM payment  
WHERE studentid IN(select studentid  FROM Student  WHERE 
Month(registerdate)=12 ) 

SELECT DISTINCT studentid,fullname,dob,address,program,classtype,registerdate FROM student  
WHERE studentid IN  
(SELECT studentid  FROM student  WHERE registerdate='2022-12-11')
 

  


