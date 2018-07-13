<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="AltaRodaje.aspx.cs" Inherits="obligTallerObjWeb.AltaRodajeEstudio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Alta de Rodaje Estudio</h1>

    <asp:Label ID="lblId" runat="server" Text="Ingrese numero identificador"></asp:Label>
    <asp:TextBox ID="txtId" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar un numero identificador" ControlToValidate="txtId"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Debe ingresar un numero valido" ControlToValidate="txtId" Type="Integer" MaximumValue="9999999" MinimumValue="0"></asp:RangeValidator>
     <br />
    <asp:Label ID="lblFechaCom" runat="server" Text="Seleccione fecha de comienzo (xx/yy/zzzz)"></asp:Label>
    <asp:TextBox ID="txtFechaCom" runat="server" TextMode="Date"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar una fecha" ControlToValidate="txtFechaCom"></asp:RequiredFieldValidator>
     <br />
    <asp:Label ID="lblHoraCom" runat="server" Text="Ingrese hora de comienzo"></asp:Label>
    <asp:TextBox ID="txtHoraCom" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe Ingresar hora comienzo" ControlToValidate="txtHoraCom"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Debe ser un dato valido" ControlToValidate="txtHoraCom" MinimumValue="0" MaximumValue="2500" Type="Integer"></asp:RangeValidator>
    <br />
    <asp:Label ID="lblDuracion" runat="server" Text="Ingrese la duracion"></asp:Label>
    <asp:TextBox ID="txtDuracion" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe ingresar la duracion" ControlToValidate="txtDuracion"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtDuracion" MaximumValue="9999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
    <br />
    <asp:Label ID="lblObra" runat="server" Text="Seleccione una obra"></asp:Label>
    <asp:DropDownList ID="DDLObra" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="lblLugar" runat="server" Text="Selleccione un lugar"></asp:Label>
    <asp:DropDownList ID="DDLLugar" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblTipo" runat="server" Text="Seleccione un tipo"></asp:Label>
    <br />
    <asp:RadioButton ID="rbnEstudio" runat="server" Text="Estudio" OnCheckedChanged="rbtEstudio_CheckedChanged" AutoPostBack="True" GroupName="TipoRodaje" />
    <asp:RadioButton ID="rbnLocacion" runat="server" Text="Locacion" OnCheckedChanged="rbtLocacion_CheckedChanged" AutoPostBack="True" GroupName="TipoRodaje" />
    <br />
    <asp:PlaceHolder ID="plcEstudio" runat="server">
        <asp:Label ID="lblSet" runat="server" Text="Ingrese Set"></asp:Label>
        <asp:TextBox ID="txtSet" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe ingresar un nombre de set" ControlToValidate="txtSet"></asp:RequiredFieldValidator>
    </asp:PlaceHolder>
    <br />
    <asp:PlaceHolder ID="plcLocacion" runat="server">
        <asp:Label ID="lblLocacion" runat="server" Text="Ingrese Locacion"></asp:Label>
        <asp:TextBox ID="txtLocacion" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe ingresar una locacion" ControlToValidate="txtLocacion"></asp:RequiredFieldValidator>
    </asp:PlaceHolder>
    <br />
    <br />
    <asp:Button ID="btnAltaRodaje" runat="server" Text="Dar de alta" OnClick="btnAltaRodaje_Click" />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
