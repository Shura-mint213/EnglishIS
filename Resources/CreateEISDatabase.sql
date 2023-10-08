CREATE TABLE Types (
	Type_Id SMALLSERIAL,
	Name    CHARACTER VARYING(64) NOT NULL,
	CONSTRAINT Type_Id PRIMARY KEY (Type_Id)
);

CREATE TABLE Levels (
	Level_Id 	SMALLSERIAL,
	Type_Id     SMALLINT   NOT NULL,
	Name        CHARACTER VARYING(64)  NOT NULL,
	Description CHARACTER VARYING(128) NOT NULL,
	CONSTRAINT Level_Id PRIMARY KEY (Level_Id),
	FOREIGN KEY (Type_Id) REFERENCES Types (Type_Id)
);

CREATE TABLE Roles (
	Role_Id SMALLSERIAL,
	Name    CHARACTER VARYING(64) NOT NULL,
	CONSTRAINT Role_Id PRIMARY KEY (Role_Id)
);

CREATE TABLE Theories (
	Theory_Id SERIAL,
	Topic     CHARACTER VARYING(64) NOT NULL,
	Text      Text      NOT NULL,
	Level_Id  SMALLINT  NOT NULL,
	CONSTRAINT Theory_Id PRIMARY KEY (Theory_Id),  
	FOREIGN KEY (Level_Id) REFERENCES Levels (Level_Id)
);

CREATE TABLE Files (
	File_Id   BIGINT,
	Name      CHARACTER VARYING(64)  NOT NULL,
	Path      CHARACTER VARYING(128) NOT NULL,
	Extension CHARACTER VARYING(16)  NOT NULL,
	CONSTRAINT File_Id PRIMARY KEY (File_Id)
);

CREATE TABLE Words (
	Word_id      BIGINT,
	Word_Ru      CHARACTER VARYING(64) NOT NULL,
	Word_Eng     CHARACTER VARYING(64) NOT NULL,
	Voiceover_Id BIGINT    NOT NULL,
	Image_Id     BIGINT    NOT NULL,
	Level_Id  	 SMALLINT  NOT NULL,
	CONSTRAINT Word_id PRIMARY KEY (Word_id),
	FOREIGN KEY (Level_Id) REFERENCES Levels (Level_Id),
	FOREIGN KEY (Image_Id) REFERENCES Files (File_Id),
	FOREIGN KEY (Voiceover_Id) REFERENCES Files (File_Id)
);

CREATE TABLE Users
(
    User_Id    SERIAL,
    First_Name CHARACTER VARYING(64)  NOT NULL,
    Last_Name  CHARACTER VARYING(64)  NULL,
    Birthday   DATE  NULL,	
	Password   CHARACTER VARYING (30) NOT NULL,	
    Email      CHARACTER VARYING(30)  UNIQUE NULL,
    Phone      CHARACTER VARYING(30)  UNIQUE NOT NULL,
	Role_Id    SMALLINT   NOT NULL, 
	Level_Id   SMALLINT   NOT NULL,
	CHECK(Phone != ''),
	CONSTRAINT User_Id   PRIMARY KEY (User_Id),
	FOREIGN KEY (Role_Id) REFERENCES Roles (Role_Id),
	FOREIGN KEY (Level_Id) REFERENCES Levels (Level_Id)
);


CREATE TABLE Subscription (
	Subscription_Id BIGINT,
	User_Id         BIGINT,
	Date_Start      DATE,
	Date_End        DATE,
	Level_Id        SMALLINT,
	CONSTRAINT Subscription_Id PRIMARY KEY (Subscription_Id),
	FOREIGN KEY (User_Id) REFERENCES Users (User_Id)
);

INSERT INTO roles(name)
VALUES ('Пользователь') 
INSERT INTO roles(name)
VALUES ('Админ') 

INSERT INTO types(name)
VALUES ('Уровень английского языка') 

INSERT INTO levels(type_id, name, description)
VALUES (1,'A1', 'Начальный');
INSERT INTO levels(type_id, name, description)
VALUES (1,'A2', 'Ниже среднего');
INSERT INTO levels(type_id, name, description)
VALUES (1,'B1', 'Средний');
INSERT INTO levels(type_id, name, description)
VALUES (1,'B2', 'Выше среднего');
INSERT INTO levels(type_id, name, description)
VALUES (1,'C1', 'Продвинутый');
INSERT INTO levels(type_id, name, description)
VALUES (1,'C2', 'Профессиональный уровень владения');


