namespace Task3._1
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.comboBoxChoosingClass = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.comboBoxChoosingMethod = new System.Windows.Forms.ComboBox();
      this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // comboBoxChoosingClass
      // 
      this.comboBoxChoosingClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxChoosingClass.FormattingEnabled = true;
      resources.ApplyResources(this.comboBoxChoosingClass, "comboBoxChoosingClass");
      this.comboBoxChoosingClass.Name = "comboBoxChoosingClass";
      this.comboBoxChoosingClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxСhoosingClass_SelectedIndexChanged);
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // flowLayoutPanel1
      // 
      resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      // 
      // comboBoxChoosingMethod
      // 
      this.comboBoxChoosingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      resources.ApplyResources(this.comboBoxChoosingMethod, "comboBoxChoosingMethod");
      this.comboBoxChoosingMethod.FormattingEnabled = true;
      this.comboBoxChoosingMethod.Name = "comboBoxChoosingMethod";
      this.comboBoxChoosingMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxChoosingMethod_SelectedIndexChanged);
      // 
      // flowLayoutPanel2
      // 
      resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // label4
      // 
      resources.ApplyResources(this.label4, "label4");
      this.label4.Name = "label4";
      // 
      // label5
      // 
      resources.ApplyResources(this.label5, "label5");
      this.label5.Name = "label5";
      // 
      // label6
      // 
      resources.ApplyResources(this.label6, "label6");
      this.label6.Name = "label6";
      // 
      // button1
      // 
      resources.ApplyResources(this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      resources.ApplyResources(this.button2, "button2");
      this.button2.Name = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label7
      // 
      resources.ApplyResources(this.label7, "label7");
      this.label7.Name = "label7";
      // 
      // label8
      // 
      resources.ApplyResources(this.label8, "label8");
      this.label8.Name = "label8";
      // 
      // Form1
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.flowLayoutPanel2);
      this.Controls.Add(this.comboBoxChoosingMethod);
      this.Controls.Add(this.flowLayoutPanel1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBoxChoosingClass);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.ShowIcon = false;
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.ComboBox comboBoxChoosingClass;

    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    private System.Windows.Forms.ComboBox comboBoxChoosingMethod;

    private System.Windows.Forms.Label label1;

    #endregion
  }
}