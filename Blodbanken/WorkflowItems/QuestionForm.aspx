<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionForm.aspx.cs" Inherits="Blodbanken.WorkflowItems.QuestionForm"  MasterPageFile="~/Master.master" Title="Blodbanken"%>
<asp:Content ID="MainPage" ContentPlaceHolderID="MainPage" Runat="Server">
    <div class="well topPlacement" style="margin-left:100px;margin-right:100px;padding-top:0px;padding-bottom:0px;">
      <h1 style="margin-top:10px;">Login</h1>
    </div>
    <a href="/WorkflowItems/BookTime.aspx" class="pull-right" style="padding-top:5px;padding-right:110px;">Next -></a>
    <div class="jumbotron" style="margin-left:auto;margin-right:auto;width:950px;padding:20px;">  
        <h2 style="margin-left:150px;margin-right:auto;margin-top:10px;">Spørreskjema for helseundersøkelse</h2>    
        <br/>  
        <form id="frmHealthDeclaration" class="form-horizontal" runat="server">
            <fieldset>          
            <!-- Question 1 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du fått informasjon om blodgivning?</label>
                <div class="col-md-2"> 
                    <label class="radio-inline" for="radios-1a">
                        <input type="radio" name="radios" id="radios-1a" value="1" />
                        Ja
                    </label> 
                    <label class="radio-inline" for="radios-1b">
                        <input type="radio" name="radios" id="radios-1b" value="0" />
                        Nei
                    </label>
                </div>
            </div>
                <!-- Question 2 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Føler du deg frisk nå?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-2a">
                    <input type="radio" name="radios" id="radios-2a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-2b">
                    <input type="radio" name="radios" id="radios-2b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 3 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Ha du gitt blod tidligere?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-3a">
                    <input type="radio" name="radios" id="radios-3a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-3b">
                    <input type="radio" name="radios" id="radios-3b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 4 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Hvis du har gitt blod tidligere, har du vært frisk i perioden fra forrige blodgivning og til nå?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-4a">
                    <input type="radio" name="radios" id="radios-4a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-4b">
                    <input type="radio" name="radios" id="radios-4b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 5 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Veier du 50 kg eller mer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-5a">
                    <input type="radio" name="radios" id="radios-5a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-5b">
                    <input type="radio" name="radios" id="radios-5b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 6 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du åpne sår, eksem eller hudsykdom?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-6a">
                    <input type="radio" name="radios" id="radios-6a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-6b">
                    <input type="radio" name="radios" id="radios-6b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 7 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du piercing i slimhinne?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-7a">
                    <input type="radio" name="radios" id="radios-7a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-7b">
                    <input type="radio" name="radios" id="radios-7b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 8 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - brukt medisiner?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-8a">
                    <input type="radio" name="radios" id="radios-8a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-8b">
                    <input type="radio" name="radios" id="radios-8b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 9 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - vært syk eller hatt feber?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-9a">
                    <input type="radio" name="radios" id="radios-9a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-9b">
                    <input type="radio" name="radios" id="radios-9b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 10 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - hatt løs avføring?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-10a">
                    <input type="radio" name="radios" id="radios-10a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-10b">
                    <input type="radio" name="radios" id="radios-10b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 11 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - fått vaksine?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-11a">
                    <input type="radio" name="radios" id="radios-11a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-11b">
                    <input type="radio" name="radios" id="radios-11b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 12 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste fire uker - vært hos tannlege eller tannpleier?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-12a">
                    <input type="radio" name="radios" id="radios-12a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-12b">
                    <input type="radio" name="radios" id="radios-12b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 13 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - vært til legeundersøkelse eller på sykehus?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-13a">
                    <input type="radio" name="radios" id="radios-13a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-13b">
                    <input type="radio" name="radios" id="radios-13b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 14 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått behandling for noen sykdom?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-14a">
                    <input type="radio" name="radios" id="radios-14a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-14b">
                    <input type="radio" name="radios" id="radios-14b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 15 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått behandling med sprøyter?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-15a">
                    <input type="radio" name="radios" id="radios-15a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-15b">
                    <input type="radio" name="radios" id="radios-15b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 16 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt kjønnssykdom, eller fått behandling for kjønnssykdom?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-6b">
                    <input type="radio" name="radios" id="radios-16a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-16b">
                    <input type="radio" name="radios" id="radios-16b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 17 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksuell kontakt med person med HIVinfeksjon eller hepatitt B eller hepatitt C, eller med person som har hatt positiv test for en av disse sykdommene?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-17a">
                    <input type="radio" name="radios" id="radios-17a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-17b">
                    <input type="radio" name="radios" id="radios-17b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 18 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksuell kontakt med person som bruker eller har brukt dopingmidler eller narkotiske midler som sprøyter?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-18a">
                    <input type="radio" name="radios" id="radios-18a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-18b">
                    <input type="radio" name="radios" id="radios-18b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 19 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksuell kontakt med prostituerte eller tidligere prostituerte?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-19a">
                    <input type="radio" name="radios" id="radios-19a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-19b">
                    <input type="radio" name="radios" id="radios-19b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 20 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - blitt tatovert, fått piercing eller tatt hull i ørene?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-20a">
                    <input type="radio" name="radios" id="radios-20a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-20b">
                    <input type="radio" name="radios" id="radios-20b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 21 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått akupunktur?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-21a">
                    <input type="radio" name="radios" id="radios-21a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-21b">
                    <input type="radio" name="radios" id="radios-21b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 22 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått blodoverføring i Afrika eller Sør-Amerika?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-22a">
                    <input type="radio" name="radios" id="radios-22a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-22b">
                    <input type="radio" name="radios" id="radios-22b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 23 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - stukket eller skåret deg på gjenstander som var forurenset med blod eller kroppsvæsker, bodd i samme husstand som en person som har hepatitt B?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-23a">
                    <input type="radio" name="radios" id="radios-23a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-23b">
                    <input type="radio" name="radios" id="radios-23b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 24 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - fått blodsøl på slimhinner eller skadet hud?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-24a">
                    <input type="radio" name="radios" id="radios-24a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-24b">
                    <input type="radio" name="radios" id="radios-24b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 25 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - blitt bitt av flått?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-25a">
                    <input type="radio" name="radios" id="radios-25a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-25b">
                    <input type="radio" name="radios" id="radios-25b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 26 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksualpartner som har bodd mer enn ett år sammenhengende utenfor Vest-Europa ?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-26a">
                    <input type="radio" name="radios" id="radios-26a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-26b">
                    <input type="radio" name="radios" id="radios-26b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 27 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksualpartner som har vært i Afrika?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-27a">
                    <input type="radio" name="radios" id="radios-27a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-27b">
                    <input type="radio" name="radios" id="radios-27b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 28 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt seksuell kontakt med en person som har fått blod eller blodprodukter utenfor Norden?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-28a">
                    <input type="radio" name="radios" id="radios-28a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-28b">
                    <input type="radio" name="radios" id="radios-28b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 29 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - hatt ny seksualpartner?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-29a">
                    <input type="radio" name="radios" id="radios-29a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-29b">
                    <input type="radio" name="radios" id="radios-29b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 30 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste seks måneder - vært utenfor Vest-Europa?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-30a">
                    <input type="radio" name="radios" id="radios-30a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-30b">
                    <input type="radio" name="radios" id="radios-30b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 31 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste to år - hatt sjeldne eller alvorlige infeksjonssykdommer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-31a">
                    <input type="radio" name="radios" id="radios-31a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-31b">
                    <input type="radio" name="radios" id="radios-31b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 32 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt, hjerte-, lever-, eller lungesykdom?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-0">
                    <input type="radio" name="radios" id="radios-32a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-1">
                    <input type="radio" name="radios" id="radios-32b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 33 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt kreft?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-33a">
                    <input type="radio" name="radios" id="radios-33a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-33b">
                    <input type="radio" name="radios" id="radios-33b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 34 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt blødningstendens?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-34a">
                    <input type="radio" name="radios" id="radios-34a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-34b">
                    <input type="radio" name="radios" id="radios-34b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 35 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt allergi mot mat eller medisiner?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-35a">
                    <input type="radio" name="radios" id="radios-35a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-35b">
                    <input type="radio" name="radios" id="radios-35b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 36 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt malaria?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-36a">
                    <input type="radio" name="radios" id="radios-36a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-36b">
                    <input type="radio" name="radios" id="radios-36b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 37 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt tropesykdommer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-37a">
                    <input type="radio" name="radios" id="radios-37a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-37b">
                    <input type="radio" name="radios" id="radios-37b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 38 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt hepatitt (gulsott), HIV-infeksjon eller AIDS?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-38a">
                    <input type="radio" name="radios" id="radios-38a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-38b">
                    <input type="radio" name="radios" id="radios-38b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 39 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt positiv prøve for hepatitt (gulsott) eller HIVinfeksjon?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-39a">
                    <input type="radio" name="radios" id="radios-39a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-39b">
                    <input type="radio" name="radios" id="radios-39b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 40 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - fått blodoverføring?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-40a">
                    <input type="radio" name="radios" id="radios-40a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-40b">
                    <input type="radio" name="radios" id="radios-40b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 41 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - fått veksthormon?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-41a">
                    <input type="radio" name="radios" id="radios-41a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-41b">
                    <input type="radio" name="radios" id="radios-41b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 42 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - fått hornhinnetransplantat?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-42a">
                    <input type="radio" name="radios" id="radios-42a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-42b">
                    <input type="radio" name="radios" id="radios-42b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 43 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt syfilis?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-43a">
                    <input type="radio" name="radios" id="radios-43a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-43b">
                    <input type="radio" name="radios" id="radios-43b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 44 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - hatt alvorlig sykdom som ikke er nevnt her?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-44a">
                    <input type="radio" name="radios" id="radios-44a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-44b">
                    <input type="radio" name="radios" id="radios-44b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 45 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - brukt dopingmidler eller narkotiske midler som sprøyter?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-45a">
                    <input type="radio" name="radios" id="radios-45a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-45b">
                    <input type="radio" name="radios" id="radios-45b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 46 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du på noe tidspunkt gjennom livet - mottatt penger eller narkotika som gjenytelse for sex?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-46a">
                    <input type="radio" name="radios" id="radios-46a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-46b">
                    <input type="radio" name="radios" id="radios-46b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 47 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av kvinner - Er du gravid?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-47a">
                    <input type="radio" name="radios" id="radios47a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios-47b">
                    <input type="radio" name="radios" id="radios47b" value="0" runat="server"/>
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 48 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av kvinner - Har du vært gravid i løpet av de siste tolv måneder, eller ammer du nå?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-48a">
                    <input type="radio" name="radios" id="radios48a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios-48b">
                    <input type="radio" name="radios" id="radios48b" value="0" runat="server"/>
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 49 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av kvinner - Hvis du har gitt blod tidligere, har du vært gravid siden forrige blodgivning?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-49a">
                    <input type="radio" name="radios" id="radios49a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios-49b">
                    <input type="radio" name="radios" id="radios49b" value="0" runat="server"/>
                    Nei
                </label>              
                </div>
            </div>
                <!-- Question 50 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av kvinner - Har du i løpet av de siste seks måneder hatt seksuell kontakt med en mann som du vet har hatt seksuell kontakt med andre menn?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-50a">
                    <input type="radio" name="radios" id="radios50a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios-50b">
                    <input type="radio" name="radios" id="radios50b" value="0" runat="server"/>
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 51 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Besvares av menn - Har eller har du hatt seksuell kontakt med andre menn?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios51a">
                    <input type="radio" name="radios" id="radios51a" value="1" runat="server"/>
                    Ja
                </label> 
                <label class="radio-inline" for="radios-51b">
                    <input type="radio" name="radios" id="radios51b" value="0" runat="server"/>
                    Nei
                </label>             
                </div>
            </div>
                <!-- Question 52 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du brukt narkotika en eller flere ganger de siste 12 måneder?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-52a">
                    <input type="radio" name="radios" id="radios-52a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-52b">
                    <input type="radio" name="radios" id="radios-52b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 53 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du eller noen i familien hatt Creutzfeldt-Jakob sykdom eller variant CJD?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-53a">
                    <input type="radio" name="radios" id="radios-53a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-53b">
                    <input type="radio" name="radios" id="radios-53b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 54 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du oppholdt deg i Storbritannia i mer enn ett år til sammen i perioden mellom 1980 og 1996?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-54a">
                    <input type="radio" name="radios" id="radios-54a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-54b">
                    <input type="radio" name="radios" id="radios-54b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 55 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du i løpet av de siste tre år vært i områder der malaria forekommer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-55a">
                    <input type="radio" name="radios" id="radios-55a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-55b">
                    <input type="radio" name="radios" id="radios-55b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 56 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du oppholdt deg sammenhengende i minst seks måneder i områder der malaria forekommer?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-56a">
                    <input type="radio" name="radios" id="radios-56a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-56b">
                    <input type="radio" name="radios" id="radios-56b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 57 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du oppholdt deg i Afrika i mer enn fem år til sammen?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-57a">
                    <input type="radio" name="radios" id="radios-57a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-57b">
                    <input type="radio" name="radios" id="radios-57b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 58 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Er du eller din mor født i Amerika sør for USA?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-58a">
                    <input type="radio" name="radios" id="radios-58a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-58b">
                    <input type="radio" name="radios" id="radios-58b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 59 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Godtar du at anonymiserte prøver av ditt blod kan brukes til forskning? Du er like velkommen som blodgiver enten du svarer ja eller nei. Blodbanken kan gi informasjon om aktuelle forskningsprosjekter.</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-59a">
                    <input type="radio" name="radios" id="radios-59a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-59b">
                    <input type="radio" name="radios" id="radios-59b" value="0" />
                    Nei
                </label>
                </div>
            </div>
                <!-- Question 60 -->
            <div class="form-group">
                <label class="col-md-10 control-label" for="radios">Har du deltatt i medikamentforsøk de siste 12 måneder?</label>
                <div class="col-md-2"> 
                <label class="radio-inline" for="radios-60a">
                    <input type="radio" name="radios" id="radios-60a" value="1" />
                    Ja
                </label> 
                <label class="radio-inline" for="radios-60b">
                    <input type="radio" name="radios" id="radios-60b" value="0" />
                    Nei
                </label>
                </div>
            </div>

            </fieldset>
            <asp:button class="btn btn-lg btn-primary btn-block" type="submit" id="btnSubmitForm" runat="server" Text="Send skjema" />        
        </form>

    </div>
</asp:Content>
