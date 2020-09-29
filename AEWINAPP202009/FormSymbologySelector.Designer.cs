namespace AEWINAPP202009
{
    partial class FormSymbologySelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSymbologySelector));
            this.Ctrl_Symbology = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_Symbology)).BeginInit();
            this.SuspendLayout();
            // 
            // Ctrl_Symbology
            // 
            this.Ctrl_Symbology.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_Symbology.Location = new System.Drawing.Point(0, 0);
            this.Ctrl_Symbology.Name = "Ctrl_Symbology";
            this.Ctrl_Symbology.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Ctrl_Symbology.OcxState")));
            this.Ctrl_Symbology.Size = new System.Drawing.Size(800, 450);
            this.Ctrl_Symbology.TabIndex = 0;
            this.Ctrl_Symbology.OnDoubleClick += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnDoubleClickEventHandler(this.Ctrl_Symbology_OnDoubleClick);
            this.Ctrl_Symbology.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.Ctrl_Symbology_OnItemSelected);
            // 
            // FormSymbologySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Ctrl_Symbology);
            this.Name = "FormSymbologySelector";
            this.Text = "FormSymbologySelector";
            ((System.ComponentModel.ISupportInitialize)(this.Ctrl_Symbology)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxSymbologyControl Ctrl_Symbology;
    }
}