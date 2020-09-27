namespace AEWINAPP202009
{
    partial class FormQuery
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
            this.CbBox_TargetLayer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_GetUniqueValue = new System.Windows.Forms.Button();
            this.TxtBox_WhereClause = new System.Windows.Forms.TextBox();
            this.LstBox_FieldName = new System.Windows.Forms.ListBox();
            this.LstBoxUniqueValue = new System.Windows.Forms.ListBox();
            this.Btn_ApplyAttributeFilter = new System.Windows.Forms.Button();
            this.CbBox_SelectionSetOperationType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CbBox_SourceLayer = new System.Windows.Forms.ComboBox();
            this.Btn_ApplySpatialFilter = new System.Windows.Forms.Button();
            this.CbBox_Mode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBox_BufferSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbBox_TargetLayer
            // 
            this.CbBox_TargetLayer.FormattingEnabled = true;
            this.CbBox_TargetLayer.Location = new System.Drawing.Point(109, 18);
            this.CbBox_TargetLayer.Name = "CbBox_TargetLayer";
            this.CbBox_TargetLayer.Size = new System.Drawing.Size(221, 23);
            this.CbBox_TargetLayer.TabIndex = 0;
            this.CbBox_TargetLayer.SelectedIndexChanged += new System.EventHandler(this.CbBox_TargetLayer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "目标图层：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "字段：";
            // 
            // Btn_GetUniqueValue
            // 
            this.Btn_GetUniqueValue.Location = new System.Drawing.Point(183, 41);
            this.Btn_GetUniqueValue.Name = "Btn_GetUniqueValue";
            this.Btn_GetUniqueValue.Size = new System.Drawing.Size(35, 94);
            this.Btn_GetUniqueValue.TabIndex = 5;
            this.Btn_GetUniqueValue.Text = "获取唯一值";
            this.Btn_GetUniqueValue.UseVisualStyleBackColor = true;
            this.Btn_GetUniqueValue.Click += new System.EventHandler(this.Btn_GetUniqueValue_Click);
            // 
            // TxtBox_FilterString
            // 
            this.TxtBox_WhereClause.Location = new System.Drawing.Point(17, 155);
            this.TxtBox_WhereClause.Name = "TxtBox_FilterString";
            this.TxtBox_WhereClause.Size = new System.Drawing.Size(286, 25);
            this.TxtBox_WhereClause.TabIndex = 4;
            // 
            // LstBox_FieldName
            // 
            this.LstBox_FieldName.FormattingEnabled = true;
            this.LstBox_FieldName.ItemHeight = 15;
            this.LstBox_FieldName.Location = new System.Drawing.Point(17, 41);
            this.LstBox_FieldName.Name = "LstBox_FieldName";
            this.LstBox_FieldName.Size = new System.Drawing.Size(160, 94);
            this.LstBox_FieldName.TabIndex = 6;
            this.LstBox_FieldName.SelectedIndexChanged += new System.EventHandler(this.LstBox_FieldName_SelectedIndexChanged);
            this.LstBox_FieldName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstBox_FieldName_MouseDoubleClick);
            // 
            // LstBoxUniqueValue
            // 
            this.LstBoxUniqueValue.FormattingEnabled = true;
            this.LstBoxUniqueValue.ItemHeight = 15;
            this.LstBoxUniqueValue.Location = new System.Drawing.Point(224, 41);
            this.LstBoxUniqueValue.Name = "LstBoxUniqueValue";
            this.LstBoxUniqueValue.Size = new System.Drawing.Size(160, 94);
            this.LstBoxUniqueValue.TabIndex = 7;
            this.LstBoxUniqueValue.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstBox_UniqueValue_MouseDoubleClick);
            // 
            // Btn_ApplyAttributeFilter
            // 
            this.Btn_ApplyAttributeFilter.Location = new System.Drawing.Point(309, 155);
            this.Btn_ApplyAttributeFilter.Name = "Btn_ApplyAttributeFilter";
            this.Btn_ApplyAttributeFilter.Size = new System.Drawing.Size(75, 25);
            this.Btn_ApplyAttributeFilter.TabIndex = 8;
            this.Btn_ApplyAttributeFilter.Text = "应用";
            this.Btn_ApplyAttributeFilter.UseVisualStyleBackColor = true;
            this.Btn_ApplyAttributeFilter.Click += new System.EventHandler(this.Btn_ApplyAttributeFilter_Click);
            // 
            // CbBox_SelectionSetOperationType
            // 
            this.CbBox_SelectionSetOperationType.FormattingEnabled = true;
            this.CbBox_SelectionSetOperationType.Items.AddRange(new object[] {
            "创建新集合",
            "添加至现有集合",
            "从现有集合删除",
            "从现有集合中选择",
            "从非选择集中选择"});
            this.CbBox_SelectionSetOperationType.Location = new System.Drawing.Point(109, 47);
            this.CbBox_SelectionSetOperationType.Name = "CbBox_SelectionSetOperationType";
            this.CbBox_SelectionSetOperationType.Size = new System.Drawing.Size(221, 23);
            this.CbBox_SelectionSetOperationType.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "集合操作：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "源图层：";
            // 
            // CbBox_SourceLayer
            // 
            this.CbBox_SourceLayer.FormattingEnabled = true;
            this.CbBox_SourceLayer.Location = new System.Drawing.Point(94, 39);
            this.CbBox_SourceLayer.Name = "CbBox_SourceLayer";
            this.CbBox_SourceLayer.Size = new System.Drawing.Size(121, 23);
            this.CbBox_SourceLayer.TabIndex = 12;
            this.CbBox_SourceLayer.SelectedIndexChanged += new System.EventHandler(this.CbBox_SourceLayer_SelectedIndexChanged);
            // 
            // Btn_ApplySpatialFilter
            // 
            this.Btn_ApplySpatialFilter.Location = new System.Drawing.Point(243, 42);
            this.Btn_ApplySpatialFilter.Name = "Btn_ApplySpatialFilter";
            this.Btn_ApplySpatialFilter.Size = new System.Drawing.Size(75, 33);
            this.Btn_ApplySpatialFilter.TabIndex = 15;
            this.Btn_ApplySpatialFilter.Text = "应用";
            this.Btn_ApplySpatialFilter.UseVisualStyleBackColor = true;
            this.Btn_ApplySpatialFilter.Click += new System.EventHandler(this.Btn_ApplySpatialFilter_Click);
            // 
            // CbBox_Mode
            // 
            this.CbBox_Mode.FormattingEnabled = true;
            this.CbBox_Mode.Items.AddRange(new object[] {
            "未定义",
            "相交",
            "外包框相交",
            "索引相交",
            "接触",
            "覆盖",
            "交叉",
            "在其内",
            "包含所有",
            "Query geometry IBE(Interior-Boundary-Exterior) relationship with target geometry." +
                ""});
            this.CbBox_Mode.Location = new System.Drawing.Point(94, 79);
            this.CbBox_Mode.Name = "CbBox_Mode";
            this.CbBox_Mode.Size = new System.Drawing.Size(121, 23);
            this.CbBox_Mode.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "模式：";
            // 
            // TxtBox_BufferSize
            // 
            this.TxtBox_BufferSize.Location = new System.Drawing.Point(115, 125);
            this.TxtBox_BufferSize.Name = "TxtBox_BufferSize";
            this.TxtBox_BufferSize.Size = new System.Drawing.Size(100, 25);
            this.TxtBox_BufferSize.TabIndex = 19;
            this.TxtBox_BufferSize.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "缓冲大小：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CbBox_TargetLayer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CbBox_SelectionSetOperationType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 90);
            this.panel1.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstBox_FieldName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtBox_WhereClause);
            this.groupBox1.Controls.Add(this.Btn_GetUniqueValue);
            this.groupBox1.Controls.Add(this.LstBoxUniqueValue);
            this.groupBox1.Controls.Add(this.Btn_ApplyAttributeFilter);
            this.groupBox1.Location = new System.Drawing.Point(12, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 200);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性查询";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CbBox_SourceLayer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Btn_ApplySpatialFilter);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CbBox_Mode);
            this.groupBox2.Controls.Add(this.TxtBox_BufferSize);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 177);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拓扑查询";
            // 
            // FormQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 514);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FormQuery";
            this.Text = "FromQuery";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbBox_TargetLayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_GetUniqueValue;
        private System.Windows.Forms.TextBox TxtBox_WhereClause;
        private System.Windows.Forms.ListBox LstBox_FieldName;
        private System.Windows.Forms.ListBox LstBoxUniqueValue;
        private System.Windows.Forms.Button Btn_ApplyAttributeFilter;
        private System.Windows.Forms.ComboBox CbBox_SelectionSetOperationType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbBox_SourceLayer;
        private System.Windows.Forms.Button Btn_ApplySpatialFilter;
        private System.Windows.Forms.ComboBox CbBox_Mode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBox_BufferSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}