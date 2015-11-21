<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserDeleteControl.ascx.cs" Inherits="Blodbanken.Controls.UserDeleteControl" %>
<div class="form-group">
    <div class="col-md-3">
       
    </div>
    <div class="col-md-6">
        <asp:button CausesValidation="false" CommandName="DeleteUser" id="btnDeleteUser" name="btnDeleteUser" cssclass="btn btn-danger" runat="server" Text="Slett bruker" OnCommand="DeleteUser"/>
    </div>
    <div class="col-md-3">

    </div>
</div>
