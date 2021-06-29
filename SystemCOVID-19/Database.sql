CREATE DATABASE SystemCOVID_19DB;
USE systemcovid_19db;

CREATE TABLE CITIZEN(
	DUI INT PRIMARY KEY NOT NULL,
    name varchar(40) NOT NULL,
    mail varchar(25) NOT NULL,
    city varchar(25) NOT NULL,
    departament char(15) NOT NULL,
    phone int NOT NULL,
    age int NOT NULL,
    associate_number int,
    GOB_institution_id int,
    Appointment_id int
    );
CREATE TABLE GOB_institution(
	code int PRIMARY KEY NOT NULL auto_increment,
    institution varchar(50) NOT NULL
	);    
CREATE TABLE citizenxsickness(
	code INT PRIMARY KEY NOT NULL auto_increment,
	citizen_dui int,
    sickness_code int
    );
CREATE TABLE citizenxsecondary_effect(
	code INT PRIMARY KEY NOT NULL auto_increment,
	citizen_dui int,
    secondaryeffect_code int
    );
CREATE TABLE sickness(
	code int PRIMARY KEY NOT NULL auto_increment,
    sickness varchar(50) NOT NULL
	);
CREATE TABLE secondary_effect(
	code int PRIMARY KEY NOT NULL auto_increment,
    secondary_effect varchar(50) NOT NULL
	);
CREATE TABLE cabin(
	code int PRIMARY KEY NOT NULL auto_increment,
    phone int NOT NULL,
    caretaker varchar(35) NOT NULL,
    city varchar(25) NOT NULL,
    departament char(15) NOT NULL
);
CREATE TABLE employee(
	code int PRIMARY KEY NOT NULL auto_increment,
    mail varchar(25) NOT NULL,
    city varchar(25) NOT NULL,
    departament char(15) NOT NULL,
    occupation varchar(30) NOT NULL,
    manager_code int NOT NULL,
    security_answer varchar(75) NOT NULL,
    code_security_question int NOT NULL
);

CREATE TABLE manager(
	code int PRIMARY KEY NOT NULL auto_increment,
    user varchar(30) NOT NULL,
    password varchar(40) NOT NULL,
    code_cabin int NOT NULL
);

CREATE TABLE access_log(
	code int PRIMARY KEY NOT NULL auto_increment,
    date date NOT NULL,
    hour time NOT NULL,
    employee_code int NOT NULL
);

CREATE TABLE appointment(
	code int PRIMARY KEY NOT NULL auto_increment,
    date date NOT NULL,
    hour time NOT NULL,
    street varchar(30) NOT NULL,
    city varchar(25) NOT NULL,
    departament char(15) NOT NULL,
    dose char(10) NOT NULL,
    employee_code int NOT NULL
);

CREATE TABLE security_question(
	code int PRIMARY KEY NOT NULL auto_increment,
    security_question VARCHAR(90) NOT NULL
);

ALTER TABLE citizenxsecondary_effect 
ADD CONSTRAINT FK_citizenxseccondary_effect_dui 
FOREIGN KEY (citizen_dui) REFERENCES citizen (dui);
ALTER TABLE citizenxsecondary_effect 
ADD CONSTRAINT FK_citizenxseccondary_effect_code 
FOREIGN KEY (secondaryeffect_code) REFERENCES secondary_effect (code);

ALTER TABLE citizenxsickness 
ADD CONSTRAINT FK_citizenxsickeness_dui
FOREIGN KEY (citizen_dui) REFERENCES citizen (dui);
ALTER TABLE citizenxsickness
ADD CONSTRAINT FK_citizenxsickeness_code
FOREIGN KEY (sickness_code) REFERENCES sickness (code);

ALTER TABLE citizen
ADD CONSTRAINT FK_citizen_gob
FOREIGN KEY (gob_institution_id) REFERENCES gob_institution (code);
ALTER TABLE citizen
ADD CONSTRAINT FK_citizen_appointment
FOREIGN KEY (Appointment_id) REFERENCES appointment (code);

ALTER TABLE manager
ADD CONSTRAINT FK_manager_cabin
FOREIGN KEY (code_cabin) REFERENCES cabin (code);

ALTER TABLE employee
ADD CONSTRAINT FK_employee_manager
FOREIGN KEY (manager_code) REFERENCES manager (code);
ALTER TABLE employee
ADD CONSTRAINT FK_employee_securityquestion
FOREIGN KEY (code_security_question) REFERENCES security_question(code);

ALTER TABLE access_log
ADD CONSTRAINT FK_accesslog_employee
FOREIGN KEY (employee_code) REFERENCES employee(code);

ALTER TABLE appointment
ADD CONSTRAINT FK_appointment_employee
FOREIGN KEY (employee_code) REFERENCES employee(code);


ALTER TABLE cabin
	ADD COLUMN mail VARCHAR(75) NOT NULL AFTER caretaker,
	MODIFY caretaker VARCHAR(75) NOT NULL;
    
ALTER TABLE citizen
	MODIFY name varchar(75) NOT NULL,
    MODIFY mail varchar(75) NOT NULL;
    
ALTER TABLE gob_institution
	MODIFY institution varchar(75) NOT NULL;
    
ALTER TABLE employee
	MODIFY mail varchar(75) NOT NULL,
    MODIFY occupation varchar(75) NOT NULL,
    ADD COLUMN name varchar(75) NOT NULL AFTER code;

ALTER TABLE manager
	MODIFY user varchar(75) NOT NULL,
    MODIFY password varchar(75) NOT NULL;

ALTER TABLE appointment
	DROP COLUMN street;

	



