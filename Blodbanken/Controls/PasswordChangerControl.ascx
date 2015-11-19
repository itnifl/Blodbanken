<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PasswordChangerControl.ascx.cs" Inherits="Blodbanken.Controls.PasswordChangerControl" %>
<fieldset>
    <!-- Password input 1 -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtPassword1">Gammelt Passord</label>
        <asp:RequiredFieldValidator Validationgroup="PasswordChangerInput" Display="Dynamic" runat="server" ControlToValidate="txtPassword0" style="color:red;" ErrorMessage="<b>* Passord må fylles inn</b>" />
        <div class="col-md-4">
        <input id="txtPassword0" name="txtPassword0" type="password" placeholder="Passord" class="form-control input-md" runat="server" />
    
        </div>
    </div>

    <!-- Password input 2 -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtPassword1">Nytt Passord</label>
        <asp:RequiredFieldValidator Validationgroup="PasswordChangerInput" Display="Dynamic" runat="server" ControlToValidate="txtPassword1" style="color:red;" ErrorMessage="<b>* Passord må fylles inn</b>" />
        <asp:RegularExpressionValidator Validationgroup="PasswordChangerInput" Display="Dynamic" runat="server" ControlToValidate="txtPassword1" style="color:red;" ValidationExpression="(^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$)" ErrorMessage="<b>* Feil passordkompleksitet.</b>"/>
        <asp:CompareValidator Validationgroup="PasswordChangerInput" Display="Dynamic" runat="server" id="cmpNumbers" controltovalidate="txtPassword1" style="color:red;" controltocompare="txtPassword2" operator="Equal" type="String" errormessage="<br/><b>* Begge passord må være like.</b>" />
        <div class="col-md-4">
        <input id="txtPassword1" name="txtPassword1" type="password" placeholder="Passord" class="form-control input-md" runat="server" />
    
        </div>
    </div>

    <!-- Password input 3 -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtPassword2">Gjenta nytt passord</label>
        <asp:RequiredFieldValidator Validationgroup="PasswordChangerInput" Display="Dynamic" runat="server" ControlToValidate="txtPassword2" style="color:red;" ErrorMessage="<b>* Passord må fylles inn</b>" />
        <asp:RegularExpressionValidator Validationgroup="PasswordChangerInput" Display="Dynamic" runat="server" ControlToValidate="txtPassword2" style="color:red;" ValidationExpression="(^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$)" ErrorMessage="<b>* Feil passordkompleksitet.</b>"/>
        <div class="col-md-4">
        <input id="txtPassword2" name="txtPassword2" type="password" placeholder="Passord" class="form-control input-md" runat="server" />
    
        </div>
    </div>

    <!-- Buttons -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="btnExecute"></label>
        <div class="col-md-8">
            <asp:button Validationgroup="PasswordChangerInput" CommandName="ChangePassword" id="btnExecute" name="btnExecute" class="btn btn-success" runat="server" Text="Utfør" OnCommand="ChangePassword"/>
        </div>
    </div>
</fieldset>