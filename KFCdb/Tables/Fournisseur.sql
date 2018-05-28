CREATE TABLE [dbo].[Fournisseur]
(
  idFournisseur int NOT NULL CONSTRAINT PK_Fournisseur PRIMARY KEY identity,
  [nom] NVARCHAR(100) NOT NULL CONSTRAINT UK_Fournisseur_nom UNIQUE,
  numCompte NVARCHAR(100) NOT NULL CONSTRAINT UK_Fournisseur_numCompte UNIQUE,
  tva NVARCHAR(100) NOT NULL CONSTRAINT UK_Fournisseur_tva UNIQUE,
  rue NVARCHAR(100) NOT NULL,
  numero NVARCHAR(100) NOT NULL,
  cp int NOT NULL,
  localite NVARCHAR(100) NOT NULL,
  pays NVARCHAR(100) NOT NULL,
  email NVARCHAR(100) NOT NULL CONSTRAINT UK_Fournisseur_email UNIQUE,
  telephone NVARCHAR(100) NOT NULL CONSTRAINT UK_Fournisseur_telephone UNIQUE, 
  actif bit NOT NULL DEFAULT 1
)
