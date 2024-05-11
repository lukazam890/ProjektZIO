using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZioClient.ModelData;
using ZioClient.WindowManagment;

namespace ZioClient.Windows
{
    public partial class ResultsWindow : Form
    {
        public ResultsWindow(List<Test> results)
        {
            InitializeComponent();
            dataGridView_results.DataSource = results;
        }

    }
}
