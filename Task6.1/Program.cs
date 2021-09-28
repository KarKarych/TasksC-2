using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task6._1
{
  internal static class Program
  {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      var form1 = new Form1();
      form1.Size = new Size(1280, 960);
      Application.Run(form1);
    }
  }
}