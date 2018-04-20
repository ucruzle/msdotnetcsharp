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
    public partial class Funcionarios : System.Web.UI.Page
    {
        private cntrlFuncionario objCntrlFuncionario = null;
        private DS_DTO.tblFuncionariosRow rowFuncionario = null;

        private DS_DTO.tblFuncionariosDataTable tblFuncionario
        {
            set { ViewState["tblFuncionario"] = value; }
            get
            {
                object obj = ViewState["tblFuncionario"];

                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return (DS_DTO.tblFuncionariosDataTable)obj;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string IdRequest = Request.QueryString["Id"];

                int Id = int.Parse(IdRequest);

                getData(Id);
                fillDropDowListDepartamentoControl();
            }
        }

        private void fillDropDowListDepartamentoControl()
        {
            try
            {
                DataTable tblDepartamento = cntrlDepartamento.Select();

                ddlDepartamento.DataSource = tblDepartamento;
                ddlDepartamento.DataValueField = "Id";
                ddlDepartamento.DataTextField = "Nome";
                ddlDepartamento.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void getData(int Id)
        {
            try
            {
                this.tblFuncionario = cntrlFuncionario.SelectByDepartamento(Id);

                dataGrid.DataSource = this.tblFuncionario;
                dataGrid.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex();
        }

        private void selectedIndex()
        {
            lblValueId.Text = dataGrid.SelectedRow.Cells[1].Text;
            txtNome.Text = dataGrid.SelectedRow.Cells[2].Text;
            txtDataAdmin.Text = dataGrid.SelectedRow.Cells[3].Text;
            ddlDepartamento.SelectedIndex = Convert.ToInt32(dataGrid.SelectedRow.Cells[4].Text);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateFuncionario();
        }

        private void updateFuncionario()
        {
            updateData();
        }

        private void updateData()
        {
            Boolean Result = false;

            int dep_Id = int.Parse(ddlDepartamento.SelectedValue.ToString());

            int Id = int.Parse(lblValueId.Text);

            try
            {
                this.objCntrlFuncionario = new cntrlFuncionario();

                this.rowFuncionario = this.objCntrlFuncionario.Select(Id);
                this.rowFuncionario.Nome = txtNome.Text;
                this.rowFuncionario.DataAdmin = Convert.ToDateTime(txtDataAdmin.Text);
                this.rowFuncionario.IdDepartamento = dep_Id;

                Result = this.objCntrlFuncionario.Save(rowFuncionario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.objCntrlFuncionario = null;
                this.rowFuncionario = null;
            }

            this.getData(dep_Id);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void insertData()
        {
            Boolean Result = false;

            int dep_Id = int.Parse(ddlDepartamento.SelectedValue.ToString());

            try
            {
                this.objCntrlFuncionario = new cntrlFuncionario();

                this.rowFuncionario = this.tblFuncionario.NewtblFuncionariosRow();
                this.rowFuncionario.Nome = txtNome.Text.Trim();
                this.rowFuncionario.DataAdmin = Convert.ToDateTime(txtDataAdmin.Text.Trim());
                this.rowFuncionario.IdDepartamento = dep_Id;

                Result = this.objCntrlFuncionario.Save(rowFuncionario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.objCntrlFuncionario = null;
                this.rowFuncionario = null;
            }

            this.getData(dep_Id);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            lblValueId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtDataAdmin.Text = string.Empty;
            ddlDepartamento.SelectedIndex = 0;
            txtNome.Focus();
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
                int Id = Convert.ToInt32(lblValueId.Text);

                Result = cntrlFuncionario.Delete(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.objCntrlFuncionario = null;
                this.rowFuncionario = null;
            }

            this.getData(int.Parse(Request.QueryString["Id"].ToString()));

            this.clearFields();
        }
    }
}