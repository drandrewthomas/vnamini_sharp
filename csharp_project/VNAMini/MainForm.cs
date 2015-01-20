using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using ZedGraph;

namespace VNAMini
{

  public partial class MainForm : Form
  {
  
    int rtmode=0,numbytes=0,gtype=0;
    byte[] rawdata=new Byte[4096];
    double[] freqs=new double[1024];
    double[] phase_angle=new double[1024];
    double[] return_loss=new double[1024];
    double[] cal_loss=new double[1024];
    double startfreq=100000,endfreq=180000000,numsamples=1024,stepsize=0;
    double ddssize=10.737,adc12max=1024,avr_vref=1.8,AttOffset=10;
    bool correctFbug=true;
    bool gotdata=false,docals=false,iscaled=false,scanning=false;

    public MainForm()
    {
      InitializeComponent();
      stepsize=((endfreq-startfreq)/(numsamples-1));
      this.Load+=MainFormLoad;
	    this.FormClosing+=MainFormClosing;
	    this.Resize+=MainFormResize;
	    serialPort1.PortName="COM3";
      serialPort1.BaudRate=115200;
      serialPort1.DataBits=8;
      serialPort1.Parity=Parity.None;
      serialPort1.StopBits=StopBits.One;
      serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
      scan.Enabled=false;
      graph.Visible=false;
      layoutform();
    }
    
    private void MainFormLoad(object sender,EventArgs e)
    {
      checkports();
      measmode.Items.Add("Reflection");
      measmode.Items.Add("Transmission");
      measmode.SelectedIndex=0;
      graphtype.Items.Add("Return loss");
      graphtype.Items.Add("Phase angle");
      graphtype.SelectedIndex=0;
      scanmode.Items.Add("Single scan");
      scanmode.Items.Add("Continuous");
      scanmode.SelectedIndex=0;
    }

	  void layoutform()
	  {
	    graph.Location=new Point(serialgroup.Right+10,menubar.Height+10);
      graph.Size=new Size(ClientRectangle.Width-serialgroup.Right-10-vnagroup.Width-20,ClientRectangle.Height-status.Height-10-menubar.Height);
      statuslabel.Location=new Point(5,status.Top+5);
      statuslabel.Height=status.Height-10;
      statuslabel.Width=ClientRectangle.Width/2;
	    vnagroup.Location=new Point(ClientRectangle.Width-vnagroup.Width-10,menubar.Height+10);
	    graphgroup.Location=new Point(ClientRectangle.Width-graphgroup.Width-10,menubar.Height+vnagroup.Height+20);
	    scan.Width=vnagroup.Width;
	    scan.Location=new Point(ClientRectangle.Width-scan.Width-10,ClientRectangle.Height-status.Height-scan.Height-10);
	  }

	  private void MainFormResize(object sender,EventArgs e)
	  {
	    layoutform();
	  }

    void MainFormClosing(object sender,FormClosingEventArgs e)
    {
	    if(serialPort1.IsOpen) serialPort1.Close();
    }
    
    void checkports()
    {
      var ports=SerialPort.GetPortNames();
      serialchoice.DataSource=ports;
    }

    void Refresh_Click(object sender, EventArgs e)
    {
      checkports();
    }
    
    void Connect_Click(object sender, EventArgs e)
    {
      if(serialPort1.IsOpen==true)
      {
        serialPort1.Close();
        connect.Text="Connect";
        statuslabel.Text="Not connected";
        scan.Enabled=false;
        serialchoice.Enabled=true;
        refresh.Enabled=true;
      }
      else
      {
        if(serialchoice.SelectedIndex>-1)
        {
          serialPort1.PortName=serialchoice.SelectedItem.ToString();
          serialPort1.Open();
          serialPort1.DiscardInBuffer();
          connect.Text="Disconnect";
          statuslabel.Text="Connected";
          scan.Enabled=true;
          serialchoice.Enabled=false;
          refresh.Enabled=false;
        }
      }
    }
    
    void drawgraph()
    {
      switch(graphtype.SelectedIndex)
      {
        case 0: drawreturnlossgraph(); break;
        case 1: drawphaseanglegraph(); break;
      }
    }
    
    void drawreturnlossgraph()
    {
      double freq;
      LineItem myCurve1;
      graph.Visible=true;
      GraphPane myPane=graph.GraphPane;
      myPane.Title.IsVisible = false;
      myPane.Legend.IsVisible = false;
      myPane.XAxis.Title.Text="Frequency (Hz)";
      myPane.YAxis.Title.Text="Return loss (dB)";
//      myPane.YAxis.Scale.Min=0;
//      myPane.YAxis.Scale.Max=graphmax;
      myPane.YAxis.Scale.MajorStepAuto=true;
      myPane.XAxis.Scale.Min=startfreq;
      myPane.XAxis.Scale.Max=endfreq;
      myPane.Fill.Color=System.Drawing.Color.White;
      myPane.Chart.Fill.Color=System.Drawing.Color.White;
//      myPane.XAxis.Scale.MajorStep=500;
      myPane.XAxis.Scale.FontSpec.Size=20;
      myPane.YAxis.Scale.FontSpec.Size=20;
      myPane.XAxis.Title.FontSpec.Size=24;
      myPane.YAxis.Title.FontSpec.Size=24;
      myPane.Margin.All=10;
      myPane.Border.IsVisible=false;
      PointPairList list1=new PointPairList();
      for(int c=0;c<numsamples;c++)
      {
        list1.Add(freqs[c],return_loss[c]);
      }
      myPane.CurveList.Clear();
      myCurve1=myPane.AddCurve("RL",list1,Color.Red,SymbolType.None);
      myCurve1.Line.Width=1.0F;
      graph.AxisChange();
      graph.Invalidate();
    }
    
    void drawphaseanglegraph()
    {
      double freq;
      LineItem myCurve1;
      graph.Visible=true;
      GraphPane myPane=graph.GraphPane;
      myPane.Title.IsVisible = false;
      myPane.Legend.IsVisible = false;
      myPane.XAxis.Title.Text="Frequency (Hz)";
      myPane.YAxis.Title.Text="Phase angle";
//      myPane.YAxis.Scale.Min=0;
//      myPane.YAxis.Scale.Max=graphmax;
      myPane.YAxis.Scale.MajorStepAuto=true;
      myPane.XAxis.Scale.Min=startfreq;
      myPane.XAxis.Scale.Max=endfreq;
      myPane.Fill.Color=System.Drawing.Color.White;
      myPane.Chart.Fill.Color=System.Drawing.Color.White;
//      myPane.XAxis.Scale.MajorStep=500;
      myPane.XAxis.Scale.FontSpec.Size=20;
      myPane.YAxis.Scale.FontSpec.Size=20;
      myPane.XAxis.Title.FontSpec.Size=24;
      myPane.YAxis.Title.FontSpec.Size=24;
      myPane.Margin.All=10;
      myPane.Border.IsVisible=false;
      PointPairList list1=new PointPairList();
      for(int c=0;c<numsamples;c++)
      {
        list1.Add(freqs[c],phase_angle[c]);
      }
      myPane.CurveList.Clear();
      myCurve1=myPane.AddCurve("PA",list1,Color.Red,SymbolType.None);
      myCurve1.Line.Width=1.0F;
      graph.AxisChange();
      graph.Invalidate();
    }
    
    void processdata()
    {
      int c;
      double adjf=avr_vref/adc12max;
      double padj=180.0/1.8;
      double rladj=60.0/1.8;
      for(c=0;c<numsamples;c++)
      {
        phase_angle[c]=rawdata[(c*4)+0]+(rawdata[(c*4)+1]*256);
        phase_angle[c]=phase_angle[c]*adjf*padj;
        if(phase_angle[c]<0) phase_angle[c]=phase_angle[c]*(-1);
        return_loss[c]=rawdata[(c*4)+2]+(rawdata[(c*4)+3]*256);
        return_loss[c]=return_loss[c]*adjf;
        return_loss[c]=-30+(return_loss[c]*rladj);
        if(rtmode==0) return_loss[c]=return_loss[c]+AttOffset;
        return_loss[c]*=(-1);
      }
      for(c=0;c<numsamples;c++) freqs[c]=startfreq+(((double)c)*stepsize);
      gotdata=true;
    }
    
    void startVNA()
    {
      double adjstart;
      rtmode=measmode.SelectedIndex;
//  startfreq=cdbl(sfreq.Text)*1000
//  endfreq=cdbl(efreq.Text)*1000
      stepsize=((endfreq-startfreq)/(numsamples-1));
      if(correctFbug==true) adjstart=startfreq-stepsize;
      else adjstart=startfreq;
      serialPort1.Write(rtmode.ToString()+"\r");
      Thread.Sleep(100);
      serialPort1.Write((adjstart*ddssize).ToString()+"\r");
      Thread.Sleep(100);
      serialPort1.Write(numsamples.ToString()+"\r");
      Thread.Sleep(100);
      serialPort1.Write((stepsize*ddssize).ToString()+"\r");
      numbytes=0;
      scanning=true;
    }
 
    void Scan_Click(object sender, EventArgs e)
    {
      if(serialPort1.IsOpen==true)
      {
        scan.Enabled=false;
        statuslabel.Text="Scanning...";
        startVNA();
      }
    }

    void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      MethodInvoker mi;
      int count=serialPort1.BytesToRead;
      for(int c=0;c<count;c++)
      {
        if(scanning==true && numbytes<(numsamples*4))
        {
          if(serialPort1.IsOpen==true)
          {
            rawdata[numbytes]=(byte)serialPort1.ReadByte();
            numbytes++;
            if(numbytes>=(numsamples*4))
            {
              scanning=false;
              processdata();
              mi=delegate
              {
                statuslabel.Text="Scan completed";
                drawgraph();
                scan.Enabled=true;
              };
              if(InvokeRequired) this.Invoke(mi);
            }
          }
        }
        else if(serialPort1.IsOpen==true) serialPort1.ReadByte();
      }
    }

    void Graphtype_SelectedIndexChanged(object sender, EventArgs e)
    {
      if(gotdata==true) drawgraph();
    }

    void ExportCSVToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int c;
      SaveFileDialog savefile=new SaveFileDialog();
      savefile.FileName="vnamini.csv";
      savefile.Filter="Comma separated values file (*.csv)|*.csv";
      if(savefile.ShowDialog()==DialogResult.OK)
      {
      	try 
        {
          StreamWriter sw=new StreamWriter(savefile.FileName);
          sw.WriteLine("Frequency(Hz),Return Loss(dB),Phase(deg)");
          for(c=0;c<numsamples;c++)
          {
          	double freq=startfreq+(((double)(c))*stepsize);
          	sw.Write(freq);
          	sw.Write(",");
          	sw.Write(return_loss[c]);
          	sw.Write(",");
          	sw.Write(phase_angle[c]);
          	sw.WriteLine("");
          }
          sw.Close();
        }
        catch(Exception ex)
        {
          MessageBox.Show(ex.ToString());
        }
        finally{}
      }
    }

  }
}
