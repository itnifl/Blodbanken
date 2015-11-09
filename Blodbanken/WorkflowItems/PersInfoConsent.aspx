<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersInfoConsent.aspx.cs" Inherits="Blodbanken.WorkflowItems.PersInfoConsent" MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="ConsentEditControl" Src="~/Controls/ConsentEditControl.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <div>
        <form id="frmPersinfoConsent" runat="server" class="form-horizontal">
            <div id="inlineContainer">
	            <div id="inlineRow">
		            <div id="inlineCell1">
                        <div class="topPlacement">
                            <div class="topPlacement">
                                <uc:ConsentEditControl id="ConsentEditForm" runat="server" />
                                <a href="/WorkflowItems/BookMedicalExamination.aspx" class="pull-right" style="padding-top:0px;padding-right:40px;">Next -></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
