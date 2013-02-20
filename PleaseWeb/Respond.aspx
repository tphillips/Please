<%@ Page Language="C#" Inherits="PleaseWeb.Respond" MasterPageFile="~/Master.master" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ContentPlaceHolderID="titleContent" ID="titleContentContent" runat="server">Thank You</asp:Content>
<asp:Content ContentPlaceHolderID="headerContent" ID="headerPlaceHolderContent" runat="server">Thank You</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">
<p><asp:Label runat="server" id="lblMessage" text="" /></p>
</asp:Content>


