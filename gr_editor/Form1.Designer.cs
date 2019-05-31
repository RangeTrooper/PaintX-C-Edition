using System;
using System.Windows.Forms;

namespace gr_editor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RectButton = new System.Windows.Forms.Button();
            this.OvalButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.RhombusButton = new System.Windows.Forms.Button();
            this.TriButton = new System.Windows.Forms.Button();
            this.StarButton = new System.Windows.Forms.Button();
            this.selectTool = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(882, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Инструмент:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(863, 578);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelMousePressed);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseReleased);
            // 
            // RectButton
            // 
            this.RectButton.Location = new System.Drawing.Point(885, 69);
            this.RectButton.Name = "RectButton";
            this.RectButton.Size = new System.Drawing.Size(183, 23);
            this.RectButton.TabIndex = 4;
            this.RectButton.Text = "Rect";
            this.RectButton.UseVisualStyleBackColor = true;
            this.RectButton.Click += new System.EventHandler(this.RectButtonClicked);
            // 
            // OvalButton
            // 
            this.OvalButton.Location = new System.Drawing.Point(885, 109);
            this.OvalButton.Name = "OvalButton";
            this.OvalButton.Size = new System.Drawing.Size(182, 22);
            this.OvalButton.TabIndex = 5;
            this.OvalButton.Text = "Oval";
            this.OvalButton.UseVisualStyleBackColor = true;
            this.OvalButton.Click += new System.EventHandler(this.OvalButtonClicked);
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(885, 152);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(182, 22);
            this.LineButton.TabIndex = 6;
            this.LineButton.Text = "Line";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButtonClicked);
            // 
            // RhombusButton
            // 
            this.RhombusButton.Location = new System.Drawing.Point(886, 191);
            this.RhombusButton.Name = "RhombusButton";
            this.RhombusButton.Size = new System.Drawing.Size(182, 22);
            this.RhombusButton.TabIndex = 7;
            this.RhombusButton.Text = "Rhombus";
            this.RhombusButton.UseVisualStyleBackColor = true;
            this.RhombusButton.Click += new System.EventHandler(this.RhombusButtonClicked);
            // 
            // TriButton
            // 
            this.TriButton.Location = new System.Drawing.Point(886, 232);
            this.TriButton.Name = "TriButton";
            this.TriButton.Size = new System.Drawing.Size(182, 25);
            this.TriButton.TabIndex = 8;
            this.TriButton.Text = "Triangle";
            this.TriButton.UseVisualStyleBackColor = true;
            this.TriButton.Click += new System.EventHandler(this.TriButtonClicked);
            // 
            // StarButton
            // 
            this.StarButton.Location = new System.Drawing.Point(886, 275);
            this.StarButton.Name = "StarButton";
            this.StarButton.Size = new System.Drawing.Size(182, 22);
            this.StarButton.TabIndex = 9;
            this.StarButton.Text = "Star";
            this.StarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.StarButton.UseVisualStyleBackColor = true;
            this.StarButton.Click += new System.EventHandler(this.StarButtonClicked);
            // 
            // selectTool
            // 
            this.selectTool.Location = new System.Drawing.Point(886, 381);
            this.selectTool.Name = "selectTool";
            this.selectTool.Size = new System.Drawing.Size(181, 23);
            this.selectTool.TabIndex = 10;
            this.selectTool.Text = "Выделить";
            this.selectTool.UseVisualStyleBackColor = true;
            this.selectTool.Click += new System.EventHandler(this.selectTool_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1088, 27);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(87, 24);
            this.toolStripButton1.Text = "Сохранить";
            this.toolStripButton1.Click += new System.EventHandler(this.SaveButtonClicked);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(81, 24);
            this.toolStripButton2.Text = "Загрузить";
            this.toolStripButton2.ToolTipText = "Загрузить из файла";
            this.toolStripButton2.Click += new System.EventHandler(this.LoadButtonClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 606);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.selectTool);
            this.Controls.Add(this.StarButton);
            this.Controls.Add(this.TriButton);
            this.Controls.Add(this.RhombusButton);
            this.Controls.Add(this.LineButton);
            this.Controls.Add(this.OvalButton);
            this.Controls.Add(this.RectButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private Button RectButton;
        private Button OvalButton;
        private Button LineButton;
        private Button RhombusButton;
        private Button TriButton;
        private Button StarButton;
        private Button selectTool;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
    }
}

