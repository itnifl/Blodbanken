<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowControl.ascx.cs" Inherits="Blodbanken.Controls.WorkFlowControl" %>
<ul class="list-group">
  <li class="list-group-item" runat="server" id="workflowCreateUser"><b><a href="/WorkflowItems/PersInfoPage.aspx" style="color:inherit;">Opprett egen bruker</a></b><span id="errorInfo1" class="pull-right" runat="server"></span></li>
  <li class="list-group-item" runat="server" id="workflowConsent"><b><a href="/WorkflowItems/PersInfoConsent.aspx" style="color:inherit;">Samtykke personopplysninger</a></b><span id="errorInfo2" class="pull-right" runat="server"></span></li>
  <li class="list-group-item" runat="server" id="workflowExamination"><b><a href="/WorkflowItems/BookMedicalExamination.aspx" style="color:inherit;">Helseundersøkelse</a></b><span id="errorInfo3" class="pull-right" runat="server"></span></li>
  <li class="list-group-item" runat="server" id="workflowSchema"><b><a href="/WorkflowItems/QuestionForm.aspx" style="color:inherit;">Spørrekjema før avgivning</a></b><span id="errorInfo4" class="pull-right" runat="server"></span></li>
  <li class="list-group-item" runat="server" id="workflowBookAppointment"><b><a href="/WorkflowItems/BookTime.aspx" style="color:inherit;">Booke donortime</a></b><span id="errorInfo5" class="pull-right" runat="server"></span></li>
  <li class="list-group-item" runat="server" id="workflowBookParking"><b><a href="/WorkflowItems/BookParking.aspx" style="color:inherit;">Booke parkering</a></b><span id="errorInfo6" class="pull-right" runat="server"></span></li>
</ul>


