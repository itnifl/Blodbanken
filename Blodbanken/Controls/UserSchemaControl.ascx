<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserSchemaControl.ascx.cs" Inherits="Blodbanken.Controls.UserSchemaControl" %>
<div class="panel panel-default panel-nested">
    <div class="panel-heading" id="infoPanelHeader" style="font-weight:bold;" runat="server">Egenerklæringer for</div>
    <div class="panel-body">
        <fieldset>          
            <div class="form-group">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <asp:DropdownList runat="server" class="form-control" ID="selectUserFormList">

                    </asp:DropdownList>
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-3">
                </div>
                <label class="col-md-4 control-label" for="btnDeleteUserForm">Ønsker du å slette valgt egenerklæring?</label>
                <div class="col-md-4"> 
                    <asp:button id="btnDeleteUserForm" CommandName="DeleteForm" type="button" class="btn btn-danger" runat="server" Text="Delete" OnCommand="DeleteForm"></asp:button>

                </div>
                <div class="col-md-1">
                </div> 
            </div>
        </fieldset>        
    </div>
</div>

