CREATE TABLE Operation 
(
    id int identity(1, 1),
    operationDescription varchar(50),
    CONSTRAINT PK_Operation PRIMARY KEY (id)
)

SELECT id, operationDescription FROM Operation;