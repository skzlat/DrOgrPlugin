using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tekla.Structures.Drawing;
using SD = System.Drawing;

namespace DrawLine
{
    public partial class MainForm : Tekla.Structures.Dialog.PluginFormBase
    {
        readonly Dictionary<Color, DrawingColors> systemColorDrawingColorDic;
        public MainForm()
        {
            InitializeComponent();

            systemColorDrawingColorDic = SystemColorDrawingColor();
            cmbColor.DataSource = new BindingSource(systemColorDrawingColorDic, null);
            cmbColor.DisplayMember = "Key";
            cmbColor.ValueMember = "Value";
            cmbColor.DrawMode = DrawMode.OwnerDrawVariable;
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            
            cmbColor.DrawItem += ComboBoxColor_DrawItem;
        }
        private Dictionary<Color, DrawingColors> SystemColorDrawingColor()
        {
            Dictionary<Color, DrawingColors> colors = new Dictionary<Color, DrawingColors>
            {
                { Color.White, DrawingColors.Invisible },
                { Color.Black, DrawingColors.Black },
                { Color.Red, DrawingColors.Red },
                { Color.Lime, DrawingColors.Green },
                { Color.Blue, DrawingColors.Blue },
                { Color.Cyan, DrawingColors.Cyan },
                { Color.FromArgb(240, 240, 0), DrawingColors.Yellow },
                { Color.Magenta, DrawingColors.Magenta },
                { Color.FromArgb(128, 64, 64), DrawingColors.NewLine1 },
                { Color.FromArgb(0, 160, 0), DrawingColors.NewLine2 },
                { Color.FromArgb(51, 51, 153), DrawingColors.NewLine3 },
                { Color.Teal, DrawingColors.NewLine4 },
                { Color.FromArgb(255, 102, 0), DrawingColors.NewLine5 },
                { Color.FromArgb(150, 150, 150), DrawingColors.NewLine6 },
                { Color.FromArgb(77, 77, 77), DrawingColors.Gray30 },
                { Color.FromArgb(127, 127, 127), DrawingColors.Gray50 },
                { Color.FromArgb(179, 179, 179), DrawingColors.Gray70 },
                { Color.FromArgb(229, 229, 229), DrawingColors.Gray90 }
            };
            return colors;
        }
        private void ComboBoxColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Color drColor = ((KeyValuePair<Color, DrawingColors>)cmbColor.Items[e.Index]).Key;
            e.DrawBackground();
            SD.Rectangle rectangle = new SD.Rectangle(2, e.Bounds.Top + 5, 70, 5);
            e.Graphics.FillRectangle(new SolidBrush(drColor), rectangle);
            e.Graphics.DrawString("", cmbColor.Font, Brushes.Black,
                new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }
        private void TextBoxStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && !(e.KeyChar == ',') && !(e.KeyChar == '.'))
                e.Handled = true;
        }
        private void TextBoxDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && !(e.KeyChar == ',') && !(e.KeyChar == '.'))
                e.Handled = true;
        }
        private void TextBox_step_TextChanged(object sender, EventArgs e)
        {
            if (textBox_step.Text.StartsWith("0"))
                textBox_step.Text = "";
            SetAttributeValue(textBox_step, textBox_step.Text);
            Modify();
        }
        private void TextBoxDiameter_TextChanged(object sender, EventArgs e)
        {
            SetAttributeValue(textBoxDiameter, textBoxDiameter.Text);
            Modify();
        }
        private void ComboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAttributeValue(txtColorValue, (int)((KeyValuePair<Color, DrawingColors>)cmbColor.SelectedItem).Value);
            Modify();
        }


        private void OkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e)
        {
            Apply();
            Close();
        }
        private void OkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e)
        {
            Apply();
        }
        private void OkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e)
        {
            Close();
        }
        private void OkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e)
        {
            Get();
        }
        private void OkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e)
        {
            Modify();
        }
        private void OkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e)
        {
            ToggleSelection();
        }
        private void OkApplyModifyGetOnOffCancel_Load(object sender, EventArgs e)
        {

        }
    }
}
