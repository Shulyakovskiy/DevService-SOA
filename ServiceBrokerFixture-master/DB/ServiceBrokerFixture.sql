-- 05/28/2013
-- service broker empty db creation script
-- creates sample service broker db [ServiceBrokerFixture] with related objects
RAISERROR(N'Script started work', 0, 1) WITH NOWAIT
GO

USE [master]
GO

-- drop db if required
DECLARE @dropDatabase bit = 1
DECLARE @databaseExists bit = 
	(SELECT 
		CAST(COUNT(name) AS bit) 
	FROM 
		sys.databases 
	WHERE 
		name = 'ServiceBrokerFixture')

IF (@dropDatabase = 1 AND @databaseExists = 1)
BEGIN
	RAISERROR('Dropping db...', 0, 1) WITH NOWAIT
	EXEC 
		msdb.dbo.sp_delete_database_backuphistory 
		@database_name = N'ServiceBrokerFixture'

	ALTER DATABASE 
		[ServiceBrokerFixture] 
	SET 
		SINGLE_USER WITH ROLLBACK IMMEDIATE

	DROP DATABASE 
		[ServiceBrokerFixture]
END

-- check db existence
SET @databaseExists = 
	(SELECT 
		CAST(COUNT(name) AS bit) 
	FROM 
		sys.databases 
	WHERE 
		name = 'ServiceBrokerFixture')
IF (@databaseExists = 1)
BEGIN
	RAISERROR('ServiceBrokerFixture already exists!', 20, -1) WITH LOG
END
GO

-- get paths to db files
DECLARE @dataPath varchar(max) = 
	(SELECT 
		SUBSTRING(physical_name, 1, CHARINDEX(N'master.mdf', LOWER(physical_name)) - 1)
	FROM 
		master.sys.master_files
    WHERE 
		database_id = 1 AND 
		file_id = 1)
DECLARE @mdfPath varchar(max) = @dataPath + N'ServiceBrokerFixture.mdf'
DECLARE @ldfPath varchar(max) = @dataPath + N'ServiceBrokerFixture_log.ldf'


-- create db
RAISERROR(N'Creating db files...', 0, 1) WITH NOWAIT
EXECUTE('
	CREATE DATABASE 
		[ServiceBrokerFixture]
	CONTAINMENT = NONE
	ON PRIMARY 
		(NAME = N''ServiceBrokerFixture'', 
		FILENAME = N''' + @mdfPath + ''', 
		SIZE = 128MB , 
		MAXSIZE = 1024MB, 
		FILEGROWTH = 128MB)
	LOG ON 
		(NAME = N''ServiceBrokerFixture_log'', 
		FILENAME = N''' + @ldfPath + ''' , 
		SIZE = 128MB , 
		MAXSIZE = 1024MB , 
		FILEGROWTH = 128MB )')
GO


-- set db options
RAISERROR(N'Setting db options...', 0, 1) WITH NOWAIT
-- set recovery model
ALTER DATABASE [ServiceBrokerFixture] SET RECOVERY SIMPLE
GO

-- set sql server 2012 compatibility level
ALTER DATABASE [ServiceBrokerFixture] SET COMPATIBILITY_LEVEL = 110
GO

-- enable broker
ALTER DATABASE ServiceBrokerFixture SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE
GO

ALTER DATABASE [ServiceBrokerFixture] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET ARITHABORT OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ServiceBrokerFixture] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ServiceBrokerFixture] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ServiceBrokerFixture] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ServiceBrokerFixture] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ServiceBrokerFixture] SET  MULTI_USER 
GO
ALTER DATABASE [ServiceBrokerFixture] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ServiceBrokerFixture] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ServiceBrokerFixture] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ServiceBrokerFixture] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ServiceBrokerFixture', N'ON'
GO


-- create db objects
USE [ServiceBrokerFixture]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- tables
RAISERROR(N'Creating tables...', 0, 1) WITH NOWAIT
CREATE TABLE 
	[dbo].[TableIn]
	([Id] [int] IDENTITY(1,1) NOT NULL,
	[BatchId] [uniqueidentifier] NOT NULL,
	[MessageBody] [xml] NOT NULL,
	CONSTRAINT [PK_TableIn] PRIMARY KEY CLUSTERED 
		([Id] ASC) 
	WITH 
		(PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON)
	ON [PRIMARY]) 
ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


-- indexes
RAISERROR(N'Creating indexes...', 0, 1) WITH NOWAIT
CREATE NONCLUSTERED INDEX 
	[IX_TableIn] 
ON 
	[dbo].[TableIn]
	([BatchId] ASC)
WITH 
	(PAD_INDEX = OFF, 
	STATISTICS_NORECOMPUTE = OFF, 
	SORT_IN_TEMPDB = OFF, 
	DROP_EXISTING = OFF,
	ONLINE = OFF,
	ALLOW_ROW_LOCKS = ON,
	ALLOW_PAGE_LOCKS = ON) 
ON [PRIMARY]
GO


-- xml schemas
RAISERROR(N'Creating xml schemas...', 0, 1) WITH NOWAIT
CREATE XML SCHEMA COLLECTION 
	InMessageSchema AS
N'<?xml version="1.0" encoding="UTF-16" ?>
	<xsd:schema elementFormDefault="qualified" xmlns:xsd="http://www.w3.org/2001/XMLSchema"> 
		<xsd:element name="InMessage">
			<xsd:complexType>
				<xsd:sequence>
					<xsd:element name="Id" type="xsd:string"/>
					<xsd:element name="Payload" type="xsd:string"/>
					<xsd:element name="Produced" type="xsd:integer"/>
				</xsd:sequence>
			</xsd:complexType>
		</xsd:element>
	</xsd:schema>'
GO

CREATE XML SCHEMA COLLECTION 
	OutMessageSchema AS
N'<?xml version="1.0" encoding="UTF-16" ?>
	<xsd:schema elementFormDefault="qualified" xmlns:xsd="http://www.w3.org/2001/XMLSchema"> 
		<xsd:element name="OutMessage">
			<xsd:complexType>
				<xsd:sequence>
					<xsd:element name="Id" type="xsd:string"/>
					<xsd:element name="Payload" type="xsd:string"/>
					<xsd:element name="Produced" type="xsd:integer"/>
					<xsd:element name="MapperActivated" type="xsd:integer"/>
					<xsd:element name="MapperConnected" type="xsd:integer"/>
					<xsd:element name="MapperPreDequeued" type="xsd:integer"/>
					<xsd:element name="MapperPostDequeued" type="xsd:integer"/>
					<xsd:element name="MapperReceived" type="xsd:integer"/>
					<xsd:element name="MapperSent" type="xsd:integer"/>
					<xsd:element name="ServiceReceived" type="xsd:integer"/>
					<xsd:element name="ServiceSent" type="xsd:integer"/>
					<xsd:element name="ServiceResponded" type="xsd:integer"/>
				</xsd:sequence>
			</xsd:complexType>
		</xsd:element>
	</xsd:schema>'
GO


-- service broker message types
RAISERROR(N'Creating service broker message types...', 0, 1) WITH NOWAIT
CREATE MESSAGE TYPE 
	[InMessage] 
VALIDATION = VALID_XML WITH SCHEMA COLLECTION InMessageSchema
GO

CREATE MESSAGE TYPE 
	[OutMessage] 
VALIDATION = VALID_XML WITH SCHEMA COLLECTION OutMessageSchema
GO


-- service broker contracts
RAISERROR(N'Creating service broker contracts...', 0, 1) WITH NOWAIT
CREATE CONTRACT 
	[InContract] 
	([InMessage] SENT BY INITIATOR)
GO

CREATE CONTRACT 
	[OutContract] 
	([OutMessage] SENT BY INITIATOR)
GO


-- service broker queues
RAISERROR(N'Creating service broker queue...', 0, 1) WITH NOWAIT
CREATE QUEUE 
	[dbo].[InQueue] 
WITH 
	STATUS = ON , 
	RETENTION = OFF , 
	POISON_MESSAGE_HANDLING (STATUS = ON)  
	ON [PRIMARY] 
GO

CREATE QUEUE 
	[dbo].[OutQueue] 
WITH 
	STATUS = ON, 
	RETENTION = OFF, 
	POISON_MESSAGE_HANDLING (STATUS = ON) 
	ON [PRIMARY] 
GO

CREATE QUEUE 
	[dbo].[InNotificationQueue] 
WITH 
	STATUS = ON, 
	RETENTION = OFF, 
	POISON_MESSAGE_HANDLING (STATUS = ON) 
	ON [PRIMARY] 
GO


-- service broker services
RAISERROR(N'Creating service broker services...', 0, 1) WITH NOWAIT
CREATE SERVICE 
	[InFromService] 
ON QUEUE 
	[dbo].[InQueue] 
	([InContract])
GO

CREATE SERVICE 
	[InToService] 
ON QUEUE 
	[dbo].[InQueue] 
	([InContract])
GO

CREATE SERVICE 
	[OutFromService]
ON QUEUE 
	[dbo].[OutQueue] 
	([OutContract])
GO

CREATE SERVICE 
	[OutToService]
ON QUEUE 
	[dbo].[OutQueue]
	([OutContract])
GO

CREATE SERVICE 
	[InNotificationService] 
ON QUEUE 
	[dbo].[InNotificationQueue] 
	([http://schemas.microsoft.com/SQL/Notifications/PostEventNotification])
GO


-- event notifications
RAISERROR(N'Creating event notifications...', 0, 1) WITH NOWAIT
CREATE EVENT NOTIFICATION 
	InEventNotification
ON QUEUE 
	InQueue
FOR QUEUE_ACTIVATION
TO SERVICE 
	'InNotificationService' , 'current database'
GO


-- stored procedures
-- SP_DequeueIn
RAISERROR(N'Creating stored procedures...', 0, 1) WITH NOWAIT
GO
CREATE PROCEDURE [dbo].[DequeueIn] 
	@batchSize int,
	@batchId uniqueidentifier OUTPUT
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRAN
		SET @batchId = NEWID()

        DECLARE 
			@batch 
		TABLE
			(QueuingOrder bigint,
			ConversationHandle uniqueidentifier,
			MessageTypeName nvarchar(max),
			MessageBody xml)

        DECLARE 
			batchCursor
		CURSOR FORWARD_ONLY READ_ONLY
		FOR 
			SELECT 
				ConversationHandle,
				MessageTypeName
			FROM 
				@batch
			WHERE
				MessageTypeName = N'InMessage'
			ORDER BY 
				QueuingOrder

        WHILE(1=1)
        BEGIN
		    WAITFOR
			    (RECEIVE TOP(@batchSize)
				    queuing_order AS QueuingOrder,
				    conversation_handle AS ConversationHandle,
				    message_type_name AS MessageTypeName,
				    CAST(message_body AS xml) AS MessageBody
		    FROM
			    InQueue
		    INTO
			    @batch), 
		    TIMEOUT 0

		    IF @@rowcount = 0
			    BREAK
			
			DECLARE @conversationHandle uniqueidentifier 
			DECLARE @messageTypeName nvarchar(max)

			OPEN 
				batchCursor

			WHILE (1=1)
			BEGIN
				FETCH NEXT FROM 
					batchCursor
				INTO 
					@conversationHandle, 
					@messageTypeName

				IF (@@FETCH_STATUS != 0)
					BREAK

				END CONVERSATION @conversationHandle
			END

			CLOSE 
				batchCursor

			INSERT INTO
				[dbo].[TableIn]
				(BatchId,
				MessageBody)
			SELECT
				@batchId,
				MessageBody
			FROM
				@batch
			WHERE
				MessageTypeName = N'InMessage'

			DELETE FROM 
				@batch
		END

        SELECT
            COUNT(Id)
        FROM
            [dbo].[TableIn]
        WHERE
            [BatchId] = @batchId
	COMMIT TRAN
END
GO

-- SP_DequeueOut
CREATE PROCEDURE [dbo].[DequeueOut] 
	@messageBody xml OUTPUT
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRAN
		DECLARE @conversationHandle uniqueidentifier 
		DECLARE @messageTypeName nvarchar(max)

		WAITFOR(RECEIVE TOP(1)
			@conversationHandle = conversation_handle,
			@messageTypeName = message_type_name,
			@messageBody = CAST(message_body AS xml)
		FROM
			OutQueue), 
		TIMEOUT 0

		IF @@rowcount = 0
			SELECT 0
		ELSE
		BEGIN
			END CONVERSATION @conversationHandle

			IF @messageTypeName = N'OutMessage'
				SELECT 1
			ELSE
				SELECT NULL
		END
	COMMIT TRAN
END
GO

-- SP_EnqueueIn
CREATE PROCEDURE [dbo].[EnqueueIn]
	@messageBody xml
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRAN
		DECLARE @conversationHandle uniqueidentifier

		BEGIN DIALOG 
			CONVERSATION @conversationHandle
			FROM SERVICE [InFromService]
			TO SERVICE 'InToService'
			ON CONTRACT [InContract]
			WITH ENCRYPTION = OFF;

		SEND ON CONVERSATION @conversationHandle MESSAGE TYPE [InMessage] (@messageBody)

		END CONVERSATION @conversationHandle

		SELECT 1
	COMMIT TRAN
END
GO

-- SP_EnqueueOut
CREATE PROCEDURE [dbo].[EnqueueOut]
	@messageBody xml
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRAN
		DECLARE @conversationHandle uniqueidentifier

		BEGIN DIALOG 
			CONVERSATION @conversationHandle
			FROM SERVICE [OutFromService]
			TO SERVICE 'OutToService'
			ON CONTRACT [OutContract]
			WITH ENCRYPTION = OFF;

		SEND ON CONVERSATION @conversationHandle MESSAGE TYPE [OutMessage] (@messageBody)

		END CONVERSATION @conversationHandle

		SELECT 1
	COMMIT TRAN
END
GO

-- SP_ListenOut
CREATE PROCEDURE [dbo].[ListenOut] 
	@timeout int,
	@messageBody xml OUTPUT
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRAN
		DECLARE @conversationHandle uniqueidentifier 
		DECLARE @messageTypeName nvarchar(max)

		WAITFOR(RECEIVE TOP(1)
			@conversationHandle = conversation_handle,
			@messageTypeName = message_type_name,
			@messageBody = CAST(message_body AS xml)
		FROM
			OutQueue), 
		TIMEOUT @timeout

		IF @@rowcount = 0
			SELECT 0
		ELSE
		BEGIN
			END CONVERSATION @conversationHandle

			IF @messageTypeName = N'OutMessage'
				SELECT 1
			ELSE
				SELECT NULL
		END
	COMMIT TRAN
END
GO


-- SP_TruncateIn
CREATE PROCEDURE [dbo].[TruncateIn]
	@batchId uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON

    DELETE FROM
        TableIn
    WHERE
        [BatchId] = @batchId

    SELECT @@ROWCOUNT
END
GO


-- table-valued functions
-- TVF_GetIn
CREATE FUNCTION [dbo].[GetIn]
	(@batchId uniqueidentifier)
RETURNS TABLE 
AS
RETURN 
(
	SELECT
		[MessageBody]
	FROM
		[dbo].[TableIn]
	WITH 
		(NOLOCK) 
	WHERE
		[BatchId] = @batchId
)
GO

-- finish
RAISERROR(N'Almost done...', 0, 1) WITH NOWAIT
USE [master]
GO

ALTER DATABASE [ServiceBrokerFixture] SET READ_WRITE 
GO

RAISERROR(N'Script finished work', 0, 1) WITH NOWAIT
GO