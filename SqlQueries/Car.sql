CREATE TABLE Car 
(
    plate varchar(10),
    carName varchar(50) not null,
    modelYear int not null,
    manufactureYear int not null,
    color varchar(20) not null,
    CONSTRAINT pk_car PRIMARY KEY (plate)
)

SELECT plate, carName, modelYear, manufactureYear, color FROM Car;