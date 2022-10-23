Create Database HRAS_DB

use HRAS_DB
------------------Table Declarations
Create table Employee(
EmpFname varchar(20),
EmpLname varchar(20),
EmpId int identity(100,5) primary key,
EmpPass varchar(10) check(len(EmpPass)<=8) unique,
EmpRole varchar(15)
)


create table Customer(
CustFname varchar(20),
CustLname varchar(20),
CustId int identity(1,2) primary key,
CustPhone varchar(11) 
)

create table Owners(
OwnFname varchar(20),
OwnLname varchar(20),
OwnId int identity(2,2) primary key,
OwnPhone varchar(11) 
)

create Table Property(
PropId int identity(3,3) primary key,
OwnId int foreign key References Owners(OwnID) On Delete cascade on update no action,
Adress varchar(20) Default('TBD'),
SaleType varchar(10) Default('Rent'),
HouseType varchar(10) Default('Condo'),
statuss varchar(2) Default('A'),
rooms int default(1)
)

create table Pictures(
PropId int foreign key References Property(PropID) On Delete cascade on update no action,
pic image null
)

create table Audits(
Customer_ID int foreign key references Customer(CustID) On delete No action on update No Action,
Owner_ID int foreign key references Owners(OwnID) On delete No action on update No Action,
Property_ID int foreign key references Property(PropID) On delete No action on update No Action,
Employee_ID int foreign key references Employee(EmpID) On delete No action on update No Action,
Sale_Type varchar(10),
Transaction_Date date
)
----------------Data Entery

insert into Employee values

('Admin','Admin','1234','HR')


-----------------------------------------------------Functions

---------EmpFuncs
go
Create function sendRole(@id int,@pass varchar(10))
returns varchar(15)
as
Begin
declare @role varchar(15)
Set @role = (Select EmpRole from Employee where EmpId=@id and @pass=EmpPass collate SQL_Latin1_General_CP1_CS_AS)
return @role

end

go

Create function sendFullName(@id int,@pass varchar(10))
returns varchar(41)
as
Begin
declare @fullname varchar(41)
Set @fullname = (Select CONCAT(EmpFname,' ',EmpLname) from Employee where EmpId=@id and @pass=EmpPass)
return @fullname

end

go

------------CustFuncs

Create function sendCustomer(@id int)
returns table
as
return(select * from Customer where CustId=@id)

-------------------------------------------------------------------------
go

create function countAllCustomers() -----------
 returns int
 as
 begin
    declare @count int
   set @count=(select count(*) from Customer)
   
   return @count
 end
go

-------------------------------------------------------------------------
go

create function countAllOwners() ----------
 returns int
 as
 begin
    declare @count int
   set @count=(select count(*) from Owners)
   
   return @count
 end
go

-------------------------------------------------------------------------
go

create function countAllProperties() -----------
 returns int
 as
 begin
    declare @count int
   set @count=(select count(*) from Property)
   
   return @count
 end
go

-------------------------------------------------------------------------
go

create function countAvailableProperties() -----------
 returns int
 as
 begin
    declare @count int
   set @count=(select count(*) from Property where Statuss='A')
   
   return @count
 end
go


go

create function countSoldProperties() -----------
 returns int
 as
 begin
    declare @count int
   set @count=(select count(*) from Property where Statuss='S')
   
   return @count
 end
go
 -------------------------------------------------------------------------
go

create function countRentedProperties() -----------
 returns int
 as
 begin
    declare @count int
   set @count=(select count(*) from Property where Statuss='S')
   
   return @count
 end

 

 -------------------------------------------------------------------------
go

create function calculateRevenue() -----------
 returns int
 as
 begin
    declare @revenue int
   set @revenue=(select sum(Price) from Property where statuss='S')
   
   return @revenue
 end


go
Create function sendEmployeeAudit(@id int)
returns int
as
begin
Declare @count int
set @count=(select Count(Employee_ID) from Audits where Employee_ID=@id)
return @count
end

-------------------------------------------------------------Stored Procedures

----EmpProcs
go
Create Proc sendEmp
as
begin
select * from Employee
end


go
Create Proc AddEmp
@fname varchar(20),@lname varchar(20),@pass varchar(10),@role varchar(15),@id int output
as
begin
insert into Employee values(@fname,@lname,@pass,@role) 
set @id=SCOPE_IDENTITY()
end

go
Create Proc updateEmp
@fname varchar(20),@lname varchar(20),@pass varchar(10),@role varchar(15),@id int
as
begin
update Employee set EmpFname=@fname,EmpLname=@lname,
EmpPass=@pass,EmpRole=@role 
where
EmpId=@id
end

go
Create Proc deleteEmp
@id int
as
begin
Delete from Employee where EmpId=@id
end

go

Create proc ResetID
as
begin
 Declare @tempTable table 
 (EmpFname varchar(20), EmpLname varchar(20), 
 EmpPass varchar(10),EmpRole varchar(10)) 

insert into @tempTable select EmpFname,EmpLname,EmpPass,EmpRole from Employee

Delete from Employee

DBCC CHECKIDENT ('dbo.Employee', RESEED, 0)

insert into Employee(EmpFname,EmpLname,EmpPass,EmpRole) select * from @tempTable

end

---------CustProcs
go

Create Proc sendCust @id int
as
Begin
	select * from sendCustomer(@id)
end

go

create proc updateCustomer @fn varchar(20),@ln varchar(20),@id int,@ph varchar(11)
as
begin
update Customer set CustFname=@fn,CustLname=@ln,CustPhone=@ph where CustId=@id
end

go

Create proc insertCustomer @fn varchar(20),@ln varchar(20),@ph varchar(11),@id int output
as
begin
insert into Customer values(@fn,@ln,@ph)
set @id=SCOPE_IDENTITY()
end

go
Create proc sendCustID
as
select Customer.CustId from Customer

go
Create proc sendCustDetail
as
select * from Customer order by CustFname

go
Create proc DeleteCustomer @id int
as
Delete from Customer where CustID=@id

---------OwnProcs


go
Create Proc sendOwn @id int
as
Begin
	select * from Owners where OwnId=@id
end




go
create proc updateOwner @fn varchar(20),@ln varchar(20),@id int,@ph varchar(11)
as
begin
update Owners set OwnFname=@fn,OwnLname=@ln,OwnPhone=@ph where OwnId=@id
end




go
Create proc insertOwner @fn varchar(20),@ln varchar(20),@ph varchar(11),@id int output
as
begin
insert into Owners values(@fn,@ln,@ph)
set @id=SCOPE_IDENTITY()
end


go
create Proc searchByOwnerID @id int
as
begin
select * from Property where Property.OwnId=@id
end



go
create proc sendOwnID
as
select Owners.OwnId from Owners

go
Create proc sendOwner
as
select * from Owners order by OwnFname


go
Create proc DeleteOwner @id int
as
Delete from Owners where OwnId=@id


------Property Procedures



go
Create Proc searchByPropertyID @id int
as
begin
select * from Property where Property.PropId=@id
end




go
create Proc updateProperty
@Adress varchar(20),@SaleType varchar(10), 
@HouseType varchar(10), @stat varchar(2),
@price int,@rooms int,@id int
as
begin
update Property set Adress=@Adress,SaleType=@SaleType,HouseType=@HouseType
,statuss=@stat,rooms=@rooms,price=@price where PropId=@id
end



go
Create Proc searchProperty 
@minRoom int,@maxRoom int,@maxPrice int,@minPrice int,
@saleType varchar(10),@houseType varchar(10)
as
begin
select *  from Property 
where 
price between @minPrice and @maxPrice+1
and
rooms between @minRoom and @maxRoom+1
and
SaleType=@saleType
and
HouseType=@houseType
and
statuss like 'A'
end


go
Create Proc sendPropId
as
select Property.PropId from Property where Property.statuss like 'A'


go
Create proc sendProperty
as
select * from Property order by PropId

go
Create proc DeleteProperty @id int
as
Delete from Property where PropId=@id

----Picture Procedures


go
Create Proc sendImage @id int
as
begin
select Pictures.pic from Pictures 
where Pictures.PropId=@id
end

go
Create Proc enterImage
@id int,@pic image
as
begin
insert into Pictures values (@id,@pic)
end


go
Create proc sendPicture
as
select * from Pictures order by PropId
----Audit Procedures

go
Create Proc insertAudit
@custID int,@ownID int, @propID int,@empId int,@saleType varchar(20)
as
begin

Insert into Audits values(@custID,@ownID,@propID,@empId,@saleType,GETDATE())

end


go
Create Proc sendAudit
as
select * from Audits



------------------Procs

go
Create Proc backUpDatabase
as
begin
BACKUP DATABASE HRAS_DB
TO DISK = 'C:\DB BACKUPS\HRAS_DB.bak';
end








-------------------------------------------------------------- triggers

----Property Trigger

go
Create trigger createProperty 
on Owners
after insert
as
begin
Declare @ownId int
set @ownId =(select OwnId from inserted)
insert into Property (OwnId,Adress,SaleType,HouseType,statuss,rooms,price) 
values
(@ownId,default,default,default,default,default,0)  
end



----Picture Trigger


go
Create Trigger createPicture
on Property
after insert
as
Begin
Declare @propId int
set @propId=(Select PropId from inserted)
insert into Pictures values(@propId,null)
end




----AUDIT TRIGGER


go
Create Trigger changeState
on Audits
after insert
as
Begin
Declare @propId int
Declare @ownID int
Declare @ownID2 int

set @ownID2=(select Owner_ID from inserted)
set @propId=(select Property_Id from inserted)
set @ownID=(select OwnId from Property where PropId=@propId)

if(@ownID<>@ownID2)
begin
Rollback
raiserror( 'OwnerID must be oriented with same property ',16,1)
end
else
update Property set statuss='S' where PropId=@propId
end


go
Create trigger checkEmpID
on Employee
after update
as
begin
Declare @newID int
Declare @oldID int

set @newID=(select EmpID from inserted)

set @oldID=(select EmpID from deleted)

if(@newID<>@oldID)
begin
Rollback
raiserror( 'Employee ID can not be changed',16,1)
end  

end

-----Employee Trigger

go

Create trigger DeleteEmployee
on Employee
after Delete
as
Exec ResetID


 


Disable Trigger DeleteEmployee on Employee



select dbo.sendEmployeeAudit(115) as Sold_Property_Amount 


 




