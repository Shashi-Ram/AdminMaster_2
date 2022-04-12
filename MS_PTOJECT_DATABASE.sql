create database MS_PROJECT
use MS_PROJECT

create table Tbl_Users
(Id int primary key identity,
F_Name varchar(50),
L_Name varchar(50),
Email varchar(50) unique,
Gender varchar(10),
Password varchar(50),
Profile_Image varchar(max),
isactive bit,
isverified bit,  
Create_On datetime,
Update_On datetime
)

Create table Verified_Account
(Id int primary key identity,
OTP varchar(10),
UserId varchar(20) foreign key references Tbl_Users(Id))
alter table verified_account alter column userid varchar(20)
alter table verified_account add SendTime datetime
alter table verified_account drop constraint FK__Verified___UserI__276EDEB3
select * from Verified_Account
select * from Tbl_Users
select * from Employee_Image

truncate table tbl_users
truncate table verified_account

create table Employee_Image(id int primary key identity,
Uploader_Name varchar(50),
Title varchar(max),
Description varchar(max),
Image_Path varchar(max))








