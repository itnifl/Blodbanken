<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConsentEditControl.ascx.cs" Inherits="Blodbanken.Controls.ConsentEditControl" %>
<div class="panel panel-default panel-nested">
    <div class="panel-heading" id="infoPanelHeaderConsentEdit" style="font-weight:bold;" runat="server">Tillatelser for</div>
    <div class="panel-body">
        <fieldset>          
            <div class="form-group">
                <div class="col-md-2">
                </div>
                <label class="col-md-5 control-label" for="radios">Aksepterer du å lagre personopplysninger?</label>
                <div class="col-md-3"> 
                    <label class="radio-inline" for="radiosPersInfoAccept-1a">
                        <input type="radio" name="radios" id="radiosPersInfoAccept-1a" value="1" />
                        Ja
                    </label> 
                    <label class="radio-inline" for="radiosPersInfoAccept-1b">
                        <input type="radio" name="radios" id="radiosPersInfoAccept-1b" value="0" />
                        Nei
                    </label>
                </div>
                <div class="col-md-2">
                </div> 
            </div>
            <div class="form-group">
                <div class="col-md-2">
                </div>
                <label class="col-md-5 control-label" for="radios">Aksepterer du å bli kontaktet på mail?</label>
                <div class="col-md-3"> 
                    <label class="radio-inline" for="radiosEMailAccept-1a">
                        <input type="radio" name="radios" id="radiosEMailAccept-1a" value="1" />
                        Ja
                    </label> 
                    <label class="radio-inline" for="radiosEMailAccept-1b">
                        <input type="radio" name="radios" id="radiosEMailAccept-1b" value="0" />
                        Nei
                    </label>
                </div>
                <div class="col-md-2">
                </div> 
            </div>
            <div class="form-group">
                <div class="col-md-2">
                </div>
                <label class="col-md-5 control-label" for="radios">Aksepterer du å bli kontaktet på sms?</label>
                <div class="col-md-3"> 
                    <label class="radio-inline" for="radiosSMSAccept-1a">
                        <input type="radio" name="radios" id="radiosSMSAccept-1a" value="1" />
                        Ja
                    </label> 
                    <label class="radio-inline" for="radiosSMSAccept-1b">
                        <input type="radio" name="radios" id="radiosSMSAccept-1b" value="0" />
                        Nei
                    </label>
                </div>
                <div class="col-md-2">
                </div> 
            </div>
        </fieldset>        
    </div>
</div>
