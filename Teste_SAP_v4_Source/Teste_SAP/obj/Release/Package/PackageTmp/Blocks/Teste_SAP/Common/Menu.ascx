<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Blocks\Teste_SAP\Common\Menu.ascx.cs" Inherits="ssTeste_SAP.Flows.FlowCommon.WBlkMenu,Teste_SAP" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="osweb" Namespace="OutSystems.HubEdition.WebWidgets" Assembly="OutSystems.HubEdition.WebWidgets" %>
<%@ Assembly Name="OutSystems.WidgetsRuntimeAPI" %>
<%@ Import namespace="ssTeste_SAP" %>
<%# PageStartHook() %><osweb:Container runat="server" id="wt_Container3" anonymous="true" onDataBinding="cnt_Container3_onDataBinding" cssClass="Application_Menu"><osweb:Container runat="server" id="wt_Container2" anonymous="true" onDataBinding="cnt_Container2_onDataBinding" cssClass="Menu_TopMenus"></osweb:Container></osweb:Container><%# PageEndHook() %>