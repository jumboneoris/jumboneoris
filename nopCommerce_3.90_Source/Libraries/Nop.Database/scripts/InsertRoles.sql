/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
  insert into [NopCommerce].[dbo].[CustomerRole] (Name,FreeShipping,TaxExempt,Active,IsSystemRole,SystemName,EnablePasswordLifetime,PurchasedWithProductId)
  values ('Socio',0,0,1,0,'Socio Jumbo+',0,0) 

    insert into [NopCommerce].[dbo].[CustomerRole] (Name,FreeShipping,TaxExempt,Active,IsSystemRole,SystemName,EnablePasswordLifetime,PurchasedWithProductId)
  values ('Premium',1,0,1,0,'Premium Jumbo+',0,0) 