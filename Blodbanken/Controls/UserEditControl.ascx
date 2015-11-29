<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserEditControl.ascx.cs" Inherits="Blodbanken.Controls.UserEditControl" %>
<div class="panel panel-default panel-nested">
    <div class="panel-heading" id="infoPanelEditUserHeader" style="font-weight:bold;" runat="server">Endre brukeropplysninger for</div>
    <div class="panel-body">
        <fieldset>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="txtFirstname">Fornavn</label>  
            <div class="col-md-4">
            <asp:RequiredFieldValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtFirstname" style="color:red;" ErrorMessage="<b>* Feltet må fylles inn</b>" />
            <input runat="server" id="txtFirstname" name="txtFirstname" type="text" placeholder="Fornavn" class="form-control input-md" />
    
            </div>
        </div>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="txtLastName">Etternavn</label>  
            <div class="col-md-4">
            <asp:RequiredFieldValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtLastName" style="color:red;" ErrorMessage="<b>* Feltet må fylles inn</b>" />
            <input runat="server"  id="txtLastName" name="txtLastName" type="text" placeholder="Etternavn" class="form-control input-md" />
    
            </div>
        </div>

        <!-- Select Basic -->
        <div class="form-group">
            <label class="col-md-4 control-label" for="selectRole">System rolle</label>
            <div class="col-md-4">
            <asp:DropdownList runat="server" id="selectRole" name="selectRole" cssclass="form-control">
                <asp:ListItem value="1">Admin</asp:ListItem>
                <asp:ListItem value="2">Donor</asp:ListItem>
                <asp:ListItem value="3">Leser</asp:ListItem>
            </asp:DropdownList>
            </div>
        </div>

        <!-- Select Basic -->
        <div class="form-group">
            <label class="col-md-4 control-label" for="selectGender">Kjønn</label>
            <div class="col-md-4">
            <asp:DropdownList runat="server" id="selectGender" name="selectGender" cssclass="form-control">
                <asp:ListItem value="1">Mann</asp:ListItem>
                <asp:ListItem value="2">Kvinne</asp:ListItem>
            </asp:DropdownList>
            </div>
        </div>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="txtTlfMobil">Mobil</label>  
            <div class="col-md-4">
            <asp:RequiredFieldValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtTlfMobil" style="color:red;" ErrorMessage="<b>* Feltet må fylles inn</b>" />
            <asp:RegularExpressionValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtTlfMobil" style="color:red;" ValidationExpression="(\d{8})" ErrorMessage="<b>* Må ha 8 sifre.</b>"/>
            <input runat="server" id="txtTlfMobil" name="txtTlfMobil" type="text" placeholder="Mobil" class="form-control input-md">
    
            </div>
        </div>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="txtTlfPrivat">Telefon Privat</label>  
            <div class="col-md-4">
            <input runat="server" id="txtTlfPrivat" name="txtTlfPrivat" type="text" placeholder="Telefon Privat" class="form-control input-md">
    
            </div>
        </div>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="txtTlfArbeid">Telefon Arbeid</label>  
            <div class="col-md-4">
            <input runat="server" id="txtTlfArbeid" name="txtTlfArbeid" type="text" placeholder="Telefon Arbeid" class="form-control input-md">
    
            </div>
        </div>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="txtEPost">E-post</label>  
            <div class="col-md-4">
            <asp:RequiredFieldValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtEPost" style="color:red;" ErrorMessage="<b>* Feltet må fylles inn</b>" />
            <asp:RegularExpressionValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtEPost" style="color:red;" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="<b>* Må ha 8 sifre.</b>"/>
            <input runat="server" id="txtEPost" name="txtEPost" type="text" placeholder="E-post" class="form-control input-md">
    
            </div>
        </div>

        <!-- Select Basic -->
        <div class="form-group">
            <label class="col-md-4 control-label" for="selectAge">Alder</label>
            <div class="col-md-4">
            <asp:DropdownList runat="server" id="selectAge" name="selectAge" class="form-control">
                <asp:ListItem value="0">0</asp:ListItem>
                <asp:ListItem value="1">1</asp:ListItem>
                <asp:ListItem value="2">2</asp:ListItem>
                <asp:ListItem value="3">3</asp:ListItem>
                <asp:ListItem value="4">4</asp:ListItem>
                <asp:ListItem value="5">5</asp:ListItem>
                <asp:ListItem value="6">6</asp:ListItem>
                <asp:ListItem value="7">7</asp:ListItem>
                <asp:ListItem value="8">8</asp:ListItem>
                <asp:ListItem value="9">9</asp:ListItem>
                <asp:ListItem value="10">10</asp:ListItem>
                <asp:ListItem value="11">11</asp:ListItem>
                <asp:ListItem value="12">12</asp:ListItem>
                <asp:ListItem value="13">13</asp:ListItem>
                <asp:ListItem value="14">14</asp:ListItem>
                <asp:ListItem value="15">15</asp:ListItem>
                <asp:ListItem value="16">16</asp:ListItem>
                <asp:ListItem value="17">17</asp:ListItem>
                <asp:ListItem value="18">18</asp:ListItem>
                <asp:ListItem value="19">19</asp:ListItem>
                <asp:ListItem value="20">20</asp:ListItem>
                <asp:ListItem value="21">21</asp:ListItem>
                <asp:ListItem value="22">22</asp:ListItem>
                <asp:ListItem value="23">23</asp:ListItem>
                <asp:ListItem value="24">24</asp:ListItem>
                <asp:ListItem value="25">25</asp:ListItem>
                <asp:ListItem value="26">26</asp:ListItem>
                <asp:ListItem value="27">27</asp:ListItem>
                <asp:ListItem value="28">28</asp:ListItem>
                <asp:ListItem value="29">29</asp:ListItem>
                <asp:ListItem value="30">30</asp:ListItem>
                <asp:ListItem value="31">31</asp:ListItem>
                <asp:ListItem value="32">32</asp:ListItem>
                <asp:ListItem value="33">33</asp:ListItem>
                <asp:ListItem value="34">34</asp:ListItem>
                <asp:ListItem value="35">35</asp:ListItem>
                <asp:ListItem value="36">36</asp:ListItem>
                <asp:ListItem value="37">37</asp:ListItem>
                <asp:ListItem value="38">38</asp:ListItem>
                <asp:ListItem value="39">39</asp:ListItem>
                <asp:ListItem value="40">40</asp:ListItem>
                <asp:ListItem value="41">41</asp:ListItem>
                <asp:ListItem value="42">42</asp:ListItem>
                <asp:ListItem value="43">43</asp:ListItem>
                <asp:ListItem value="44">44</asp:ListItem>
                <asp:ListItem value="45">45</asp:ListItem>
                <asp:ListItem value="46">46</asp:ListItem>
                <asp:ListItem value="47">47</asp:ListItem>
                <asp:ListItem value="48">48</asp:ListItem>
                <asp:ListItem value="49">49</asp:ListItem>
                <asp:ListItem value="50">50</asp:ListItem>
                <asp:ListItem value="51">51</asp:ListItem>
                <asp:ListItem value="52">52</asp:ListItem>
                <asp:ListItem value="53">53</asp:ListItem>
                <asp:ListItem value="54">54</asp:ListItem>
                <asp:ListItem value="55">55</asp:ListItem>
                <asp:ListItem value="56">56</asp:ListItem>
                <asp:ListItem value="57">57</asp:ListItem>
                <asp:ListItem value="58">58</asp:ListItem>
                <asp:ListItem value="59">59</asp:ListItem>
                <asp:ListItem value="60">60</asp:ListItem>
                <asp:ListItem value="61">61</asp:ListItem>
                <asp:ListItem value="62">62</asp:ListItem>
                <asp:ListItem value="63">63</asp:ListItem>
                <asp:ListItem value="64">64</asp:ListItem>
                <asp:ListItem value="65">65</asp:ListItem>
                <asp:ListItem value="66">66</asp:ListItem>
                <asp:ListItem value="67">67</asp:ListItem>
                <asp:ListItem value="68">68</asp:ListItem>
                <asp:ListItem value="69">69</asp:ListItem>
                <asp:ListItem value="70">70</asp:ListItem>
                <asp:ListItem value="71">71</asp:ListItem>
                <asp:ListItem value="72">72</asp:ListItem>
                <asp:ListItem value="73">73</asp:ListItem>
                <asp:ListItem value="74">74</asp:ListItem>
                <asp:ListItem value="75">75</asp:ListItem>
                <asp:ListItem value="76">76</asp:ListItem>
                <asp:ListItem value="77">77</asp:ListItem>
                <asp:ListItem value="78">78</asp:ListItem>
                <asp:ListItem value="79">79</asp:ListItem>
                <asp:ListItem value="80">80</asp:ListItem>
                <asp:ListItem value="81">81</asp:ListItem>
                <asp:ListItem value="82">82</asp:ListItem>
                <asp:ListItem value="83">83</asp:ListItem>
                <asp:ListItem value="84">84</asp:ListItem>
                <asp:ListItem value="85">85</asp:ListItem>
                <asp:ListItem value="86">86</asp:ListItem>
                <asp:ListItem value="87">87</asp:ListItem>
                <asp:ListItem value="88">88</asp:ListItem>
                <asp:ListItem value="89">89</asp:ListItem>
                <asp:ListItem value="90">90</asp:ListItem>
                <asp:ListItem value="91">91</asp:ListItem>
                <asp:ListItem value="92">92</asp:ListItem>
                <asp:ListItem value="93">93</asp:ListItem>
                <asp:ListItem value="94">94</asp:ListItem>
                <asp:ListItem value="95">95</asp:ListItem>
                <asp:ListItem value="96">96</asp:ListItem>
                <asp:ListItem value="97">97</asp:ListItem>
                <asp:ListItem value="98">98</asp:ListItem>
                <asp:ListItem value="99">99</asp:ListItem>
                <asp:ListItem value="100">100</asp:ListItem>
            </asp:DropdownList>
            </div>
        </div>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="txtAddress">Adresse</label>  
            <div class="col-md-4">
            <asp:RequiredFieldValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtAddress" style="color:red;" ErrorMessage="<b>* Feltet må fylles inn</b>" />
            <input runat="server" id="txtAddress" name="txtAddress" type="text" placeholder="Adresse" class="form-control input-md">
    
            </div>
        </div>

        <!-- Text input -->
        <div class="form-group">
            <label class="col-md-4 control-label" for="txtSocialSecurityNumber">Fødselsnummer</label>  
            <div class="col-md-4">
                <asp:RequiredFieldValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtSocialSecurityNumber" style="color:red;" ErrorMessage="<b>* Feltet må fylles inn</b>" />
                <asp:RegularExpressionValidator Validationgroup="UserEditValidatorGroup" Display="Dynamic" runat="server" ControlToValidate="txtSocialSecurityNumber" style="color:red;" ValidationExpression="(\d{11})" ErrorMessage="<b>* Må ha 11 sifre.</b>"/>
                <input runat="server" id="txtSocialSecurityNumber" name="txtSocialSecurityNumber" type="text" placeholder="Fødselsnummer" class="form-control input-md">    
            </div>
        </div>

            <!-- Error label if persInfConsent is not approved -->
        <div class="form-group">
            <label class="col-md-10 control-label" id="lblPersInfConsent" runat="server" style="color:red;">* <a href="/WorkflowItems/PersInfoConsent.aspx" style="color:inherit;">For å kunne fylle inn personopplysninger, må lagring av personopplysinger være godkjent først av gjeldende bruker.</a></label>              
        </div>

        <!-- Buttons -->
        <div class="form-group">
            <label class="col-md-4 control-label" for="btnUpdate"></label>
            <div class="col-md-8">
                <asp:button id="btnUpdate" CommandName="EditUser" Validationgroup="UserEditValidatorGroup" name="btnUpdate" class="btn btn-success" runat="server" Text="Oppdater" OnCommand="UpdateUser"/>
            </div>
        </div>
        </fieldset>
    </div>
</div>

