<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AutoBookerSettingsControl.ascx.cs" Inherits="Blodbanken.Controls.AutoBookerSettingsControl" %>
<fieldset>
<!-- Multiple Checkboxes -->
<div class="form-group">
  <label class="col-md-4 control-label" for="chkActiveBookers">Aktive bookere</label>
  <div class="col-md-4">
  <div class="checkbox">
    <label for="chkActiveBookers-0">
      <input type="checkbox" name="chkActiveBookers" id="chkActiveBookers-0" value="1">
      Parkeningsbooker
    </label>
	</div>
  <div class="checkbox">
    <label for="chkActiveBookers-1">
      <input type="checkbox" name="chkActiveBookers" id="chkActiveBookers-1" value="2">
      Undersølelsesbooker
    </label>
	</div>
  <div class="checkbox">
    <label for="chkActiveBookers-2">
      <input type="checkbox" name="chkActiveBookers" id="chkActiveBookers-2" value="3">
      Donorbooker
    </label>
	</div>
  </div>
</div>

<!-- Multiple Radios (inline) -->
<div class="form-group">
  <label class="col-md-4 control-label" for="rdBookingInterval">Booking Interval</label>
  <div class="col-md-4"> 
    <label class="radio-inline" for="rdBookingInterval-0">
      <input type="radio" name="rdBookingInterval" id="rdBookingInterval-0" value="8" checked="checked">
      8t
    </label> 
    <label class="radio-inline" for="rdBookingInterval-1">
      <input type="radio" name="rdBookingInterval" id="rdBookingInterval-1" value="16">
      16t
    </label> 
    <label class="radio-inline" for="rdBookingInterval-2">
      <input type="radio" name="rdBookingInterval" id="rdBookingInterval-2" value="24">
      24t
    </label> 
    <label class="radio-inline" for="rdBookingInterval-3">
      <input type="radio" name="rdBookingInterval" id="rdBookingInterval-3" value="48">
      48t
    </label> 
    <label class="radio-inline" for="rdBookingInterval-4">
      <input type="radio" name="rdBookingInterval" id="rdBookingInterval-4" value="72">
      72t
    </label>
  </div>
</div>

</fieldset>
