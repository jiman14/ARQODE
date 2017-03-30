using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARQODE_VISUAL_EDITOR.REGISTRO_ACCESOS
{
    public partial class VentanaEdicion : Form
    {
        public VentanaEdicion()
        {
            InitializeComponent();
        }

        private void Grid1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
