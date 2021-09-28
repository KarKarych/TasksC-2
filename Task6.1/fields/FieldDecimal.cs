namespace Task6._1.fields
{
  internal class FieldDecimal : Field
  {
    public FieldDecimal(string labelText) : base(labelText)
    {
      TextBox.KeyPress += (_, e) =>
      {
        if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 46)
          e.Handled = true;
      };
    }
  }
}