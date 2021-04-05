namespace PDFMergeSplitSample
{
    partial class MergeSplit
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
            this.Icon = PDFMergeSplitSample.Properties.Resources.pdf_tools;

            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseInput2 = new System.Windows.Forms.Button();
            this.btnBrowseInput1 = new System.Windows.Forms.Button();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.labelInput2 = new System.Windows.Forms.Label();
            this.labelInput1 = new System.Windows.Forms.Label();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.label2);
            this.groupBoxInput.Controls.Add(this.label1);
            this.groupBoxInput.Controls.Add(this.btnBrowseInput2);
            this.groupBoxInput.Controls.Add(this.btnBrowseInput1);
            this.groupBoxInput.Controls.Add(this.txtInput2);
            this.groupBoxInput.Controls.Add(this.txtInput1);
            this.groupBoxInput.Controls.Add(this.labelInput2);
            this.groupBoxInput.Controls.Add(this.labelInput1);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(482, 115);
            this.groupBoxInput.TabIndex = 0;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "for merge";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "for merge/split";
            // 
            // btnBrowseInput2
            // 
            this.btnBrowseInput2.Location = new System.Drawing.Point(427, 67);
            this.btnBrowseInput2.Name = "btnBrowseInput2";
            this.btnBrowseInput2.Size = new System.Drawing.Size(29, 29);
            this.btnBrowseInput2.TabIndex = 5;
            this.btnBrowseInput2.Text = "...";
            this.btnBrowseInput2.UseVisualStyleBackColor = true;
            this.btnBrowseInput2.Click += new System.EventHandler(this.btnBrowseInput2_Click);
            // 
            // btnBrowseInput1
            // 
            this.btnBrowseInput1.Location = new System.Drawing.Point(427, 27);
            this.btnBrowseInput1.Name = "btnBrowseInput1";
            this.btnBrowseInput1.Size = new System.Drawing.Size(29, 29);
            this.btnBrowseInput1.TabIndex = 4;
            this.btnBrowseInput1.Text = "...";
            this.btnBrowseInput1.UseVisualStyleBackColor = true;
            this.btnBrowseInput1.Click += new System.EventHandler(this.btnBrowseInput1_Click);
            // 
            // txtInput2
            // 
            this.txtInput2.Location = new System.Drawing.Point(114, 72);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(301, 20);
            this.txtInput2.TabIndex = 3;
            // 
            // txtInput1
            // 
            this.txtInput1.Location = new System.Drawing.Point(114, 32);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(301, 20);
            this.txtInput1.TabIndex = 2;
            // 
            // labelInput2
            // 
            this.labelInput2.AutoSize = true;
            this.labelInput2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInput2.Location = new System.Drawing.Point(22, 74);
            this.labelInput2.Name = "labelInput2";
            this.labelInput2.Size = new System.Drawing.Size(83, 13);
            this.labelInput2.TabIndex = 1;
            this.labelInput2.Text = "Input PDF 2";
            // 
            // labelInput1
            // 
            this.labelInput1.AutoSize = true;
            this.labelInput1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInput1.Location = new System.Drawing.Point(22, 34);
            this.labelInput1.Name = "labelInput1";
            this.labelInput1.Size = new System.Drawing.Size(83, 13);
            this.labelInput1.TabIndex = 0;
            this.labelInput1.Text = "Input PDF 1";
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.label3);
            this.groupBoxOutput.Controls.Add(this.btnOutput);
            this.groupBoxOutput.Controls.Add(this.txtOutput);
            this.groupBoxOutput.Controls.Add(this.labelOutput);
            this.groupBoxOutput.Location = new System.Drawing.Point(12, 133);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(482, 70);
            this.groupBoxOutput.TabIndex = 1;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "for merge/split";
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(428, 22);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(29, 29);
            this.btnOutput.TabIndex = 6;
            this.btnOutput.Text = "...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(114, 27);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(301, 20);
            this.txtOutput.TabIndex = 1;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutput.Location = new System.Drawing.Point(22, 29);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(79, 13);
            this.labelOutput.TabIndex = 0;
            this.labelOutput.Text = "Output PDF";
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.Controls.Add(this.label7);
            this.groupBoxAction.Controls.Add(this.label6);
            this.groupBoxAction.Controls.Add(this.label5);
            this.groupBoxAction.Controls.Add(this.label4);
            this.groupBoxAction.Controls.Add(this.btnSplit);
            this.groupBoxAction.Controls.Add(this.btnMerge);
            this.groupBoxAction.Location = new System.Drawing.Point(12, 209);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Size = new System.Drawing.Size(482, 102);
            this.groupBoxAction.TabIndex = 2;
            this.groupBoxAction.TabStop = false;
            this.groupBoxAction.Text = "Action";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "- a file containing page 3 and the following";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "- a file containing the first two pages";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "split the input file 1 into:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Merge the first and the second PDF file";
            // 
            // btnSplit
            // 
            this.btnSplit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplit.Location = new System.Drawing.Point(277, 29);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(138, 23);
            this.btnSplit.TabIndex = 1;
            this.btnSplit.Text = "Split PDF File";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerge.Location = new System.Drawing.Point(43, 29);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(138, 23);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge PDF Files";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MergeSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 323);
            this.Controls.Add(this.groupBoxAction);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxInput);
            this.Name = "MergeSplit";
            this.Text = "PDF Merge Split Sample";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBoxAction.ResumeLayout(false);
            this.groupBoxAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.Label labelInput2;
        private System.Windows.Forms.Label labelInput1;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.GroupBox groupBoxAction;
        private System.Windows.Forms.Button btnBrowseInput2;
        private System.Windows.Forms.Button btnBrowseInput1;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

