<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Desemp2.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <p>
        <br />
        Formulario de Registración:</p>
    <p>
        Email:
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" ErrorMessage="Debe ingresar un email" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="No es válido el formato del email ingresado." ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Username:
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Username" ErrorMessage="Debe ingresar un username" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
    </p>
    <p>
        Edad:
        <asp:TextBox ID="Edad" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Edad" ErrorMessage="Debe ingresar su edad" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="Edad" ErrorMessage="Su edad debe ser mayor a 15 años" ForeColor="#FF3300" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
    </p>
    <p>
        Contraseña:
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Password" ErrorMessage="Debe ingresar una contraseña" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
    </p>
    <p>
        Repita la contraseña:
        <asp:TextBox ID="Password2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Password2" ErrorMessage="Debe ingresar su contraseña nuevamente" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="Password2" ErrorMessage="Las contraseñas ingresadas deben ser iguales." ForeColor="#FF3300">*</asp:CompareValidator>
    </p>
    <p>
        <asp:Button ID="BtnRegistro" runat="server" OnClick="BtnRegistro_Click" Text="REGISTRAR" />
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" />
    <p>
        <asp:Label ID="ResRegistro" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>



</asp:Content>
