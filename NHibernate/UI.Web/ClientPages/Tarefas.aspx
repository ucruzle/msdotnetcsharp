<%@ Page Title="Tarefas" 
    Language="C#" 
    MasterPageFile="~/MasterPageMain.Master" 
    AutoEventWireup="true" 
    CodeBehind="Tarefas.aspx.cs" 
    Inherits="UI.Web.ClientPages.Tarefas" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ContentMidleContent" ContentPlaceHolderID="cphMidleContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerTarefasPage" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanelTarefasPage" runat="server">
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
                            <asp:Label ID="lblDescricao" runat="server" Text="Descrição"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:TextBox ID="txtDescricao" runat="server" style="width: 200px;"></asp:TextBox>
                        </td>
                        <td style="width: 150px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="lblFuncionario" runat="server" Text="Funcionário"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:DropDownList ID="ddlFuncionario" runat="server" style="width: 200px;">
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
                <fieldset><legend>Listar Dados das Tarefas</legend>
                    <asp:GridView ID="dataGrid" runat="server" Width="100%" 
                        AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                        onselectedindexchanged="dataGrid_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="Descricao" HeaderText="Descrição" 
                                SortExpression="Descricao" />
                            <asp:BoundField DataField="IdFuncionario" HeaderText="Funcionário" 
                                SortExpression="IdFuncionario" />
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
