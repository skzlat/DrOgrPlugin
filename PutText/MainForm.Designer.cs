using System.Windows.Forms;

namespace DrawLine
{
    partial class MainForm : Tekla.Structures.Dialog.PluginFormBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OkApplyModifyGetOnOffCancel = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.SaveLoadSaveAs = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ParametersTabPage = new System.Windows.Forms.TabPage();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBoxDiameter = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox_step = new System.Windows.Forms.TextBox();
            this.txtColorValue = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.ParametersTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkApplyModifyGetOnOffCancel
            // 
            this.structuresExtender.SetAttributeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetAttributeTypeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetBindPropertyName(this.OkApplyModifyGetOnOffCancel, null);
            this.OkApplyModifyGetOnOffCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkApplyModifyGetOnOffCancel.Location = new System.Drawing.Point(0, 189);
            this.OkApplyModifyGetOnOffCancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.OkApplyModifyGetOnOffCancel.Name = "OkApplyModifyGetOnOffCancel";
            this.OkApplyModifyGetOnOffCancel.Size = new System.Drawing.Size(712, 36);
            this.OkApplyModifyGetOnOffCancel.TabIndex = 7;
            this.OkApplyModifyGetOnOffCancel.OkClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_OkClicked);
            this.OkApplyModifyGetOnOffCancel.ApplyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_ApplyClicked);
            this.OkApplyModifyGetOnOffCancel.ModifyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_ModifyClicked);
            this.OkApplyModifyGetOnOffCancel.GetClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_GetClicked);
            this.OkApplyModifyGetOnOffCancel.OnOffClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_OnOffClicked);
            this.OkApplyModifyGetOnOffCancel.CancelClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_CancelClicked);
            this.OkApplyModifyGetOnOffCancel.Load += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_Load);
            // 
            // SaveLoadSaveAs
            // 
            this.structuresExtender.SetAttributeName(this.SaveLoadSaveAs, null);
            this.structuresExtender.SetAttributeTypeName(this.SaveLoadSaveAs, null);
            this.SaveLoadSaveAs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.SaveLoadSaveAs, null);
            this.SaveLoadSaveAs.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveLoadSaveAs.HelpFileType = Tekla.Structures.Dialog.UIControls.SaveLoad.HelpFileTypeEnum.General;
            this.SaveLoadSaveAs.HelpKeyword = "";
            this.SaveLoadSaveAs.HelpUrl = "";
            this.SaveLoadSaveAs.Location = new System.Drawing.Point(0, 0);
            this.SaveLoadSaveAs.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SaveLoadSaveAs.Name = "SaveLoadSaveAs";
            this.SaveLoadSaveAs.SaveAsText = "";
            this.SaveLoadSaveAs.Size = new System.Drawing.Size(712, 53);
            this.SaveLoadSaveAs.TabIndex = 16;
            this.SaveLoadSaveAs.UserDefinedHelpFilePath = null;
            // 
            // tabControl1
            // 
            this.structuresExtender.SetAttributeName(this.tabControl1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl1, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl1, null);
            this.tabControl1.Controls.Add(this.ParametersTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 53);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(712, 136);
            this.tabControl1.TabIndex = 17;
            // 
            // ParametersTabPage
            // 
            this.structuresExtender.SetAttributeName(this.ParametersTabPage, null);
            this.structuresExtender.SetAttributeTypeName(this.ParametersTabPage, null);
            this.structuresExtender.SetBindPropertyName(this.ParametersTabPage, null);
            this.ParametersTabPage.Controls.Add(this.txtColorValue);
            this.ParametersTabPage.Controls.Add(this.cmbColor);
            this.ParametersTabPage.Controls.Add(this.checkBox3);
            this.ParametersTabPage.Controls.Add(this.checkBox2);
            this.ParametersTabPage.Controls.Add(this.textBoxDiameter);
            this.ParametersTabPage.Controls.Add(this.checkBox1);
            this.ParametersTabPage.Controls.Add(this.textBox_step);
            this.ParametersTabPage.Location = new System.Drawing.Point(4, 25);
            this.ParametersTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ParametersTabPage.Name = "ParametersTabPage";
            this.ParametersTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ParametersTabPage.Size = new System.Drawing.Size(704, 107);
            this.ParametersTabPage.TabIndex = 2;
            this.ParametersTabPage.Text = "albl_Parameters";
            this.ParametersTabPage.UseVisualStyleBackColor = true;
            // 
            // cmbColor
            // 
            this.structuresExtender.SetAttributeName(this.cmbColor, null);
            this.structuresExtender.SetAttributeTypeName(this.cmbColor, null);
            this.structuresExtender.SetBindPropertyName(this.cmbColor, null);
            this.cmbColor.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(108, 70);
            this.cmbColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbColor.MaxDropDownItems = 100;
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(160, 24);
            this.cmbColor.TabIndex = 6;
            this.cmbColor.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxColor_SelectedIndexChanged);
            // 
            // checkBox3
            // 
            this.structuresExtender.SetAttributeName(this.checkBox3, "color");
            this.structuresExtender.SetAttributeTypeName(this.checkBox3, null);
            this.checkBox3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBox3, null);
            this.structuresExtender.SetIsFilter(this.checkBox3, true);
            this.checkBox3.Location = new System.Drawing.Point(37, 71);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox3.Size = new System.Drawing.Size(63, 21);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Цвет";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.structuresExtender.SetAttributeName(this.checkBox2, "diameter");
            this.structuresExtender.SetAttributeTypeName(this.checkBox2, null);
            this.checkBox2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBox2, null);
            this.structuresExtender.SetIsFilter(this.checkBox2, true);
            this.checkBox2.Location = new System.Drawing.Point(11, 43);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox2.Size = new System.Drawing.Size(89, 21);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Диаметр";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBoxDiameter
            // 
            this.structuresExtender.SetAttributeName(this.textBoxDiameter, "diameter");
            this.structuresExtender.SetAttributeTypeName(this.textBoxDiameter, "String");
            this.structuresExtender.SetBindPropertyName(this.textBoxDiameter, null);
            this.textBoxDiameter.Location = new System.Drawing.Point(108, 41);
            this.textBoxDiameter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDiameter.Name = "textBoxDiameter";
            this.textBoxDiameter.Size = new System.Drawing.Size(160, 22);
            this.textBoxDiameter.TabIndex = 4;
            this.textBoxDiameter.TextChanged += new System.EventHandler(this.TextBoxDiameter_TextChanged);
            this.textBoxDiameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDiameter_KeyPress);
            // 
            // checkBox1
            // 
            this.structuresExtender.SetAttributeName(this.checkBox1, "step");
            this.structuresExtender.SetAttributeTypeName(this.checkBox1, null);
            this.checkBox1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBox1, null);
            this.structuresExtender.SetIsFilter(this.checkBox1, true);
            this.checkBox1.Location = new System.Drawing.Point(45, 14);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(54, 21);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Шаг";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox_step
            // 
            this.structuresExtender.SetAttributeName(this.textBox_step, "step");
            this.structuresExtender.SetAttributeTypeName(this.textBox_step, "String");
            this.structuresExtender.SetBindPropertyName(this.textBox_step, null);
            this.textBox_step.Location = new System.Drawing.Point(108, 12);
            this.textBox_step.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_step.Name = "textBox_step";
            this.textBox_step.Size = new System.Drawing.Size(160, 22);
            this.textBox_step.TabIndex = 2;
            this.textBox_step.TextChanged += new System.EventHandler(this.TextBox_step_TextChanged);
            this.textBox_step.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxStep_KeyPress);
            // 
            // txtColorValue
            // 
            this.structuresExtender.SetAttributeName(this.txtColorValue, "color");
            this.structuresExtender.SetAttributeTypeName(this.txtColorValue, "Integer");
            this.structuresExtender.SetBindPropertyName(this.txtColorValue, "Text");
            this.txtColorValue.Location = new System.Drawing.Point(275, 70);
            this.txtColorValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtColorValue.Name = "txtColorValue";
            this.txtColorValue.ReadOnly = true;
            this.txtColorValue.Size = new System.Drawing.Size(49, 22);
            this.txtColorValue.TabIndex = 15;
            this.txtColorValue.Visible = false;
            // 
            // MainForm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(712, 225);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.SaveLoadSaveAs);
            this.Controls.Add(this.OkApplyModifyGetOnOffCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Линия ограждения";
            this.tabControl1.ResumeLayout(false);
            this.ParametersTabPage.ResumeLayout(false);
            this.ParametersTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel OkApplyModifyGetOnOffCancel;
        private Tekla.Structures.Dialog.UIControls.SaveLoad SaveLoadSaveAs;
        private TabControl tabControl1;
        private TabPage ParametersTabPage;
        private TextBox textBox_step;
        private TextBox textBoxDiameter;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ComboBox cmbColor;
        private CheckBox checkBox3;
        private TextBox txtColorValue;
    }
}
