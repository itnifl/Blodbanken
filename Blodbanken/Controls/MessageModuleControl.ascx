<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageModuleControl.ascx.cs" Inherits="Blodbanken.Controls.MessageModuleControl" %>
<!-- This control requires that the main page implements a div with ID #MainPage_responsebox that the page codebehind
    populates with the ReplyObject as JSON format. -->
<script type="text/javascript">
    var replyObject;
    $(document).ready(function () {
        var jsonReply = $('#MainPage_responsebox').text();
        if(jsonReply) {
            replyObject = JSON.parse(jsonReply);
        }
        if (replyObject && replyObject.hasOwnProperty("RequestStatus")) {
            //Show status here
            //Set Focus
            if (replyObject.hasOwnProperty("FocusID")) {
                $('#' + replyObject.FocusID).addClass('in');
            }
        }
        if (replyObject && replyObject.hasOwnProperty("CustomMessage")) {
            $('#messageModalBody').text(replyObject.CustomMessage);
            if (replyObject.CustomMessage) $('#buttonFeedbackModal').modal({ show: true })
        }
    });
</script>
<div class="modal fade" id="buttonFeedbackModal" tabindex="-1" role="dialog" aria-labelledby="buttonFeedbackModalLabel">
    <div class="modal-dialog" role="document">
    <div class="modal-content">
        <div class="modal-header">
        <h4 class="modal-title" id="buttonFeedbackModalLabel">Brukerbeskjed</h4>
        </div>
        <div class="modal-body" id="messageModalBody">

        </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Lukk</button>
        </div>
    </div>
    </div>
</div>
