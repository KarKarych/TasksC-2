using System;
using System.Windows.Forms;
using Task6._1.reflection;

namespace Task6._1
{
  public partial class Form1 : Form
  {
    private ComboBox _comboBox2;

    public Form1()
    {
      InitializeComponent();


      const string libraryName = "../../../VehiclesLibrary/bin/Debug/VehiclesLibrary.dll";
      var classFinder = new ClassFinder();
      var classesList = classFinder.ClassesImplementingInterface(libraryName);

      foreach (var classType in classesList)
      {
        comboBox1.Items.Add(classType.Name);
      }

      label1.Text = @"App";
    }


    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
      throw new System.NotImplementedException();
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_comboBox2 != null)
      {
        _comboBox2.Items.Clear();
        comboBox1.SelectedIndex = 0;
        _comboBox2.Items.Add(new Random().Next(3));
      };
      
      _comboBox2 = new ComboBox();
      Controls.Add(_comboBox2);
      _comboBox2.FormattingEnabled = true;
      _comboBox2.Location = new System.Drawing.Point(226, 60);
      _comboBox2.Name = "comboBox2";
      _comboBox2.Size = new System.Drawing.Size(124, 21);
      _comboBox2.TabIndex = 3;
      _comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
      
      _comboBox2.Items.Add(new Random().Next(3));
    }
  }
}