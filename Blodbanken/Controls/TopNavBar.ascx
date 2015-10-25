<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavBar.ascx.cs" Inherits="Blodbanken.WebUserControl1" %>
<nav class="navbar navbar-default navbar-fixed-top">
    <!-- We use the fluid option here to avoid overriding the fixed width of a normal container within the narrow content columns. -->
    <div class="container-fluid">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-6" aria-expanded="false">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/Index.aspx">Blodbanken</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-6">
            <ul class="nav navbar-nav">
                <li id="HomeLink"><a href="/Public/Login.aspx">Login</a></li>
                <li id="AboutLink"><a href="/Public/About.aspx">Om Blodbanken</a></li>
                <li id="NewsLink"><a href="/Public/News.aspx">Nyheter</a></li>
            </ul>
        </div><!-- /.navbar-collapse -->

        <div class="pull-right">
            <ul class="nav navbar-nav navbar-right">
                <li>
                    Hallo <asp:label runat="server" ID="lblLoggedInUsername" />!
                </li>
                <!-- Denne skal bruk Ajax for å logge av bruker -->
                <li><asp:LinkButton runat="server" id="btnLogoff">Log off</asp:LinkButton></li>
            </ul>
        </div>
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