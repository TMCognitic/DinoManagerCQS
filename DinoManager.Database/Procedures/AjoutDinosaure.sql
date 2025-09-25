CREATE PROCEDURE [dbo].[AjoutDinosaure]
	@Espece NVARCHAR(128),
	@Poids INT,
	@Taille INT
AS
BEGIN
	BEGIN TRY
		IF LEN(TRIM(@Espece)) = 0
			RAISERROR('L''espèce ne peut pas être vide.', 16, 1);

		IF @Poids <= 0
			RAISERROR('Le poids doit être positif.', 16, 1);

		IF @Taille <= 0
			RAISERROR('La taille doit être positive.', 16, 1);

		INSERT INTO [dbo].[Dinosaure] ([Espece], [Poids], [Taille])
		VALUES (@Espece, @Poids, @Taille)
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
