<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookTime.aspx.cs" Inherits="Blodbanken.WorkflowItems.BookTime" MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="BloodDonorBooking" Src="~/Controls/BookingControl2.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.21/themes/redmond/jquery-ui.css" />
    <link rel="stylesheet" href="/Content/jquery.ptTimeSelect.css"/>
    <script src="/Scripts/jquery.ptTimeSelect.js" type="text/javascript"></script>
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
</asp:Content>
