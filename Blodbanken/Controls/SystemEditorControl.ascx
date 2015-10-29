<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemEditorControl.ascx.cs" Inherits="Blodbanken.Controls.SystemEditor" %>
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
                    <form class="form-horizontal">
                        <fieldset>

                        <!-- Text input-->
                        <div class="form-group">
                          <label class="col-md-4 control-label" for="txtUsername">Brukernavn</label>  
                          <div class="col-md-4">
                          <input id="txtUsername" name="txtUsername" type="text" placeholder="Brukernavn" class="form-control input-md" required="">
    
                          </div>
                        </div>

                        <!-- Password input-->
                        <div class="form-group">
                          <label class="col-md-4 control-label" for="txtPassword">Passord</label>
                          <div class="col-md-4">
                            <input id="txtPassword" name="txtPassword" type="password" placeholder="Passord" class="form-control input-md" required="">
    
                          </div>
                        </div>

                        <!-- Button Drop Down -->
                        <div class="form-group">
                          <label class="col-md-4 control-label" for="btnRoles">Rolle</label>
                          <div class="col-md-4">
                            <div class="input-group">
                              <input id="btnRoles" name="btnRoles" class="form-control" placeholder="Rolle" type="text" required="">
                              <div class="input-group-btn">
                                <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                  Velg
                                  <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu pull-right">
                                  <li><a href="#">Admin</a></li>
                                  <li><a href="#">Donor</a></li>
                                  <li><a href="#">Leser</a></li>
                                </ul>
                              </div>
                            </div>
                          </div>
                        </div>

                        <!-- Text input-->
                        <div class="form-group">
                          <label class="col-md-4 control-label" for="txtFornavn">Fornavn</label>  
                          <div class="col-md-4">
                          <input id="txtFornavn" name="txtFornavn" type="text" placeholder="Fornavn" class="form-control input-md" required="">
    
                          </div>
                        </div>

                        <!-- Text input-->
                        <div class="form-group">
                          <label class="col-md-4 control-label" for="txtEtternavn">Etternavn</label>  
                          <div class="col-md-4">
                          <input id="txtEtternavn" name="txtEtternavn" type="text" placeholder="Etternavn" class="form-control input-md" required="">
    
                          </div>
                        </div>

                        <!-- Textarea -->
                        <div class="form-group">
                          <label class="col-md-4 control-label" for="txtAdresse">Adresse</label>
                          <div class="col-md-4">                     
                            <textarea class="form-control" id="txtAdresse" name="txtAdresse">Adresse</textarea>
                          </div>
                        </div>

                        </fieldset>
                        </form>

                  </div>
                </div>
                <a href="#itemUserChanger" id="headingUserChanger" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpUserEditor" aria-expanded="false" aria-controls="itemUserEditor">Endre bruker</a>
                <div id="itemUserChanger" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingUserEditor">
                  <div class="well well-sm well-custom">
                    Endre en bruker bla bla
                  </div>
                </div>
                <a href="#itemUserDeletor" id="headingUserDeletor" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpUserEditor" aria-expanded="false" aria-controls="itemUserEditor">Slett bruker</a>
                <div id="itemUserDeletor" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingUserDeletor">
                  <div class="well well-sm well-custom">
                    Slett en bruker bla bla
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
                    Booking av undersøkelser bla bla
                  </div>
                </div>
                <a href="#itemTimeBooker" id="headingTimeBooker" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpBookingEditor" aria-expanded="false" aria-controls="itemTimeBooker">Timebooking</a>
                <div id="itemTimeBooker" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTimeBooker">
                  <div class="well well-sm well-custom">
                    Booking av timer bla bla
                  </div>
                </div>
                <a href="#itemParkingBooker" id="headingParkingBooker" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpBookingEditor" aria-expanded="false" aria-controls="itemParkingBooker">Parkeringsbooking</a>
                <div id="itemParkingBooker" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingParkingBooker">
                  <div class="well well-sm well-custom">
                    Booking av parkering bla bla
                  </div>
                </div>
                <a href="#itemAutoBooker" id="headingAutoBooker" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpBookingEditor" aria-expanded="false" aria-controls="itemAutoBooker">Automatisk booker</a>
                <div id="itemAutoBooker" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingAutoBooker">
                  <div class="well well-sm well-custom">
                    Endring av automatisk booker bla bla
                  </div>
                </div>
            </div>
        </div>
        <div id="inlineCell3">
             <div class="list-group" id="lstgrpDiverseEditor">
                <a href="#" class="list-group-item active">
                   Annet
                </a>
                <a href="#itemSchemaEdit" id="headingSchemaEdit" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemSchemaEdit">Skjema</a>
                <div id="itemSchemaEdit" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingSchemaEdit">
                  <div class="well well-sm well-custom">
                    Edit av skjema bla bla
                  </div>
                </div>
                <a href="#itemConsentEdit" id="headingConsentEdit" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemConsentEdit">Samtykker</a>
                <div id="itemConsentEdit" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingConsentEdit">
                  <div class="well well-sm well-custom">
                    Edit av samtykker bla bla
                  </div>
                </div>
                 <a href="#itemWorkflowEdit" id="headingWorkflowEdit" class="list-group-item collapsed list-group-item-header" data-toggle="collapse" data-parent="#lstgrpDiverseEditor" aria-expanded="false" aria-controls="itemWorkflowEdit">Workflows</a>
                <div id="itemWorkflowEdit" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingWorkflowEdit">
                  <div class="well well-sm well-custom">
                    Edit av workflows bla bla
                  </div>
                </div>
            </div>
        </div>
    </div>
</div>