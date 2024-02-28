IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AdminInfo] (
    [Email] nvarchar(450) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AdminInfo] PRIMARY KEY ([Email])
);
GO

CREATE TABLE [EmpInfo] (
    [Email] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [DateOfJoining] datetime2 NOT NULL,
    [PassCode] int NOT NULL,
    CONSTRAINT [PK_EmpInfo] PRIMARY KEY ([Email])
);
GO

CREATE TABLE [BlogInfo] (
    [BlogId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Subject] nvarchar(max) NOT NULL,
    [DateOfCreation] datetime2 NOT NULL,
    [BlogUrl] nvarchar(max) NOT NULL,
    [Email] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_BlogInfo] PRIMARY KEY ([BlogId]),
    CONSTRAINT [FK_BlogInfo_EmpInfo_Email] FOREIGN KEY ([Email]) REFERENCES [EmpInfo] ([Email]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_BlogInfo_Email] ON [BlogInfo] ([Email]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240228072511_firstMig', N'6.0.13');
GO

COMMIT;
GO

