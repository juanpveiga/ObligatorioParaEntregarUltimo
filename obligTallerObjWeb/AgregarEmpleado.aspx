<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarEmpleado.aspx.cs" Inherits="obligTallerObjWeb.AgregarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Agregar Empleado a Rodaje</h1>

    <asp:Label ID="lblRodaje" runat="server" Text="Seleccione un rodaje"></asp:Label>
    <asp:DropDownList ID="DDLRodaje" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="lblEmpleado" runat="server" Text="Seleccione un empleado"></asp:Label>
    <asp:DropDownList ID="DDLEmpleado" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="lblCantHoras" runat="server" Text="Ingrese cantidad de horas"></asp:Label>
    <asp:TextBox ID="txtCantHoras" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar la cantidad de horas" ControlToValidate="txtCantHoras"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Debe ingresar un valor correcto" ControlToValidate="txtCantHoras" MaximumValue="9999999" MinimumValue="0"></asp:RangeValidator>
    <br />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
