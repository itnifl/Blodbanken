<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserArea.aspx.cs" Inherits="Blodbanken.Sections.UserArea" MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="MessageModuleControl" Src="~/Controls/MessageModuleControl.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <div runat="server" id="responsebox" style="visibility:hidden"></div>
    <div class="well topPlacement" style="margin-left:100px;margin-right:100px;padding-top:0px;padding-bottom:0px;">
      <h1 style="margin-top:10px;"><asp:label runat="server" ID="lblLoggedInFullName" /> </h1>
    </div>
    <div class="jumbotron" style="margin-left:100px;margin-right:100px;padding:20px;">
        <form id="frmEditor" runat="server" class="form-horizontal">
            <div id="inlineContainer">
	            <div id="inlineRow">
		            <div id="inlineCell1">
                        <div class="list-group" id="lstgrpUserWorkPanel">
                            <a href="#" class="list-group-item active">
                               Arbeidspanel
                            </a>
                            <a href="#itemUserChanger" id="headingUserChanger" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpUserEditor" aria-expanded="false" aria-controls="itemUserEditor">Endre bruker</a>
                            <div id="itemUserChanger" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingUserEditor">
                              <div class="well well-sm well-custom">
                                <fieldset>
                                    <div class="form-group">
                                        <div class="col-md-12" id="changeUserPlaceHolder" runat="server">

                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                            <a href="#itemConsentEdit" id="headingConsentEdit" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemConsentEdit">Samtykker</a>
                            <div id="itemConsentEdit" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingConsentEdit">
                              <div class="well well-sm well-custom">
                                <fieldset>
                                    <div class="form-group">
                                        <div class="col-md-12" id="consentEditPlaceHolder" runat="server">

                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                            <a href="#itemWorkflowEdit" id="headingWorkflowEdit" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemWorkflowEdit">Handlinger</a>
                            <div id="itemWorkflowEdit" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingWorkflowEdit">
                              <div class="well well-sm well-custom">
                                <fieldset>                                   
                                    <div class="form-group">
                                        <div class="col-md-12" id="workflowPlaceHolder" runat="server">

                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <uc:MessageModuleControl id="MessageModuleControl" runat="server"/>
</asp:Content>
