<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConsentEditControl.ascx.cs" Inherits="Blodbanken.Controls.ConsentEditControl" %>
<div class="panel panel-default panel-nested">
    <div class="panel-heading" id="infoPanelHeaderConsentEdit" style="font-weight:bold;" runat="server">Tillatelser for</div>
    <div class="panel-body">
        <fieldset>          
            <div class="form-group">
                <div class="col-md-2">
                </div>
                <label class="col-md-5 control-label" for="radiosPersInfoAccept">Aksepterer du å lagre personopplysninger?</label>
                <div class="col-md-3"> 
                    <label class="radio-inline" for="radiosPersInfoAccept1a">
                        <input type="radio" name="radiosPersInfoAccept" id="radiosPersInfoAccept1a" value="1" runat="server"/>
                        Ja
                    </label> 
                    <label class="radio-inline" for="radiosPersInfoAccept1b">
                        <input type="radio" name="radiosPersInfoAccept" id="radiosPersInfoAccept1b" value="0" runat="server"/>
                        Nei
                    </label>
                </div>
                <div class="col-md-2">
                </div> 
            </div>
            <div class="form-group">
                <div class="col-md-2">
                </div>
                <label class="col-md-5 control-label" for="radiosEMailAccept">Aksepterer du å bli kontaktet på mail?</label>
                <div class="col-md-3"> 
                    <label class="radio-inline" for="radiosEMailAccept1a">
                        <input type="radio" name="radiosEMailAccept" id="radiosEMailAccept1a" value="1" runat="server"/>
                        Ja
                    </label> 
                    <label class="radio-inline" for="radiosEMailAccept1b">
                        <input type="radio" name="radiosEMailAccept" id="radiosEMailAccept1b" value="0" runat="server"/>
                        Nei
                    </label>
                </div>
                <div class="col-md-2">
                </div> 
            </div>
            <div class="form-group">
                <div class="col-md-2">
                </div>
                <label class="col-md-5 control-label" for="radiosSMSAccept">Aksepterer du å bli kontaktet på sms?</label>
                <div class="col-md-3"> 
                    <label class="radio-inline" for="radiosSMSAccept1a">
                        <input type="radio" name="radiosSMSAccept" id="radiosSMSAccept1a" value="1" runat="server"/>
                        Ja
                    </label> 
                    <label class="radio-inline" for="radiosSMSAccept1b">
                        <input type="radio" name="radiosSMSAccept" id="radiosSMSAccept1b" value="0" runat="server"/>
                        Nei
                    </label>
                </div>
                <div class="col-md-2">
                </div> 
            </div>
        </fieldset>        
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        var logonName = $('#infoPanelHeaderConsentEdit').data('currentUser');
        $('#radiosSMSAccept1a').click(function (e) {
            e.preventDefault();            
            var accept = true;
            setSMSAccept(logonName, accept);
        });
        $('#radiosSMSAccept1b').click(function (e) {
            e.preventDefault();
            var accept = false;
            setSMSAccept(logonName, accept);
        });

        $('#radiosEMailAccept1a').click(function (e) {
            e.preventDefault();
            var accept = true;
            setPersInfoAccept(logonName, accept);
        });
        $('#radiosEMailAccept1b').click(function (e) {
            e.preventDefault();
            var accept = false;
            setPersInfoAccept(logonName, accept);
        });

        $('#radiosPersInfoAccept1a').click(function (e) {
            e.preventDefault();
            var accept = true;
            setEmailAccept(logonName, accept);
        });
        $('#radiosPersInfoAccept1b').click(function (e) {
            e.preventDefault();
            var accept = false;
            setEmailAccept(logonName, accept);
        });
    });
</script>
