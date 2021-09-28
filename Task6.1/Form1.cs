using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Task6._1.fields;
using Task6._1.reflection;

namespace Task6._1
{
  public partial class Form1 : Form
  {
    private readonly ClassFinder _classFinder = new();
    private Type _currentClass;
    private MethodInfo _currentMethod;
    private object _currentVehicleObj;

    public Form1()
    {
      InitializeComponent();
      InitializeClassChooser();
    }

    private void InitializeClassChooser()
    {
      foreach (var classType in _classFinder.ClassesList) comboBoxChoosingClass.Items.Add(classType.Name);
    }

    private void InitializeMethodChooser()
    {
      label6.Visible = true;
      comboBoxChoosingMethod.Items.Clear();
      comboBoxChoosingMethod.Visible = true;

      var parameters = _currentClass
        .GetMethods();

      foreach (var parameter in parameters) comboBoxChoosingMethod.Items.Add(parameter.Name);

      foreach (var field in flowLayoutPanel1.Controls)
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
      _currentClass = _classFinder.Assembly
        .GetType("VehiclesLibrary.model." + (string)comboBoxChoosingClass.SelectedItem);
    }

    private void FindSelectedMethod()
    {
      _currentMethod = _currentClass.GetMethod((string)comboBoxChoosingMethod.SelectedItem);
    }

    private static void AddElementsToFlowLayoutPanel(
      Control flowLayoutPanel,
      IEnumerable<ParameterInfo> parameters
    )
    {
      foreach (var parameter in parameters)
      {
        var name = $"{parameter.Name} ({parameter.ParameterType.Name})";

        if (parameter.ParameterType == typeof(int))
          flowLayoutPanel.Controls.Add(new FieldInt(name));

        if (parameter.ParameterType == typeof(string))
          flowLayoutPanel.Controls.Add(new FieldString(name));

        if (parameter.ParameterType == typeof(decimal))
          flowLayoutPanel.Controls.Add(new FieldDecimal(name));
      }
    }

    private void comboBoxСhoosingClass_SelectedIndexChanged(object sender, EventArgs e)
    {
      InputConstructorParameters();
      FindSelectedClass();

      var parameters = _currentClass.GetConstructors()[0].GetParameters();

      if (parameters.Length == 0)
        label1.Text = @"Конструктор класса не имеет параметров";
      else
        AddElementsToFlowLayoutPanel(flowLayoutPanel1, parameters);
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
        label2.Text = @"Метод не имеет параметров";
      else
        AddElementsToFlowLayoutPanel(flowLayoutPanel2, parameters);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      label8.Visible = false;
      
      var arrayList = GetArguments(flowLayoutPanel1, label8);

      if (label8.Visible) return;

      var args = new object[arrayList.Count];

      for (var i = 0; i < arrayList.Count; i++) args[i] = arrayList[i];

      _currentVehicleObj = Activator.CreateInstance(_currentClass, args);

      InitializeMethodChooser();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      label4.Visible = true;
      label7.Visible = false;

      var arrayList = GetArguments(flowLayoutPanel2, label7);

      if (label7.Visible) return;

      var args = new object[arrayList.Count];

      for (var i = 0; i < arrayList.Count; i++) args[i] = arrayList[i];

      var result = _currentMethod.Invoke(_currentVehicleObj, args);

      label7.Text = result == null ? "Метод имеет сигнатуру void" : result.ToString();
      label7.Visible = true;
    }

    private ArrayList GetArguments(Control flowLayoutPanel, Label label)
    {
      var arrayList = new ArrayList();
      
      foreach (var field in flowLayoutPanel.Controls)
        switch (field)
        {
          case FieldInt fieldInt:
            arrayList.Add(CheckInitializer(fieldInt.TextBox, typeof(int), label));
            break;
          case FieldString fieldString:
            arrayList.Add(CheckInitializer(fieldString.TextBox, typeof(string), label));
            break;
          case FieldDecimal fieldDecimal:
            arrayList.Add(CheckInitializer(fieldDecimal.TextBox, typeof(decimal), label));
            break;
        }

      return arrayList;
    }

    private object CheckInitializer(Control textBox, Type type, Label label)
    {
      if (textBox.Text == "")
      {
        label.Text = @"Какое-то из полей является пустым";
        label.Visible = true;
      }

      switch (Type.GetTypeCode(type))
      {
        case TypeCode.Int32:
          if (int.TryParse(textBox.Text, out var intValue)) return intValue;

          break;
        case TypeCode.Decimal:
          if (decimal.TryParse(textBox.Text, out var decimalValue))
          {
            return decimalValue;
          }
          else
          {
            label.Text = @"Аргументы заданы неверно";
            label.Visible = true;
          }

          break;
      }

      return textBox.Text;
    }
  }
}