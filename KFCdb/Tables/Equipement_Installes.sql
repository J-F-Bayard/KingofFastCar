CREATE TABLE [dbo].[Equipement_Installes]
(
	[idEquipInst] INT NOT NULL CONSTRAINT PK_Equipement_Installes PRIMARY KEY IDENTITY, 
    [idVoiture] INT NOT NULL, 
    [idEquip] INT NOT NULL, 
    CONSTRAINT [FK_Equipement_Installes_To_Voiture] FOREIGN KEY ([idVoiture]) REFERENCES [Voiture]([idVoiture]),
    CONSTRAINT [FK_Equipement_Installes_To_Equipement] FOREIGN KEY ([idEquip]) REFERENCES [Equipement]([idEquip])
)
