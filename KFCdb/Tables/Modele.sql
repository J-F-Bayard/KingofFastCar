CREATE TABLE [dbo].[Modele]
(
  [idModele] int NOT NULL CONSTRAINT PK_Modele PRIMARY KEY IDENTITY,
  [idMarque] int NOT NULL,
  [nom] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_Modele_To_Marque] FOREIGN KEY ([idMarque]) REFERENCES [Marque]([idMarque])
)
