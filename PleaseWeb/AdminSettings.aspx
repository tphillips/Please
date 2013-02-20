<%@ Page Language="C#" Inherits="PleaseWeb.AdminSettings" MasterPageFile="~/Master.master" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ContentPlaceHolderID="titleContent" ID="titleContentContent" runat="server">Settings</asp:Content>
<asp:Content ContentPlaceHolderID="headerContent" ID="headerContentContent" runat="server">Settings</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">
<p>
	SMTP Server:<br/>
	<asp:TextBox runat="server" id="txtSMTPServer" /> <asp:TextBox runat="server" id="txtPort" size="2" /> 
</p>
<p>
	Mail From:<br/>
	<asp:TextBox runat="server" id="txtMailFrom" />
</p>
<p>
	Respond Link:<br/>
	<asp:TextBox runat="server" id="txtLinkUrl" />
</p>
<p>
	New Subscriber Email:<br/>
	<asp:TextBox runat="server" id="txtEmailSubjectNewSubscriber" />
	<asp:TextBox runat="server" id="txtEmailBodyNewSubscriber" TextMode="MultiLine" />
</p>
<p>
	New Request Email:<br/>
	<asp:TextBox runat="server" id="txtEmailSubjectNewRequest" />
	<asp:TextBox runat="server" id="txtEmailBodyNewRequest" TextMode="MultiLine" />
</p>
<p>
	Request Accepted (All Subscribers):<br/>
	<asp:TextBox runat="server" id="txtEmailSubjectRequestAcceptedSubscribers" />
	<asp:TextBox runat="server" id="txtEmailBodyRequestAcceptedSubscribers" TextMode="MultiLine" />
</p>
<p>
	Request Accepted (Requestor):<br/>
	<asp:TextBox runat="server" id="txtEmailSubjectRequestAcceptedRequestor" />
	<asp:TextBox runat="server" id="txtEmailBodyRequestAcceptedRequestor" TextMode="MultiLine" />
</p>
<p>
<asp:Button runat="server" id="cmdSave" text="Save" onclick="cmdSaveClick" />
</p>
</asp:Content>


