using System;
using System.Collections.Generic;
using System.Text;

namespace Test_M
{// Объявление делегата
    public delegate void ChangedEventHandler(object sender,
                            ChangedEventArgs args);
    
    public class ChangedEventArgs : EventArgs
    {
        private int indexX;
        private int indexY;
        public int IndexX
        {
            get { return (indexX); }
            set { indexX = value; }
        }
        public int IndexY
        {
            get { return (indexY); }
            set { indexY = value; }
        }
    }//class ChangedEventArgs

    class MyButton:System.Windows.Forms.Button 
    {
        private bool IfChecked = false;
        new public event ChangedEventHandler MouseLeave;
        new public event ChangedEventHandler MouseEnter;
        new public event ChangedEventHandler Click;
        private ChangedEventArgs evargs = new ChangedEventArgs();
        public bool IfCheck() {
            return this.IfChecked;
        }
        public void IfCheck(bool val) {
            this.IfChecked = val;
        }
        protected override void OnMouseEnter(EventArgs e)
        {   evargs.IndexX = Convert.ToInt32(this.Name.Substring((this.Name.IndexOf("[")+1),1));
            evargs.IndexY = Convert.ToInt32(this.Name.Substring((this.Name.IndexOf("]") -1), 1));
            if (MouseEnter != null)
                MouseEnter(this, evargs );
            base.OnMouseEnter(e);
           
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            evargs.IndexX = Convert.ToInt32(this.Name.Substring((this.Name.IndexOf("[") + 1), 1));
            evargs.IndexY = Convert.ToInt32(this.Name.Substring((this.Name.IndexOf("]") - 1), 1));
            if (MouseLeave != null)
                MouseLeave(this, evargs);
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            evargs.IndexX = Convert.ToInt32(this.Name.Substring((this.Name.IndexOf("[") + 1), 1));
            evargs.IndexY = Convert.ToInt32(this.Name.Substring((this.Name.IndexOf("]") - 1), 1));
            if (Click != null)
                Click(this, evargs);
            base.OnClick(e);
        }

    }





}
