<%@ Control Language="c#" AutoEventWireup="false" Inherits="proxy_Teste_SAP_Charts.Flows.FlowCharts.WBlkColumnChart,Teste_SAPReferencesProxy" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="client" TagName="node" Src="..\..\Charts\Charts\ColumnChart.ascx" %>
<client:node id="block" runat="server" OnBindDelegates="BindProxyDelegates" />