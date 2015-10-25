<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedInUserControl.ascx.cs" Inherits="Blodbanken.Controls.LoggedInUserControl" %>
<div class="navbar-image">
    
</div>
    
<ul class="nav navbar-nav navbar-right">
    <li>
        Hallo <asp:label runat="server" ID="lblLoggedInUsername" />!
    </li>
    <li><a href="javascript:document.getElementById('logoutForm').submit()">Log off</a></li>
</ul>
