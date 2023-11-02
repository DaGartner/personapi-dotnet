drop table persona_db.dbo.telefono;
drop table persona_db.dbo.estudios;
drop table persona_db.dbo.profesion;
drop table persona_db.dbo.persona;

use persona_db
-- -----------------------------------------------------
-- Table `arq_per_db`.`persona`
-- -----------------------------------------------------
CREATE TABLE persona (
  cc INT NOT NULL,
  nombre VARCHAR(45) NOT NULL,
  apellido VARCHAR(45) NOT NULL,
  genero VARCHAR(1) NOT NULL CHECK (genero IN('M', 'F')),
  edad INT NULL DEFAULT NULL,
  PRIMARY KEY (cc)
  );


-- -----------------------------------------------------
-- Table `arq_per_db`.`profesion`
-- -----------------------------------------------------
CREATE TABLE profesion (
  id INT NOT NULL,
  nom VARCHAR(90) NOT NULL,
  des TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id)
  );


-- -----------------------------------------------------
-- Table `arq_per_db`.`estudios`
-- -----------------------------------------------------
CREATE TABLE estudios (
  id_prof INT NOT NULL,
  cc_per INT NOT NULL,
  fecha DATE NULL DEFAULT NULL,
  univer VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (id_prof, cc_per),
    FOREIGN KEY (cc_per)
    REFERENCES persona (cc) on delete cascade on update cascade,
	FOREIGN KEY (id_prof)
    REFERENCES profesion (id) on delete cascade on update cascade
	);


-- -----------------------------------------------------
-- Table `arq_per_db`.`telefono`
-- -----------------------------------------------------
CREATE TABLE telefono (
  num VARCHAR(15) NOT NULL,
  oper VARCHAR(45) NOT NULL,
  duenio INT NOT NULL,
  PRIMARY KEY (num),
    FOREIGN KEY (duenio)
    REFERENCES persona (cc))
