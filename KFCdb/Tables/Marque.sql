﻿CREATE TABLE [dbo].[Marque]
(
  [idMarque] int NOT NULL CONSTRAINT PK_Marque PRIMARY KEY IDENTITY,
  [nom] NVARCHAR(100) NOT NULL CONSTRAINT UK_Marque_Nom unique
)
