CREATE PROCEDURE [dbo].[DeleteDinosaure]
	@Id INT
AS
BEGIN
	DELETE 
	FROM [dbo].[Dinosaure]
	WHERE [Id] = @Id
END
