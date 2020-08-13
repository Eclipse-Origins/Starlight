using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Starlight.Editors
{
    public class FormContainer
    {
        private readonly StarlightContext context;

        public Form PrimaryForm { get; private set; }

        public FormContainer(StarlightContext context) {
            this.context = context;
        }

        public TForm ChangeForm<TForm>() where TForm : Form {
            if (this.PrimaryForm != null) {
                this.PrimaryForm.FormClosed -= PrimaryForm_FormClosed;
                this.PrimaryForm.Close();
            }

            var form = (TForm)Activator.CreateInstance(typeof(TForm), context);
            form.Show();

            this.PrimaryForm = form;
            this.PrimaryForm.FormClosed += PrimaryForm_FormClosed;

            return form;
        }

        private void PrimaryForm_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
