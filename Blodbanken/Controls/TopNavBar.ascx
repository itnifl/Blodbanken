<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavBar.ascx.cs" Inherits="Blodbanken.WebUserControl1" %>
<script type="text/javascript">
    $(document).ready(function () {
       $('#btnLogoff').click(logoffUser);
    });
</script>
<nav class="navbar navbar-default navbar-fixed-top">
    <!-- We use the fluid option here to avoid overriding the fixed width of a normal container within the narrow content columns. -->
    <div class="container-fluid">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#mainNav" aria-expanded="false">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/Index.aspx">Blodbanken</a>
        </div>

        <div class="collapse navbar-collapse" id="mainNav">
            <ul class="nav navbar-nav">
                <li id="HomeLink"><a href="/Public/Login.aspx">Login</a></li>
                <li id="AboutLink"><a href="/Public/About.aspx">Om Blodbanken</a></li>
                <li id="NewsLink"><a href="/Public/News.aspx">Nyheter</a></li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li id="lstWelcome" runat="server"><a href="#">Velkommen <asp:label runat="server" ID="lblLoggedInUsername" />!</a></li>
                <li id="lstAdminLink" runat="server"><a href="/Sections/AdminArea.aspx">Admin Page</a></li>
                <li id="lstLogOff" runat="server"><a href="#" id="btnLogoff">Logg av</a></li>
            </ul>
        </div><!-- /.navbar-collapse -->
    </div>
</nav>
<script type="text/javascript">
    var pathname = window.location.pathname;
    if (pathname == "/Public/Index.aspx") {
        $('#HomeLink').addClass('/Public/active');
    } else if (pathname == "/Public/About.aspx") {
        $('#AboutLink').addClass('active');
    } else if (pathname == "/Public/News.aspx") {
        $('#NewsLink').addClass('active');
    } 
</script>