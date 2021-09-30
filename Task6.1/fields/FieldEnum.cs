using System.Drawing;
using System.Windows.Forms;

namespace Task6._1.fields
{
  internal class FieldEnum : FlowLayoutPanel
  {
    public FieldEnum(string labelText)
    {
      var label = new Label();
      label.Text = labelText;
      label.AutoSize = true;
      label.MinimumSize = new Size(200, 30);
      
      ComboBox = new ComboBox();
      ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBox.FormattingEnabled = true;
      ComboBox.MinimumSize = new Size(190, 30);
      Controls.Add(label);
      Controls.Add(ComboBox);
    }

    public ComboBox ComboBox { get; }

    public sealed override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }
  }
}