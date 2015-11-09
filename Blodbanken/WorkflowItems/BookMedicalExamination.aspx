<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookMedicalExamination.aspx.cs" Inherits="Blodbanken.WorkflowItems.BookMedicalExamination"  MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="ExaminationBooking" Src="~/Controls/BookingControl1.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.21/themes/redmond/jquery-ui.css" />
    <link rel="stylesheet" href="/Content/jquery.ptTimeSelect.css"/>
    <script src="/Scripts/jquery.ptTimeSelect.js" type="text/javascript"></script>
    <div>
        <form id="frmBookMedicalExamination" runat="server" class="form-horizontal">
            <div id="inlineContainer">
	            <div id="inlineRow">
		            <div id="inlineCell1">
                        <div class="topPlacement">
                            <uc:ExaminationBooking runat="server" ID="ExaminationBookingForm" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>

