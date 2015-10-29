<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminArea.aspx.cs" Inherits="Blodbanken.Sections.AdminArea"  MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="SystemEditor" Src="~/Controls/SystemEditorControl.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <div class="well topPlacement" style="margin-left:100px;margin-right:100px;padding-top:0px;padding-bottom:0px;">
      <h1 style="margin-top:10px;">Kontroll panel</h1>
    </div>
    <div class="jumbotron" style="margin-left:100px;margin-right:100px;padding:20px;">
        <p>
       
        </p>
        <uc:SystemEditor id="TopNavBar" runat="server" />
    </div>
</asp:Content>
