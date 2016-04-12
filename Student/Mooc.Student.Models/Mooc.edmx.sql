
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2016 13:05:53
-- Generated from EDMX file: C:\Users\gfli\Source\Repos\Mooc2\Student\StudentClient.Models\Mooc.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Mooc];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Answers_Homeworks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_Answers_Homeworks];
GO
IF OBJECT_ID(N'[dbo].[FK_Answers_Students]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_Answers_Students];
GO
IF OBJECT_ID(N'[dbo].[FK_Courses_Teachers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK_Courses_Teachers];
GO
IF OBJECT_ID(N'[dbo].[FK_Homeworks_Courses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Homeworks] DROP CONSTRAINT [FK_Homeworks_Courses];
GO
IF OBJECT_ID(N'[dbo].[FK_Notes_Courses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_Notes_Courses];
GO
IF OBJECT_ID(N'[dbo].[FK_Notes_Students]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_Notes_Students];
GO
IF OBJECT_ID(N'[dbo].[FK_Schools_Students]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Schools] DROP CONSTRAINT [FK_Schools_Students];
GO
IF OBJECT_ID(N'[dbo].[FK_Teachers_Schools]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teachers] DROP CONSTRAINT [FK_Teachers_Schools];
GO
IF OBJECT_ID(N'[dbo].[FK_Videos_Courses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Videos] DROP CONSTRAINT [FK_Videos_Courses];
GO
IF OBJECT_ID(N'[dbo].[FK_Videos_Teachers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Videos] DROP CONSTRAINT [FK_Videos_Teachers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Answers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answers];
GO
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Homeworks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Homeworks];
GO
IF OBJECT_ID(N'[dbo].[Notes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notes];
GO
IF OBJECT_ID(N'[dbo].[Schools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schools];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teachers];
GO
IF OBJECT_ID(N'[dbo].[Videos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Videos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Answers'
CREATE TABLE [dbo].[Answers] (
    [Answer_Id] uniqueidentifier  NOT NULL,
    [Answer_Student] uniqueidentifier  NOT NULL,
    [Answer_Homework] uniqueidentifier  NOT NULL,
    [Answer_Context] nvarchar(500)  NOT NULL,
    [Answer_IsDel] bit  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Course_Id] uniqueidentifier  NOT NULL,
    [Course_Name] nvarchar(50)  NOT NULL,
    [Course_Teacher] uniqueidentifier  NOT NULL,
    [Course_IsGeneral] bit  NOT NULL,
    [Course_Week] nvarchar(50)  NOT NULL,
    [Course_IsOpen] bit  NOT NULL,
    [Course_DayOfWeek] nvarchar(10)  NOT NULL,
    [Course_Time] time  NOT NULL,
    [Course_Password] nvarchar(100)  NOT NULL,
    [Course_College] nvarchar(50)  NOT NULL,
    [Course_Major] nvarchar(50)  NOT NULL,
    [Course_IsDel] bit  NOT NULL,
    [Course_IsOffline] bit  NOT NULL
);
GO

-- Creating table 'Homeworks'
CREATE TABLE [dbo].[Homeworks] (
    [Homework_Id] uniqueidentifier  NOT NULL,
    [Homework_Course] uniqueidentifier  NOT NULL,
    [Homework_CourseNum] int  NOT NULL,
    [Homework_Type] int  NOT NULL,
    [Homework_Context] nvarchar(500)  NOT NULL,
    [Homework_IsDel] bit  NOT NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [Note_Id] uniqueidentifier  NOT NULL,
    [Note_Course] uniqueidentifier  NOT NULL,
    [Note_Student] uniqueidentifier  NOT NULL,
    [Note_Context] nvarchar(500)  NOT NULL,
    [Note_IsDel] bit  NOT NULL
);
GO

-- Creating table 'Schools'
CREATE TABLE [dbo].[Schools] (
    [School_Id] uniqueidentifier  NOT NULL,
    [School_Name] nvarchar(50)  NOT NULL,
    [School_Logo] nvarchar(50)  NOT NULL,
    [School_Introduction] nvarchar(250)  NOT NULL,
    [School_IsRegister] bit  NOT NULL,
    [School_IsOpen] bit  NOT NULL,
    [School_Admin] uniqueidentifier  NOT NULL,
    [School_IsDel] bit  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Student_Id] uniqueidentifier  NOT NULL,
    [Student_StuId] nvarchar(11)  NOT NULL,
    [Student_Password] nvarchar(150)  NOT NULL,
    [Student_Email] nvarchar(50)  NOT NULL,
    [Student_School] uniqueidentifier  NOT NULL,
    [Student_Name] nvarchar(50)  NOT NULL,
    [Student_StartDate] datetime  NOT NULL,
    [Student_College] nvarchar(50)  NOT NULL,
    [Student_Class] nvarchar(50)  NOT NULL,
    [Student_Image] nvarchar(50)  NOT NULL,
    [Student_Major] nvarchar(50)  NOT NULL,
    [Student_Sex] bit  NOT NULL,
    [Student_IsDel] bit  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Teachers'
CREATE TABLE [dbo].[Teachers] (
    [Teacher_Id] uniqueidentifier  NOT NULL,
    [Teacher_TeaId] nvarchar(20)  NOT NULL,
    [Teacher_Password] nvarchar(200)  NOT NULL,
    [Teacher_Email] nvarchar(50)  NOT NULL,
    [Teacher_School] uniqueidentifier  NOT NULL,
    [Teacher_Name] nvarchar(50)  NOT NULL,
    [Teacher_College] nvarchar(50)  NOT NULL,
    [Teacher_Image] nvarchar(50)  NOT NULL,
    [Teacher_Sex] bit  NOT NULL,
    [Teacher_IsDel] bit  NOT NULL
);
GO

-- Creating table 'Videos'
CREATE TABLE [dbo].[Videos] (
    [Video_Id] uniqueidentifier  NOT NULL,
    [Video_Major] nvarchar(50)  NOT NULL,
    [Video_Name] nvarchar(50)  NOT NULL,
    [Video_Address] nvarchar(50)  NOT NULL,
    [Video_Teacher] uniqueidentifier  NOT NULL,
    [Video_College] nvarchar(50)  NOT NULL,
    [Video_IsGeneral] bit  NOT NULL,
    [Video_Password] nvarchar(100)  NOT NULL,
    [Video_IsOpen] bit  NOT NULL,
    [Video_IsDel] bit  NOT NULL,
    [Video_CourseID] uniqueidentifier  NOT NULL,
    [Video_SerialNumber] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Answer_Id] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [PK_Answers]
    PRIMARY KEY CLUSTERED ([Answer_Id] ASC);
GO

-- Creating primary key on [Course_Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Course_Id] ASC);
GO

-- Creating primary key on [Homework_Id] in table 'Homeworks'
ALTER TABLE [dbo].[Homeworks]
ADD CONSTRAINT [PK_Homeworks]
    PRIMARY KEY CLUSTERED ([Homework_Id] ASC);
GO

-- Creating primary key on [Note_Id] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [PK_Notes]
    PRIMARY KEY CLUSTERED ([Note_Id] ASC);
GO

-- Creating primary key on [School_Id] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [PK_Schools]
    PRIMARY KEY CLUSTERED ([School_Id] ASC);
GO

-- Creating primary key on [Student_Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Student_Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Teacher_Id] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [PK_Teachers]
    PRIMARY KEY CLUSTERED ([Teacher_Id] ASC);
GO

-- Creating primary key on [Video_Id] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [PK_Videos]
    PRIMARY KEY CLUSTERED ([Video_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Answer_Homework] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [FK_Answers_Homeworks]
    FOREIGN KEY ([Answer_Homework])
    REFERENCES [dbo].[Homeworks]
        ([Homework_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Answers_Homeworks'
CREATE INDEX [IX_FK_Answers_Homeworks]
ON [dbo].[Answers]
    ([Answer_Homework]);
GO

-- Creating foreign key on [Answer_Student] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [FK_Answers_Students]
    FOREIGN KEY ([Answer_Student])
    REFERENCES [dbo].[Students]
        ([Student_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Answers_Students'
CREATE INDEX [IX_FK_Answers_Students]
ON [dbo].[Answers]
    ([Answer_Student]);
GO

-- Creating foreign key on [Course_Teacher] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_Courses_Teachers]
    FOREIGN KEY ([Course_Teacher])
    REFERENCES [dbo].[Teachers]
        ([Teacher_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Courses_Teachers'
CREATE INDEX [IX_FK_Courses_Teachers]
ON [dbo].[Courses]
    ([Course_Teacher]);
GO

-- Creating foreign key on [Homework_Course] in table 'Homeworks'
ALTER TABLE [dbo].[Homeworks]
ADD CONSTRAINT [FK_Homeworks_Courses]
    FOREIGN KEY ([Homework_Course])
    REFERENCES [dbo].[Courses]
        ([Course_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Homeworks_Courses'
CREATE INDEX [IX_FK_Homeworks_Courses]
ON [dbo].[Homeworks]
    ([Homework_Course]);
GO

-- Creating foreign key on [Note_Course] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_Notes_Courses]
    FOREIGN KEY ([Note_Course])
    REFERENCES [dbo].[Courses]
        ([Course_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Notes_Courses'
CREATE INDEX [IX_FK_Notes_Courses]
ON [dbo].[Notes]
    ([Note_Course]);
GO

-- Creating foreign key on [Note_Student] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_Notes_Students]
    FOREIGN KEY ([Note_Student])
    REFERENCES [dbo].[Students]
        ([Student_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Notes_Students'
CREATE INDEX [IX_FK_Notes_Students]
ON [dbo].[Notes]
    ([Note_Student]);
GO

-- Creating foreign key on [School_Id] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [FK_Schools_Students]
    FOREIGN KEY ([School_Id])
    REFERENCES [dbo].[Students]
        ([Student_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teacher_School] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [FK_Teachers_Schools]
    FOREIGN KEY ([Teacher_School])
    REFERENCES [dbo].[Schools]
        ([School_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Teachers_Schools'
CREATE INDEX [IX_FK_Teachers_Schools]
ON [dbo].[Teachers]
    ([Teacher_School]);
GO

-- Creating foreign key on [Video_Teacher] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [FK_Videos_Teachers]
    FOREIGN KEY ([Video_Teacher])
    REFERENCES [dbo].[Teachers]
        ([Teacher_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Videos_Teachers'
CREATE INDEX [IX_FK_Videos_Teachers]
ON [dbo].[Videos]
    ([Video_Teacher]);
GO

-- Creating foreign key on [Video_CourseID] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [FK_Videos_Courses]
    FOREIGN KEY ([Video_CourseID])
    REFERENCES [dbo].[Courses]
        ([Course_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Videos_Courses'
CREATE INDEX [IX_FK_Videos_Courses]
ON [dbo].[Videos]
    ([Video_CourseID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------