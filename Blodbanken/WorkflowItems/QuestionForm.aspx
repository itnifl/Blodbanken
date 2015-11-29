<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionForm.aspx.cs" Inherits="Blodbanken.WorkflowItems.QuestionForm"  MasterPageFile="~/Master.master" Title="Blodbanken"%>
<%@ Register TagPrefix="uc" TagName="BottomNavBar" Src="~/Controls/BottomNavBar.ascx" %>
<%@ Register TagPrefix="uc" TagName="MessageModuleControl" Src="~/Controls/MessageModuleControl.ascx" %>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <div runat="server" id="responsebox" style="visibility:hidden"></div>
    <div class="well topPlacement" style="margin-left:100px;margin-right:100px;padding-top:0px;padding-bottom:0px;">
      <h1 style="margin-top:10px;" runat="server" id="lblHeading">Login</h1>
    </div>
    <div class="jumbotron" style="margin-left:auto;margin-right:auto;width:950px;padding:20px; margin-bottom:65px;">  
        <h2 style="margin-left:150px;margin-right:auto;margin-top:10px;">Spørreskjema for helseundersøkelse</h2>    
        <br/>  
        <form id="frmHealthDeclaration" class="form-horizontal" runat="server">
            <fieldset>          
            <!-- Question 1 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios1a">Har du fått informasjon om blodgivning?</label>
                <div class="col-md-2"> 
                    <label class="radio-inline" for="radios1a">
                        <input type="radio" name="radios1" id="radios1a" value="1" runat="server" />
                        Ja
                    </label> 
                    <label class="radio-inline" for="radios1b">
                        <input type="radio" name="radios1" id="radios1b" value="0" runat="server" />
                        Nei
                    </label>
                </div>
            </div>
                <!-- Question 2 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Føler du deg frisk nå?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios2a">
                    <input type="radio" name="radios2" id="radios2a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios2b">
                    <input type="radio" name="radios2" id="radios2b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 3 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Ha du gitt blod tidligere?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios3a">
                    <input type="radio" name="radios3" id="radios3a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios3b">
                    <input type="radio" name="radios3" id="radios3b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 4 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Hvis du har gitt blod tidligere, har du vært frisk i perioden fra forrige blodgivning og til nå?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios4a">
                    <input type="radio" name="radios4" id="radios4a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios4b">
                    <input type="radio" name="radios4" id="radios4b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 5 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Veier du 50 kg eller mer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios5a">
                    <input type="radio" name="radio5s" id="radios5a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios5b">
                    <input type="radio" name="radios5" id="radios5b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 6 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du åpne sår, eksem eller hudsykdom?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios6a">
                    <input type="radio" name="radios6" id="radios6a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios6b">
                    <input type="radio" name="radios6" id="radios6b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 7 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du piercing i slimhinne?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios7a">
                    <input type="radio" name="radios7" id="radios7a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios7b">
                    <input type="radio" name="radios7" id="radios7b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 8 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - brukt medisiner?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios8a">
                    <input type="radio" name="radios8" id="radios8a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios8b">
                    <input type="radio" name="radios8" id="radios8b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 9 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - vært syk eller hatt feber?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios9a">
                    <input type="radio" name="radios9" id="radios9a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios9b">
                    <input type="radio" name="radios9" id="radios9b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 10 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - hatt løs avføring?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios10a">
                    <input type="radio" name="radios10" id="radios10a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios10b">
                    <input type="radio" name="radios10" id="radios10b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 11 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - fått vaksine?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios11a">
                    <input type="radio" name="radios11" id="radios11a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios11b">
                    <input type="radio" name="radios11" id="radios11b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 12 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - vært hos tannlege eller tannpleier?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios12a">
                    <input type="radio" name="radios12a" id="radios12a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios12b">
                    <input type="radio" name="radios12" id="radios12b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 13 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - vært til legeundersøkelse eller på sykehus?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios13a">
                    <input type="radio" name="radios13" id="radios13a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios13b">
                    <input type="radio" name="radios13" id="radios13b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 14 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått behandling for noen sykdom?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios14a">
                    <input type="radio" name="radios14" id="radios14a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios14b">
                    <input type="radio" name="radios14" id="radios14b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 15 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått behandling med sprøyter?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios15a">
                    <input type="radio" name="radios15" id="radios15a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios15b">
                    <input type="radio" name="radios15" id="radios15b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 16 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt kjønnssykdom, eller fått behandling for kjønnssykdom?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios16b">
                    <input type="radio" name="radios16" id="radios16a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios16b">
                    <input type="radio" name="radios16" id="radios16b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 17 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios17a">Har du i løpet av de siste seks måneder - hatt seksuell kontakt med person med HIVinfeksjon eller hepatitt B eller hepatitt C, eller med person som har hatt positiv test for en av disse sykdommene?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios17a">
                    <input type="radio" name="radios17" id="radios17a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios17b">
                    <input type="radio" name="radios17" id="radios17b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 18 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksuell kontakt med person som bruker eller har brukt dopingmidler eller narkotiske midler som sprøyter?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios18a">
                    <input type="radio" name="radios18" id="radios18a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios18b">
                    <input type="radio" name="radios18" id="radios18b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 19 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksuell kontakt med prostituerte eller tidligere prostituerte?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios19a">
                    <input type="radio" name="radios19" id="radios19a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios19b">
                    <input type="radio" name="radios19" id="radios19b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 20 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - blitt tatovert, fått piercing eller tatt hull i ørene?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios20a">
                    <input type="radio" name="radios20" id="radios20a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios20b">
                    <input type="radio" name="radios20" id="radios20b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 21 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått akupunktur?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios21a">
                    <input type="radio" name="radios21" id="radios21a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios21b">
                    <input type="radio" name="radios21" id="radios21b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 22 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått blodoverføring i Afrika eller Sør-Amerika?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios22a">
                    <input type="radio" name="radios22" id="radios22a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios22b">
                    <input type="radio" name="radios22" id="radios22b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 23 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - stukket eller skåret deg på gjenstander som var forurenset med blod eller kroppsvæsker, bodd i samme husstand som en person som har hepatitt B?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios23a">
                    <input type="radio" name="radios23" id="radios23a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios23b">
                    <input type="radio" name="radios23" id="radios23b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 24 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått blodsøl på slimhinner eller skadet hud?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios24a">
                    <input type="radio" name="radios24" id="radios24a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios24b">
                    <input type="radio" name="radios24" id="radios24b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 25 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - blitt bitt av flått?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios25a">
                    <input type="radio" name="radios25" id="radios25a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios25b">
                    <input type="radio" name="radios25" id="radios25b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 26 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksualpartner som har bodd mer enn ett år sammenhengende utenfor Vest-Europa ?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios26a">
                    <input type="radio" name="radios26" id="radios26a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios26b">
                    <input type="radio" name="radios26" id="radios26b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 27 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksualpartner som har vært i Afrika?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios27a">
                    <input type="radio" name="radios27" id="radios27a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios27b">
                    <input type="radio" name="radios27" id="radios27b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 28 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksuell kontakt med en person som har fått blod eller blodprodukter utenfor Norden?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios28a">
                    <input type="radio" name="radios28" id="radios28a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios28b">
                    <input type="radio" name="radios28" id="radios28b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 29 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt ny seksualpartner?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios29a">
                    <input type="radio" name="radios29" id="radios29a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios29b">
                    <input type="radio" name="radios29" id="radios29b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 30 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - vært utenfor Vest-Europa?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios30a">
                    <input type="radio" name="radios30" id="radios30a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios30b">
                    <input type="radio" name="radios30" id="radios30b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 31 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste to år - hatt sjeldne eller alvorlige infeksjonssykdommer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios31a">
                    <input type="radio" name="radios31" id="radios31a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios31b">
                    <input type="radio" name="radios31" id="radios31b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 32 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt, hjerte-, lever-, eller lungesykdom?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios32a">
                    <input type="radio" name="radios32" id="radios32a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios32b">
                    <input type="radio" name="radios32" id="radios32b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 33 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt kreft?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios33a">
                    <input type="radio" name="radios33" id="radios33a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios33b">
                    <input type="radio" name="radios33" id="radios33b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 34 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt blødningstendens?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios34a">
                    <input type="radio" name="radios34" id="radios34a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios34b">
                    <input type="radio" name="radios34" id="radios34b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 35 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt allergi mot mat eller medisiner?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios35a">
                    <input type="radio" name="radios35" id="radios35a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios35b">
                    <input type="radio" name="radios35" id="radios35b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 36 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt malaria?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios36a">
                    <input type="radio" name="radios36" id="radios36a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios36b">
                    <input type="radio" name="radios36" id="radios36b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 37 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt tropesykdommer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios37a">
                    <input type="radio" name="radios37" id="radios37a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios37b">
                    <input type="radio" name="radios37" id="radios37b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 38 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt hepatitt (gulsott), HIV-infeksjon eller AIDS?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios38a">
                    <input type="radio" name="radios38" id="radios38a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios38b">
                    <input type="radio" name="radios38" id="radios38b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 39 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt positiv prøve for hepatitt (gulsott) eller HIVinfeksjon?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios39a">
                    <input type="radio" name="radios39" id="radios39a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios39b">
                    <input type="radio" name="radios39" id="radios39b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 40 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - fått blodoverføring?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios40a">
                    <input type="radio" name="radios40" id="radios40a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios40b">
                    <input type="radio" name="radios40" id="radios40b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 41 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - fått veksthormon?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios41a">
                    <input type="radio" name="radios41" id="radios41a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios41b">
                    <input type="radio" name="radios41" id="radios41b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 42 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - fått hornhinnetransplantat?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios42a">
                    <input type="radio" name="radios42" id="radios42a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios42b">
                    <input type="radio" name="radios42" id="radios42b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 43 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt syfilis?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios43a">
                    <input type="radio" name="radios43" id="radios43a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios43b">
                    <input type="radio" name="radios43" id="radios43b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 44 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt alvorlig sykdom som ikke er nevnt her?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios44a">
                    <input type="radio" name="radios44" id="radios44a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios44b">
                    <input type="radio" name="radios44" id="radios44b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 45 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - brukt dopingmidler eller narkotiske midler som sprøyter?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios45a">
                    <input type="radio" name="radios45" id="radios45a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios45b">
                    <input type="radio" name="radios45" id="radios45b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 46 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - mottatt penger eller narkotika som gjenytelse for sex?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios46a">
                    <input type="radio" name="radios46" id="radios46a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios46b">
                    <input type="radio" name="radios46" id="radios46b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 47 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av kvinner - Er du gravid?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios47a">
                    <input type="radio" name="radios47" id="radios47a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios47b">
                    <input type="radio" name="radios47" id="radios47b" value="0" runat="server"/>
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 48 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av kvinner - Har du vært gravid i løpet av de siste tolv måneder, eller ammer du nå?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios48a">
                    <input type="radio" name="radios48" id="radios48a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios48b">
                    <input type="radio" name="radios48" id="radios48b" value="0" runat="server"/>
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 49 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av kvinner - Hvis du har gitt blod tidligere, har du vært gravid siden forrige blodgivning?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radio-49a">
                    <input type="radio" name="radios49" id="radios49a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios49b">
                    <input type="radio" name="radios49" id="radios49b" value="0" runat="server"/>
                    Nei
                </label>              
                </div>
            </div>
                <!-- Question 50 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av kvinner - Har du i løpet av de siste seks måneder hatt seksuell kontakt med en mann som du vet har hatt seksuell kontakt med andre menn?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios50a">
                    <input type="radio" name="radios50" id="radios50a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios50b">
                    <input type="radio" name="radios50" id="radios50b" value="0" runat="server"/>
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 51 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av menn - Har eller har du hatt seksuell kontakt med andre menn?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios51a">
                    <input type="radio" name="radios51" id="radios51a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios51b">
                    <input type="radio" name="radios51" id="radios51b" value="0" runat="server"/>
                    Nei
                </label>             
                </div>
            </div>
                <!-- Question 52 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du brukt narkotika en eller flere ganger de siste 12 måneder?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios52a">
                    <input type="radio" name="radios52" id="radios52a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios52b">
                    <input type="radio" name="radios52" id="radios52b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 53 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du eller noen i familien hatt Creutzfeldt-Jakob sykdom eller variant CJD?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios53a">
                    <input type="radio" name="radios53" id="radios53a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios53b">
                    <input type="radio" name="radios53" id="radios53b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 54 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du oppholdt deg i Storbritannia i mer enn ett år til sammen i perioden mellom 1980 og 1996?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios54a">
                    <input type="radio" name="radios54" id="radios54a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios54b">
                    <input type="radio" name="radios54" id="radios54b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 55 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste tre år vært i områder der malaria forekommer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios55a">
                    <input type="radio" name="radios55" id="radios55a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios55b">
                    <input type="radio" name="radios55" id="radios55b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 56 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du oppholdt deg sammenhengende i minst seks måneder i områder der malaria forekommer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios56a">
                    <input type="radio" name="radios56" id="radios56a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios56b">
                    <input type="radio" name="radios56" id="radios56b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 57 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du oppholdt deg i Afrika i mer enn fem år til sammen?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios57a">
                    <input type="radio" name="radios57" id="radios57a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios57b">
                    <input type="radio" name="radios57" id="radios57b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 58 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Er du eller din mor født i Amerika sør for USA?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios58a">
                    <input type="radio" name="radios58" id="radios58a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios58b">
                    <input type="radio" name="radios58" id="radios58b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 59 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Godtar du at anonymiserte prøver av ditt blod kan brukes til forskning? Du er like velkommen som blodgiver enten du svarer ja eller nei. Blodbanken kan gi informasjon om aktuelle forskningsprosjekter.</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios59a">
                    <input type="radio" name="radios59" id="radios59a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios59b">
                    <input type="radio" name="radios59" id="radios59b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 60 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du deltatt i medikamentforsøk de siste 12 måneder?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios60a">
                    <input type="radio" name="radios60" id="radios60a" value="1" runat="server" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios60b">
                    <input type="radio" name="radios60" id="radios60b" value="0" runat="server" />
                    Nei
                </label>
                </div>
            </div>

            </fieldset>
            <asp:button class="btn btn-lg btn-primary btn-block" type="submit" id="btnSubmitForm" runat="server" Text="Send skjema" OnCommand="SubmitForm" CommandName="CreateUser" />        
        </form>
    </div>
    <uc:MessageModuleControl id="MessageModuleControl" runat="server"/>
    <uc:BottomNavBar runat="server" ID="BottomNavBar" />
</asp:Content>
