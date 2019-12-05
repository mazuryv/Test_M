namespace Test_M
{
    partial class FormForAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForAdmin));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.додатиАдміністратораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиАдміністратораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редагуватиАдміністратораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(22, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(404, 228);
            this.listBox1.TabIndex = 0;
            this.listBox1.Tag = "Список користувачів у программі";
            this.listBox1.DoubleClick += new System.EventHandler(this.buttonEdit_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиАдміністратораToolStripMenuItem,
            this.видалитиАдміністратораToolStripMenuItem,
            this.редагуватиАдміністратораToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 70);
            // 
            // додатиАдміністратораToolStripMenuItem
            // 
            this.додатиАдміністратораToolStripMenuItem.Image = global::Test_M.Properties.Resources.plus;
            this.додатиАдміністратораToolStripMenuItem.Name = "додатиАдміністратораToolStripMenuItem";
            this.додатиАдміністратораToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.додатиАдміністратораToolStripMenuItem.Tag = "Додати нового користувача-адміністратора";
            this.додатиАдміністратораToolStripMenuItem.Text = "Додати";
            this.додатиАдміністратораToolStripMenuItem.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // видалитиАдміністратораToolStripMenuItem
            // 
            this.видалитиАдміністратораToolStripMenuItem.Enabled = false;
            this.видалитиАдміністратораToolStripMenuItem.Image = global::Test_M.Properties.Resources.minus;
            this.видалитиАдміністратораToolStripMenuItem.Name = "видалитиАдміністратораToolStripMenuItem";
            this.видалитиАдміністратораToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.видалитиАдміністратораToolStripMenuItem.Tag = "Видалити користувача-адміністратора з програми";
            this.видалитиАдміністратораToolStripMenuItem.Text = "Видалити";
            this.видалитиАдміністратораToolStripMenuItem.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // редагуватиАдміністратораToolStripMenuItem
            // 
            this.редагуватиАдміністратораToolStripMenuItem.Enabled = false;
            this.редагуватиАдміністратораToolStripMenuItem.Image = global::Test_M.Properties.Resources.videlenie;
            this.редагуватиАдміністратораToolStripMenuItem.Name = "редагуватиАдміністратораToolStripMenuItem";
            this.редагуватиАдміністратораToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.редагуватиАдміністратораToolStripMenuItem.Tag = "Редагувати виділеного користувача-адміністратора";
            this.редагуватиАдміністратораToolStripMenuItem.Text = "Редагувати";
            this.редагуватиАдміністратораToolStripMenuItem.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(17, 311);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(404, 32);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Додати адміністратора";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Enabled = false;
            this.buttonDel.Location = new System.Drawing.Point(17, 349);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(404, 32);
            this.buttonDel.TabIndex = 2;
            this.buttonDel.Tag = "Натисніть, щоб видалити";
            this.buttonDel.Text = "Видалити адміністратора";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(17, 387);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(404, 32);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Tag = "Натисніть для редагування виділеного користувача";
            this.buttonEdit.Text = "Редагувати адміністратора";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Location = new System.Drawing.Point(86, 442);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(266, 48);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Закрити";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Список адміністраторів";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Виберіть групу:";
            this.label2.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(22, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(404, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Tag = "Список наявних груп (для додавання нової групи, натисніть кнопку \"Редагування гру" +
    "п чи класів у вкладці \"Адміністратор\")";
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Список учнів:";
            this.label3.Visible = false;
            // 
            // FormForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 507);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormForAdmin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormForAdmin_KeyUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem додатиАдміністратораToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиАдміністратораToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редагуватиАдміністратораToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
    }
}