<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCreator.aspx.cs" Inherits="Blodbanken.Sections.UserCreator" MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="UserCreatorForm" Src="~/Controls/UserCreatorFormControl.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <div class="jumbotron topPlacement" style="margin-left:100px;margin-right:100px;padding:20px;">
        <form id="frmCreateUser" runat="server" class="form-horizontal">
            <div id="inlineContainer">
	            <div id="inlineRow">
		            <div id="inlineCell1">
                        <div class="list-group" id="lstgrpUserEditor">
                            <a href="#" class="list-group-item active">
                               Bruker oppetter
                            </a>
                            <a href="#itemUserEditor" id="headingUserCreator" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpUserEditor" aria-expanded="false" aria-controls="itemUserEditor">Opprett bruker</a>
                            <div id="itemUserEditor" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingUserCreator">
                              <div class="well well-sm well-custom">
                                <uc:UserCreatorForm id="UserCreatorForm" runat="server" />
                              </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>

