<%@ Page Language="C#" Inherits="PleaseWeb.Request" MasterPageFile="~/Master.master" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ContentPlaceHolderID="titleContent" ID="titleContentContent" runat="server">Make a Request</asp:Content>
<asp:Content ContentPlaceHolderID="headerContent" ID="headerPlaceHolderContent" runat="server">Make a Request</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">

<p>Before you continue, make sure you have <a href="Subscribe.aspx">subscribed.</a></p>
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
Date you cannot cover (dd mmm yyyy):<br/>
<asp:TextBox runat="server" id="txtDate" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDate"
                    ErrorMessage="You must enter a date" Display="Dynamic"/>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                ControlToValidate="txtDate" ValidationExpression=".. ... ...."
                runat="server" ErrorMessage="Format must be dd mmm yyyy" Display="Dynamic" />
</p>

<p>
<asp:Button runat="server" id="cmdSubscribe" text="Request" onclick="cmdRequestClick" />
</p>
</asp:Content>


