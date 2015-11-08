<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Blodbanken.Public.Login" MasterPageFile="~/Master.master" Title="Blodbanken"%>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <div class="well topPlacement" style="margin-left:100px;margin-right:100px;padding-top:0px;padding-bottom:0px;">
      <h1 style="margin-top:10px;">Login</h1>
    </div>
    <div class="jumbotron" style="margin-left:auto;margin-right:auto;width:400px;padding:20px;">
        <form class="form-signin" runat="server" id="loginForm">
            <h2 class="form-signin-heading">Pålogging</h2>
            <asp:label for="inputBrukernavn" class="sr-only" runat="server">Brukernavn</asp:label>
            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtInputBrukernavn" style="color:red;" ErrorMessage="<b>* Brukernavn må fylles inn</b>" />
            <asp:TextBox id="txtInputBrukernavn" class="form-control" placeholder="Brukernavn" runat="server"/>
            <asp:label for="inputPassord" class="sr-only" runat="server">Passord</asp:label>
            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtInputPassord" style="color:red;" ErrorMessage="<b>* Passord må fylles inn</b>" />
            <asp:TextBox TextMode="Password" id="txtInputPassord" class="form-control" placeholder="Passord" runat="server"/>        
            <div runat="server" id="logonErrorSpan" class=" alert alert-danger glyphicon glyphicon-exclamation-sign customErrorStyle" aria-hidden="true">&nbsp;Feil brukernavn og passord</div>
            <div class="checkbox">
              <label>
                <asp:checkbox type="checkbox" value="remember-me" runat="server" ID="chkRememberMe"/> Husk meg
              </label>
            </div>        
            <asp:button class="btn btn-lg btn-primary btn-block" type="submit" id="btnLogon" runat="server" Text="Logg På" OnClick="btnLogon_Click"/> 
            <a href="/Public/UserCreator.aspx">Har du ikke bruker?</a>   
        </form>               
    </div>
</asp:Content>