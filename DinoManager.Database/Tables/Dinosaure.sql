CREATE TABLE [dbo].[Dinosaure]
(
	[Id] INT NOT NULL IDENTITY, 
	[Espece] NVARCHAR(128) NOT NULL,
	[Poids] INT NOT NULL,
	[Taille] INT NOT NULL,
    CONSTRAINT [PK_Dinosaure] PRIMARY KEY ([Id]) 
)
