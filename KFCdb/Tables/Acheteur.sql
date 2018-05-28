CREATE TABLE [dbo].[Acheteur]
(
  idAcheteur int NOT NULL  CONSTRAINT PK_Acheteur PRIMARY KEY identity,                          
  nom varchar(100) NOT NULL ,
  prenom varchar(100) NOT NULL,
  email varchar(100) NOT NULL CONSTRAINT UK_Acheteur_Email unique,
  telephone varchar(100) NOT NULL CONSTRAINT UK_Acheteur_Telephone unique,
  rue varchar(100) NOT NULL,
  numero varchar(100) NOT NULL,
  cp int NOT NULL,
  localite varchar(100) NOT NULL,
  pays varchar(100) NOT NULL,
  numCompte varchar(100) NOT NULL CONSTRAINT UK_Acheteur_NumCompte unique,
  actif bit NOT NULL DEFAULT 1
)
