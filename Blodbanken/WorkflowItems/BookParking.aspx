﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookParking.aspx.cs" Inherits="Blodbanken.WorkflowItems.BookParking"  MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="ParkingBooking" Src="~/Controls/ParkingBookingControl1.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.21/themes/redmond/jquery-ui.css" />
    <link rel="stylesheet" href="/Content/jquery.ptTimeSelect.css"/>
    <script src="/Scripts/jquery.ptTimeSelect.js" type="text/javascript"></script>
    <div>
        <form id="frmBookParking" runat="server" class="form-horizontal">
            <div id="inlineContainer">
	            <div id="inlineRow">
		            <div id="inlineCell1">
                        <div class="topPlacement">
                            <uc:ParkingBooking runat="server" ID="ParkBookingForm" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
