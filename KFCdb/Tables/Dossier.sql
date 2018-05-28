CREATE TABLE [dbo].[Dossier]
(
  idDossier int NOT NULL CONSTRAINT PK_Dossier PRIMARY KEY identity,
  idVoiture int NOT NULL CONSTRAINT UK_Dossier_idVoiture UNIQUE,
  idVendeur int NOT NULL,
  idAcheteur int DEFAULT NULL,
  prixAchat INT NOT NULL,
  prixVente INT DEFAULT NULL NULL,
  actif bit NOT NULL DEFAULT 1, 
    [dateAchat] DATE NOT NULL, 
    [dateVente] DATE NULL, 
    [factureAchat] NVARCHAR(100) NOT NULL, 
    [factureVente] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_Dossier_To_Voiture] FOREIGN KEY (idVoiture) REFERENCES Voiture(idVoiture), 
    CONSTRAINT [FK_Dossier_To_Vendeur] FOREIGN KEY (idVendeur) REFERENCES Vendeur(idVendeur),
    CONSTRAINT [FK_Dossier_To_Acheteur] FOREIGN KEY (idAcheteur) REFERENCES Acheteur(idAcheteur)
)
