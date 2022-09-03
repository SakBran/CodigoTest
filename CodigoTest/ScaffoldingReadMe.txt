dotnet aspnet-codegenerator identity -dc WorldCities.Data.ApplicationDbContext --files "Account.Register"

File List:
Account._StatusMessage
Account.AccessDenied
Account.ConfirmEmail
Account.ConfirmEmailChange
Account.ExternalLogin
Account.ForgotPassword
Account.ForgotPasswordConfirmation
Account.Lockout
Account.Login
Account.LoginWith2fa
Account.LoginWithRecoveryCode
Account.Logout
Account.Manage._Layout
Account.Manage._ManageNav
Account.Manage._StatusMessage
Account.Manage.ChangePassword
Account.Manage.DeletePersonalData
Account.Manage.Disable2fa
Account.Manage.DownloadPersonalData
Account.Manage.Email
Account.Manage.EnableAuthenticator
Account.Manage.ExternalLogins
Account.Manage.GenerateRecoveryCodes
Account.Manage.Index
Account.Manage.PersonalData
Account.Manage.ResetAuthenticator
Account.Manage.SetPassword
Account.Manage.ShowRecoveryCodes
Account.Manage.TwoFactorAuthentication
Account.Register
Account.RegisterConfirmation
Account.ResendEmailConfirmation
Account.ResetPassword
Account.ResetPasswordConfirmation

Trigger for Logevents
-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[LogEventsDelete] 
   ON [dbo].[LogEvents]
   AFTER INSERT
AS 
BEGIN
	Delete from LogEvents
where 
DAY(TimeStamp)=DAY(GETDATE())
AND
Month(TimeStamp)=Month(GETDATE())
AND
Year(TimeStamp)=Year(GETDATE())
AND
DATEPART(HOUR, TimeStamp)<DATEPART(HOUR, GETDATE());
Delete from LogEvents where Level='Information';
	PRINT('Record(s) Delete successfully')

END
GO
