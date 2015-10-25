<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedInUserControl.ascx.cs" Inherits="Blodbanken.Controls.LoggedInUserControl" %>
<script type="text/javascript">
    $(document).ready(function () {
       $('#btnLogoff').click(logoffUser);
    });
</script>
<ul class="nav navbar-nav navbar-right">
    <li id="lstWelcome" runat="server"><a href="#">Velkommen <asp:label runat="server" ID="lblLoggedInUsername" />!</a></li>
    <li id="lstLogOff" runat="server"><a href="#" id="btnLogoff">Log off</a></li>
</ul>
