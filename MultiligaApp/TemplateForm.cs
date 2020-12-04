using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiligaApp
{
    public partial class TemplateForm : Form
    {
        public multiligaEntities db;
        private TemplateForm previousForm;
        public TemplateForm(TemplateForm form)
        {
            InitializeComponent();
            this.db = new multiligaEntities();
            Utility.setDBContext(db);
            previousForm = form;  //sprawdzam co było poprzednią form
        }
        public TemplateForm()
        {

        }
        private void TemplateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Dispose();
            if (previousForm != null)
            {
                Utility.setDBContext(previousForm.db);
            }

            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
            else
            {
                int visibleForms = 0;
                for (int i = 0; i < Application.OpenForms.Count; ++i)
                {
                    if (Application.OpenForms[i].Visible == true)
                    {
                        ++visibleForms;
                    }
                }
                if (visibleForms == 0)
                {
                    Application.Exit();
                }
            }
        }        
    }
}
