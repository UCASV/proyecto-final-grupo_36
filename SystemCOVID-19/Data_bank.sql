USE systemcovid_19db;

INSERT INTO cabin (phone, caretaker, mail, city, departament)
VALUES (63102398, "Henry","VacunasES@MDS.gob.sv", "San Salvador", "El Salvador");

INSERT INTO manager (user, password, code_cabin)
VALUES ("HenryChikito", "12345", 1);

INSERT INTO security_question(security_question)
VALUES ("¿Cual es el nombre de su primera mascota?");
INSERT INTO security_question(security_question)
VALUES ("¿Cual es el nombre de su escuela?");
INSERT INTO security_question(security_question)
VALUES ("¿En que hospital naciste?");
INSERT INTO security_question(security_question)
VALUES ("¿Como se llama tu mejor amigo/a?");
INSERT INTO security_question(security_question)
VALUES ("¿Cual es tu comida favorita?");
INSERT INTO security_question(security_question)
VALUES ("¿A que pais te gustaria viajar?");

INSERT INTO gob_institution(institution)
VALUES ("Ministerio de defensa");
INSERT INTO gob_institution(institution)
VALUES ("Ministerio de salud");
INSERT INTO gob_institution(institution)
VALUES ("Ministerio de agricultura y ganaderia");
INSERT INTO gob_institution(institution)
VALUES ("Ministerio de educación");
INSERT INTO gob_institution(institution)
VALUES ("Ministerio de gobernación");
INSERT INTO gob_institution(institution)
VALUES ("Policía Nacional Civil");
INSERT INTO gob_institution(institution)
VALUES ("Alcaldías");
INSERT INTO gob_institution(institution)
VALUES ("Seguro social");
INSERT INTO gob_institution(institution)
VALUES ("Periodistas");
INSERT INTO gob_institution(institution)
VALUES ("Cruz roja");

INSERT INTO secondary_effect(secondary_effect)
VALUES ("Dolor de cabeza");
INSERT INTO secondary_effect(secondary_effect)
VALUES ("Diarrea");
INSERT INTO secondary_effect(secondary_effect)
VALUES ("Dolor");
INSERT INTO secondary_effect(secondary_effect)
VALUES ("Temperatura");
INSERT INTO secondary_effect(secondary_effect)
VALUES ("Nausas");
INSERT INTO secondary_effect(secondary_effect)
VALUES ("Rash localizados");
INSERT INTO secondary_effect(secondary_effect)
VALUES ("Malestar General");

INSERT INTO sickness(sickness)
VALUES ("Enfermedades cardiovasculares");
INSERT INTO sickness(sickness)
VALUES ("Diabetes");
INSERT INTO sickness(sickness)
VALUES ("Obesidad grado III");
INSERT INTO sickness(sickness)
VALUES ("Sindrome de Down");
INSERT INTO sickness(sickness)
VALUES ("Insuficiencia renal");
INSERT INTO sickness(sickness)
VALUES ("Esclerosis multiple");
INSERT INTO sickness(sickness)
VALUES ("Neoplasia maligna");
INSERT INTO sickness(sickness)
VALUES ("Esquizofrenia");
INSERT INTO sickness(sickness)
VALUES ("Transplante");