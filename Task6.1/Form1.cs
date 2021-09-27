using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Task6._1.fields;
using Task6._1.reflection;
using VehiclesLibrary.model;

namespace Task6._1
{
  public partial class Form1 : Form
  {
    private readonly ClassFinder _classFinder = new();
    private Type _currentClass;
    private MethodInfo _currentMethod;
    private IVehicle _currentVehicle;
    private object _currentVehicleObj;

    public Form1()
    {
      InitializeComponent();
      InitializeClassChooser();
    }

    private void InitializeClassChooser()
    {
      foreach (var classType in _classFinder.ClassesList)
      {
        comboBoxChoosingClass.Items.Add(classType.Name);
      }
    }

    private void InitializeMethodChooser()
    {
      label6.Visible = true;
      comboBoxChoosingMethod.Items.Clear();
      comboBoxChoosingMethod.Visible = true;

      var parameters = _currentClass
        .GetMethods();

      foreach (var parameter in parameters)
      {
        comboBoxChoosingMethod.Items.Add(parameter.Name);
      }

      foreach (var field in flowLayoutPanel1.Controls)
      {
        switch (field)
        {
          case FieldInt fieldInt:
            fieldInt.Enabled = false;
            break;
          case FieldString fieldString:
            fieldString.Enabled = false;
            break;
          case FieldDecimal fieldDecimal:
            fieldDecimal.Enabled = false;
            break;
        }
      }

      button1.Enabled = false;
    }

    private void InputConstructorParameters()
    {
      label1.Visible = true;
      label1.Text = @"Введите аргументы конструктора класса: ";
      flowLayoutPanel1.Controls.Clear();
      button1.Visible = true;
      button1.Enabled = true;
      label8.Visible = false;
      label8.ForeColor = Color.Brown;

      label6.Visible = false;
      comboBoxChoosingMethod.Visible = false;
      flowLayoutPanel2.Controls.Clear();
      label2.Visible = false;
      button2.Visible = false;
      label4.Visible = false;
      label7.Visible = false;
    }

    private void FindSelectedClass()
    {
      foreach (var classType in _classFinder.ClassesList)
      {
        if (classType.Name != (string)comboBoxChoosingClass.SelectedItem) continue;
        _currentClass = classType;
        break;
      }
      //_currentClass = _classFinder.Assembly.GetType("VehiclesLibrary.model." + (string)comboBoxChoosingClass.SelectedItem);
    }

    private void FindSelectedMethod()
    {
      _currentMethod = _currentClass.GetMethod((string)comboBoxChoosingMethod.SelectedItem);
    }

    private void comboBoxСhoosingClass_SelectedIndexChanged(object sender, EventArgs e)
    {
      InputConstructorParameters();
      FindSelectedClass();

      var parameters = _currentClass.GetConstructors()[0].GetParameters();

      if (parameters.Length == 0)
      {
        label1.Text = @"Конструктор класса не имеет параметров";
      }
      else
      {
        foreach (var parameter in parameters)
        {
          if (parameter.ParameterType == typeof(int))
          {
            flowLayoutPanel1.Controls.Add(new FieldInt($"{parameter.Name} ({parameter.ParameterType.Name})"));
          }

          if (parameter.ParameterType == typeof(string))
          {
            flowLayoutPanel1.Controls.Add(new FieldString($"{parameter.Name} ({parameter.ParameterType.Name})"));
          }

          if (parameter.ParameterType == typeof(decimal))
          {
            flowLayoutPanel1.Controls.Add(new FieldDecimal($"{parameter.Name} ({parameter.ParameterType.Name})"));
          }
        }
      }
    }

    private void comboBoxChoosingMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
      flowLayoutPanel2.Controls.Clear();
      label2.Text = @"Введите аргументы метода класса: ";
      label2.Visible = true;
      button2.Visible = true;
      label4.Visible = false;
      label7.Visible = false;

      FindSelectedMethod();
      var parameters = _currentMethod.GetParameters();

      if (parameters.Length == 0)
      {
        label2.Text = @"Метод не имеет параметров";
      }
      else
      {
        foreach (var parameter in parameters)
        {
          if (parameter.ParameterType == typeof(int))
          {
            flowLayoutPanel2.Controls.Add(new FieldInt($"{parameter.Name} ({parameter.ParameterType.Name})"));
          }

          if (parameter.ParameterType == typeof(string))
          {
            flowLayoutPanel2.Controls.Add(new FieldString($"{parameter.Name} ({parameter.ParameterType.Name})"));
          }

          if (parameter.ParameterType == typeof(decimal))
          {
            flowLayoutPanel2.Controls.Add(new FieldDecimal($"{parameter.Name} ({parameter.ParameterType.Name})"));
          }
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      label8.Visible = false;
      var arrayList = new ArrayList();

      foreach (var field in flowLayoutPanel1.Controls)
      {
        switch (field)
        {
          case FieldInt fieldInt:
            arrayList.Add(CheckClassInitializer(fieldInt.TextBox, typeof(int)));
            break;
          case FieldString fieldString:
            arrayList.Add(CheckClassInitializer(fieldString.TextBox, typeof(string)));
            break;
          case FieldDecimal fieldDecimal:
            arrayList.Add(CheckClassInitializer(fieldDecimal.TextBox, typeof(decimal)));
            break;
        }
      }

      if (label8.Visible) return;

      _currentVehicle = _currentClass.Name switch
      {
        "Truck" => new Truck((decimal)arrayList[0]),
        "Motorcycle" => new Motorcycle(),
        "Tractor" => new Tractor(),
        _ => _currentVehicle
      };
      
      _currentVehicleObj = Activator.CreateInstance(_currentClass, null);
      
      InitializeMethodChooser();
    }

    private object CheckClassInitializer(Control textBox, Type type)
    {
      if (textBox.Text == "")
      {
        label8.Text = @"Какое-то из полей является пустым";
        label8.Visible = true;
      }

      switch (Type.GetTypeCode(type))
      {
        case TypeCode.Int32:
          if (int.TryParse(textBox.Text, out var intValue))
          {
            return intValue;
          }

          break;
        case TypeCode.Decimal:
          if (decimal.TryParse(textBox.Text, out var decimalValue))
          {
            return decimalValue;
          }
          else
          {
            label8.Text = @"Аргументы заданы неверно";
            label8.Visible = true;
          }

          break;
      }

      return textBox.Text;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      label4.Visible = true;

      var arrayList = new ArrayList();

      foreach (var field in flowLayoutPanel2.Controls)
      {
        switch (field)
        {
          case FieldInt fieldInt:
            arrayList.Add(CheckMethodInitializer(fieldInt.TextBox, typeof(int)));
            break;
          case FieldString fieldString:
            arrayList.Add(CheckMethodInitializer(fieldString.TextBox, typeof(string)));
            break;
          case FieldDecimal fieldDecimal:
            arrayList.Add(CheckMethodInitializer(fieldDecimal.TextBox, typeof(decimal)));
            break;
        }
      }

      if (label7.Visible) return;

      var result = _currentMethod.Invoke(_currentVehicleObj, null );

      label7.Text = result.ToString();
      label7.Visible = true;
    }

    private object CheckMethodInitializer(Control textBox, Type type)
    {
      if (textBox.Text == "")
      {
        label7.Text = @"Какое-то из полей является пустым";
        label7.Visible = true;
      }

      switch (Type.GetTypeCode(type))
      {
        case TypeCode.Int32:
          if (int.TryParse(textBox.Text, out var intValue))
          {
            return intValue;
          }

          break;
        case TypeCode.Decimal:
          if (decimal.TryParse(textBox.Text, out var decimalValue))
          {
            return decimalValue;
          }
          else
          {
            label7.Text = @"Аргументы заданы неверно";
            label7.Visible = true;
          }

          break;
      }

      return textBox.Text;
    }
  }
}