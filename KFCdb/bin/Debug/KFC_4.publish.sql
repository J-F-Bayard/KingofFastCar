﻿/*
Script de déploiement pour KFC

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "KFC"
:setvar DefaultFilePrefix "KFC"
:setvar DefaultDataPath "C:\Users\jef\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\jef\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Modification de [dbo].[AddAcheteur]...';


GO
ALTER PROCEDURE [dbo].[AddAcheteur]
	@LastName nvarchar(100) ,
	@FirstName nvarchar(100) ,
	@Email nvarchar(100) ,
	@Phone nvarchar(100),
	@Street nvarchar(100),
	@Number nvarchar(100),
	@Zip int,
	@Locality nvarchar(100),
	@Country nvarchar(100),
	@Account  nvarchar(100)
AS
	INSERT INTO Acheteur (nom,prenom,email,telephone,rue,numero,cp,localite,pays,numCompte) 
	VALUES 
	(@LastName,@FirstName,@Email,@Phone,@Street,@Number,@Zip,@Locality,@Country,@Account);

	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddDossier]...';


GO
ALTER PROCEDURE [dbo].[AddDossier]
	@IdVoiture int,
	@IdVendeur int,
	@IdAcheteur int,	
	@PrixAchat int,
	@PrixVente int
AS
	INSERT INTO Dossier(idVoiture,idVendeur,idAcheteur,prixAchat,prixVente) 
	VALUES(@IdVoiture,@IdVendeur,@IdAcheteur,@PrixAchat,@PrixVente);
	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddEquipement]...';


GO
/*
La base de données doit avoir un groupe de fichiers MEMORY_OPTIMIZED_DATA
avant de créer l'objet mémoire optimisé.
*/

ALTER PROCEDURE [dbo].[AddEquipement]
	@Name nvarchar(100),
	@Description nvarchar(100)

AS 
INSERT INTO Equipement(nom,description) 
	VALUES(@Name,@Description);
	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddEquipementInstalles]...';


GO
ALTER PROCEDURE [dbo].[AddEquipementInstalles]
	@IdVoiture int,
	@IdEquipment int

AS 
INSERT INTO Equipement_Installes(idVoiture,idEquip) 
	VALUES(@IdVoiture,@IdEquipment);
	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddFournisseur]...';


GO
ALTER PROCEDURE [dbo].[AddFournisseur]
	@Name nvarchar(100) ,
	@Account nvarchar(100),
	@Tva int,
	@Street nvarchar(100),
	@Number nvarchar(100),
	@Zip int,
	@Locality nvarchar(100),
	@Country nvarchar(100),
	@Email nvarchar(100) ,
	@Phone nvarchar(100)
AS
	
	INSERT INTO Fournisseur(nom,numCompte,tva,rue,numero,cp,localite,pays,email,telephone) 
	VALUES (@Name,@Account,@Tva,@Street,@Number,@Zip,@Locality,@Country,@Email,@Phone);
	
	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddFrais]...';


GO
ALTER PROCEDURE [dbo].[AddFrais]
	@IdDossier int,	
	@IdProvider int,
	@Entitled nvarchar(100),
	@Amount float,
	@BillNumber int,
	@DeliveryDate date
AS
	INSERT INTO Frais(idDossier,idFournisseur,intitule,montant,numFacture,datePrestation) 
	VALUES(@IdDossier,@IdProvider,@Entitled,@Amount,@BillNumber,@DeliveryDate);
	
	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddMarque]...';


GO
ALTER PROCEDURE [dbo].[AddMarque]
	@Name nvarchar(100)
AS
	INSERT INTO Marque(nom)VALUES(@Name);
	
	SELECT SCOPE_IDENTITY();
GO
PRINT N'Modification de [dbo].[AddModele]...';


GO
ALTER PROCEDURE [dbo].[AddModele]
	@idBrand int,
	@Name nvarchar(100)
AS
	
	INSERT INTO Modele(idMarque,nom) 
	VALUES(@idBrand,@Name);
	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddUser]...';


GO
ALTER PROCEDURE [dbo].[AddUser]
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Email nvarchar(384),
	@Passwd varchar(512) 
AS
	set @Email=LTRIM(RTRIM(@Email));
	declare @hashPasswd varbinary(512);
    exec GetHash @Email=@Email, @Passwd=@Passwd, @hashPasswd=@hashPasswd output;

    insert into [User] (nom, prenom, email, mdp) values(@LastName, @FirstName, @Email, @hashPasswd);
	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddVendeur]...';


GO
ALTER PROCEDURE [dbo].[AddVendeur]
	@Name nvarchar(100) ,
	@Tva int,
	@Email nvarchar(100) ,
	@Phone nvarchar(100),
	@Street nvarchar(100),
	@Number nvarchar(100),
	@Zip int,
	@Locality nvarchar(100),
	@Country nvarchar(100),
	@Account  nvarchar(100)
AS
	INSERT INTO Vendeur (nom,tva,email,telephone,rue,numero,cp,localite,pays,numCompte) 
	VALUES 
	(@Name,@Tva,@Email,@Phone,@Street,@Number,@Zip,@Locality,@Country,@Account);
	
	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[AddVoiture]...';


GO
ALTER PROCEDURE [dbo].[AddVoiture]
	@ChassisNumber nvarchar(100),
	@IdModel int,
	@Version nvarchar(100),
	@Year date,
	@ChassisType nvarchar(100),
	@Condition nvarchar(100),
	@Mileage int,
	@Power int,
	@Cylinder int,
	@Location nvarchar(100),
	@Fuel nvarchar(100),
	@Transmition nvarchar(100),
	@Color nvarchar(100),
	@MetalPainting bit,
	@ServiceBook bit,
	@LeftHand bit
AS
	INSERT INTO Voiture(numChassis,idModele,[version],annee,typeChasssis,etat,kilometrage,puissance,
						 cylindree,localisation,carburant,transmition,couleur,peintureMetal,
						 carnetEntretient,volantGauche)
	VALUES(@ChassisNumber,@IdModel,@Version,@Year,@ChassisType,@Condition,@Mileage, 
			@Power,@Cylinder,@Location,@Fuel,@Transmition, 
			@Color,@MetalPainting,@ServiceBook,@LeftHand);

	SELECT @@IDENTITY;
GO
PRINT N'Modification de [dbo].[GetEquipementInstalles]...';


GO
ALTER PROCEDURE [dbo].[GetEquipementInstalles]	
AS
	SELECT idEquip as IdEquipment,idVoiture as IdCar , idEquipInst as IdEquipmentInst
	from V_Equipement_Installes
RETURN
GO
PRINT N'Modification de [dbo].[GetEquipementInstallesById]...';


GO
ALTER PROCEDURE [dbo].[GetEquipementInstallesById]	
	@IdInstalledEquipment int
AS
	SELECT idEquip as IdEquipment,idVoiture as IdCar , idEquipInst as IdEquipmentInst
	from V_Equipement_Installes where idEquipInst=@IdInstalledEquipment; 
RETURN
GO
PRINT N'Modification de [dbo].[GetUser]...';


GO
ALTER PROCEDURE [dbo].[GetUser]
AS
	select idUser as IdUser,nom as LastName,prenom as FirstName,email as Email,mdp as [Password] from [V_User];
RETURN
GO
/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

	USE KFC
GO



	EXEC AddUser 'Admin','Istrateur','admin@kf.c','Test1234=';
	EXEC AddUser 'Modo','Érateur','modo@kf.c','Test1234=';
	EXEC AddUser 'User','Lambda','user@kf.c','Test1234=';
	EXEC AddUser 'Ban','Nis','ban@kf.c','Test1234=';
GO
	EXEC AddMarque '9ff';
	INSERT INTO Marque (nom) VALUES 
	('Abarth'),('AC'),('ACM'),('Acura'),('Aixam'),('Alfa Romeo'),('Alpina'),('Amphicar'),('Ariel Motor'),('Artega'),('Aspid'),('Aston Martin'),('Austin'),('Autobianchi'),('Auverland'),('Baic'),('Bedford'),('Bellier'),('Bentley'),('Bolloré'),('Borgward'),('Brilliance'),('Bugatti'),('Buick'),('BYD'),('Cadillac'),('Caravans-Wohnm'),('Casalini'),('Caterham'),('Changhe'),('Chatenet'),('Chery'),('Chevrolet'),('Chrysler'),('Citroen'),('CityEL'),('CMC'),('Corvette'),('Courb'),('Dacia'),('Daewoo'),('DAF'),('Daihatsu'),('Daimler'),('Dangel'),('De la Chapelle'),('De Tomaso'),('Derways'),('DFSK'),('Dodge'),('Donkervoort'),('DR Motor'),('DS Automobiles'),('Dutton'),('Estrima'),('Ferrari'),('Fiat'),('FISKER'),('Gac Gonow'),('Galloper'),('GAZ'),('Geely'),('GEM'),('GEMBALLA'),('Giotti Victoria'),('GMC'),('Great Wall'),('Grecav'),('Haima'),('Hamann'),('Honda'),('HUMMER'),('Hurtan'),('Hyundai'),('Infiniti'),('Innocenti'),('Iso Rivolta'),('Isuzu'),('Iveco'),('IZH'),('Jaguar'),('Jeep'),('Karabag'),('Kia'),('Koenigsegg'),('KTM'),('Lada'),('Lamborghini'),('Lancia'),('Land Rover'),('LDV'),('Lexus'),('Lifan'),('Ligier'),('Lincoln'),('Lotus'),('Mahindra'),('MAN'),('Mansory'),('Martin Motors'),('Maserati'),('Maybach'),('Mazda'),('McLaren'),('Melex'),('MG'),('Microcar'),('Minauto'),('MINI'),('Mitsubishi'),('Mitsuoka'),('Morgan'),('Moskvich'),('MP Lafer'),('MPM Motors'),('Nissan'),('Oldsmobile'),('Oldtimer'),('Pagani'),('Panther Westwinds'),('PGO'),('Piaggio'),('Plymouth'),('Pontiac'),('Porsche'),('Proton'),('Puch'),('Qoros'),('Qvale'),('Reliant'),('Renault'),('Rolls-Royce'),('Rover'),('Ruf'),('Saab'),('Santana'),('Savel'),('SDG'),('SEAT'),('Skoda'),('smart'),('SpeedArt'),('Spyker'),('SsangYong'),('Subaru'),('Suzuki'),('TagAZ'),('Talbot'),('Tasso'),('Tata'),('Tazzari EV'),('TECHART'),('Tesla'),('Town Life'),('Toyota'),('Trabant'),('Trailer-Anhänger'),('Triumph'),('Trucks-Lkw'),('TVR'),('UAZ'),('VAZ'),('VEM'),('Volvo'),('Vortex'),('Wallys'),('Wartburg'),('Westfield'),('Wiesmann'),('Zastava'),('ZAZ'),('Autres');
GO
	EXEC AddModele 001,'F70 Etronic';
	INSERT INTO Modele (idMarque, nom) VALUES 
	(001,'F97 A-Max'),(001,'GT9'),(001,'GTronic'),(001,'GTurbo'),(001,'Speed9'),(001,'zz== Autres ==zz'),(002,'124 Spider'),(002,'500'),(002,'500C'),(002,'595 Competizione'),(002,'595 Turismo'),(002,'595'),(002,'595C'),(002,'695'),(002,'695C'),(002,'Grande Punto'),(002,'Punto EVO'),(002,'Punto Supersport'),(002,'zz== Autres ==zz'),(003,'Ace'),(003,'Cobra'),(003,'zz== Autres ==zz'),(004,'4 WD'),(004,'Biagini Passo'),(004,'zz== Autres ==zz'),(005,'ILX'),(005,'MDX'),(005,'NSX'),(005,'RDX'),(005,'RL'),(005,'RLX'),(005,'RSX'),(005,'TL'),(005,'TLX'),(005,'TSX'),(005,'ZDX'),(005,'zz== Autres ==zz'),(006,'400'),(006,'500'),(006,'A.'),(006,'City'),(006,'Coupe'),(006,'Crossline'),(006,'Crossover'),(006,'GTI'),(006,'GTO'),(006,'Mac'),(006,'Mega'),(006,'Roadline'),(006,'Scouty R'),(006,'zz== Autres ==zz'),(007,'145'),(007,'146'),(007,'147'),(007,'155'),(007,'156'),(007,'159'),(007,'164'),(007,'166'),(007,'1750'),(007,'2000'),(007,'33'),(007,'4C'),(007,'75'),(007,'8C'),(007,'90'),(007,'Alfa 6'),(007,'Alfasud'),(007,'Alfetta'),(007,'Brera'),(007,'Crosswagon'),(007,'Giulia'),(007,'Giulietta'),(007,'GT'),(007,'GTV'),(007,'MiTo'),(007,'Quadrifoglio'),(007,'RZ'),(007,'Spider'),(007,'Sportwagon'),(007,'Sprint'),(007,'Stelvio'),(007,'SZ'),(007,'zz== Autres ==zz'),(008,'B10'),(008,'B11'),(008,'B12'),(008,'B3'),(008,'B4'),(008,'B5'),(008,'B6'),(008,'B7'),(008,'B8'),(008,'B9'),(008,'C1'),(008,'C2'),(008,'D10'),(008,'D3'),(008,'D4'),(008,'D5'),(008,'Roadster Limited Edition'),(008,'Roadster S'),(008,'Roadster V8'),(008,'XD3'),(008,'zz== Autres ==zz'),(009,'770'),(009,'zz== Autres ==zz'),(010,'Atom'),(010,'Nomad'),(010,'zz== Autres ==zz'),(011,'GT'),(011,'Scalo'),(011,'zz== Autres ==zz'),(012,'GT-21'),(012,'SS'),(012,'zz== Autres ==zz'),(013,'AR1'),(013,'Cygnet'),(013,'DB'),(013,'DB11'),(013,'DB7'),(013,'DB9'),(013,'DBS'),(013,'Lagonda'),(013,'Rapide'),(013,'V12 Vanquish'),(013,'V8'),(013,'Valkyrie'),(013,'Vantage'),(013,'Virage'),(013,'Volante'),(013,'zz== Autres ==zz'),(014,'Estate'),(014,'Healey'),(014,'Maestro'),(014,'Metro'),(014,'Mini Moke'),(014,'Mini'),(014,'MK'),(014,'Montego'),(014,'zz== Autres ==zz'),(015,'A 1000'),(015,'A 112'),(015,'Y 10'),(015,'zz== Autres ==zz'),(016,'A3'),(016,'A4'),(016,'zz== Autres ==zz'),(017,'B40'),(017,'BJ20'),(017,'D20'),(017,'Senova X25'),(017,'Senova X35'),(017,'Senova X55'),(017,'Senova X65'),(017,'zz== Autres ==zz'),(018,'Astramax'),(018,'Astravan'),(018,'Beagle'),(018,'Blitz'),(018,'Brava'),(018,'CA'),(018,'CF2'),(018,'Chevanne'),(018,'Dormobile'),(018,'HA'),(018,'KB'),(018,'Midi'),(018,'MW'),(018,'Rascal'),(018,'TJ'),(018,'zz== Autres ==zz'),(019,'Asso'),(019,'B8'),(019,'Divane'),(019,'Docker City'),(019,'Jade'),(019,'Opale'),(019,'Sturdy'),(019,'VX'),(019,'zz== Autres ==zz'),(020,'Arnage'),(020,'Azure'),(020,'Bentayga'),(020,'Brooklands'),(020,'Continental'),(020,'Eight'),(020,'Flying Spur'),(020,'Mulsanne'),(020,'S1'),(020,'S2'),(020,'S3'),(020,'Turbo R'),(020,'Turbo RT'),(020,'Turbo S'),(020,'zz== Autres ==zz'),(021,'Bluecar'),(021,'Bluesummer'),(021,'Blueutility'),(021,'zz== Autres ==zz'),(022,'Arabella'),(022,'BX 7'),(022,'Hansa 1100'),(022,'Hansa 1500'),(022,'Hansa 1700'),(022,'Hansa 1800'),(022,'Hansa 2000'),(022,'Hansa 2300'),(022,'Hansa 2400'),(022,'Hansa 3500'),(022,'Hansa 400/500'),(022,'Isabella'),(022,'P100'),(022,'zz== Autres ==zz'),(023,'BC3'),(023,'BS2'),(023,'BS4'),(023,'BS6'),(023,'Granse'),(023,'Jinbei'),(023,'Zhonghua'),(023,'Zunchi'),(023,'zz== Autres ==zz'),(024,'Chiron'),(024,'EB 110'),(024,'EB 112'),(024,'Veyron'),(024,'zz== Autres ==zz'),(025,'Cascada'),(025,'Century'),(025,'Electra'),(025,'Enclave'),(025,'Encore'),(025,'Envision'),(025,'La Crosse'),(025,'Le Sabre'),(025,'Park Avenue'),(025,'Regal'),(025,'Riviera'),(025,'Roadmaster'),(025,'Skylark'),(025,'Special'),(025,'Verano'),(025,'zz== Autres ==zz'),(026,'E6'),(026,'F1'),(026,'F3'),(026,'F3R'),(026,'F6'),(026,'F8'),(026,'zz== Autres ==zz'),(027,'Allante'),(027,'ATS'),(027,'BLS'),(027,'Brougham'),(027,'CT6'),(027,'CTS'),(027,'Deville'),(027,'DTS'),(027,'Eldorado'),(027,'Escalade'),(027,'Fleetwood'),(027,'LaSalle'),(027,'Series 62'),(027,'Series 6200'),(027,'Seville'),(027,'SRX'),(027,'STS'),(027,'XLR'),(027,'XT5'),(027,'zz== Autres ==zz'),(028,'Adria'),(028,'Ahorn'),(028,'Airstream'),(028,'Alpha'),(028,'Arca'),(028,'Autoroller'),(028,'Autostar'),(028,'Bavaria'),(028,'Bawemo'),(028,'Beisl'),(028,'Benimar'),(028,'Bimobil'),(028,'Biod'),(028,'Burow'),(028,'Burow-Mobil'),(028,'Bürstner'),(028,'Ca-Mo-Car'),(028,'Carado'),(028,'Caravelair'),(028,'Caro'),(028,'Carthago'),(028,'Challenger'),(028,'Chausson'),(028,'Chrysler'),(028,'Ci International'),(028,'Coachmen'),(028,'Concorde'),(028,'Cristall'),(028,'Cs Reisemobile'),(028,'Damon'),(028,'Dehler'),(028,'Delta'),(028,'Dethleffs'),(028,'Dream'),(028,'Due Erre'),(028,'Eifelland'),(028,'Elnagh'),(028,'Eriba'),(028,'Euramobil'),(028,'Euro Liner'),(028,'EVM'),(028,'Fendt'),(028,'Ffb / Tabbert'),(028,'Fiat'),(028,'Fleetwood'),(028,'Florence'),(028,'Ford / Reimo'),(028,'Ford'),(028,'Frankia'),(028,'General Motors'),(028,'Gigant'),(028,'Giottiline'),(028,'Globecar'),(028,'Granduca'),(028,'Hehn'),(028,'Heku'),(028,'Hobby'),(028,'Holiday Rambler'),(028,'Home-Car'),(028,'Hymer'),(028,'ICF'),(028,'Iveco'),(028,'Karmann'),(028,'Kentucky'),(028,'Kip'),(028,'Knaus'),(028,'La Strada'),(028,'Laika'),(028,'Linne-Liner'),(028,'LMC'),(028,'M+M Mobile'),(028,'Ma-Bu'),(028,'Maesss'),(028,'Man'),(028,'Mazda'),(028,'McLouis'),(028,'Mercedes-Benz'),(028,'Miller'),(028,'Mirage'),(028,'Mitsubishi'),(028,'Mizar'),(028,'Mobilvetta'),(028,'Monaco'),(028,'Moncayo'),(028,'Morelo'),(028,'Neotec'),(028,'Niesmann+Bischoff'),(028,'Niewiadow'),(028,'Nordstar'),(028,'Ormocar'),(028,'Peugeot'),(028,'Phoenix'),(028,'Pilote'),(028,'Pössl'),(028,'ProCab'),(028,'Rapido'),(028,'Reimo'),(028,'Reisemobile Beier'),(028,'Renault'),(028,'Rimor'),(028,'Riva'),(028,'Riviera'),(028,'RMB'),(028,'Roadtrek'),(028,'Robel-Mobil'),(028,'Rockwood'),(028,'Selbstbau'),(028,'Sterckeman'),(028,'Swift'),(028,'Tabbert'),(028,'TEC'),(028,'Tischer'),(028,'Trigano'),(028,'Triple E'),(028,'Ultra'),(028,'Vario'),(028,'VW'),(028,'Weinsberg'),(028,'Weippert'),(028,'Westfalia'),(028,'Wilk'),(028,'Winnebago'),(028,'zz== Autres ==zz'),(029,'Kerry'),(029,'M10'),(029,'M110'),(029,'M12'),(029,'M14'),(029,'M20'),(029,'Other'),(029,'Pick Up12'),(029,'Sulky'),(029,'Sulkycar'),(029,'Sulkydea/Ydea'),(029,'zz== Autres ==zz'),(030,'21'),(030,'Classic 7'),(030,'Classic S7'),(030,'Cosworth CSR 200'),(030,'CSR 175'),(030,'CSR 260'),(030,'R 400'),(030,'R300 Superlight'),(030,'Roadsport Seven'),(030,'Seven 458'),(030,'SP/300.R'),(030,'Super 7'),(030,'Superlight'),(030,'zz== Autres ==zz'),(031,'CoolCar'),(031,'Freedom'),(031,'Ideal'),(031,'Mini Truck'),(031,'X5'),(031,'zz== Autres ==zz'),(032,'Barooder'),(032,'CH 26'),(032,'CH 28'),(032,'CH 30'),(032,'CH 32'),(032,'CH 40'),(032,'Media'),(032,'Pick-Up'),(032,'Speedino'),(032,'Sporteevo'),(032,'Stella'),(032,'zz== Autres ==zz'),(033,'A13'),(033,'A18'),(033,'A21'),(033,'A3'),(033,'Amulet'),(033,'B13'),(033,'B14'),(033,'CrossEastar'),(033,'Crossover'),(033,'Eastar'),(033,'FengYun'),(033,'Fora'),(033,'Karry'),(033,'Kimo'),(033,'M11'),(033,'M14'),(033,'Mikado'),(033,'MPV'),(033,'QQ6'),(033,'S18'),(033,'Sweet'),(033,'Tiggo'),(033,'Very'),(033,'WOW'),(033,'zz== Autres ==zz'),(034,'2500'),(034,'Alero'),(034,'Astro'),(034,'Avalanche'),(034,'Aveo'),(034,'Bel Air'),(034,'Beretta'),(034,'Blazer'),(034,'Bolt'),(034,'C1500'),(034,'Camaro'),(034,'Caprice'),(034,'Captiva'),(034,'Cavalier'),(034,'Celebrity'),(034,'Chevelle'),(034,'Chevy Van'),(034,'Citation'),(034,'Colorado'),(034,'Corsica'),(034,'Corvette'),(034,'Crew cab'),(034,'Cruze'),(034,'Dixie van'),(034,'El Camino'),(034,'Epica'),(034,'Equinox'),(034,'Evanda'),(034,'Express'),(034,'G'),(034,'HHR'),(034,'Impala'),(034,'K1500'),(034,'K30'),(034,'Kalos'),(034,'Lacetti'),(034,'Lanos'),(034,'Lumina'),(034,'Malibu'),(034,'Matiz'),(034,'Monte Carlo'),(034,'Niva'),(034,'Nubira'),(034,'Orlando'),(034,'Rezzo'),(034,'S-10'),(034,'Silverado'),(034,'Spark'),(034,'SSR'),(034,'Suburban'),(034,'Tacuma'),(034,'Tahoe'),(034,'Tracker'),(034,'Trailblazer'),(034,'Trans Sport'),(034,'Traverse'),(034,'Trax'),(034,'Uplander'),(034,'Viva'),(034,'Volt'),(034,'zz== Autres ==zz'),(035,'300 M'),(035,'300C'),(035,'Aspen'),(035,'Crossfire'),(035,'Daytona'),(035,'ES'),(035,'Grand Voyager'),(035,'GS'),(035,'GTS'),(035,'Imperial'),(035,'Le Baron'),(035,'Neon'),(035,'New Yorker'),(035,'Pacifica'),(035,'Prowler'),(035,'PT Cruiser'),(035,'Ram Van'),(035,'Saratoga'),(035,'Sebring'),(035,'Stratus'),(035,'Town & Country'),(035,'Valiant'),(035,'Viper'),(035,'Vision'),(035,'Voyager'),(035,'zz== Autres ==zz'),(036,'2CV'),(036,'Acadiane'),(036,'AX'),(036,'Axel'),(036,'Berlingo'),(036,'BX'),(036,'C1'),(036,'C15'),(036,'C2'),(036,'C25'),(036,'C3 Aircross'),(036,'C3 Picasso'),(036,'C3'),(036,'C35'),(036,'C4 Aircross'),(036,'C4 Cactus'),(036,'C4 Picasso'),(036,'C4'),(036,'C5'),(036,'C6'),(036,'C8'),(036,'C-Crosser'),(036,'C-Elysée'),(036,'CX'),(036,'C-Zero'),(036,'DS'),(036,'DS3'),(036,'DS4'),(036,'DS5'),(036,'Dyane'),(036,'E-Méhari'),(036,'Evasion'),(036,'Grand C4 Picasso'),(036,'GSA'),(036,'Jumper'),(036,'Jumpy'),(036,'LNA'),(036,'Méhari'),(036,'Nemo'),(036,'SAXO'),(036,'SM'),(036,'Spacetourer'),(036,'Visa'),(036,'Xantia'),(036,'XM'),(036,'Xsara Picasso'),(036,'Xsara'),(036,'ZX'),(036,'zz== Autres ==zz'),(037,'CityEl FactFour'),(037,'CityEl'),(037,'MiniEl'),(037,'zz== Autres ==zz'),(038,'Electric Mistry'),(038,'Gipsy 500'),(038,'zz== Autres ==zz'),(039,'C1'),(039,'C2'),(039,'C3'),(039,'C4'),(039,'C5'),(039,'C6 Convertible'),(039,'C6 Coupe'),(039,'C7'),(039,'CZ6'),(039,'Stingray'),(039,'Z06'),(039,'ZR1'),(039,'zz== Autres ==zz'),(040,'C-Zen'),(040,'zz== Autres ==zz'),(041,'1310'),(041,'Berlina'),(041,'Break'),(041,'Dokker'),(041,'Double Cab'),(041,'Drop Side'),(041,'Duster'),(041,'Lodgy'),(041,'Logan'),(041,'Nova'),(041,'Pick Up'),(041,'Sandero'),(041,'Solenza'),(041,'Stepway'),(041,'zz== Autres ==zz'),(042,'Aranos'),(042,'Espero'),(042,'Evanda'),(042,'Kalos'),(042,'Korando'),(042,'Lacetti'),(042,'Lanos'),(042,'Leganza'),(042,'Lublin'),(042,'Matiz'),(042,'Musso'),(042,'Nexia'),(042,'Nubira'),(042,'Rexton'),(042,'Rezzo'),(042,'Tacuma'),(042,'Truck Plus'),(042,'zz== Autres ==zz'),(043,'400'),(043,'zz== Autres ==zz'),(044,'Applause'),(044,'Charade'),(044,'Charmant'),(044,'Copen'),(044,'Cuore'),(044,'Domino'),(044,'Extol'),(044,'F Modelle'),(044,'Feroza'),(044,'Freeclimber'),(044,'Gran Move'),(044,'Hijet'),(044,'Materia'),(044,'Move'),(044,'Pionier'),(044,'Rocky'),(044,'Sirion'),(044,'Taft'),(044,'Terios'),(044,'Trevis'),(044,'Valera'),(044,'YRV'),(044,'zz== Autres ==zz'),(045,'Double Six'),(045,'Six'),(045,'Sovereign'),(045,'Super Eight'),(045,'Super V8'),(045,'zz== Autres ==zz'),(046,'504'),(046,'505'),(046,'Berlingo'),(046,'Boxer'),(046,'C25'),(046,'Ducato'),(046,'Expert'),(046,'J5'),(046,'Jumper'),(046,'Jumpy'),(046,'Partner'),(046,'Scudo'),(046,'zz== Autres ==zz'),(047,'Atalante 57S'),(047,'Grand-Prix'),(047,'Roadster'),(047,'Type 55 Roadster'),(047,'Type 55 Tourer'),(047,'zz== Autres ==zz'),(048,'Deauville'),(048,'Guarà'),(048,'Longchamp'),(048,'Mangusta'),(048,'Pantera'),(048,'Vallelunga'),(048,'zz== Autres ==zz'),(049,'Aurora'),(049,'Cowboy'),(049,'Land Crown'),(049,'Plutus'),(049,'Shuttle'),(049,'zz== Autres ==zz'),(050,'C32'),(050,'C35'),(050,'City Pickup'),(050,'K01'),(050,'K02'),(050,'V21'),(050,'V25'),(050,'zz== Autres ==zz'),(051,'Avenger'),(051,'Caliber'),(051,'Caravan'),(051,'Challenger'),(051,'Charger'),(051,'Coronet'),(051,'Dakota'),(051,'Dart'),(051,'Demon'),(051,'Durango'),(051,'Grand Caravan'),(051,'Intrepid'),(051,'Journey'),(051,'Magnum'),(051,'Neon'),(051,'Nitro'),(051,'RAM'),(051,'Stealth'),(051,'Stratus'),(051,'Van'),(051,'Viper'),(051,'zz== Autres ==zz'),(052,'D8'),(052,'S8'),(052,'zz== Autres ==zz'),(053,'City Cross'),(053,'DR EVO5'),(053,'DR Zero'),(053,'DR1'),(053,'DR2'),(053,'DR3'),(053,'DR4'),(053,'DR5'),(053,'DR6'),(053,'KATAY'),(053,'zz== Autres ==zz'),(054,'DS 3'),(054,'DS 4'),(054,'DS 5'),(054,'DS 7'),(054,'zz== Autres ==zz'),(055,'B Plus Series 2'),(055,'B Plus'),(055,'B Type'),(055,'Beneto'),(055,'Cantera'),(055,'Legerra'),(055,'Malaga B+'),(055,'Malaga'),(055,'Melos'),(055,'P1'),(055,'Phaeton Series 1'),(055,'Phaeton Series 2'),(055,'Phaeton Series 3'),(055,'Phaeton Series 4'),(055,'Rico Shuttle'),(055,'Rico'),(055,'Sierra Drop Head'),(055,'Sierra Series 1'),(055,'Sierra Series 2'),(055,'Sierra Series 3'),(055,'zz== Autres ==zz'),(056,'Birò'),(056,'zz== Autres ==zz');
	INSERT INTO Modele (idMarque, nom) VALUES 
	(057,'195'),(057,'206'),(057,'208'),(057,'246'),(057,'250'),(057,'275'),(057,'288'),(057,'308'),(057,'328'),(057,'330'),(057,'348'),(057,'360'),(057,'365'),(057,'400'),(057,'412'),(057,'456'),(057,'458'),(057,'488'),(057,'512'),(057,'550'),(057,'575'),(057,'599'),(057,'612'),(057,'750'),(057,'812'),(057,'California'),(057,'Daytona'),(057,'Dino GT4'),(057,'Enzo Ferrari'),(057,'F12'),(057,'F355'),(057,'F40'),(057,'F430'),(057,'F50'),(057,'F512'),(057,'FF'),(057,'FXX'),(057,'GTC4 Lusso'),(057,'LaFerrari'),(057,'Mondial'),(057,'Portofino'),(057,'Scuderia Spider 16M'),(057,'Superamerica'),(057,'Testarossa'),(057,'zz== Autres ==zz'),(058,'124 Coupè'),(058,'124 Spider'),(058,'126'),(058,'127'),(058,'128'),(058,'130'),(058,'131'),(058,'132'),(058,'133'),(058,'242'),(058,'500 Abarth'),(058,'500'),(058,'500C Abarth'),(058,'500C'),(058,'500L'),(058,'500X'),(058,'595 Abarth'),(058,'600'),(058,'850'),(058,'900'),(058,'Albea'),(058,'Argenta'),(058,'Barchetta'),(058,'Brava'),(058,'Bravo'),(058,'Campagnola'),(058,'Cinquecento'),(058,'Coupe'),(058,'Croma'),(058,'Dino'),(058,'Doblo'),(058,'Ducato'),(058,'Duna'),(058,'Fiorino'),(058,'Freemont'),(058,'Fullback'),(058,'Grande Punto'),(058,'Idea'),(058,'Linea'),(058,'Marea'),(058,'Marengo'),(058,'Maxi'),(058,'Multipla'),(058,'New Panda'),(058,'Palio'),(058,'Panda'),(058,'Penny'),(058,'Pininfarina'),(058,'Punto Evo'),(058,'Punto'),(058,'Qubo'),(058,'Regata'),(058,'Ritmo'),(058,'Scudo'),(058,'Sedici'),(058,'Seicento'),(058,'Spider Europa'),(058,'Stilo'),(058,'Strada'),(058,'Talento'),(058,'Tempra'),(058,'Tipo'),(058,'Ulysse'),(058,'Uno'),(058,'X 1/9'),(058,'zz== Autres ==zz'),(059,'Karma'),(059,'Latigo CS'),(059,'zz== Autres ==zz'),(060,'GA200'),(060,'GA500'),(060,'GX6'),(060,'Troy'),(060,'Victor'),(060,'Victory'),(060,'WAY'),(060,'zz== Autres ==zz'),(061,'Exceed'),(061,'GALLOPER'),(061,'Santamo'),(061,'Super Exceed'),(061,'zz== Autres ==zz'),(062,'22171'),(062,'22177'),(062,'24'),(062,'2401'),(062,'2402'),(062,'2404'),(062,'2410'),(062,'2411'),(062,'2412'),(062,'2434'),(062,'31'),(062,'3102'),(062,'31022'),(062,'310221'),(062,'31026'),(062,'31029'),(062,'3105'),(062,'3110'),(062,'31105'),(062,'3111'),(062,'38407'),(062,'38649'),(062,'38710'),(062,'Gazelle'),(062,'Next'),(062,'Siber'),(062,'Sobol'),(062,'zz== Autres ==zz'),(063,'MK'),(063,'Otaka'),(063,'Vision'),(063,'zz== Autres ==zz'),(064,'E2'),(064,'E4'),(064,'e6'),(064,'eL'),(064,'eS'),(064,'Four'),(064,'Two'),(064,'zz== Autres ==zz'),(065,'zz== Autres ==zz'),(066,'Gladiator'),(066,'Gyppo'),(066,'zz== Autres ==zz'),(067,'Acadia'),(067,'Canyon'),(067,'Envoy'),(067,'Safari'),(067,'Savana'),(067,'Sierra'),(067,'Sonoma'),(067,'Syclone'),(067,'Terrain'),(067,'Typhoon'),(067,'Vandura'),(067,'Yukon'),(067,'zz== Autres ==zz'),(068,'Coolbear'),(068,'Cowry'),(068,'Deer'),(068,'Florid'),(068,'Gwperi'),(068,'H6'),(068,'Hover 5'),(068,'Hover H3'),(068,'Hover'),(068,'Pegasus'),(068,'Safe'),(068,'Sailor'),(068,'Sing'),(068,'Socool'),(068,'Steed'),(068,'Voleex'),(068,'Wingle 3'),(068,'Wingle'),(068,'zz== Autres ==zz'),(069,'Amica'),(069,'EKE'),(069,'Sonique'),(069,'zz== Autres ==zz'),(070,'2'),(070,'3 HB'),(070,'3'),(070,'6'),(070,'Family'),(070,'Freema'),(070,'zz== Autres ==zz'),(071,'zz== Autres ==zz'),(072,'Accord'),(072,'Ascot'),(072,'Avancier'),(072,'Beat'),(072,'Capa'),(072,'City'),(072,'Civic'),(072,'Concerto'),(072,'Crosstour'),(072,'CR-V'),(072,'CRX'),(072,'CR-Z'),(072,'Element'),(072,'Fit'),(072,'FR-V'),(072,'HR-V'),(072,'Insight'),(072,'Inspire'),(072,'Integra'),(072,'Jazz'),(072,'Legend'),(072,'Life'),(072,'Logo'),(072,'Mobilio'),(072,'NSX'),(072,'Odyssey'),(072,'Orthia'),(072,'Partner'),(072,'Pilot'),(072,'Prelude'),(072,'Quintet'),(072,'Ridgeline'),(072,'S 2000'),(072,'Saber'),(072,'Sabre'),(072,'Shuttle'),(072,'Sm-x'),(072,'Stepwgn'),(072,'Stream'),(072,'Torneo'),(072,'zz== Autres ==zz'),(073,'H1'),(073,'H2'),(073,'H3'),(073,'zz== Autres ==zz'),(074,'Albaycín'),(074,'Grand Albaycín'),(074,'T2'),(074,'zz== Autres ==zz'),(075,'Accent'),(075,'Atos'),(075,'Avante'),(075,'Azera'),(075,'Coupe'),(075,'Creta'),(075,'Elantra'),(075,'Equus'),(075,'Excel'),(075,'Galloper'),(075,'Genesis Coupe'),(075,'Genesis'),(075,'Getz'),(075,'Grace'),(075,'Grand Santa Fe'),(075,'Grand Starex H1'),(075,'Grandeur'),(075,'H 100'),(075,'H 200'),(075,'H 300'),(075,'H 350'),(075,'H-1 Cargo'),(075,'H-1 Starex'),(075,'H-1 Travel'),(075,'H-1'),(075,'Highway'),(075,'i10'),(075,'i20'),(075,'i30'),(075,'i40'),(075,'i800'),(075,'Ioniq'),(075,'iX20'),(075,'iX35'),(075,'iX55'),(075,'Kona'),(075,'Lantra'),(075,'Matrix'),(075,'NF'),(075,'Pony'),(075,'Porter'),(075,'Santa Fe'),(075,'Santamo'),(075,'Satellite'),(075,'S-Coupe'),(075,'Solaris'),(075,'Sonata'),(075,'Sonica'),(075,'Starex'),(075,'Stellar'),(075,'Terracan'),(075,'Tiburon'),(075,'Trajet'),(075,'Tucson'),(075,'Veloster'),(075,'Verna'),(075,'XG 30'),(075,'XG 350'),(075,'zz== Autres ==zz'),(076,'EX25'),(076,'EX30'),(076,'EX35'),(076,'EX37'),(076,'FX'),(076,'G25'),(076,'G35'),(076,'G37'),(076,'I35'),(076,'JX35'),(076,'M30'),(076,'M35'),(076,'M37'),(076,'M45'),(076,'Q30'),(076,'Q45'),(076,'Q50'),(076,'Q60'),(076,'Q70'),(076,'Q80'),(076,'QX30'),(076,'QX50'),(076,'QX56'),(076,'QX60'),(076,'QX70'),(076,'QX80'),(076,'zz== Autres ==zz'),(077,'Clip'),(077,'Elba'),(077,'Mille'),(077,'Mini'),(077,'Minitre'),(077,'Small'),(077,'zz== Autres ==zz'),(078,'300'),(078,'Fidia'),(078,'Grifo'),(078,'Lele'),(078,'zz== Autres ==zz'),(079,'Axiom'),(079,'Bighorn'),(079,'Campo'),(079,'DLX'),(079,'D-Max'),(079,'Gemini'),(079,'Midi'),(079,'NKR'),(079,'NNR'),(079,'NPR'),(079,'PICK UP'),(079,'Rodeo'),(079,'Trooper'),(079,'WFR'),(079,'zz== Autres ==zz'),(080,'Campagnola'),(080,'Daily'),(080,'LKW/TRUCKS'),(080,'Massif'),(080,'zz== Autres ==zz'),(081,'2106'),(081,'2125'),(081,'21251'),(081,'2126'),(081,'21261'),(081,'2715'),(081,'27156'),(081,'2717'),(081,'27171'),(081,'412'),(081,'Nika'),(081,'zz== Autres ==zz'),(082,'420'),(082,'Daimler'),(082,'D-Type'),(082,'E-Pace'),(082,'E-Type'),(082,'F-Pace'),(082,'F-Type'),(082,'I-Pace'),(082,'MK II'),(082,'Sovereign'),(082,'S-Type'),(082,'X300'),(082,'XE'),(082,'XF'),(082,'XJ'),(082,'XJ12'),(082,'XJ40'),(082,'XJ6'),(082,'XJ8'),(082,'XJR'),(082,'XJS'),(082,'XJSC'),(082,'XK'),(082,'XK8'),(082,'XKR'),(082,'X-Type'),(082,'zz== Autres ==zz'),(083,'Cherokee'),(083,'CJ-5'),(083,'CJ-7'),(083,'CJ-8'),(083,'Comanche'),(083,'Commander'),(083,'Compass'),(083,'Grand Cherokee'),(083,'Liberty'),(083,'Patriot'),(083,'Renegade'),(083,'Wagoneer'),(083,'Willys'),(083,'Wrangler'),(083,'zz== Autres ==zz'),(084,'500e'),(084,'zz== Autres ==zz'),(085,'Besta'),(085,'Carens'),(085,'Carnival'),(085,'cee''d Sportswagon'),(085,'cee''d'),(085,'Cerato'),(085,'Clarus'),(085,'Elan'),(085,'Joice'),(085,'K2500'),(085,'K2700'),(085,'K2900'),(085,'Leo'),(085,'Magentis'),(085,'Mentor'),(085,'Mohave/Borrego'),(085,'Niro'),(085,'Opirus'),(085,'Optima'),(085,'Picanto'),(085,'Pregio'),(085,'Pride'),(085,'Pro_ceed'),(085,'Retona'),(085,'Rio'),(085,'Roadster'),(085,'Rocsta'),(085,'Sephia'),(085,'Shuma'),(085,'Sorento'),(085,'Soul'),(085,'Spectra'),(085,'Sportage'),(085,'Stinger'),(085,'Stonic'),(085,'Venga'),(085,'zz== Autres ==zz'),(086,'Agera'),(086,'CC'),(086,'Regera'),(086,'zz== Autres ==zz'),(087,'X-Bow GT'),(087,'X-Bow R'),(087,'X-Bow RR'),(087,'X-Bow Street'),(087,'zz== Autres ==zz'),(088,'110'),(088,'111'),(088,'112'),(088,'1200'),(088,'1300/1500/1600'),(088,'2106'),(088,'4x4'),(088,'Aleko'),(088,'Carlota'),(088,'C-Cross'),(088,'Forma'),(088,'Granta'),(088,'Kalina'),(088,'Largus'),(088,'Natacha'),(088,'Niva'),(088,'Nova'),(088,'Priora'),(088,'Sagona'),(088,'Samara'),(088,'Sprint'),(088,'Taiga'),(088,'Universal'),(088,'VAZ 215'),(088,'Vesta'),(088,'X-Ray'),(088,'zz== Autres ==zz'),(089,'Asterion'),(089,'Aventador'),(089,'Centenario'),(089,'Countach'),(089,'Diablo'),(089,'Espada'),(089,'Estoque'),(089,'Gallardo'),(089,'Huracán'),(089,'Jalpa'),(089,'LM'),(089,'Miura'),(089,'Murciélago'),(089,'Reventon'),(089,'Urraco P250'),(089,'Urus'),(089,'Veneno'),(089,'zz== Autres ==zz'),(090,'A 112 Abarth'),(090,'A 112 Elite'),(090,'A 112'),(090,'Beta'),(090,'Dedra'),(090,'Delta'),(090,'Flaminia'),(090,'Flavia'),(090,'Fulvia'),(090,'Gamma'),(090,'HPE'),(090,'K'),(090,'Kappa'),(090,'Lybra'),(090,'MUSA'),(090,'Phedra'),(090,'Prisma'),(090,'Stratos'),(090,'Thema'),(090,'Thesis'),(090,'Trevi'),(090,'Voyager'),(090,'Y'),(090,'Ypsilon'),(090,'Z'),(090,'ZETA'),(090,'zz== Autres ==zz'),(091,'Defender'),(091,'Discovery Sport'),(091,'Discovery'),(091,'Freelander'),(091,'LRX'),(091,'Range Rover Evoque'),(091,'Range Rover Sport'),(091,'Range Rover Velar'),(091,'Range Rover'),(091,'Series'),(091,'zz== Autres ==zz'),(092,'Convoy'),(092,'Maxus'),(092,'zz== Autres ==zz'),(093,'CT 200h'),(093,'ES 350'),(093,'GS 200t'),(093,'GS 250'),(093,'GS 300'),(093,'GS 430'),(093,'GS 450h'),(093,'GS 460'),(093,'GS F'),(093,'GX 460'),(093,'GX 470'),(093,'IS 200'),(093,'IS 220d'),(093,'IS 250'),(093,'IS 300'),(093,'IS F'),(093,'LC 500'),(093,'LFA'),(093,'LS 400'),(093,'LS 430'),(093,'LS 460'),(093,'LS 500'),(093,'LS 600'),(093,'LX 470'),(093,'LX 570'),(093,'NX 200t'),(093,'NX 300h'),(093,'RC 200t'),(093,'RC 300h'),(093,'RC 350'),(093,'RC F'),(093,'RX 200t'),(093,'RX 300'),(093,'RX 330'),(093,'RX 350'),(093,'RX 400'),(093,'RX 450h'),(093,'SC 400'),(093,'SC 430'),(093,'zz== Autres ==zz'),(094,'Breez (520)'),(094,'Smily'),(094,'Solano (620)'),(094,'zz== Autres ==zz'),(095,'162'),(095,'Ambra'),(095,'Be-Sun'),(095,'Be-Two'),(095,'Be-Up'),(095,'Due'),(095,'IXO'),(095,'JS'),(095,'Nova'),(095,'Optima'),(095,'Optimax'),(095,'Prima'),(095,'X-Pro'),(095,'X-TOO Max'),(095,'X-TOO R DCI'),(095,'X-TOO R'),(095,'X-TOO RS'),(095,'X-TOO S'),(095,'X-Too'),(095,'X-TOO2'),(095,'zz== Autres ==zz'),(096,'Aviator'),(096,'Continental'),(096,'Cosmopolitan'),(096,'LS'),(096,'Mark'),(096,'MKC'),(096,'MKT'),(096,'MKX'),(096,'MKZ'),(096,'Navigator'),(096,'Town Car'),(096,'Zephyr'),(096,'zz== Autres ==zz'),(097,'2-Eleven'),(097,'340 R'),(097,'3-Eleven'),(097,'Cortina'),(097,'Elan'),(097,'Elise'),(097,'Elite'),(097,'Esprit'),(097,'Europa'),(097,'Evora'),(097,'Excel'),(097,'Exige'),(097,'Omega'),(097,'Super Seven'),(097,'V8'),(097,'Venturi'),(097,'zz== Autres ==zz'),(098,'Bolero'),(098,'CJ'),(098,'Genio'),(098,'Goa'),(098,'Jeep'),(098,'Quanto'),(098,'Reva'),(098,'Thar'),(098,'XUV500'),(098,'zz== Autres ==zz'),(099,'TGE'),(099,'zz== Autres ==zz'),(100,'Aston Martin - Cyrus'),(100,'Aston Martin - DB9'),(100,'Aston Martin - Vanquish'),(100,'Aston Martin - Vantage'),(100,'Audi - R8'),(100,'Bentley - Continental GT'),(100,'Bentley - Flying Spur'),(100,'Bentley - Le Mansory'),(100,'Bentley - Vitesse Rosé'),(100,'BMW - 7'),(100,'BMW - X5'),(100,'BMW - X6'),(100,'Bugatti - Veyron'),(100,'Ferrari - 458'),(100,'Ferrari - 599 GTB'),(100,'Ferrari - F12'),(100,'Ferrari - La Revoluzione'),(100,'Ferrari - Siracusa'),(100,'Land Rover - Range Rover'),(100,'Lotus - Elise'),(100,'Lotus - Evora'),(100,'Maserati - Ghibli'),(100,'Maserati - Gran Turismo'),(100,'McLaren - 12C'),(100,'Mercedes-Benz - C'),(100,'Mercedes-Benz - CLS'),(100,'Mercedes-Benz - E'),(100,'Mercedes-Benz - G'),(100,'Mercedes-Benz - GL'),(100,'Mercedes-Benz - M'),(100,'Mercedes-Benz - ML'),(100,'Mercedes-Benz - S'),(100,'Mercedes-Benz - SL'),(100,'Mercedes-Benz - SLK'),(100,'Mercedes-Benz - SLR'),(100,'Mercedes-Benz - SLS'),(100,'Mercedes-Benz - V'),(100,'Mercedes-Benz - Viano'),(100,'Porsche - 918'),(100,'Porsche - 991'),(100,'Porsche - 997'),(100,'Porsche - Cayenne'),(100,'Porsche - Macan'),(100,'Porsche - Panamera'),(100,'Rolls-Royce - Ghost'),(100,'Rolls-Royce - Phantom'),(100,'Rolls-Royce - Wraith'),(100,'Tesla - Model S'),(100,'zz== Autres ==zz'),(101,'Bubble'),(101,'CEO'),(101,'CoolCar'),(101,'MM520'),(101,'MM620'),(101,'zz== Autres ==zz'),(102,'222'),(102,'224'),(102,'228'),(102,'3200'),(102,'418'),(102,'420'),(102,'4200'),(102,'422'),(102,'424'),(102,'430'),(102,'Biturbo'),(102,'Coupe'),(102,'Ghibli'),(102,'GranCabrio'),(102,'GranSport'),(102,'GranTurismo'),(102,'Indy'),(102,'Karif'),(102,'Levante'),(102,'MC12'),(102,'Merak'),(102,'Quattroporte'),(102,'Racing'),(102,'Shamal'),(102,'Spyder'),(102,'TC'),(102,'zz== Autres ==zz'),(103,'57'),(103,'62'),(103,'zz== Autres ==zz'),(104,'121'),(104,'2'),(104,'3'),(104,'323'),(104,'5'),(104,'6'),(104,'626'),(104,'929'),(104,'Atenza'),(104,'Axela'),(104,'B 2500'),(104,'B 2600'),(104,'Bongo'),(104,'BT-50'),(104,'Capella'),(104,'CX-3'),(104,'CX-5'),(104,'CX-7'),(104,'CX-9'),(104,'Demio'),(104,'E'),(104,'Familia'),(104,'Millenia'),(104,'MPV'),(104,'MX-3'),(104,'MX-5'),(104,'MX-6'),(104,'Pick Up'),(104,'Premacy'),(104,'Protege'),(104,'RX-7'),(104,'RX-8'),(104,'Tribute'),(104,'Xedos 6'),(104,'Xedos'),(104,'zz== Autres ==zz');
	INSERT INTO Modele (idMarque, nom) VALUES 
	(105,'12 C'),(105,'540C'),(105,'570GT'),(105,'570S'),(105,'650S Coupe'),(105,'650S Spider'),(105,'675LT'),(105,'720S'),(105,'F1'),(105,'MP4-12C'),(105,'P1'),(105,'Senna'),(105,'zz== Autres ==zz'),(106,'148'),(106,'341'),(106,'343'),(106,'345'),(106,'363'),(106,'364'),(106,'366'),(106,'378'),(106,'381'),(106,'385'),(106,'391'),(106,'392'),(106,'395'),(106,'433'),(106,'443'),(106,'563'),(106,'565'),(106,'627'),(106,'833'),(106,'835'),(106,'843'),(106,'845'),(106,'848'),(106,'860'),(106,'861'),(106,'864'),(106,'865'),(106,'943'),(106,'945'),(106,'947'),(106,'960'),(106,'961'),(106,'962'),(106,'963'),(106,'964'),(106,'965'),(106,'966'),(106,'967'),(106,'969'),(106,'986'),(106,'zz== Autres ==zz'),(107,'Metro'),(107,'MGA'),(107,'MGB'),(107,'MGC'),(107,'MGF'),(107,'Midget'),(107,'RV8'),(107,'TD'),(107,'TF'),(107,'ZR'),(107,'ZS'),(107,'ZT'),(107,'zz== Autres ==zz'),(108,'Cargo'),(108,'Due'),(108,'Ecology/Lyra'),(108,'Flex'),(108,'M.Go'),(108,'M8'),(108,'MC1'),(108,'MC2'),(108,'Virgo'),(108,'zz== Autres ==zz'),(109,'Minauto'),(109,'zz== Autres ==zz'),(110,'1000'),(110,'1300'),(110,'3/5 Portes'),(110,'Clubvan'),(110,'Cooper Cabrio'),(110,'Cooper Clubman'),(110,'Cooper Countryman'),(110,'Cooper Coupe'),(110,'Cooper D Cabrio'),(110,'Cooper D Clubman'),(110,'Cooper D Countryman'),(110,'Cooper D Coupe'),(110,'Cooper D Paceman'),(110,'Cooper D'),(110,'Cooper Paceman'),(110,'Cooper Roadster'),(110,'Cooper S Cabrio'),(110,'Cooper S Clubman'),(110,'Cooper S Countryman'),(110,'Cooper S Coupe'),(110,'Cooper S Paceman'),(110,'Cooper S Roadster'),(110,'Cooper S'),(110,'Cooper SD Cabrio'),(110,'Cooper SD Clubman'),(110,'Cooper SD Countryman'),(110,'Cooper SD Coupe'),(110,'Cooper SD Paceman'),(110,'Cooper SD Roadster'),(110,'Cooper SD'),(110,'Cooper'),(110,'John Cooper Works Cabrio'),(110,'John Cooper Works Clubman'),(110,'John Cooper Works Countryman'),(110,'John Cooper Works Coupe'),(110,'John Cooper Works Paceman'),(110,'John Cooper Works Roadster'),(110,'John Cooper Works'),(110,'One Cabrio'),(110,'One Clubman'),(110,'One Countryman'),(110,'One D Clubman'),(110,'One D Countryman'),(110,'One D'),(110,'One'),(110,'zz== Autres ==zz'),(111,'3000 GT'),(111,'400'),(111,'Airtrek'),(111,'ASX'),(111,'Attrage'),(111,'Canter'),(111,'Carisma'),(111,'Chariot'),(111,'Colt'),(111,'Cordia'),(111,'Cosmos'),(111,'Delica'),(111,'Diamante'),(111,'DINGO'),(111,'Dion'),(111,'Eclipse Cross'),(111,'Eclipse'),(111,'FTO'),(111,'Galant'),(111,'Galloper'),(111,'Grandis'),(111,'I-MiEV'),(111,'L200'),(111,'L300'),(111,'L400'),(111,'Lancer'),(111,'Legnum'),(111,'Libero'),(111,'Mirage'),(111,'Montero'),(111,'Outlander'),(111,'Pajero Pinin'),(111,'Pajero Sport'),(111,'Pajero'),(111,'PICK UP'),(111,'RVR'),(111,'Santamo'),(111,'Sapporo'),(111,'Sigma Wagon'),(111,'Sigma'),(111,'Space Gear'),(111,'Space Runner'),(111,'Space Star'),(111,'Space Wagon'),(111,'Starion'),(111,'Tredia'),(111,'zz== Autres ==zz'),(112,'Galue'),(112,'Himiko'),(112,'Ryugi'),(112,'Viewt'),(112,'zz== Autres ==zz'),(113,'100-Years-Special'),(113,'3-Wheeler'),(113,'4/4'),(113,'4-Sitzer'),(113,'Aero 8'),(113,'Aero Coupe'),(113,'Aero Max'),(113,'Aero Supersports'),(113,'EVA GT'),(113,'Lifecar'),(113,'Plus 4'),(113,'Plus 8 Speedster'),(113,'Plus 8'),(113,'Plus E'),(113,'Roadster Sport'),(113,'Roadster'),(113,'Supersport Pedal'),(113,'zz== Autres ==zz'),(114,'21215'),(114,'2137'),(114,'2138'),(114,'2140'),(114,'21406'),(114,'2141'),(114,'21412'),(114,'214145'),(114,'2142'),(114,'2335'),(114,'408'),(114,'412'),(114,'426'),(114,'427'),(114,'434'),(114,'Duet'),(114,'Ivan Kalita'),(114,'Jurij Dolgorukij'),(114,'Knjaz Vladimir'),(114,'Svjatogor'),(114,'zz== Autres ==zz'),(115,'MP Lafer'),(115,'zz== Autres ==zz'),(116,'PS160'),(116,'zz== Autres ==zz'),(117,'100'),(117,'200 SX'),(117,'280 ZX'),(117,'300 ZX'),(117,'350Z'),(117,'370Z'),(117,'AD'),(117,'Almera Tino'),(117,'Almera'),(117,'Altima'),(117,'Armada'),(117,'Avenir'),(117,'Bassara'),(117,'Bluebird'),(117,'Cabstar'),(117,'Cargo'),(117,'Cedric'),(117,'Cefiro'),(117,'Cherry'),(117,'Cube'),(117,'Datsun'),(117,'Elgrand'),(117,'E-NV200'),(117,'Evalia'),(117,'Expert'),(117,'Figaro'),(117,'Frontier'),(117,'Gloria'),(117,'GT-R'),(117,'Interstar'),(117,'Juke'),(117,'King Cab'),(117,'Kubistar'),(117,'Laurel'),(117,'Leaf'),(117,'Liberty'),(117,'March'),(117,'Maxima'),(117,'Micra'),(117,'Murano'),(117,'Navara'),(117,'Note'),(117,'NP300'),(117,'NV200'),(117,'NV300'),(117,'NV400'),(117,'Pathfinder'),(117,'Patrol'),(117,'Pick Up'),(117,'Pixo'),(117,'Prairie'),(117,'Presage'),(117,'Presea'),(117,'Primastar'),(117,'Primera'),(117,'Pulsar'),(117,'Qashqai'),(117,'Qashqai+2'),(117,'Quest'),(117,'R Nessa'),(117,'Rogue'),(117,'Safari'),(117,'Serena'),(117,'Silvia'),(117,'Skyline'),(117,'Stagea'),(117,'Stanza'),(117,'Sunny'),(117,'Teana'),(117,'Terrano II'),(117,'Terrano'),(117,'Tiida'),(117,'Titan'),(117,'Trade'),(117,'Urvan'),(117,'Vanette'),(117,'Wingroad'),(117,'X-Trail'),(117,'zz== Autres ==zz'),(118,'Bravada'),(118,'Custom Cruiser'),(118,'Cutlass'),(118,'Delta 88'),(118,'Dynamic 88'),(118,'Silhouette'),(118,'Supreme'),(118,'Toronado'),(118,'zz== Autres ==zz'),(119,'Abarth'),(119,'AC'),(119,'Adler'),(119,'Alfa Romeo'),(119,'Allard'),(119,'Alvis'),(119,'AMC'),(119,'American'),(119,'Amphicar'),(119,'Ariel'),(119,'Aries'),(119,'Armstrong Siddeley'),(119,'Arnolt'),(119,'ASA'),(119,'ASC'),(119,'Aston Martin'),(119,'Auburn'),(119,'Audi'),(119,'Aurora'),(119,'Austin'),(119,'Austin-Healey'),(119,'Auto Union'),(119,'Autobianchi'),(119,'Avanti'),(119,'Barkas'),(119,'Beast'),(119,'Bedford'),(119,'Belsize'),(119,'Benjamin'),(119,'Bentley'),(119,'Berkeley'),(119,'Bitter'),(119,'Bizzarrini'),(119,'BMW'),(119,'Borgward'),(119,'Brennabor'),(119,'Bricklin'),(119,'Bugatti'),(119,'Buick'),(119,'Cadillac'),(119,'Chaika'),(119,'Champion'),(119,'Charron'),(119,'Checker'),(119,'Chenard & Walker'),(119,'Chevrolet'),(119,'Chrysler'),(119,'Cisitalia'),(119,'Citroen'),(119,'CJ Rayburn'),(119,'Clan'),(119,'Clenet'),(119,'Commer'),(119,'Continental'),(119,'Cord'),(119,'Corvette'),(119,'Cunningham'),(119,'D.F.P'),(119,'Daf'),(119,'Daimler'),(119,'Dante'),(119,'Datsun'),(119,'Day Elder'),(119,'De Dion Bouton'),(119,'De Lorean'),(119,'De Soto'),(119,'De Tomaso'),(119,'Delage'),(119,'Delahaye'),(119,'Denzel'),(119,'DeSoto'),(119,'Deutz'),(119,'DKW'),(119,'Dodge'),(119,'Dort'),(119,'Duesenberg'),(119,'Durant'),(119,'Dutton'),(119,'Edsel'),(119,'Elva'),(119,'EMW'),(119,'England'),(119,'Enzmann'),(119,'Essex'),(119,'Excalibur'),(119,'Facel Vega'),(119,'Fairthorpe'),(119,'Falcon'),(119,'Fenton-Riley'),(119,'Ferrari'),(119,'Fiat'),(119,'Fire Vehicle'),(119,'Fleur de Lys'),(119,'FN'),(119,'Ford'),(119,'Fordson'),(119,'Formula-Car'),(119,'Franklin'),(119,'Frazer Nash'),(119,'Fuldamobil'),(119,'Gaz'),(119,'Ghia'),(119,'Gilbern'),(119,'Ginatta'),(119,'Ginetta'),(119,'Glas'),(119,'GMC'),(119,'Goggomobil'),(119,'Goliath'),(119,'Gordon Keeble'),(119,'Graham-Paige'),(119,'GSM'),(119,'Gutbrod'),(119,'Hanomag'),(119,'Harley Davidson'),(119,'Healey'),(119,'Heinkel'),(119,'Heritage'),(119,'Hillman'),(119,'Hino'),(119,'Hispano-Suiza'),(119,'Holden'),(119,'Honda'),(119,'Horch'),(119,'Hotchkiss'),(119,'HRG'),(119,'Hudson'),(119,'Humber'),(119,'Hupmobile'),(119,'IFA'),(119,'IHC'),(119,'Innocenti'),(119,'International'),(119,'Iso Rivolta'),(119,'Isuzu'),(119,'Jaguar'),(119,'Jeep'),(119,'Jensen'),(119,'Kaiser - Frazer'),(119,'Kaiser'),(119,'Karmann Ghia'),(119,'Karmann'),(119,'Kelly'),(119,'Kleinschnittger'),(119,'La Licorne'),(119,'Lagonda'),(119,'Lamborghini'),(119,'Lanchester'),(119,'Lancia'),(119,'Land Rover'),(119,'Lanz'),(119,'LaSalle'),(119,'Lea Francis'),(119,'Ligier'),(119,'Lincoln'),(119,'LKW-Trucks'),(119,'Lloyd'),(119,'LMX'),(119,'Lombardi'),(119,'Lorraine Dietrich'),(119,'Lotus'),(119,'Mack'),(119,'Magirus'),(119,'MAN'),(119,'Marauder'),(119,'March'),(119,'Marcos'),(119,'Marendaz'),(119,'Marmon'),(119,'Maserati'),(119,'Mathis'),(119,'Matra'),(119,'Maybach'),(119,'Mazda'),(119,'Mercedes Benz'),(119,'Mercury'),(119,'Merlin'),(119,'Messerschmitt'),(119,'Metz'),(119,'MG'),(119,'Military Vehicle'),(119,'Minerva'),(119,'Mitsubishi'),(119,'Monica'),(119,'Monteverdi'),(119,'Moretti'),(119,'Morgan Darmont'),(119,'Morgan'),(119,'Morris Leon Bolle'),(119,'Morris Minor'),(119,'Moskvitch'),(119,'Motorräder-Bike'),(119,'Munga'),(119,'Muntz'),(119,'Nash'),(119,'Nissan'),(119,'NSU'),(119,'Ogle'),(119,'Oldsmobile'),(119,'OM'),(119,'Opel'),(119,'Osca'),(119,'Overland'),(119,'Packard'),(119,'Panhard'),(119,'Panther'),(119,'Paterson'),(119,'Peerless'),(119,'Pegaso'),(119,'Peugeot'),(119,'Pierce Arrow'),(119,'Pontiac'),(119,'Porsche'),(119,'Puch'),(119,'Puma'),(119,'Rambler'),(119,'Reliant'),(119,'Renault'),(119,'RenT Bonnet'),(119,'Republic'),(119,'Riley'),(119,'Rolls Royce'),(119,'Rosengart'),(119,'Rotus'),(119,'Roush'),(119,'Rover'),(119,'Rovin'),(119,'Saab'),(119,'Salmson'),(119,'Saurer'),(119,'Seat'),(119,'Sebring'),(119,'Setra'),(119,'Shelby'),(119,'Shores'),(119,'Siata'),(119,'Simca'),(119,'Skoda'),(119,'Spartan'),(119,'Spitzer'),(119,'Standard'),(119,'Stephens'),(119,'Steyr'),(119,'Studebaker'),(119,'Stutz'),(119,'Subaru'),(119,'Sunbeam'),(119,'Talbot'),(119,'Tatra'),(119,'Tempo'),(119,'Toyota'),(119,'Trabant'),(119,'Tractor'),(119,'Trident'),(119,'Triumph'),(119,'Tucker'),(119,'Turner'),(119,'TVR'),(119,'Uaz'),(119,'Unic'),(119,'Unimog'),(119,'Vanden Plas'),(119,'Veritas'),(119,'Vignale'),(119,'Vixen'),(119,'Voisin'),(119,'Volkswagen'),(119,'Volvo'),(119,'Wanderer'),(119,'Wartburg'),(119,'Westfalia'),(119,'Westfield'),(119,'Wetsch'),(119,'Willys'),(119,'Wolseley'),(119,'Yugo'),(119,'Zimmer'),(119,'Zündapp'),(119,'zz== Autres ==zz'),(120,'Huayra'),(120,'Zonda C12'),(120,'Zonda F'),(120,'zz== Autres ==zz'),(121,'De Ville'),(121,'Kallista'),(121,'Lazer'),(121,'Lima'),(121,'Rio'),(121,'zz== Autres ==zz'),(122,'Cévennes'),(122,'Cobra'),(122,'Hemera'),(122,'Speedster II'),(122,'Speedster'),(122,'zz== Autres ==zz'),(123,'AL500'),(123,'Ape'),(123,'M500'),(123,'PK500'),(123,'Porter'),(123,'Quargo'),(123,'zz== Autres ==zz'),(124,'Acclaim'),(124,'Arrow'),(124,'Barracuda'),(124,'Belvedere'),(124,'Breeze'),(124,'Caravelle'),(124,'Colt'),(124,'Conquest'),(124,'Cricket'),(124,'Duster'),(124,'Fury'),(124,'Gran Fury'),(124,'GTX'),(124,'Horizon'),(124,'Laser'),(124,'Neon'),(124,'Prowler'),(124,'Reliant'),(124,'Road Runner'),(124,'Sapporo'),(124,'Satellite'),(124,'Savoy'),(124,'Scamp'),(124,'Sundance'),(124,'Trailduster'),(124,'Turismo'),(124,'Valiant'),(124,'Volaré'),(124,'Voyager'),(124,'zz== Autres ==zz'),(125,'6000'),(125,'Aztek'),(125,'Bonneville'),(125,'Catalina Safari'),(125,'Fiero'),(125,'Firebird'),(125,'G6'),(125,'Grand-Am'),(125,'Grand-Prix'),(125,'GTO'),(125,'Montana'),(125,'Solstice'),(125,'Sunbird'),(125,'Sunfire'),(125,'Targa'),(125,'Trans Am'),(125,'Trans Sport'),(125,'Vibe'),(125,'zz== Autres ==zz'),(126,'356'),(126,'550'),(126,'911'),(126,'912'),(126,'914'),(126,'918'),(126,'924'),(126,'928'),(126,'930'),(126,'944'),(126,'959'),(126,'962'),(126,'964'),(126,'968'),(126,'991'),(126,'993'),(126,'996'),(126,'997'),(126,'Boxster'),(126,'Carrera GT'),(126,'Cayenne'),(126,'Cayman'),(126,'Macan'),(126,'Panamera'),(126,'Targa'),(126,'zz== Autres ==zz'),(127,'313'),(127,'315'),(127,'316'),(127,'318'),(127,'413'),(127,'415'),(127,'416'),(127,'418'),(127,'420'),(127,'Gen2'),(127,'Persona'),(127,'zz== Autres ==zz'),(128,'G'),(128,'Haflinger'),(128,'Pinzgauer'),(128,'zz== Autres ==zz'),(129,'Qoros 3'),(129,'zz== Autres ==zz'),(130,'Mangusta'),(130,'zz== Autres ==zz'),(131,'Ant'),(131,'Fox'),(131,'Kitten'),(131,'Rebel'),(131,'Regal'),(131,'Regent'),(131,'Rialto'),(131,'Robin'),(131,'Sabre Four'),(131,'Scimitar'),(131,'zz== Autres ==zz'),(132,'Alaskan'),(132,'Alpine A110'),(132,'Alpine A310'),(132,'Alpine A610'),(132,'Alpine V6'),(132,'Avantime'),(132,'Captur'),(132,'Clio'),(132,'Coupe'),(132,'Duster'),(132,'Espace'),(132,'Express'),(132,'Fluence Z.E.'),(132,'Fluence'),(132,'Fuego'),(132,'Grand Espace'),(132,'Grand Modus'),(132,'Grand Scenic'),(132,'Kadjar'),(132,'Kangoo Z.E.'),(132,'Kangoo'),(132,'Koleos'),(132,'Laguna'),(132,'Latitude'),(132,'Logan'),(132,'Mascott'),(132,'Master'),(132,'Megane'),(132,'Messenger'),(132,'Modus'),(132,'P 1400'),(132,'R 11'),(132,'R 14'),(132,'R 18'),(132,'R 19'),(132,'R 20'),(132,'R 21'),(132,'R 25'),(132,'R 30'),(132,'R 4'),(132,'R 5'),(132,'R 6'),(132,'R 9'),(132,'Rapid'),(132,'Safrane'),(132,'Sandero Stepway'),(132,'Sandero'),(132,'Scenic'),(132,'Spider'),(132,'Super 5'),(132,'Symbol'),(132,'Talisman'),(132,'Trafic'),(132,'Twingo'),(132,'Twizy'),(132,'Vel Satis'),(132,'Wind'),(132,'ZOE'),(132,'zz== Autres ==zz');
	INSERT INTO Modele (idMarque, nom) VALUES 
	(133,'Arnage Green Label'),(133,'Arnage Red Label'),(133,'Azure Mulliner'),(133,'Azure'),(133,'Camargue'),(133,'Cloud'),(133,'Continental R Mulliner'),(133,'Continental R'),(133,'Continental SC'),(133,'Corniche'),(133,'Cullinan'),(133,'Dawn'),(133,'Flying Spur'),(133,'Ghost'),(133,'Le Mains Series'),(133,'Park Ward Turbo'),(133,'Park Ward'),(133,'Phantom Drophead'),(133,'Phantom'),(133,'Silver Dawn'),(133,'Silver Seraph'),(133,'Silver Shadow'),(133,'Silver Spirit'),(133,'Silver Spur'),(133,'Silver Wraith'),(133,'T'),(133,'Touring'),(133,'Wraith'),(133,'zz== Autres ==zz'),(134,'100'),(134,'111'),(134,'114'),(134,'200'),(134,'213'),(134,'214'),(134,'216'),(134,'218'),(134,'220'),(134,'25'),(134,'400'),(134,'414'),(134,'416'),(134,'418'),(134,'420'),(134,'45'),(134,'600'),(134,'618'),(134,'620'),(134,'623'),(134,'75'),(134,'800'),(134,'820'),(134,'825'),(134,'827'),(134,'City Rover'),(134,'Estate'),(134,'Metro'),(134,'MINI'),(134,'Montego'),(134,'Rover'),(134,'SD'),(134,'Streetwise'),(134,'Tourer'),(134,'zz== Autres ==zz'),(135,'3400S'),(135,'3600S'),(135,'BTR'),(135,'CTR'),(135,'CTR2'),(135,'CTR3'),(135,'Dakara'),(135,'R Kompressor'),(135,'R Turbo'),(135,'RGT'),(135,'RGT-8'),(135,'RK Coupe/Spyder'),(135,'RT 12'),(135,'RT 12R'),(135,'RT 12S'),(135,'Turbo Florio'),(135,'Turbo R'),(135,'zz== Autres ==zz'),(136,'90'),(136,'900 Sedan GL'),(136,'900 Sedan'),(136,'900 Turbo'),(136,'900'),(136,'9000'),(136,'92'),(136,'9-2X'),(136,'93'),(136,'9-3'),(136,'9-4X'),(136,'9-5'),(136,'96'),(136,'96/95'),(136,'9-7X'),(136,'99'),(136,'GT 750'),(136,'Sonett I'),(136,'Sonett II'),(136,'Sonett III'),(136,'Sport / GT 850'),(136,'zz== Autres ==zz'),(137,'2500'),(137,'300'),(137,'350'),(137,'410'),(137,'Anibal'),(137,'PS-10'),(137,'S300'),(137,'S350'),(137,'Samurai'),(137,'Vitara Cabriolet'),(137,'Vitara'),(137,'zz== Autres ==zz'),(138,'Agora'),(138,'Spacia'),(138,'zz== Autres ==zz'),(139,'Auto Elettrica'),(139,'zz== Autres ==zz'),(140,'Alhambra'),(140,'Altea XL'),(140,'Altea'),(140,'Arona'),(140,'Arosa'),(140,'Ateca'),(140,'Cordoba'),(140,'Exeo'),(140,'Fura'),(140,'Ibiza'),(140,'Inca'),(140,'Leon'),(140,'Malaga'),(140,'Marbella'),(140,'Mii'),(140,'Panda'),(140,'Ronda'),(140,'Terra'),(140,'Toledo'),(140,'zz== Autres ==zz'),(141,'105'),(141,'120'),(141,'130'),(141,'135'),(141,'Citigo'),(141,'Fabia'),(141,'Favorit'),(141,'Felicia'),(141,'Forman'),(141,'Karoq'),(141,'Kodiaq'),(141,'Octavia'),(141,'Pick-up'),(141,'Praktik'),(141,'Rapid/Spaceback'),(141,'Roomster'),(141,'Snowman'),(141,'Superb'),(141,'Yeti'),(141,'zz== Autres ==zz'),(142,'brabus'),(142,'city-coupé/city-cabrio'),(142,'crossblade'),(142,'forFour'),(142,'forTwo'),(142,'roadster'),(142,'zz== Autres ==zz'),(143,'zz== Autres ==zz'),(144,'C12'),(144,'C8'),(144,'D12'),(144,'zz== Autres ==zz'),(145,'Actyon'),(145,'Family'),(145,'Kallista'),(145,'Korando'),(145,'Kyron'),(145,'MUSSO'),(145,'REXTON'),(145,'Rodius'),(145,'Tivoli'),(145,'XLV'),(145,'zz== Autres ==zz'),(146,'1200'),(146,'1800'),(146,'Baja'),(146,'BRZ'),(146,'E10'),(146,'E12'),(146,'Forester'),(146,'Impreza'),(146,'Justy'),(146,'Legacy'),(146,'Leone'),(146,'Levorg'),(146,'Libero'),(146,'M60'),(146,'M70'),(146,'M80'),(146,'Mini'),(146,'OUTBACK'),(146,'SVX'),(146,'Trezia'),(146,'Tribeca'),(146,'Vanille'),(146,'Vivio'),(146,'WRX'),(146,'XT'),(146,'XV'),(146,'zz== Autres ==zz'),(147,'Alto'),(147,'Baleno'),(147,'Cappuccino'),(147,'Carry'),(147,'Celerio'),(147,'Escudo'),(147,'Grand Vitara'),(147,'Ignis'),(147,'Ik-2'),(147,'Jimny'),(147,'Kizashi'),(147,'Liana'),(147,'LJ 80'),(147,'Maruti'),(147,'SA 310'),(147,'Samurai'),(147,'Santana'),(147,'SJ 410'),(147,'SJ 413'),(147,'SJ Samurai'),(147,'Splash'),(147,'Super-Carry'),(147,'Swift'),(147,'SX4 S-Cross'),(147,'SX4'),(147,'Vitara'),(147,'Wagon R+'),(147,'X-90'),(147,'XL-7'),(147,'zz== Autres ==zz'),(148,'Accent'),(148,'C10'),(148,'C190'),(148,'Estina'),(148,'Hardy'),(148,'Road Partner'),(148,'Tager'),(148,'Tiggo'),(148,'Vega'),(148,'zz== Autres ==zz'),(149,'Alpine'),(149,'Horizon'),(149,'Horizont GL'),(149,'Horizont GLS'),(149,'Matra Murena'),(149,'Matra Rancho'),(149,'Samba'),(149,'Simca 1100'),(149,'Simca 1510'),(149,'Solar GL'),(149,'Solar LS'),(149,'Solar Ralley'),(149,'Solara'),(149,'Sunbeam'),(149,'Tagora'),(149,'zz== Autres ==zz'),(150,'Bingo'),(150,'C1DB'),(150,'C1DM'),(150,'Domino'),(150,'Hola'),(150,'King'),(150,'T2'),(150,'T3'),(150,'TD'),(150,'zz== Autres ==zz'),(151,'Aria'),(151,'Estate'),(151,'Indica'),(151,'Indigo'),(151,'Nano'),(151,'Pick-Up'),(151,'Safari'),(151,'Sumo'),(151,'Telcoline'),(151,'Telcosport'),(151,'Xenon'),(151,'zz== Autres ==zz'),(152,'EM1 Anniversary'),(152,'EM1 Citysport'),(152,'Zero Classic'),(152,'Zero Evo'),(152,'Zero Special Edition'),(152,'Zero Speedster'),(152,'zz== Autres ==zz'),(153,'zz== Autres ==zz'),(154,'Model 3'),(154,'Model S'),(154,'Model X'),(154,'Roadster'),(154,'zz== Autres ==zz'),(155,'Ginevra'),(155,'Helektra'),(155,'zz== Autres ==zz'),(156,'4-Runner'),(156,'Allion'),(156,'Alphard'),(156,'Altezza'),(156,'Aristo'),(156,'Auris'),(156,'Avalon'),(156,'Avensis Verso'),(156,'Avensis'),(156,'Aygo'),(156,'BB'),(156,'Belta'),(156,'Caldina'),(156,'Cami'),(156,'Camry'),(156,'Carina'),(156,'Celica'),(156,'Chaser'),(156,'C-HR'),(156,'Coaster'),(156,'Corolla Verso'),(156,'Corolla'),(156,'Corona'),(156,'Corsa'),(156,'Cressida'),(156,'Cresta'),(156,'Crown'),(156,'Duet'),(156,'Dyna'),(156,'Estima'),(156,'F'),(156,'FJ Cruiser'),(156,'FJ40'),(156,'Fortuner'),(156,'Fun Cruiser'),(156,'Funcargo'),(156,'Gaia'),(156,'GT86'),(156,'Harrier'),(156,'HDJ'),(156,'Hiace'),(156,'Highlander'),(156,'Hilux'),(156,'Ipsum'),(156,'iQ'),(156,'Ist'),(156,'KJ'),(156,'Land Cruiser Prado'),(156,'Land Cruiser'),(156,'Lite-Ace'),(156,'Mark II'),(156,'Matrix'),(156,'Mirai'),(156,'MR 2'),(156,'Nadia'),(156,'Noah'),(156,'Opa'),(156,'Paseo'),(156,'Passo'),(156,'Pick up'),(156,'Picnic'),(156,'Platz'),(156,'Premio'),(156,'Previa'),(156,'Prius'),(156,'Prius+'),(156,'Pro Ace'),(156,'Ractis'),(156,'Raum'),(156,'RAV 4'),(156,'Sequoia'),(156,'Sienna'),(156,'Solara'),(156,'Sprinter'),(156,'Starlet'),(156,'Supra'),(156,'Tacoma'),(156,'Tercel'),(156,'Town Ace'),(156,'Tundra'),(156,'Urban Cruiser'),(156,'Venza'),(156,'Verossa'),(156,'Verso'),(156,'Verso-S'),(156,'Vista'),(156,'Vitz'),(156,'Voxy'),(156,'Will'),(156,'Windom'),(156,'Wish'),(156,'Yaris'),(156,'zz== Autres ==zz'),(157,'1.1'),(157,'P50'),(157,'P60'),(157,'P601'),(157,'Rallye'),(157,'Trabant'),(157,'zz== Autres ==zz'),(158,'zz== Autres ==zz'),(159,'Dolomite'),(159,'GT6'),(159,'Herald'),(159,'Moss'),(159,'Spitfire'),(159,'Stag'),(159,'TR1'),(159,'TR2'),(159,'TR3'),(159,'TR4'),(159,'TR5'),(159,'TR6'),(159,'TR7'),(159,'TR8'),(159,'zz== Autres ==zz'),(160,'Atlas'),(160,'Cat'),(160,'Citroen'),(160,'Daewoo'),(160,'DAF'),(160,'Deutz-Fahr'),(160,'Fiat'),(160,'Ford'),(160,'Fuchs'),(160,'Hanomag'),(160,'Hitachi'),(160,'Iveco Magirus'),(160,'Iveco'),(160,'Iveco-Fiat'),(160,'Jungheinrich'),(160,'Koegel'),(160,'Komatsu'),(160,'LDV'),(160,'Liebherr'),(160,'Linde'),(160,'MAN'),(160,'Mercedes-Benz'),(160,'Mitsubishi'),(160,'Multicar'),(160,'Neoplan'),(160,'Nissan'),(160,'O & K'),(160,'Peugeot'),(160,'Renault'),(160,'Scania'),(160,'Schaeff'),(160,'Setra'),(160,'Volvo'),(160,'VW'),(160,'Zeppelin'),(160,'Zettelmeyer'),(160,'zz== Autres ==zz'),(161,'Cerbera'),(161,'Chimaera'),(161,'Grantura'),(161,'Griffith'),(161,'S 2,8'),(161,'S2'),(161,'S3'),(161,'S4'),(161,'Sagaris'),(161,'T350'),(161,'Tamora'),(161,'Tuscan'),(161,'V8S'),(161,'zz== Autres ==zz'),(162,'2206'),(162,'2315'),(162,'23632'),(162,'3151'),(162,'31512'),(162,'31514'),(162,'31519'),(162,'315195'),(162,'3153'),(162,'3159'),(162,'3160'),(162,'31601'),(162,'31602'),(162,'3162'),(162,'3163'),(162,'3303'),(162,'3692'),(162,'3909'),(162,'3962'),(162,'469'),(162,'Dakar'),(162,'Hunter'),(162,'Tigr'),(162,'zz== Autres ==zz'),(163,'1111'),(163,'11113'),(163,'11118'),(163,'1113'),(163,'1117'),(163,'1118'),(163,'1119'),(163,'1706'),(163,'1922'),(163,'2016'),(163,'2101'),(163,'21011'),(163,'21013'),(163,'2102'),(163,'2103'),(163,'21033'),(163,'2104'),(163,'21043'),(163,'21045'),(163,'21046'),(163,'21047'),(163,'2105'),(163,'21051'),(163,'21053'),(163,'2106'),(163,'21060'),(163,'21061'),(163,'21063'),(163,'21065'),(163,'2107'),(163,'21073'),(163,'21074'),(163,'2108'),(163,'21081'),(163,'21083'),(163,'21086'),(163,'2109'),(163,'21091'),(163,'21093'),(163,'21096'),(163,'21099'),(163,'2110'),(163,'21101'),(163,'21102'),(163,'21103'),(163,'21104'),(163,'21106'),(163,'21108'),(163,'2111'),(163,'21111'),(163,'21112'),(163,'21113'),(163,'21114'),(163,'2112'),(163,'21120'),(163,'21121'),(163,'21122'),(163,'21123'),(163,'21124'),(163,'2113'),(163,'21130'),(163,'2114'),(163,'21140'),(163,'2115'),(163,'21150'),(163,'21150i'),(163,'2120'),(163,'2121'),(163,'21213'),(163,'21214'),(163,'21218'),(163,'212180'),(163,'2123'),(163,'2129'),(163,'2131'),(163,'21312'),(163,'2170'),(163,'2199'),(163,'2328'),(163,'2329'),(163,'2364'),(163,'Roadster'),(163,'zz== Autres ==zz'),(164,'Cargo'),(164,'Cover'),(164,'Double'),(164,'Multi'),(164,'Open'),(164,'People'),(164,'Ribaltabile'),(164,'zz== Autres ==zz'),(165,'240'),(165,'244'),(165,'245'),(165,'262'),(165,'264'),(165,'265'),(165,'340'),(165,'360'),(165,'440'),(165,'460'),(165,'480'),(165,'740'),(165,'744'),(165,'745'),(165,'760'),(165,'764'),(165,'780'),(165,'850'),(165,'855'),(165,'940'),(165,'944'),(165,'945'),(165,'960'),(165,'965'),(165,'Amazon'),(165,'C30'),(165,'C70'),(165,'Polar'),(165,'S40'),(165,'S60'),(165,'S70'),(165,'S80'),(165,'S90'),(165,'V40 CC'),(165,'V40'),(165,'V50'),(165,'V60'),(165,'V70'),(165,'V90'),(165,'XC40'),(165,'XC60'),(165,'XC70'),(165,'XC90'),(165,'zz== Autres ==zz'),(166,'Corda'),(166,'Estina'),(166,'Tingo'),(166,'zz== Autres ==zz'),(167,'Iris'),(167,'Izis'),(167,'zz== Autres ==zz'),(168,'1.3'),(168,'1.6'),(168,'1000'),(168,'311'),(168,'312'),(168,'313'),(168,'353'),(168,'Barkas'),(168,'Framo'),(168,'IFA F9'),(168,'WARTBURG'),(168,'zz== Autres ==zz'),(169,'7SE'),(169,'FW400'),(169,'Megablade'),(169,'Megabusa'),(169,'MegaS2000'),(169,'SDV'),(169,'SE'),(169,'SEi'),(169,'Seight'),(169,'Sport Turbo'),(169,'Sport'),(169,'XI'),(169,'XTR2'),(169,'XTR4'),(169,'zz== Autres ==zz'),(170,'MF 28'),(170,'MF 3'),(170,'MF 30'),(170,'MF 4'),(170,'MF 5'),(170,'zz== Autres ==zz'),(171,'10'),(171,'101'),(171,'1100 TF'),(171,'125 PZ'),(171,'128'),(171,'1300'),(171,'600'),(171,'750'),(171,'850 AK'),(171,'850'),(171,'900 AK'),(171,'Koral'),(171,'Other'),(171,'Skala'),(171,'Yugo'),(171,'zz== Autres ==zz'),(172,'1102'),(172,'1103'),(172,'1105'),(172,'Chance'),(172,'Sense'),(172,'zz== Autres ==zz'),(173,'AMC'),(173,'Apal'),(173,'ARO'),(173,'Asia'),(173,'Barkas'),(173,'Bertone'),(173,'Bilenkin Classic Cars'),(173,'Binz'),(173,'Bitter'),(173,'BM Grupa'),(173,'Bristol'),(173,'British Leyland'),(173,'Burton'),(173,'can-am'),(173,'Canta'),(173,'Carver'),(173,'China Automobile'),(173,'Continental'),(173,'Cord'),(173,'Datsun Go'),(173,'De Lorean'),(173,'Effedi Maranello'),(173,'Excalibur'),(173,'FSO'),(173,'Fun Tech'),(173,'Gillet'),(173,'Ginetta'),(173,'Gonow'),(173,'Grandin Dallas'),(173,'Gumpert'),(173,'Hartge'),(173,'HDPIC'),(173,'Hobbycar'),(173,'Holden'),(173,'IHC'),(173,'Indimo'),(173,'Iseki'),(173,'Italcar'),(173,'JDM'),(173,'Keinath'),(173,'La Forza'),(173,'Landwind'),(173,'Loremo'),(173,'Marcos'),(173,'Mega'),(173,'Melkus'),(173,'Mercury'),(173,'Mia'),(173,'Monteverdi'),(173,'Morris'),(173,'Mosler'),(173,'Noble'),(173,'Polaris'),(173,'Quadix'),(173,'Radical'),(173,'Reva'),(173,'Romeo Ferraris'),(173,'Saleen'),(173,'Sam'),(173,'Scion'),(173,'Shandong'),(173,'Teener'),(173,'Think City'),(173,'Tiger'),(173,'Tramontana'),(173,'Trax'),(173,'Turner'),(173,'Van Diemen'),(173,'Vauxhall'),(173,'Venturi'),(173,'VM'),(173,'Weineck'),(173,'YES!'),(173,'Zenvo'),(173,'Zoyte'),(173,'zz== Autres ==zz');
GO
	EXEC AddAcheteur 'Pichon','Bernard','Bernard.Pichon@gmail.com','065/66.66.66','rue des blattes',42,4242,'Réponse','Univers','BE04 8452 4256 3658 8';
	EXEC AddAcheteur 'Massette','Lara','Massette.Lara@hotmail.com','065/14.36.14','rue des putes',69,7458,'Quelque part','Belgique','BE06 1458 5421 1145 8';
GO
	EXEC AddVendeur 'Titegoutte','621251442','contact@titegoutte.com','071/25.22.36','Rue des',56,1020,'Bruxelles','Belgique','BE03 2546 5845 2123 3';
	EXEC AddVendeur 'Bark Marre','12565547','mail@brak-marre.be','065/45.88.58','Rue des quatres fions',6,7080,'Jemappes','Belgique','BE09 5547 2521 1468 2';
GO
	EXEC AddEquipement '4x4','4x4';
	INSERT INTO Equipement (nom, [description]) VALUES
	('ABS','ABS'),('Accoudoir','Accoudoir'),('Affichage tête haute','Affichage tête haute'),('Air conditionné','Air conditionné'),('Airbag côté conducteur','Airbag côté conducteur'),('Airbag côté passager','Airbag côté passager'),('Airbag latéral','Airbag latéral'),('Alerte de franchissement involontaire de lignes','Alerte de franchissement involontaire de lignes'),('Anti-démarrage','Anti-démarrage'),('Assistant au freinage d''urgence','Assistant au freinage d''urgence'),('Assistant de démarrage en côte','Assistant de démarrage en côte'),('Assistant de vision nocturne','Assistant de vision nocturne'),('Attache remorque','Attache remorque'),('Avertisseur d''angle mort','Avertisseur d''angle mort'),('Bluetooth','Bluetooth'),('Caméra','Caméra'),('Capteur de lumière','Capteur de lumière'),('Capteur de pluie','Capteur de pluie'),('Capteurs de stationnement à l''arrière','Capteurs de stationnement à l''arrière'),('Capteurs de stationnement à l''avant','Capteurs de stationnement à l''avant'),('Chauffage auxiliaire','Chauffage auxiliaire'),('Climatisation automatique','Climatisation automatique'),('Commande vocale','Commande vocale'),('Contrôle de traction','Contrôle de traction'),('Détection des panneaux routiers','Détection des panneaux routiers'),('Direction assistée','Direction assistée'),('Ecran tactile','Ecran tactile'),('Equipement handicapé','Equipement handicapé'),('Equipement mains-libres','Equipement mains-libres'),('ESP','ESP'),('Feux de brouillards','Feux de brouillards'),('Fonction TV','Fonction TV'),('Hayon électrique','Hayon électrique'),('Isofix','Isofix'),('Jantes en alliage','Jantes en alliage'),('Lecteur CD','Lecteur CD'),('LED phare de jour','LED phare de jour'),('MP3','MP3'),('Ordinateur de bord','Ordinateur de bord'),('Pack sport','Pack sport'),('Palettes de changement de vitesses','Palettes de changement de vitesses'),('Pare-brise chauffant','Pare-brise chauffant'),('Phares au LED','Phares au LED'),('Phares au xénon','Phares au xénon'),('Phares de jour','Phares de jour'),('Phares directionnels','Phares directionnels'),('Porte coulissante','Porte coulissante'),('Porte-bagages','Porte-bagages'),('Radio','Radio'),('Radio numérique','Radio numérique'),('Régulateur de distance','Régulateur de distance'),('Régulateur de vitesse','Régulateur de vitesse'),('Rétroviseurs électriques','Rétroviseurs électriques'),('Sac à ski','Sac à ski'),('Siège à réglage lombaire','Siège à réglage lombaire'),('Sièges chauffants','Sièges chauffants'),('Sièges électriques ajustables','Sièges électriques ajustables'),('Sièges massants','Sièges massants'),('Sièges sports','Sièges sports'),('Sièges ventilés','Sièges ventilés'),('Soundsystem','Soundsystem'),('Start/Stop automatique','Start/Stop automatique'),('Suspension pneumatique','Suspension pneumatique'),('Suspension sport','Suspension sport'),('Système d''alarme','Système d''alarme'),('Système d''appel d''urgence','Système d''appel d''urgence'),('Système de contrôle de la pression pneus','Système de contrôle de la pression pneus'),('Système de détection de la somnolence','Système de détection de la somnolence'),('Système de navigation/GPS','Système de navigation/GPS'),('Système de stationnement automatique','Système de stationnement automatique'),('Toit ouvrant','Toit ouvrant'),('Toit panoramique','Toit panoramique'),('USB','Alimentation USB dans l''habitacle'),('Verrouillage centralisé','Verrouillage centralisé'),('Verrouillage centralisé sans clé','Verrouillage centralisé sans clé'),('Vitres électriques','Vitres électriques'),('Volant chauffant','Volant chauffant'),('Volant en cuir','Volant en cuir'),('Volant multifonction','Volant multifonction');
GO
	EXEC AddFournisseur 'Chez Mimiche','BE78 5494 6322 85','012549863','Rue de Phillipe Le Breton',45,7060,'Margouin','Belgique','fourn@mimiche.ch','065/48.22.21';
GO
	EXEC AddVoiture 'TRUZZZ8N931001685',5,'1.6 HDI Black Edition','2016-04-01','Monospace','Comme neuf',38452,141,1621,'Moncul','Diesel','Auto','Bleu marine',1,1,1;
	EXEC AddVoiture 'WDB1400321A017905',12,'2.4 RS','2018-01-01','Coupé','Neuf',5121,311,2449,'Bruxelles','Essence','Manuelle','Rouge',1,1,1;
GO
	EXEC AddDossier 1,1,2,12000,18499;
	EXEC AddDossier 2,2,NULL,28999,NULL;
GO
	EXEC AddEquipementInstalles 1,4;
	INSERT INTO Equipement_Installes (idVoiture,idEquip) VALUES
	(1,8),(1,10),(1,11),(1,16),(1,18),(1,19),(1,28),(1,34),(1,36),(1,45),(1,49),(1,55),(1,56),(2,5),(2,6),(2,11),(2,14),(2,15),(2,17),(2,19),(2,24),(2,26),(2,31),(2,35),(2,41),(2,45),(2,46),(2,49),(2,50),(2,56),(2,57),(2,59),(2,62),(2,63);
GO
	EXEC AddFrais 1,1,'Transport',254.99,1,'2018-02-21';
	EXEC AddFrais 2,1,'Transport',254.99,2,'2018-02-21';
	EXEC AddFrais 2,1,'Reprogrammation (+61cv)',489.99,3,'2018-02-24';
	EXEC AddFrais 1,1,'Nettoyage complet',69.99,4,'2018-02-25';
	EXEC AddFrais 2,1,'Nettoyage complet',69.99,5,'2018-02-25';
GO

GO
PRINT N'Mise à jour terminée.';


GO
