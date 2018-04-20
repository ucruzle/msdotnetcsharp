<%@ Page Title="Departamentos" 
    Language="C#" 
    MasterPageFile="~/MasterPageMain.Master" 
    AutoEventWireup="true" 
    CodeBehind="Departamentos.aspx.cs" 
    Inherits="UI.Web.ClientPages.Departamentos" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ContentMidleContent" ContentPlaceHolderID="cphMidleContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerDepartamentoPage" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanelDepartamento" runat="server">
        <ContentTemplate>
            <fieldset><legend>Adicionar | Alterar | Excluir Registro</legend>
                <table align="center" style=" width: 100%;">
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
                        <td style="width: 150px;"></td>
                        <td style="width: 300px;">
                            <asp:Button ID="btnNew" runat="server" Text="Novo" onclick="btnNew_Click" />
                            <asp:Button ID="btnAdd" runat="server" Text="Adicionar" 
                                onclick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Alterar" 
                                onclick="btnUpdate_Click" />
                            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" 
                                onclick="btnExcluir_Click" />
                        </td>
                        <td style="width: 150px;"></td>
                    </tr>
                </table>
            </fieldset>
            <fieldset><legend>Listar Dados dos Departamentos</legend>
                <div>
                    <asp:GridView ID="dataGrid" runat="server" Width="100%" 
                        AutoGenerateColumns="False" DataKeyNames="Id" 
                        onselectedindexchanged="dataGrid_SelectedIndexChanged" 
                        AutoGenerateSelectButton="True">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                            <asp:HyperLinkField DataNavigateUrlFormatString="~/ClientPages/Funcionarios.aspx?Id={0}" 
                                Text="Funcionarios" DataNavigateUrlFields="Id" 
                                HeaderText="Funcionarios por Departamento">
                                <ItemStyle HorizontalAlign="Center" Width="250px" />
                            </asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
