CREATE DATABASE [ITM] ON  PRIMARY 
( NAME = N'ITM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ITM.mdf' , SIZE = 3072KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ITM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ITM_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)

GO

use [ITM];

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('switch'))
BEGIN;
    DROP TABLE [switch];
END;
GO


CREATE TABLE [switch] (
    [switchID] INTEGER NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL,
    PRIMARY KEY ([switchID])
);

GO
CREATE TABLE [status] (
    [statusID] INTEGER NOT NULL IDENTITY(1, 1) ,
    [switchID] INTEGER FOREIGN KEY REFERENCES [switch]([switchID]),
    [datetime] DATETIME NOT NULL CONSTRAINT ITM_status_DATE DEFAULT GETDATE(),
    [action] VARCHAR(2) NOT NULL CHECK ([action] IN('+1', '-1'))
    PRIMARY KEY ([statusID])
);

GO

INSERT INTO switch([Name]) VALUES('Commutator 1'),('Commutator 2'),('Commutator 3'),('Commutator 4'),('Commutator 5'),('Commutator 6'),('Commutator 7'),('Commutator 8'),('Commutator 9'),('Commutator 10');
INSERT INTO switch([Name]) VALUES('Commutator 11'),('Commutator 12'),('Commutator 13'),('Commutator 14'),('Commutator 15'),('Commutator 16'),('Commutator 17'),('Commutator 18'),('Commutator 19'),('Commutator 20');
INSERT INTO switch([Name]) VALUES('Commutator 21'),('Commutator 22'),('Commutator 23'),('Commutator 24'),('Commutator 25'),('Commutator 26'),('Commutator 27'),('Commutator 28'),('Commutator 29'),('Commutator 30');
INSERT INTO switch([Name]) VALUES('Commutator 31'),('Commutator 32'),('Commutator 33'),('Commutator 34'),('Commutator 35'),('Commutator 36'),('Commutator 37'),('Commutator 38'),('Commutator 39'),('Commutator 40');
INSERT INTO switch([Name]) VALUES('Commutator 41'),('Commutator 42'),('Commutator 43'),('Commutator 44'),('Commutator 45'),('Commutator 46'),('Commutator 47'),('Commutator 48'),('Commutator 49'),('Commutator 50');
INSERT INTO switch([Name]) VALUES('Commutator 51'),('Commutator 52'),('Commutator 53'),('Commutator 54'),('Commutator 55'),('Commutator 56'),('Commutator 57'),('Commutator 58'),('Commutator 59'),('Commutator 60');
INSERT INTO switch([Name]) VALUES('Commutator 61'),('Commutator 62'),('Commutator 63'),('Commutator 64'),('Commutator 65'),('Commutator 66'),('Commutator 67'),('Commutator 68'),('Commutator 69'),('Commutator 70');
INSERT INTO switch([Name]) VALUES('Commutator 71'),('Commutator 72'),('Commutator 73'),('Commutator 74'),('Commutator 75'),('Commutator 76'),('Commutator 77'),('Commutator 78'),('Commutator 79'),('Commutator 80');
INSERT INTO switch([Name]) VALUES('Commutator 81'),('Commutator 82'),('Commutator 83'),('Commutator 84'),('Commutator 85'),('Commutator 86'),('Commutator 87'),('Commutator 88'),('Commutator 89'),('Commutator 90');
INSERT INTO switch([Name]) VALUES('Commutator 91'),('Commutator 92'),('Commutator 93'),('Commutator 94'),('Commutator 95'),('Commutator 96'),('Commutator 97'),('Commutator 98'),('Commutator 99'),('Commutator 100');
GO

INSERT INTO status([switchID],[datetime],[action]) VALUES(1,'2015-01-01 00:00:00','+1'),(2,'2015-01-01 00:00:00','+1'),(3,'2015-01-01 00:00:00','+1'),(4,'2015-01-01 00:00:00','+1'),(5,'2015-01-01 00:00:00','+1'),(6,'2015-01-01 00:00:00','+1'),(7,'2015-01-01 00:00:00','+1'),(8,'2015-01-01 00:00:00','+1'),(9,'2015-01-01 00:00:00','+1'),(10,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(11,'2015-01-01 00:00:00','+1'),(12,'2015-01-01 00:00:00','+1'),(13,'2015-01-01 00:00:00','+1'),(14,'2015-01-01 00:00:00','+1'),(15,'2015-01-01 00:00:00','+1'),(16,'2015-01-01 00:00:00','+1'),(17,'2015-01-01 00:00:00','+1'),(18,'2015-01-01 00:00:00','+1'),(19,'2015-01-01 00:00:00','+1'),(20,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(21,'2015-01-01 00:00:00','+1'),(22,'2015-01-01 00:00:00','+1'),(23,'2015-01-01 00:00:00','+1'),(24,'2015-01-01 00:00:00','+1'),(25,'2015-01-01 00:00:00','+1'),(26,'2015-01-01 00:00:00','+1'),(27,'2015-01-01 00:00:00','+1'),(28,'2015-01-01 00:00:00','+1'),(29,'2015-01-01 00:00:00','+1'),(30,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(31,'2015-01-01 00:00:00','+1'),(32,'2015-01-01 00:00:00','+1'),(33,'2015-01-01 00:00:00','+1'),(34,'2015-01-01 00:00:00','+1'),(35,'2015-01-01 00:00:00','+1'),(36,'2015-01-01 00:00:00','+1'),(37,'2015-01-01 00:00:00','+1'),(38,'2015-01-01 00:00:00','+1'),(39,'2015-01-01 00:00:00','+1'),(40,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(41,'2015-01-01 00:00:00','+1'),(42,'2015-01-01 00:00:00','+1'),(43,'2015-01-01 00:00:00','+1'),(44,'2015-01-01 00:00:00','+1'),(45,'2015-01-01 00:00:00','+1'),(46,'2015-01-01 00:00:00','+1'),(47,'2015-01-01 00:00:00','+1'),(48,'2015-01-01 00:00:00','+1'),(49,'2015-01-01 00:00:00','+1'),(50,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(51,'2015-01-01 00:00:00','+1'),(52,'2015-01-01 00:00:00','+1'),(53,'2015-01-01 00:00:00','+1'),(54,'2015-01-01 00:00:00','+1'),(55,'2015-01-01 00:00:00','+1'),(56,'2015-01-01 00:00:00','+1'),(57,'2015-01-01 00:00:00','+1'),(58,'2015-01-01 00:00:00','+1'),(59,'2015-01-01 00:00:00','+1'),(60,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(61,'2015-01-01 00:00:00','+1'),(62,'2015-01-01 00:00:00','+1'),(63,'2015-01-01 00:00:00','+1'),(64,'2015-01-01 00:00:00','+1'),(65,'2015-01-01 00:00:00','+1'),(66,'2015-01-01 00:00:00','+1'),(67,'2015-01-01 00:00:00','+1'),(68,'2015-01-01 00:00:00','+1'),(69,'2015-01-01 00:00:00','+1'),(70,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(71,'2015-01-01 00:00:00','+1'),(72,'2015-01-01 00:00:00','+1'),(73,'2015-01-01 00:00:00','+1'),(74,'2015-01-01 00:00:00','+1'),(75,'2015-01-01 00:00:00','+1'),(76,'2015-01-01 00:00:00','+1'),(77,'2015-01-01 00:00:00','+1'),(78,'2015-01-01 00:00:00','+1'),(79,'2015-01-01 00:00:00','+1'),(80,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(81,'2015-01-01 00:00:00','+1'),(82,'2015-01-01 00:00:00','+1'),(83,'2015-01-01 00:00:00','+1'),(84,'2015-01-01 00:00:00','+1'),(85,'2015-01-01 00:00:00','+1'),(86,'2015-01-01 00:00:00','+1'),(87,'2015-01-01 00:00:00','+1'),(88,'2015-01-01 00:00:00','+1'),(89,'2015-01-01 00:00:00','+1'),(90,'2015-01-01 00:00:00','+1');
INSERT INTO status([switchID],[datetime],[action]) VALUES(91,'2015-01-01 00:00:00','+1'),(92,'2015-01-01 00:00:00','+1'),(93,'2015-01-01 00:00:00','+1'),(94,'2015-01-01 00:00:00','+1'),(95,'2015-01-01 00:00:00','+1'),(96,'2015-01-01 00:00:00','+1'),(97,'2015-01-01 00:00:00','+1'),(98,'2015-01-01 00:00:00','+1'),(99,'2015-01-01 00:00:00','+1'),(100,'2015-01-01 00:00:00','+1');

go


CREATE PROCEDURE [dbo].[sp_AddFakeDataToStatus] as
BEGIN

    DECLARE @SwitchIterator smallint
    DECLARE @StatusIterator smallint
    DECLARE @datetime DATETIME
    DECLARE @action VARCHAR(2)
    
    SET @SwitchIterator = 1
    
    WHILE @SwitchIterator <= 100
    begin
    set @StatusIterator = 0
       while @StatusIterator < 4
       begin
       set @datetime = (select top 1 status.datetime
                        from [status]
                        inner join switch on status.switchID = switch.switchID
                        where switch.switchID = @SwitchIterator order by status.datetime desc)
       set @action = (select top 1 status.action
                      from [status]
                      inner join switch on status.switchID = switch.switchID
                      where switch.switchID = @SwitchIterator order by status.datetime desc)
                      
                      
       IF @action = '+1' BEGIN set @action = '-1' END ELSE BEGIN set @action = '+1' END
       
       INSERT INTO status([switchID],[datetime],[action]) VALUES(@SwitchIterator, DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % 86400, @datetime), @action) 
                    
       SET @StatusIterator = @StatusIterator + 1
       end 
       SET @SwitchIterator = @SwitchIterator + 1
    END
END

go
exec [dbo].[sp_AddFakeDataToStatus]
