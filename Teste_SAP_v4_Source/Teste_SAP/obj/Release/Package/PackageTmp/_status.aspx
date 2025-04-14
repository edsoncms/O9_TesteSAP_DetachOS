<%@ Page EnableSessionState="true" language="c#" AutoEventWireup="false"  %>
<%@ Import Namespace="OutSystems.HubEdition.RuntimePlatform" %>
<%@ Import Namespace="OutSystems.HubEdition.RuntimePlatform.Log" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>status</title>
	</head>
	<body>
		<% 
            SessionInfo session = AppInfo.GetAppInfo().OsContext.Session;
            if (RuntimePlatformUtils.IsValidRequestForVisit()
                && Request.Cookies["osVisitor"] != null 
                && Request.Cookies["osVisit"] != null 
                && session["osIsNewVisit"] != null && ((bool) session["osIsNewVisit"])) 
            {
                RuntimeLogger.LogVisit(DateTime.Now, Request.Cookies["osVisitor"].Value, Request.Cookies["osVisit"].Value);
                session["osIsNewVisit"] = false;
            }
		%>
	</body>
</html>
