/*
 * Created by SharpDevelop.
 * User: Andrew
 * Date: 11/01/2015
 * Time: 15:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace VNAMini
{
  partial class MainForm
  {
    /// <summary>
    /// Designer variable used to keep track of non-visual components.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    
    /// <summary>
    /// Disposes resources used by the form.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing) {
        if (components != null) {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }
    
    /// <summary>
    /// This method is required for Windows Forms designer support.
    /// Do not change the method contents inside the source code editor. The Forms designer might
    /// not be able to load this method if it was changed manually.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.refresh = new System.Windows.Forms.Button();
      this.serialchoice = new System.Windows.Forms.ComboBox();
      this.connect = new System.Windows.Forms.Button();
      this.serialgroup = new System.Windows.Forms.GroupBox();
      this.menubar = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
      this.status = new System.Windows.Forms.StatusStrip();
      this.statuslabel = new System.Windows.Forms.Label();
      this.graph = new ZedGraph.ZedGraphControl();
      this.scan = new System.Windows.Forms.Button();
      this.vnagroup = new System.Windows.Forms.GroupBox();
      this.scanmode = new System.Windows.Forms.ComboBox();
      this.measmode = new System.Windows.Forms.ComboBox();
      this.graphgroup = new System.Windows.Forms.GroupBox();
      this.graphtype = new System.Windows.Forms.ComboBox();
      this.serialgroup.SuspendLayout();
      this.menubar.SuspendLayout();
      this.vnagroup.SuspendLayout();
      this.graphgroup.SuspendLayout();
      this.SuspendLayout();
      // 
      // refresh
      // 
      this.refresh.Location = new System.Drawing.Point(107, 19);
      this.refresh.Name = "refresh";
      this.refresh.Size = new System.Drawing.Size(28, 23);
      this.refresh.TabIndex = 0;
      this.refresh.Text = "R";
      this.refresh.UseVisualStyleBackColor = true;
      this.refresh.Click += new System.EventHandler(this.Refresh_Click);
      // 
      // serialchoice
      // 
      this.serialchoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.serialchoice.FormattingEnabled = true;
      this.serialchoice.Location = new System.Drawing.Point(6, 20);
      this.serialchoice.Name = "serialchoice";
      this.serialchoice.Size = new System.Drawing.Size(95, 21);
      this.serialchoice.TabIndex = 1;
      // 
      // connect
      // 
      this.connect.Location = new System.Drawing.Point(6, 50);
      this.connect.Name = "connect";
      this.connect.Size = new System.Drawing.Size(129, 39);
      this.connect.TabIndex = 2;
      this.connect.Text = "Connect";
      this.connect.UseVisualStyleBackColor = true;
      this.connect.Click += new System.EventHandler(this.Connect_Click);
      // 
      // serialgroup
      // 
      this.serialgroup.Controls.Add(this.serialchoice);
      this.serialgroup.Controls.Add(this.connect);
      this.serialgroup.Controls.Add(this.refresh);
      this.serialgroup.Location = new System.Drawing.Point(10, 27);
      this.serialgroup.Name = "serialgroup";
      this.serialgroup.Size = new System.Drawing.Size(141, 97);
      this.serialgroup.TabIndex = 3;
      this.serialgroup.TabStop = false;
      this.serialgroup.Text = "Serial port";
      // 
      // menubar
      // 
      this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                  this.fileToolStripMenuItem});
      this.menubar.Location = new System.Drawing.Point(0, 0);
      this.menubar.Name = "menubar";
      this.menubar.Size = new System.Drawing.Size(675, 24);
      this.menubar.TabIndex = 4;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                  this.openToolStripMenuItem,
                  this.saveToolStripMenuItem,
                  this.toolStripSeparator1,
                  this.exportCSVToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
      this.openToolStripMenuItem.Text = "Open...";
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
      this.saveToolStripMenuItem.Text = "Save...";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
      // 
      // exportCSVToolStripMenuItem
      // 
      this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
      this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
      this.exportCSVToolStripMenuItem.Text = "Export CSV...";
      this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.ExportCSVToolStripMenuItem_Click);
      // 
      // serialPort1
      // 
      this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
      // 
      // status
      // 
      this.status.Location = new System.Drawing.Point(0, 349);
      this.status.Name = "status";
      this.status.Size = new System.Drawing.Size(675, 22);
      this.status.TabIndex = 5;
      // 
      // statuslabel
      // 
      this.statuslabel.BackColor = System.Drawing.SystemColors.Control;
      this.statuslabel.Location = new System.Drawing.Point(0, 349);
      this.statuslabel.Name = "statuslabel";
      this.statuslabel.Size = new System.Drawing.Size(85, 20);
      this.statuslabel.TabIndex = 6;
      this.statuslabel.Text = "Not connected";
      // 
      // graph
      // 
      this.graph.Location = new System.Drawing.Point(165, 36);
      this.graph.Name = "graph";
      this.graph.ScrollGrace = 0D;
      this.graph.ScrollMaxX = 0D;
      this.graph.ScrollMaxY = 0D;
      this.graph.ScrollMaxY2 = 0D;
      this.graph.ScrollMinX = 0D;
      this.graph.ScrollMinY = 0D;
      this.graph.ScrollMinY2 = 0D;
      this.graph.Size = new System.Drawing.Size(345, 253);
      this.graph.TabIndex = 7;
      // 
      // scan
      // 
      this.scan.Location = new System.Drawing.Point(540, 186);
      this.scan.Name = "scan";
      this.scan.Size = new System.Drawing.Size(117, 62);
      this.scan.TabIndex = 8;
      this.scan.Text = "Scan";
      this.scan.UseVisualStyleBackColor = true;
      this.scan.Click += new System.EventHandler(this.Scan_Click);
      // 
      // vnagroup
      // 
      this.vnagroup.Controls.Add(this.scanmode);
      this.vnagroup.Controls.Add(this.measmode);
      this.vnagroup.Location = new System.Drawing.Point(522, 35);
      this.vnagroup.Name = "vnagroup";
      this.vnagroup.Size = new System.Drawing.Size(141, 81);
      this.vnagroup.TabIndex = 9;
      this.vnagroup.TabStop = false;
      this.vnagroup.Text = "VNA mode";
      // 
      // scanmode
      // 
      this.scanmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.scanmode.FormattingEnabled = true;
      this.scanmode.Location = new System.Drawing.Point(6, 51);
      this.scanmode.Name = "scanmode";
      this.scanmode.Size = new System.Drawing.Size(129, 21);
      this.scanmode.TabIndex = 11;
      // 
      // measmode
      // 
      this.measmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.measmode.FormattingEnabled = true;
      this.measmode.Location = new System.Drawing.Point(6, 19);
      this.measmode.Name = "measmode";
      this.measmode.Size = new System.Drawing.Size(129, 21);
      this.measmode.TabIndex = 10;
      // 
      // graphgroup
      // 
      this.graphgroup.Controls.Add(this.graphtype);
      this.graphgroup.Location = new System.Drawing.Point(524, 124);
      this.graphgroup.Name = "graphgroup";
      this.graphgroup.Size = new System.Drawing.Size(141, 49);
      this.graphgroup.TabIndex = 10;
      this.graphgroup.TabStop = false;
      this.graphgroup.Text = "Graph";
      // 
      // graphtype
      // 
      this.graphtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.graphtype.FormattingEnabled = true;
      this.graphtype.Location = new System.Drawing.Point(6, 19);
      this.graphtype.Name = "graphtype";
      this.graphtype.Size = new System.Drawing.Size(129, 21);
      this.graphtype.TabIndex = 11;
      this.graphtype.SelectedIndexChanged += new System.EventHandler(this.Graphtype_SelectedIndexChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(675, 371);
      this.Controls.Add(this.graphgroup);
      this.Controls.Add(this.vnagroup);
      this.Controls.Add(this.scan);
      this.Controls.Add(this.graph);
      this.Controls.Add(this.statuslabel);
      this.Controls.Add(this.status);
      this.Controls.Add(this.serialgroup);
      this.Controls.Add(this.menubar);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menubar;
      this.MinimumSize = new System.Drawing.Size(600, 340);
      this.Name = "MainForm";
      this.Text = "VNAMini";
      this.serialgroup.ResumeLayout(false);
      this.menubar.ResumeLayout(false);
      this.menubar.PerformLayout();
      this.vnagroup.ResumeLayout(false);
      this.graphgroup.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
    private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ComboBox scanmode;
    private System.Windows.Forms.ComboBox graphtype;
    private System.Windows.Forms.GroupBox graphgroup;
    private System.Windows.Forms.ComboBox measmode;
    private System.Windows.Forms.GroupBox vnagroup;
    private System.Windows.Forms.Button scan;
    private ZedGraph.ZedGraphControl graph;
    private System.Windows.Forms.Label statuslabel;
    private System.Windows.Forms.StatusStrip status;
    private System.IO.Ports.SerialPort serialPort1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.MenuStrip menubar;
    private System.Windows.Forms.GroupBox serialgroup;
    private System.Windows.Forms.Button connect;
    private System.Windows.Forms.ComboBox serialchoice;
    private System.Windows.Forms.Button refresh;
  }
}
