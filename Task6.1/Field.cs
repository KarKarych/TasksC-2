using System.Drawing;
using System.Windows.Forms;

namespace Task6._1
{
  internal class Field : FlowLayoutPanel
  {
    public readonly Label Label;
    public readonly TextBox TextBox;

    public Field(string labelText)
    {
      AutoSize = true;

      Label = new Label();
      Label.Text = labelText;
      Label.AutoSize = true;
      Label.Anchor = AnchorStyles.Left;
      Label.TextAlign = ContentAlignment.MiddleLeft;

      Controls.Add(Label);

      TextBox = new TextBox();

      Controls.Add(TextBox);
    }

    public sealed override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }
  }
}