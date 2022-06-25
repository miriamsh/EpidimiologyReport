CREATE TABLE Patient (
    Id varchar(9) PRIMARY KEY
);

CREATE TABLE Location (
    StartDate date NOT NULL,
	EndDate date NOT NULL,
    City varchar(255) NOT NULL,
	Address varchar(255) NOT NULL,
    PatientId varchar(9) NOT NULL

    FOREIGN KEY (PatientId) REFERENCES Patient(Id)
);