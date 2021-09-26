using System;
using System.Windows.Forms;
using Task6._1.reflection;

namespace Task6._1
{
  public partial class Form1 : Form
  {
    private const string LibraryName = "../../../VehiclesLibrary/bin/Debug/VehiclesLibrary.dll";
    private readonly ClassFinder _classFinder= new(LibraryName);

    public Form1()
    {
      InitializeComponent();
      InitializeCombobox1();
    }

    private void InitializeCombobox1()
    {
      foreach (var classType in _classFinder.ClassesList)
      {
        comboBox1.Items.Add(classType.Name);
      }
    }
    
    private void InitializeCombobox2()
    {
      comboBox2.Visible = true;
      label1.Visible = true;
      var field = new Field("2121");
      var field1 = new Field("2121");
      var field2 = new Field("2121");
      var field3 = new Field("2121");
      var field4 = new Field("2121");
      var field5 = new Field("2121");
      flowLayoutPanel1.Controls.Add(field);
      flowLayoutPanel1.Controls.Add(field1);
      flowLayoutPanel1.Controls.Add(field2);
      flowLayoutPanel1.Controls.Add(field3);
      flowLayoutPanel1.Controls.Add(field4);
      flowLayoutPanel1.Controls.Add(field5);
      
    }


    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      InitializeCombobox2();
      
    }

    private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      throw new System.NotImplementedException();
    }

    private void label1_Click(object sender, EventArgs e)
    {
      throw new System.NotImplementedException();
    }

    private void label1_Click_1(object sender, EventArgs e)
    {
      throw new System.NotImplementedException();
    }
  }
}