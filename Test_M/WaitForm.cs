using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_M
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
        }
        public void SetProgress(int procent)
        {
            
            if (procent>0&&procent<101) this.progressBar1.Value = procent;
        
        }
    }
}