create database bank_geeks

use bank_geeks

create table Calculator(
id int identity(1,1)primary key not null,
first_value decimal(5,2) not null,
second_value decimal(5,2) not null,
operation char(1) not null
)

