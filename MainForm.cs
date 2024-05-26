/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 5/26/2024
 * Time: 6:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace distanceAndSpeedinTime
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
	
		}
		void Button1Click(object sender, EventArgs e)
		{
			dateAvion da = new dateAvion();
			da.run(ref this.textBox1);
		}
		public class dateAvion
		{	
			public bool isCorect  = false;
			public Random rnd = new Random();
			public double p = 0;
			public double w = 0;
			public double x = 0;
			public double r = 0;
			public double d = 0;//(3*x+1)*100;
			public double t = 0;//(5*x+5)/10;
			public double si = 0;
			public double s = 0;//d/t;
			public void frnd()
			{
			
				x = rnd.Next(10);
			}
			public void setSpeed(double psi)
			{
				si = psi;
			}
			public bool testIfCorect()
			{
				if(Math.Abs(si-s)<=2)return true;
				else return false;
			}
			public void run(ref TextBox txt)
			{
				txt.Text=" ";
				w=0;
				r=0;
				txt.Text+="quiz on speed = distance/time \r\n \r\n";
				
				for(int i = 1 ; i < 10  ; i++)
				{
					frnd();
					d = (3*x+1)*100;
					frnd();
				 	t = (5*x+5)/10;
				 	
				 	txt.Text+="airplane"+i.ToString()+" goes " + d.ToString() + " miles in " + t.ToString() + "hours \r\n";
				 	txt.Text+="what is its speed in mph? \r\n";
				 	
				 	si = rnd.Next(0,1000);
				 	txt.Text+="airplane speed random answare is "+si.ToString()+" \r\n";
				 	setSpeed(si);
				 	s = d/t;
				 	
				 	isCorect = testIfCorect();
				 	
				 	if (isCorect==false){
				 		txt.Text+="no: speed = d/t = "+d.ToString() + "/" + t.ToString() +" =" + s.ToString() + "mph \r\n \r\n";
				 			w++;
				 	}
				 
				 	if(isCorect == true)
				 	{	
				 		txt.Text+="very good ! exact answare is " + s.ToString() + " mph \r\n \r\n";
				 		r++;
				 	}
				 	
				}
				txt.Text+="score is " + r.ToString() + " right ," + w.ToString() + "wrong \r\n \r\n";
				p = (r/5)*100;
				txt.Text+="percentage right:" + p.ToString() + " % \r\n";
				
			}
			
		}
	}
}
