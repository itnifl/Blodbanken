<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserCreatorFormControl.ascx.cs" Inherits="Blodbanken.Controls.UserCreatorFormControl" %>

<fieldset>
    <!-- Text input-->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtUsername">Brukernavn</label>  
        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtUsername" style="color:red;" ErrorMessage="<b>* Brukernavn må fylles inn</b>" />
        <div class="col-md-4">
        <input id="txtUsername" name="txtUsername" type="text" placeholder="Brukernavn" class="form-control input-md" required="" runat="server" />
    
        </div>
    </div>

    <!-- Password input 1 -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtPassword1">Passord</label>
        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword1" style="color:red;" ErrorMessage="<b>* Passord må fylles inn</b>" />
        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword1" style="color:red;" ValidationExpression="(^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$)" ErrorMessage="<b>* Feil passordkompleksitet.</b>"/>
        <asp:CompareValidator Display="Dynamic" runat="server" id="cmpNumbers" controltovalidate="txtPassword1" style="color:red;" controltocompare="txtPassword2" operator="Equal" type="String" errormessage="<br/><b>* Begge passord må være like.</b>" />
        <div class="col-md-4">
        <input id="txtPassword1" name="txtPassword1" type="password" placeholder="Passord" class="form-control input-md" required="" runat="server" />
    
        </div>
    </div>

    <!-- Password input 2 -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtPassword2">Verifiser Passord</label>
        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword2" style="color:red;" ErrorMessage="<b>* Passord må fylles inn</b>" />
        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword2" style="color:red;" ValidationExpression="(^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$)" ErrorMessage="<b>* Feil passordkompleksitet.</b>"/>
        <div class="col-md-4">
        <input id="txtPassword2" name="txtPassword2" type="password" placeholder="Passord" class="form-control input-md" required="" runat="server" />
    
        </div>
    </div>

    <!-- Select Basic -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="selectRole">Role</label>
        <div class="col-md-4">
        <select id="selectRole" name="selectRole" class="form-control" runat="server">
            <option value="1">Admin</option>
            <option value="2">Donor</option>
            <option value="3">Viewer</option>
        </select>
        </div>
    </div>

    <!-- Buttons -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="btnCreate"></label>
        <div class="col-md-8">
            <asp:button id="btnCreate" name="btnCreate" class="btn btn-success" runat="server" Text="Opprett" OnClick="CreateUser"/>
            <button id="btnCancel" name="btnCancel" class="btn btn-danger">Avbryt</button>
        </div>
    </div>
</fieldset>