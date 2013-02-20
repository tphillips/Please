<%@ Page Language="C#" Inherits="PleaseWeb.Requested" MasterPageFile="~/Master.master" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ContentPlaceHolderID="titleContent" ID="titleContentContent" runat="server">Thanks</asp:Content>
<asp:Content ContentPlaceHolderID="headerContent" ID="headerPlaceHolderContent" runat="server">Request</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">
<p><asp:Label runat="server" id="lblMessage" text="Your request has been broadcast." /></p>
</asp:Content>


