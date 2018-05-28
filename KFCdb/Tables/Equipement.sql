CREATE TABLE [dbo].[Equipement]
(
  [idEquip] int NOT NULL  CONSTRAINT PK_Equipement PRIMARY KEY IDENTITY,
  [nom] NVARCHAR(100) NOT NULL CONSTRAINT UK_Equipement_Nom unique,
  [description] NVARCHAR(2100) NOT NULL
)
