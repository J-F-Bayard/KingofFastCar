CREATE TABLE [dbo].[Frais]
(
  idFrais int NOT NULL CONSTRAINT PK_Frais PRIMARY KEY identity,
  [idDossier] INT NOT NULL,
  idFournisseur int NOT NULL,
  [intitule] NVARCHAR(100) NOT NULL,
  montant float NOT NULL,
  numFacture int NOT NULL CONSTRAINT UK_Frais_numFacture UNIQUE,
  datePrestation date NOT NULL, 
  actif bit NOT NULL DEFAULT 1,  
    CONSTRAINT [FK_Frais_To_Fournisseur] FOREIGN KEY (idFournisseur) REFERENCES Fournisseur(idFournisseur), 
    CONSTRAINT [FK_Frais_To_Dossier] FOREIGN KEY ([idDossier]) REFERENCES Dossier(idDossier)
)
