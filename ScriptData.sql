
-- A COLLER DANS QUERY

-- ROLES
Insert Into AspNetRoles(Id,Name) Values(1,'Enseignant')
Insert Into AspNetRoles(Id,Name) Values(2,'Etudiant')
-- USERS
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Role], [LastName], [FirstName]) VALUES (N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'Enseignant@Ens', N'ENSEIGNANT@ENS', N'Enseignant@Ens', N'ENSEIGNANT@ENS', 0, N'AQAAAAEAACcQAAAAEOaSrWYH+Bzket56xnb+6K1G/UfLk6FDoZmt6z5O7tgSQpM3yZuzz8Y++fn6dOMleQ==', N'YOTYRDMRKMN4M7SZN5JIWBNTP7UTDTLZ', N'e1cafde4-d24f-4862-8491-76324b0ca6f2', NULL, 0, 0, NULL, 1, 0, N'User', N'Enseignant', N'EnsNom', N'EnsPrenom')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Role], [LastName], [FirstName]) VALUES (N'54443d4d-b7b8-4f9f-beb6-d8a13028aafa', N'Etudiant@Etu', N'ETUDIANT@ETU', N'Etudiant@Etu', N'ETUDIANT@ETU', 0, N'AQAAAAEAACcQAAAAEM2Q6aJ9PfoEugBvTDimTke7lK18PKwerfqFEivpGb5bs5oB5J3BZ+bIOCjKhQFQjw==', N'JFCM42BWWR6SK52GLKP4MRGZSPSEAJSW', N'ce1f3578-bcb0-4c75-be44-431485a76ec9', NULL, 0, 0, NULL, 1, 0, N'User', N'Etudiant', N'EtuNom', N'EtuPrenom')
-- SUBJECT
Insert Into Subjects(Name) Values('Français')
Insert Into Subjects(Name) Values('Maths')
Insert Into Subjects(Name) Values('Géographie')
Insert Into Subjects(Name) Values('Histoire')
Insert Into Subjects(Name) Values('Algorithme')
Insert Into Subjects(Name) Values('Science')
Insert Into Subjects(Name) Values('Algorithme')

-- QUESTION TYPES
Insert Into TypeQuestions(Name, Wording) Values('Unique', 'Question à choix unique')
Insert Into TypeQuestions(Name, Wording) Values('Multiple', 'Question à choix multiple')
Insert Into TypeQuestions(Name, Wording) Values('VraiFaux', 'Question vraie ou fausse')
Insert Into TypeQuestions(Name, Wording) Values('Trou', 'Question à trou')

DECLARE @SUBJECT_MathsID int
SET @SUBJECT_MathsID = (select SubjectId from Subjects where Name = 'Maths')

DECLARE @SUBJECT_GéographieID int
SET @SUBJECT_GéographieID = (select SubjectId from Subjects where Name = 'Géographie')


DECLARE @TYPE_UniqueID int
SET @TYPE_UniqueID = (select TypeQuestionId from TypeQuestions where Name = 'Unique')

DECLARE @TYPE_MultipleID int
SET @TYPE_MultipleID = (select TypeQuestionId from TypeQuestions where Name = 'Multiple')

DECLARE @TYPE_VraiFauxID int
SET @TYPE_VraiFauxID = (select TypeQuestionId from TypeQuestions where Name = 'VraiFaux')

DECLARE @TYPE_TrouID int
SET @TYPE_TrouID = (select TypeQuestionId from TypeQuestions where Name = 'Trou')



-- QUESTIONS 

INSERT INTO [dbo].[Questions] ([Header], [Mark], [TypeQuestion_TypeQuestionId], [Subject_SubjectId], [AspNetUsers_Id], [CreationDate]) VALUES (N'Un mètre est égal à :', 2, @TYPE_UniqueID, @SUBJECT_MathsID, N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'2020-05-29 15:46:58')
INSERT INTO [dbo].[Questions] ([Header], [Mark], [TypeQuestion_TypeQuestionId], [Subject_SubjectId], [AspNetUsers_Id], [CreationDate]) VALUES (N'Quel est le périmètre d''un carré de 5 cm de côté ?', 6, @TYPE_UniqueID, @SUBJECT_MathsID, N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'2020-05-29 15:46:58')
INSERT INTO [dbo].[Questions] ([Header], [Mark], [TypeQuestion_TypeQuestionId], [Subject_SubjectId], [AspNetUsers_Id], [CreationDate]) VALUES (N'Un triangle équilatéral a :', 2, @TYPE_UniqueID, @SUBJECT_MathsID, N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'2020-05-29 15:46:58')
INSERT INTO [dbo].[Questions] ([Header], [Mark], [TypeQuestion_TypeQuestionId], [Subject_SubjectId], [AspNetUsers_Id], [CreationDate]) VALUES (N'1 H 40 + 1 H 40 = 3h', 4, @TYPE_VraiFauxID, @SUBJECT_MathsID, N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'2020-05-29 15:46:58')
INSERT INTO [dbo].[Questions] ([Header], [Mark], [TypeQuestion_TypeQuestionId], [Subject_SubjectId], [AspNetUsers_Id], [CreationDate]) VALUES (N'Quel calcul a pour résultat : 4', 4, @TYPE_MultipleID, @SUBJECT_MathsID, N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'2020-05-29 15:46:58')
INSERT INTO [dbo].[Questions] ([Header], [Mark], [TypeQuestion_TypeQuestionId], [Subject_SubjectId], [AspNetUsers_Id], [CreationDate]) VALUES (N'Quelle est la capitale de l''Espagne ?', 4, @TYPE_UniqueID, @SUBJECT_GéographieID, N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'2020-05-29 15:46:58')
INSERT INTO [dbo].[Questions] ([Header], [Mark], [TypeQuestion_TypeQuestionId], [Subject_SubjectId], [AspNetUsers_Id], [CreationDate]) VALUES (N'La capitale de la France est [Paris]', 4, @TYPE_TrouID, @SUBJECT_GéographieID, N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'2020-05-29 15:46:58')
INSERT INTO [dbo].[Questions] ([Header], [Mark], [TypeQuestion_TypeQuestionId], [Subject_SubjectId], [AspNetUsers_Id], [CreationDate]) VALUES (N'La capitale de la France est Venise.', 5, @TYPE_VraiFauxID, @SUBJECT_GéographieID, N'8d465dc8-75ae-40c4-9e30-be78ab8239b1', N'0001-01-01 00:00:00')

-- ANSWERS 
DECLARE @QuestionIdA int
SET @QuestionIdA = (select QuestionId from Questions where Header = 'Un mètre est égal à :')

DECLARE @QuestionIdB int
SET @QuestionIdB = (select QuestionId from Questions where Header = 'Quel est le périmètre d''un carré de 5 cm de côté ?')

DECLARE @QuestionIdC int
SET @QuestionIdC = (select QuestionId from Questions where Header = 'Un triangle équilatéral a :')

DECLARE @QuestionIdD int
SET @QuestionIdD = (select QuestionId from Questions where Header = '1 H 40 + 1 H 40 = 3h')

DECLARE @QuestionIdE int
SET @QuestionIdE = (select QuestionId from Questions where Header = 'Quel calcul a pour résultat : 4')

DECLARE @QuestionIdF int
SET @QuestionIdF = (select QuestionId from Questions where Header = 'Quelle est la capitale de l''Espagne ?')

DECLARE @QuestionIdG int
SET @QuestionIdG = (select QuestionId from Questions where Header = 'La capitale de la France est [Paris]')

DECLARE @QuestionIdH int
SET @QuestionIdH = (select QuestionId from Questions where Header = 'La capitale de la France est Venise.')

INSERT INTO [dbo].[BoolAnswers] ([Answer], [Question_QuestionId], [CreationDate]) VALUES (0, @QuestionIdD, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[BoolAnswers] ([Answer], [Question_QuestionId], [CreationDate]) VALUES (0, @QuestionIdH, N'2020-05-29 15:46:58')



INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'100mm', 0, @QuestionIdA, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'100dam', 0, @QuestionIdA, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'100cm', 1, @QuestionIdA, N'2020-05-29 15:46:58')

INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'100cm', 0, @QuestionIdB, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'20cm', 1, @QuestionIdB, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'200cm', 0, @QuestionIdB, N'2020-05-29 15:46:58')

INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'3 côtés égaux', 1, @QuestionIdC, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'1 angle droit', 0, @QuestionIdC, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'1 angle droit', 0, @QuestionIdC, N'2020-05-29 15:46:58')

INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'2 x 2', 1, @QuestionIdE, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'2 - 2', 0, @QuestionIdE, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'2 : 2', 0, @QuestionIdE, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'2 + 2', 1, @QuestionIdE, N'2020-05-29 15:46:58')

INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'Barcelone', 0, @QuestionIdF, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'Séville', 0, @QuestionIdF, N'2020-05-29 15:46:58')
INSERT INTO [dbo].[ChoiceAnswers] ([Answer], [IsRight], [Question_QuestionId], [CreationDate]) VALUES (N'Madrid', 1, @QuestionIdF, N'2020-05-29 15:46:58')



INSERT INTO [dbo].[HoleAnswers] ([Answer], [HoleLimitStart], [HoleLimitEnd], [Question_QuestionId], [CreationDate]) VALUES (N'Paris', 29, 35, @QuestionIdG, N'2020-05-29 15:46:58')

