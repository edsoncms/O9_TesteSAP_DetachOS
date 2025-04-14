<%@ Control Language="c#" AutoEventWireup="false" Inherits="proxy_Teste_SAP_Users.Flows.FlowUserManagement.WBlkEditMyInfo,Teste_SAPReferencesProxy" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="client" TagName="node" Src="..\..\Users\UserManagement\EditMyInfo.ascx" %>
<client:node id="block" runat="server" OnBindDelegates="BindProxyDelegates" />