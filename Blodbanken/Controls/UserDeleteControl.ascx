﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserDeleteControl.ascx.cs" Inherits="Blodbanken.Controls.UserDeleteControl" %>
<div class="form-group">
    <div class="col-md-3">
       
    </div>
    <div class="col-md-6">
        <asp:button id="btnDeleteUser" CommandName="DeleteUser" type="button" class="btn btn-danger" runat="server" Text="Slett" OnCommand="DeleteUser"></asp:button>
    </div>
    <div class="col-md-3">

    </div>
</div>
