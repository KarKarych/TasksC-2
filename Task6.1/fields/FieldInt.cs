namespace Task6._1.fields
{
  internal class FieldInt : Field
  {
    public FieldInt(string labelText) : base(labelText)
    {
      TextBox.KeyPress += (_, e) =>
      {
        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57)) e.Handled = true;
      };
    }
  }
}