﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminArea.aspx.cs" Inherits="Blodbanken.Sections.AdminArea"  MasterPageFile="~/Master.master" Title="Blodbanken" EnableEventValidation="false" %>
<%@ Register TagPrefix="uc" TagName="UserCreatorForm" Src="~/Controls/UserCreatorFormControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="ExaminationBooking" Src="~/Controls/BookHealthExaminationControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="BloodDonorBooking" Src="~/Controls/BookDonorAppointmentControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="ParkingBooking" Src="~/Controls/ParkingBookingControl1.ascx" %>
<%@ Register TagPrefix="uc" TagName="AutoBookerSettings" Src="~/Controls/AutoBookerSettingsControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="MessageModuleControl" Src="~/Controls/MessageModuleControl.ascx" %>

<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">    
    <div runat="server" id="responsebox" style="visibility:hidden"></div>
    <link rel="stylesheet" type="text/css" href="/Content/themes/base/all.css" />
    <link rel="stylesheet" href="/Content/jquery.ptTimeSelect.css" />
    <script src="/Scripts/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.ptTimeSelect.js" type="text/javascript"></script>
    <div class="well topPlacement" style="margin-left:100px;margin-right:100px;padding-top:0px;padding-bottom:0px;">
      <h1 style="margin-top:10px;">Kontroll panel</h1>
    </div>
    <div class="jumbotron" style="margin-left:100px;margin-right:100px;padding:20px;">
        <form id="frmAdministratorEditor" runat="server" class="form-horizontal">
            <asp:HiddenField ID="hidSourceID" runat="server" />
            <div id="inlineContainer">
	            <div id="inlineRow">
		            <div id="inlineCell1">
                        <div class="list-group" id="lstgrpUserEditor">
                            <a href="#" class="list-group-item active">
                               Bruker editor
                            </a>
                            <a href="#itemUserEditor" id="headingUserCreator" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpUserEditor" aria-expanded="false" aria-controls="itemUserEditor">Opprett bruker</a>
                            <div id="itemUserEditor" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingUserCreator">
                              <div class="well well-sm well-custom">                    
                                <uc:UserCreatorForm id="UserCreatorForm" runat="server"/>
                              </div>
                            </div>
                            <a href="#itemUserChanger" id="headingUserChanger" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpUserEditor" aria-expanded="false" aria-controls="itemUserEditor">Endre bruker</a>
                            <div id="itemUserChanger" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingUserEditor">
                              <div class="well well-sm well-custom">
                                <fieldset>
                                    <!-- Select Basic -->
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="selectChangeUser1">Velg bruker</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList id="selectChangeUser1" name="selectChangeUser1" cssclass="form-control" runat="server" AutoPostBack="True">

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-12" id="changeUserPlaceHolder" runat="server">

                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                            <a href="#itemUserDeletor" id="headingUserDeletor" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpUserEditor" aria-expanded="false" aria-controls="itemUserEditor">Slett bruker</a>
                            <div id="itemUserDeletor" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingUserDeletor">
                              <div class="well well-sm well-custom">
                                <fieldset>
                                    <!-- Select Basic -->
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="selectDeleteUser1">Velg bruker</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList id="selectDeleteUser1" name="select" cssclass="form-control" runat="server" AutoPostBack="True">

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-12" id="deleteUserPlaceHolder" runat="server">

                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                        </div>
                    </div>
                    <div id="inlineCell2">
                         <div class="list-group" id="lstgrpBookingEditor">
                            <a href="#" class="list-group-item active">
                               Booking editor
                            </a>
                             <a href="#itemExaminationBooker" id="headingExamintionBooker" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpBookingEditor" aria-expanded="false" aria-controls="itemExaminationBooker">Booking - helseundersøkelser</a>
                            <div id="itemExaminationBooker" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingExamintionBooker">
                              <div class="well well-sm well-custom">                                
                                <uc:ExaminationBooking id="ExaminationBooking" runat="server"/>
                              </div>
                            </div>
                            <a href="#itemTimeBooker" id="headingTimeBooker" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpBookingEditor" aria-expanded="false" aria-controls="itemTimeBooker">Booking - Donortime</a>
                            <div id="itemTimeBooker" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTimeBooker">
                              <div class="well well-sm well-custom">
                                <uc:BloodDonorBooking id="BloodDonorBooking" runat="server"/>
                              </div>
                            </div>
                            <a href="#itemParkingBooker" id="headingParkingBooker" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpBookingEditor" aria-expanded="false" aria-controls="itemParkingBooker">Parkeringsbooking</a>
                            <div id="itemParkingBooker" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingParkingBooker">
                              <div class="well well-sm well-custom">
                                <uc:ParkingBooking id="ParkingBooking" runat="server"/>
                              </div>
                            </div>
                            <a href="#itemAutoBooker" id="headingAutoBooker" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpBookingEditor" aria-expanded="false" aria-controls="itemAutoBooker">Automatisk booker</a>
                            <div id="itemAutoBooker" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingAutoBooker">
                              <div class="well well-sm well-custom">
                                <uc:AutoBookerSettings id="AutoBookerSettings" runat="server"/>
                              </div>
                            </div>
                        </div>
                    </div>
                    <div id="inlineCell3">
                         <div class="list-group" id="lstgrpDiverseEditor">
                            <a href="#" class="list-group-item active">
                               Annet
                            </a>                            
                            <a href="#itemConsentEdit" id="headingConsentEdit" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemConsentEdit">Samtykke personopplysninger</a>
                            <div id="itemConsentEdit" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingConsentEdit">
                              <div class="well well-sm well-custom">
                                <fieldset>
                                    <!-- Select Basic -->
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="selectUserForConsentEdit">Velg bruker</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList id="selectUserForConsentEdit" name="selectUserForConsentEdit" cssclass="form-control" runat="server" AutoPostBack="True">
          
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-12" id="consentEditPlaceHolder" runat="server">

                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                            <a href="#itemWorkflowEdit" id="headingWorkflowEdit" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemWorkflowEdit">Bruker Registreringer</a>
                            <div id="itemWorkflowEdit" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingWorkflowEdit">
                              <div class="well well-sm well-custom">
                                <fieldset>
                                    <!-- Select Basic -->
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="selectUserForWorkflowEdit">Velg bruker</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList id="selectUserForWorkflowEdit" name="selectUserForWorkflowEdit" cssclass="form-control" runat="server"  AutoPostBack="True">

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-12" id="workflowPlaceHolder" runat="server">

                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                            <a href="#itemExaminationAccept" id="headingExaminationAccept" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemWorkflowEdit">Helseundersøkelser - Godkjennelse</a>
                            <div id="itemExaminationAccept" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingExminationAccept">
                              <div class="well well-sm well-custom">
                                <fieldset>
                                    <!-- Select Basic -->
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="selectUserForExaminationAccept">Velg bruker</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="selectUserForExaminationAccept" cssclass="form-control" runat="server" AutoPostBack="True">

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-12" id="workflowExaminationAcceptPlaceHolder" runat="server">
                                        </div>
                                    </div>
                                </fieldset>
                              </div>
                            </div>
                            <a href="#itemSchemaEdit" id="headingSchemaEdit" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemSchemaEdit">Egenerklæring - Sletting</a>
                            <div id="itemSchemaEdit" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingSchemaEdit">
                              <div class="well well-sm well-custom">
                                 <fieldset>
                                    <!-- Select Basic -->
                                    <div class="form-group">
                                        <label class="col-md-4 control-label" for="selectUserForSchemaEdit">Velg bruker</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList id="selectUserForSchemaEdit" name="selectUserForSchemaEdit" cssclass="form-control" runat="server" AutoPostBack="True">

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-12" id="SchemaEditPlaceHolder" runat="server">
                                            <!-- mangler -->
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
    <script type="text/javascript">
        function SetSource(SourceID) {
            var hidSourceID = document.getElementById("<%=hidSourceID.ClientID%>");
            hidSourceID.value = SourceID;
        }
    </script>
</asp:Content>
