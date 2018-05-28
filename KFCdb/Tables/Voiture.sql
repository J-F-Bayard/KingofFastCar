CREATE TABLE [dbo].[Voiture]
(
  [idVoiture] int NOT NULL CONSTRAINT PK_Voiture PRIMARY KEY IDENTITY,
  [numChassis] NVARCHAR(100) NOT NULL CONSTRAINT UK_Voiture_NumChassis unique,
  [idModele] INT NOT NULL,
  [version] NVARCHAR(100) DEFAULT NULL,
  [annee] date NOT NULL,
  [typeChasssis] NVARCHAR(100) NOT NULL,
  [etat] NVARCHAR(100) NOT NULL,
  [kilometrage] int NOT NULL,
  [puissance] int NOT NULL,
  [cylindree] int NOT NULL,
  [localisation] NVARCHAR(100) NOT NULL,
  [carburant] NVARCHAR(100) NOT NULL,
  [transmition] NVARCHAR(100) NOT NULL,
  [couleur] NVARCHAR(100) NOT NULL,
  [peintureMetal] bit NOT NULL,
  [carnetEntretient] bit NOT NULL,
  [volantGauche] bit NOT NULL DEFAULT 1, 
  [actif] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Voiture_To_Modele] FOREIGN KEY (idModele) REFERENCES Modele(idModele)
)
