using System.Drawing;
using System.Windows.Forms;

namespace Task3._1.fields
{
  internal class Field : FlowLayoutPanel
  {
    public Field(string labelText)
    {
      AutoSize = true;
      var label = new Label();
      label.Text = labelText;
      label.AutoSize = true;
      label.Anchor = AnchorStyles.Left;
      label.TextAlign = ContentAlignment.MiddleLeft;

      TextBox = new TextBox();
      TextBox.MinimumSize = new Size(120, 30);

      Controls.Add(label);
      Controls.Add(TextBox);
    }

    public TextBox TextBox { get; }

    public sealed override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }
  }
}