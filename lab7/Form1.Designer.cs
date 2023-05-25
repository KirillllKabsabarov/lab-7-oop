using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab7
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox_Cntrl = new System.Windows.Forms.CheckBox();
            this.btn_doBigger = new System.Windows.Forms.Button();
            this.btn_doSmaller = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_unSelect = new System.Windows.Forms.Button();
            this.btn_Color = new System.Windows.Forms.Button();
            this.btn_circle = new System.Windows.Forms.Button();
            this.btn_square = new System.Windows.Forms.Button();
            this.btn_triangle = new System.Windows.Forms.Button();
            this.btn_line = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_group = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(944, 19);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // checkBox_Cntrl
            // 
            this.checkBox_Cntrl.AutoSize = true;
            this.checkBox_Cntrl.Location = new System.Drawing.Point(1008, 620);
            this.checkBox_Cntrl.Name = "checkBox_Cntrl";
            this.checkBox_Cntrl.Size = new System.Drawing.Size(40, 17);
            this.checkBox_Cntrl.TabIndex = 2;
            this.checkBox_Cntrl.Text = "ctrl";
            this.checkBox_Cntrl.UseVisualStyleBackColor = true;
            this.checkBox_Cntrl.CheckedChanged += new System.EventHandler(this.checkBox_Cntrl_CheckedChanged);
            // 
            // btn_doBigger
            // 
            this.btn_doBigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_doBigger.Location = new System.Drawing.Point(556, 12);
            this.btn_doBigger.Name = "btn_doBigger";
            this.btn_doBigger.Size = new System.Drawing.Size(49, 49);
            this.btn_doBigger.TabIndex = 2;
            this.btn_doBigger.Text = "+";
            this.btn_doBigger.UseVisualStyleBackColor = true;
            this.btn_doBigger.Click += new System.EventHandler(this.btn_doBigger_Click);
            // 
            // btn_doSmaller
            // 
            this.btn_doSmaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_doSmaller.Location = new System.Drawing.Point(611, 12);
            this.btn_doSmaller.Name = "btn_doSmaller";
            this.btn_doSmaller.Size = new System.Drawing.Size(49, 49);
            this.btn_doSmaller.TabIndex = 3;
            this.btn_doSmaller.Text = "-";
            this.btn_doSmaller.UseVisualStyleBackColor = true;
            this.btn_doSmaller.Click += new System.EventHandler(this.btn_doSmaller_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Delete.Location = new System.Drawing.Point(666, 12);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(104, 49);
            this.btn_Delete.TabIndex = 4;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Select.Location = new System.Drawing.Point(446, 12);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(104, 25);
            this.btn_Select.TabIndex = 5;
            this.btn_Select.Text = "Select all";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_unSelect
            // 
            this.btn_unSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_unSelect.Location = new System.Drawing.Point(446, 36);
            this.btn_unSelect.Name = "btn_unSelect";
            this.btn_unSelect.Size = new System.Drawing.Size(104, 25);
            this.btn_unSelect.TabIndex = 6;
            this.btn_unSelect.Text = "Unselect all";
            this.btn_unSelect.UseVisualStyleBackColor = true;
            this.btn_unSelect.Click += new System.EventHandler(this.btn_unSelect_Click);
            // 
            // btn_Color
            // 
            this.btn_Color.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Color.Location = new System.Drawing.Point(398, 19);
            this.btn_Color.Name = "btn_Color";
            this.btn_Color.Size = new System.Drawing.Size(37, 36);
            this.btn_Color.TabIndex = 7;
            this.btn_Color.UseVisualStyleBackColor = false;
            this.btn_Color.Click += new System.EventHandler(this.btn_Color_Click);
            // 
            // btn_circle
            // 
            this.btn_circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_circle.Location = new System.Drawing.Point(12, 12);
            this.btn_circle.Name = "btn_circle";
            this.btn_circle.Size = new System.Drawing.Size(89, 49);
            this.btn_circle.TabIndex = 8;
            this.btn_circle.Text = "Circle";
            this.btn_circle.UseVisualStyleBackColor = true;
            this.btn_circle.Click += new System.EventHandler(this.btn_circle_Click);
            // 
            // btn_square
            // 
            this.btn_square.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_square.Location = new System.Drawing.Point(107, 12);
            this.btn_square.Name = "btn_square";
            this.btn_square.Size = new System.Drawing.Size(89, 49);
            this.btn_square.TabIndex = 9;
            this.btn_square.Text = "Square";
            this.btn_square.UseVisualStyleBackColor = true;
            this.btn_square.Click += new System.EventHandler(this.btn_square_Click);
            // 
            // btn_triangle
            // 
            this.btn_triangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_triangle.Location = new System.Drawing.Point(202, 12);
            this.btn_triangle.Name = "btn_triangle";
            this.btn_triangle.Size = new System.Drawing.Size(89, 49);
            this.btn_triangle.TabIndex = 10;
            this.btn_triangle.Text = "Triangle";
            this.btn_triangle.UseVisualStyleBackColor = true;
            this.btn_triangle.Click += new System.EventHandler(this.btn_triangle_Click);
            // 
            // btn_line
            // 
            this.btn_line.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_line.Location = new System.Drawing.Point(297, 12);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(89, 49);
            this.btn_line.TabIndex = 11;
            this.btn_line.Text = "Line";
            this.btn_line.UseVisualStyleBackColor = true;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(777, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(777, 37);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 13;
            this.btn_load.Text = "load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_group
            // 
            this.btn_group.Location = new System.Drawing.Point(858, 12);
            this.btn_group.Name = "btn_group";
            this.btn_group.Size = new System.Drawing.Size(75, 23);
            this.btn_group.TabIndex = 14;
            this.btn_group.Text = "group";
            this.btn_group.UseVisualStyleBackColor = true;
            this.btn_group.Click += new System.EventHandler(this.btn_group_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(858, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "unGroup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 649);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_group);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_line);
            this.Controls.Add(this.btn_triangle);
            this.Controls.Add(this.btn_square);
            this.Controls.Add(this.btn_circle);
            this.Controls.Add(this.btn_Color);
            this.Controls.Add(this.btn_unSelect);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_doSmaller);
            this.Controls.Add(this.btn_doBigger);
            this.Controls.Add(this.checkBox_Cntrl);
            this.Controls.Add(this.trackBar1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBox_Cntrl;
        private System.Windows.Forms.Button btn_doBigger;
        private System.Windows.Forms.Button btn_doSmaller;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_unSelect;
        private System.Windows.Forms.Button btn_Color;
        private System.Windows.Forms.Button btn_circle;
        private System.Windows.Forms.Button btn_square;
        private System.Windows.Forms.Button btn_triangle;
        private System.Windows.Forms.Button btn_line;
        private Button btn_save;
        private Button btn_load;
        private Button btn_group;
        private Button button1;
    }
}

