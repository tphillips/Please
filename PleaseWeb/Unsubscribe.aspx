<%@ Page Language="C#" Inherits="PleaseWeb.Unsubscribe" MasterPageFile="~/Master.master" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ContentPlaceHolderID="titleContent" ID="titleContentContent" runat="server">Unsubscribe</asp:Content>
<asp:Content ContentPlaceHolderID="headerContent" ID="headerContentContent" runat="server">Unsubscribe</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">
<p>
Email:<br/>
<asp:TextBox runat="server" id="txtEmail" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="You must enter your email address" Display="Dynamic"/>
</p>
<p>
<asp:Button runat="server" id="cmdSubscribe" text="Unsubscribe" onclick="cmdUnsubscribeClick" />
</p>
</asp:Content>


