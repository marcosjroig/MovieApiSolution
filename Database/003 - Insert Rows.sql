USE [MoviesDb]
GO

--Insert movies
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('John Wick', 2015, 'Action', 120)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('Terminator 6', 2019, 'Science Fiction/Action', 110)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('John Wick: Chapter 2', 2017, 'Action', 130)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('The Saint', 2017, 'Action', 120)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('The Interview"', 2014, 'Action/Comedy', 120)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('Mr. & Mrs. Smith', 2005, 'Crime/Thriller', 115)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('Fast & Furious 8', 2017, 'Crime/Action', 125)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('Fast & Furious 1', 2001, 'Crime/Action', 120)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('Jason Bourne', 2016, 'Action', 135)
INSERT INTO [dbo].[Movies] (Title,YearOfRelease,Genre,RunningTime) VALUES ('Iron Man 3', 2013, 'Science Fiction/Action', 110)
GO

--Inser users
INSERT INTO [dbo].[Users] (FirstName,Lastname) VALUES ('John', 'Doe')
INSERT INTO [dbo].[Users] (FirstName,Lastname) VALUES ('Jane', 'Doe')
GO

--Inser Ratings
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (1,  1, 4.1  )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (1,  2, 5.0  )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (2,  1, 4.0  )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (2,  2, 4.0  )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (3,  1, 4.0  )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (3,  2, 4.0  )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (4,  1, 3.249)
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (4,  2, 3.249)
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (5,  1, 2.0  )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (5,  2, 2.25 )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (6,  1, 1.10 )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (6,  2, 1.12 )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (7,  1, 1.09 )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (8,  1, 1.08 )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (9,  1, 1.07 )
INSERT INTO [dbo].[Ratings] (MovieId ,UserId, RatingValue) VALUES (10, 1, 1.06 )
GO




