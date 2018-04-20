<%@ Page Title="Funcionarios" 
    Language="C#" 
    MasterPageFile="~/MasterPageMain.Master" 
    AutoEventWireup="true" 
    CodeBehind="Funcionarios.aspx.cs" 
    Inherits="UI.Web.ClientPages.Funcionarios" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ContentMidleContent" ContentPlaceHolderID="cphMidleContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerFuncionariosPage" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanelFuncionariosPage" runat="server">
        <ContentTemplate>
            <fieldset><legend>Adicionar | Alterar | Excluir Registros</legend>
                <table align="center" style="width: 100%;">
                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:Label ID="lblValueId" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 150px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 150px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="lblDataAdmin" runat="server" Text="Data de Aminissão"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:TextBox ID="txtDataAdmin" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 150px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="lblDepartamento" runat="server" Text="Departamento"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:DropDownList ID="ddlDepartamento" runat="server" style="width: 120px;">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 150px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 150px;"></td>
                        <td style="width: 300px;">
                            <asp:Button ID="btnNew" runat="server" Text="Novo" onclick="btnNew_Click" />
                            <asp:Button ID="btnAdd" runat="server" Text="Adicionar" 
                                onclick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Alterar" 
                                onclick="btnUpdate_Click" />
                            <asp:Button ID="btnDelete" runat="server" Text="Excluir" 
                                onclick="btnDelete_Click" />
                        </td>
                        <td style="width: 150px;"></td>
                    </tr>
                    </table>
                </fieldset>
                <div>
                    <fieldset><legend>Listar Dados dos Funcionarios</legend>
                        <asp:GridView ID="dataGrid" runat="server" style="width: 100%;"
                            AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                            onselectedindexchanged="dataGrid_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                                <asp:BoundField DataField="DataAdmin" HeaderText="Data de Admissão" 
                                    SortExpression="DataAdmin" />
                                <asp:BoundField DataField="IdDepartamento" HeaderText="Departamento" 
                                    SortExpression="IdDepartamento" />
                                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                                    DataNavigateUrlFormatString="~/ClientPages/Tarefas.aspx?Id={0}" 
                                    HeaderText="Tarefas por Funcionário" Text="Tarefas">
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </fieldset>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
