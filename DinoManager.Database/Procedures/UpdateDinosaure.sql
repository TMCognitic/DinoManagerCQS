CREATE PROCEDURE [dbo].[UpdateDinosaure]
	@Id INT, 
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

		UPDATE [dbo].[Dinosaure] 
		SET	[Espece] = @Espece, 
			[Poids] = @Poids, 
			[Taille] = @Taille		
		WHERE Id = @Id;
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END

