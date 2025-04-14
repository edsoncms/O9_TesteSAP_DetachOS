USE [outsystems]
GO

/****** Object:  View [dbo].[oslog_Error]    Script Date: 05/08/2019 11:11:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[oslog_Error] AS SELECT  error.[Id], error.[Instant], error.[Session_Id], error.[user_id], error.[Espace_Id], error.[Tenant_Id], error.[Message], case when errorDetail.[FullStackTrace] is null then error.[Stack] else errorDetail.[FullStackTrace] end as Stack, error.[Module_Name], error.[Server], error.[Cycle], error.[EnvironmentInformation], error.Entrypoint_Name, error.Action_Name, error.Request_Key FROM oslog_Error_2 as error LEFT JOIN oslog_Error_DETAIL_2 as errorDetail ON (error.[Id] = errorDetail.[Id]);
GO
