<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExaminationAcceptControl.ascx.cs" Inherits="Blodbanken.Controls.ExaminationAcceptControl" %>
<div class="panel panel-default panel-nested">
    <div class="panel-heading" id="infoPanelHeader" style="font-weight:bold;" runat="server">Helseundersøkelser for</div>
    <div class="panel-body">
        <fieldset>          
            <div class="form-group">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <asp:DropdownList runat="server" class="form-control" ID="healthExaminationList">

                    </asp:DropdownList>
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-3">
                </div>
                <label class="col-md-4 control-label" for="radios">Aksepteres helseundersøkelsen?</label>
                <div class="col-md-4"> 
                    <label class="radio-inline" for="radiosExaminationAccept1a">
                        <input type="radio" name="radiosExaminationAccept" id="radiosExaminationAccept1a" runat="server" value="1" />
                        Ja
                    </label> 
                    <label class="radio-inline" for="radiosExaminationAccept1b">
                        <input type="radio" name="radiosExaminationAccept" id="radiosExaminationAccept1b" runat="server" value="0" />
                        Nei
                    </label>
                </div>
                <div class="col-md-1">
                </div> 
            </div>
        </fieldset>        
    </div>
</div>
