using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL.Process;

namespace UI.Web.ClientPages
{
    public partial class Tarefas : System.Web.UI.Page
    {
        private cntrlTarefa objCntrlTarefa = null;
        private DS_DTO.tblTarefasRow rowTarefa = null;

        private DS_DTO.tblTarefasDataTable tblTarefa
        {
            set { ViewState["tblTarefa"] = value; }
            get
            {
                object obj = ViewState["tblTarefa"];

                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return (DS_DTO.tblTarefasDataTable)obj;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int Func_Id;

                string Id = Request.QueryString["Id"];

                if (Id == null) 
                {
                    lblValueId.Text = string.Empty;
                    lblValueId.Text = "Nenhum código foi Fornecido!";
                    return;
                }
                else
                {
                    Func_Id = int.Parse(Id);
                }

                getData(Func_Id);
                fillDropDowListFuncionarioControl();
            }
        }

        private void getData(int Func_Id)
        {
            try
            {
                this.tblTarefa = cntrlTarefa.SelectByFuncionario(Func_Id);

                dataGrid.DataSource = this.tblTarefa;
                dataGrid.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        private void fillDropDowListFuncionarioControl()
        {
            try
            {
                DataTable tblFuncionario = cntrlFuncionario.Select();

                ddlFuncionario.DataSource = tblFuncionario;
                ddlFuncionario.DataValueField = "Id";
                ddlFuncionario.DataTextField = "Nome";
                ddlFuncionario.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex();
        }

        private void SelectedIndex()
        {
            lblValueId.Text = dataGrid.SelectedRow.Cells[1].Text;
            txtDescricao.Text = dataGrid.SelectedRow.Cells[2].Text;
            ddlFuncionario.SelectedIndex = int.Parse(dataGrid.SelectedRow.Cells[3].Text);
            txtDescricao.Focus();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            lblValueId.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            ddlFuncionario.SelectedIndex = 0;
            txtDescricao.Focus();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void deleteData()
        {
            Boolean Result = false;

            try
            {
                int Id = int.Parse(lblValueId.Text);

                Result = cntrlTarefa.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.getData(int.Parse(Request.QueryString["Id"].ToString()));
            this.clearFields();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void insertData()
        {
            Boolean Result = false;

            int Func_Id = int.Parse(ddlFuncionario.SelectedValue.ToString());

            try
            {
                this.objCntrlTarefa = new cntrlTarefa();

                this.rowTarefa = this.tblTarefa.NewtblTarefasRow();
                this.rowTarefa.Descricao = txtDescricao.Text.Trim();
                this.rowTarefa.IdFuncionario = Func_Id;

                Result = this.objCntrlTarefa.Save(rowTarefa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.objCntrlTarefa = null;
                this.rowTarefa = null;
            }

            this.getData(Func_Id);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Boolean Result = false;

            int Func_Id = int.Parse(ddlFuncionario.SelectedValue.ToString());

            int Id = int.Parse(lblValueId.Text);

            try
            {
                this.objCntrlTarefa = new cntrlTarefa();

                this.rowTarefa = this.objCntrlTarefa.Select(Id);
                this.rowTarefa.Descricao = txtDescricao.Text.Trim();
                this.rowTarefa.IdFuncionario = Func_Id;

                Result = this.objCntrlTarefa.Save(rowTarefa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.objCntrlTarefa = null;
                this.rowTarefa = null;
            }

            this.getData(Func_Id);
        }
    }
}