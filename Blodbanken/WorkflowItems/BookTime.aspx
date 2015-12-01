<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="BookTime.aspx.cs" Inherits="Blodbanken.WorkflowItems.BookTime" MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="BloodDonorBooking" Src="~/Controls/BookDonorAppointmentControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="BottomNavBar" Src="~/Controls/BottomNavBar.ascx" %>
<%@ Register TagPrefix="uc" TagName="MessageModuleControl" Src="~/Controls/MessageModuleControl.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/Content/themes/base/all.css" />
    <script src="/Scripts/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
    <div runat="server" id="responsebox" style="visibility:hidden;display:none;"></div>
    <div>
        <form id="frmBookDonorTime" runat="server" class="form-horizontal">
            <div id="inlineContainer">
	            <div id="inlineRow">
		            <div id="inlineCell1">
                        <div class="topPlacement">                            
                            <uc:BloodDonorBooking runat="server" ID="BloodDonorForm" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <uc:MessageModuleControl id="MessageModuleControl" runat="server"/>
    <uc:BottomNavBar runat="server" ID="BottomNavBar" />
</asp:Content>
