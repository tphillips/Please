<%@ Page Language="C#" Inherits="PleaseWeb.Subscribed" MasterPageFile="~/Master.master" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ContentPlaceHolderID="titleContent" ID="titleContentContent" runat="server">Thanks</asp:Content>
<asp:Content ContentPlaceHolderID="headerContent" ID="headerPlaceHolderContent" runat="server">Subscribe</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">
<p><asp:Label runat="server" id="lblMessage" text="Thanks, you have been sent an confirmation email." /></p>
</asp:Content>


