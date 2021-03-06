﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavBar.ascx.cs" Inherits="Blodbanken.WebUserControl1" %>
<script type="text/javascript">
    $(document).ready(function () {
       $('#btnLogoff').click(logoffUser);
    });
</script>
<nav class="navbar navbar-default navbar-fixed-top">
    <!-- We use the fluid option here to avoid overriding the fixed width of a normal container within the narrow content columns. -->
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="/Index.aspx">Blodbanken</a>
        </div>

        <div class="collapse navbar-collapse" id="mainNav">
            <ul class="nav navbar-nav">
                <li id="LoginLink"><a href="/Public/Login.aspx">Login</a></li>
                <li id="AboutLink"><a href="/Public/About.aspx">Om Blodbanken</a></li>
                <li id="NewsLink"><a href="/Public/News.aspx">Nyheter</a></li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li id="lstAdminLink" runat="server"><a href="/Sections/AdminArea.aspx">Kontroll Panel</a></li>
                <li id="lstWelcome" runat="server"><a href="/Sections/UserArea.aspx">Velkommen <asp:label runat="server" ID="lblLoggedInUsername" />!</a></li>
                <li id="lstLogOff" runat="server"><a href="#" id="btnLogoff">Logg av</a></li>
            </ul>
        </div><!-- /.navbar-collapse -->
    </div>
</nav>
<script type="text/javascript">
    var pathname = window.location.pathname;
    if (pathname == "/Public/Login.aspx") {
        $('#LoginLink').addClass('active');
    } else if (pathname == "/Public/About.aspx") {
        $('#AboutLink').addClass('active');
    } else if (pathname == "/Public/News.aspx") {
        $('#NewsLink').addClass('active');
    } 
</script>