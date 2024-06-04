CREATE TABLE CarOperation
(
    id int identity(1, 1),
    carPlate varchar(10) not null,
    operationId int not null,
    operationStatus bit not null,
    CONSTRAINT pk_car_operation PRIMARY KEY (id),
    CONSTRAINT fk_car_operation_carPlate FOREIGN KEY (carPlate) REFERENCES Car(plate),
    CONSTRAINT fk_car_operation_operationId FOREIGN KEY (operationId) REFERENCES Operation(id)
)

SELECT id, carPlate, operationId, operationStatus FROM CarOperation;