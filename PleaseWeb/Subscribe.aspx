<%@ Page Language="C#" Inherits="PleaseWeb.Subscribe" MasterPageFile="~/Master.master" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ContentPlaceHolderID="titleContent" ID="titlePlaceHolderContent" runat="server">Subscribe</asp:Content>
<asp:Content ContentPlaceHolderID="headerContent" ID="headerPlaceHolderContent" runat="server">Subscribe</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">

<p>
Your Name:<br/>
<asp:TextBox runat="server" id="txtName" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage="You must enter your name" Display="Dynamic"/>
</p>

<p>
Email:<br/>
<asp:TextBox runat="server" id="txtEmail" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="You must enter your email address" Display="Dynamic"/>
</p>

<p>
SMS Number:<br/>
<asp:TextBox runat="server" id="txtSMS" />
</p>

<p>
<asp:Button runat="server" id="cmdSubscribe" text="Subscribe" onclick="cmdSubscribeClick" />
</p>

</asp:Content>


