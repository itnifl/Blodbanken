<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomNavBar.ascx.cs" Inherits="Blodbanken.Controls.BottomNavBar" %>
<nav class="navbar navbar-default navbar-fixed-bottom">
    <!-- We use the fluid option here to avoid overriding the fixed width of a normal container within the narrow content columns. -->
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="/Index.aspx"><asp:label ID="bottomNavBarBrand" runat="server"></asp:label></a>
        </div>

        <div class="collapse navbar-collapse" id="mainBottomNav">
            <ul class="nav navbar-nav navbar-right">
                <li id="lssNextLink" runat="server">
                   <asp:HyperLink runat="server" id="aNextLink" href=""></asp:HyperLink>

                </li>
            </ul>
        </div><!-- /.navbar-collapse -->
    </div>
</nav>

