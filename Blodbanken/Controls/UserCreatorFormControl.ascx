<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserCreatorFormControl.ascx.cs" Inherits="Blodbanken.Controls.UserCreatorFormControl" %>
<fieldset>
    <!-- Text input-->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtUsername">Brukernavn</label>  
        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtUsername" style="color:red;" ErrorMessage="<b>* Brukernavn må fylles inn</b>" />
        <div class="col-md-4">
        <input id="txtUsername" name="txtUsername" type="text" placeholder="Brukernavn" class="form-control input-md" required="" runat="server" />
    
        </div>
    </div>

    <!-- Password input 1 -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtPassword1">Passord</label>
        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword1" style="color:red;" ErrorMessage="<b>* Passord må fylles inn</b>" />
        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword1" style="color:red;" ValidationExpression="(^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$)" ErrorMessage="<b>* Feil passordkompleksitet.</b>"/>
        <asp:CompareValidator Display="Dynamic" runat="server" id="cmpNumbers" controltovalidate="txtPassword1" style="color:red;" controltocompare="txtPassword2" operator="Equal" type="String" errormessage="<br/><b>* Begge passord må være like.</b>" />
        <div class="col-md-4">
        <input id="txtPassword1" name="txtPassword1" type="password" placeholder="Passord" class="form-control input-md" required="" runat="server" />
    
        </div>
    </div>

    <!-- Password input 2 -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtPassword2">Verifiser Passord</label>
        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword2" style="color:red;" ErrorMessage="<b>* Passord må fylles inn</b>" />
        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="txtPassword2" style="color:red;" ValidationExpression="(^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$)" ErrorMessage="<b>* Feil passordkompleksitet.</b>"/>
        <div class="col-md-4">
        <input id="txtPassword2" name="txtPassword2" type="password" placeholder="Passord" class="form-control input-md" required="" runat="server" />
    
        </div>
    </div>

    <!-- Select Basic -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="selectRole">Role</label>
        <div class="col-md-4">
        <select id="selectRole" name="selectRole" class="form-control" runat="server">
            <option value="1">Admin</option>
            <option value="2">Donor</option>
            <option value="3">Viewer</option>
        </select>
        </div>
    </div>

    <!-- Text input
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtFornavn">Fornavn</label>  
        <div class="col-md-4">
        <input id="txtFornavn" name="txtFornavn" type="text" placeholder="Fornavn" class="form-control input-md" required="">
    
        </div>
    </div>

    <!-- Text input
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtEtternavn">Etternavn</label>  
        <div class="col-md-4">
        <input id="txtEtternavn" name="txtEtternavn" type="text" placeholder="Etternavn" class="form-control input-md" required="">
    
        </div>
    </div>
    <!-- Select Basic
    <div class="form-group">
        <label class="col-md-4 control-label" for="selectAge">Alder</label>
        <div class="col-md-2">
        <select id="selectAge" name="selectAge" class="form-control">
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
            <option value="11">11</option>
            <option value="12">12</option>
            <option value="13">13</option>
            <option value="14">14</option>
            <option value="15">15</option>
            <option value="16">16</option>
            <option value="17">17</option>
            <option value="18">18</option>
            <option value="19">19</option>
            <option value="20">20</option>
            <option value="21">21</option>
            <option value="22">22</option>
            <option value="23">23</option>
            <option value="24">24</option>
            <option value="25">25</option>
            <option value="26">26</option>
            <option value="27">27</option>
            <option value="28">28</option>
            <option value="29">29</option>
            <option value="30">30</option>
            <option value="31">31</option>
            <option value="32">32</option>
            <option value="33">33</option>
            <option value="34">34</option>
            <option value="35">35</option>
            <option value="36">36</option>
            <option value="37">37</option>
            <option value="38">38</option>
            <option value="39">39</option>
            <option value="40">40</option>
            <option value="41">41</option>
            <option value="42">42</option>
            <option value="43">43</option>
            <option value="44">44</option>
            <option value="45">45</option>
            <option value="46">46</option>
            <option value="47">47</option>
            <option value="48">48</option>
            <option value="49">49</option>
            <option value="50">50</option>
            <option value="51">51</option>
            <option value="52">52</option>
            <option value="53">53</option>
            <option value="54">54</option>
            <option value="55">55</option>
            <option value="56">56</option>
            <option value="57">57</option>
            <option value="58">58</option>
            <option value="59">59</option>
            <option value="60">60</option>
            <option value="61">61</option>
            <option value="62">62</option>
            <option value="63">63</option>
            <option value="64">64</option>
            <option value="65">65</option>
            <option value="66">66</option>
            <option value="67">67</option>
            <option value="68">68</option>
            <option value="69">69</option>
            <option value="70">70</option>
            <option value="71">71</option>
            <option value="72">72</option>
            <option value="73">73</option>
            <option value="74">74</option>
            <option value="75">75</option>
            <option value="76">76</option>
            <option value="77">77</option>
            <option value="78">78</option>
            <option value="79">79</option>
            <option value="80">80</option>
            <option value="81">81</option>
            <option value="82">82</option>
            <option value="83">83</option>
            <option value="84">84</option>
            <option value="85">85</option>
            <option value="86">86</option>
            <option value="87">87</option>
            <option value="88">88</option>
            <option value="89">89</option>
            <option value="90">90</option>
            <option value="91">91</option>
            <option value="92">92</option>
            <option value="93">93</option>
            <option value="94">94</option>
            <option value="95">95</option>
            <option value="96">96</option>
            <option value="97">97</option>
            <option value="98">98</option>
            <option value="99">99</option>
            <option value="100">100</option>
        </select>
        </div>
    </div>

    <!-- Textarea
    <div class="form-group">
        <label class="col-md-4 control-label" for="txtAdresse">Adresse</label>
        <div class="col-md-4">                     
            <textarea class="form-control" id="txtAdresse" name="txtAdresse">Adresse</textarea>
        </div>
    </div>
    <!-- Button (Double) -->
    <div class="form-group">
        <label class="col-md-4 control-label" for="btnCreate"></label>
        <div class="col-md-8">
            <asp:button id="btnCreate" name="btnCreate" class="btn btn-success" runat="server" Text="Opprett" OnClick="CreateUser"/>
            <button id="btnCancel" name="btnCancel" class="btn btn-danger">Avbryt</button>
        </div>
    </div>
</fieldset>
