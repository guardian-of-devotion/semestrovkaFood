use TestDb;

GO

CREATE TABLE Users 

(
    user_id uniqueidentifier NOT NULL,
	password NVARCHAR(255) NOT NULL,
	email NVARCHAR(255) NOT NULL,
	name NVARCHAR(255) NOT NULL,
	surname NVARCHAR(255) NOT NULL,
	CONSTRAINT pk_user PRIMARY KEY(user_id)

)
GO