using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lime
{
    public partial class ReportViewerForm2 : Form
    {
        public ReportViewerForm2()
        {
            InitializeComponent();
        }

        private void ReportViewerForm2_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

        }
    }
}
