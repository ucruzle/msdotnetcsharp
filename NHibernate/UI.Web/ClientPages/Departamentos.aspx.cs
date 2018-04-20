using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Process;

namespace UI.Web.ClientPages
{
    public partial class Departamentos : System.Web.UI.Page
    {
        private DS_DTO.tblDepartamentosRow rowDepartamento = null;
        private cntrlDepartamento objCntrlDepartamento = null;

        private DS_DTO.tblDepartamentosDataTable tblDepartamento 
        {
            set { ViewState["tblDepartamento"] = value; }
            get
            {
                object obj = ViewState["tblDepartamento"];

                if (obj == null)
                {
                    return null;
                }
                else 
                {
                    return (DS_DTO.tblDepartamentosDataTable)obj;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                getData();
            }
        }

        private void getData()
        {
            try
            {
                this.tblDepartamento = cntrlDepartamento.Select();

                dataGrid.DataSource = this.tblDepartamento;
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
            int Id = 0;
            string Nome = string.Empty;

            try
            {
                Id = Convert.ToInt32(dataGrid.SelectedRow.Cells[1].Text);
                Nome = dataGrid.SelectedRow.Cells[2].Text;

                lblValueId.Text = Id.ToString();
                txtNome.Text = Nome;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void updateData()
        {
            Boolean Result = false;
            int Id = 0;

            try
            {
                Id = Convert.ToInt32(lblValueId.Text);

                this.objCntrlDepartamento = new cntrlDepartamento();
                rowDepartamento = this.objCntrlDepartamento.Select(Id);

                rowDepartamento.Nome = txtNome.Text;

                Result = this.objCntrlDepartamento.Save(rowDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.rowDepartamento = null;
                this.objCntrlDepartamento = null;
            }

            this.getData();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void deleteData()
        {
            Boolean Result = false;
            int Id = 0;

            try
            {
                Id = Convert.ToInt32(lblValueId.Text);

                Result = cntrlDepartamento.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.getData();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            lblValueId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtNome.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void insertData()
        {
            Boolean Result = false;

            try
            {
                this.rowDepartamento = this.tblDepartamento.NewtblDepartamentosRow();
                this.objCntrlDepartamento = new cntrlDepartamento();

                rowDepartamento.Nome = txtNome.Text;

                Result = this.objCntrlDepartamento.Save(rowDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.rowDepartamento = null;
                this.objCntrlDepartamento = null;
            }

            this.getData();
        }
    }
}