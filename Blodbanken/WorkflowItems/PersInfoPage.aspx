<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PersInfoPage.aspx.cs" Inherits="Blodbanken.WorkflowItems.PersInfoPage" %>
<%@ Register TagPrefix="uc" TagName="UserEditControl" Src="~/Controls/UserEditControl.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <div>
        <form id="frmPersInfoArea" runat="server" class="form-horizontal">
            <div id="inlineContainer">
	            <div id="inlineRow">
		            <div id="inlineCell1">
                        <div class="list-group topPlacement" id="lstgrpUserWorkPanel">
                            <a href="#" class="list-group-item active">
                               Arbeidspanel
                            </a>
                            <a href="#itemUserChanger" id="headingUserChanger" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpUserEditor" aria-expanded="false" aria-controls="itemUserEditor">Endre bruker</a>
                            <div id="itemUserChanger" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingUserEditor">
                              <div class="well well-sm well-custom">
                                <fieldset>
                                    <div class="form-group">
                                        <div class="col-md-12" id="changeUserPlaceHolder" runat="server">
                                            <uc:UserEditControl id="UserEditForm" runat="server"/>
                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                            <a href="/WorkflowItems/PersInfoConsent.aspx" class="pull-right" style="padding-top:5px;padding-right:10px;">Next -></a>
                        </div>                        
                    </div>                    
                </div>                
            </div>            
        </form>        
    </div>
</asp:Content>
