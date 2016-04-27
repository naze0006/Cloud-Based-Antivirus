using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (scanfile())
        {
            //Response.Write("file upload succes");
            Label1.Visible = true;
            Label1.Text= "No Virus Detected";
            
        }
        else
        {
            //Response.Write("file have virus not upload");
            Label1.Visible = true;
            Label1.Text = "Virus Detected and File Can Not Be Uploaded";
            
        }

    }

    public bool scanfile()
    {
        bool IsValid = true;
        //foreach (FileInfo file in fileuploadExcel.Unload)
        //{
        try
        {
            //do av check here
            Process myProcess = new Process();
            FileUpload1.SaveAs(Server.MapPath(@"~\upload\") + FileUpload1.FileName);
            //address of command line virus scan exe
            myProcess.StartInfo.FileName = @"C:\Program Files (x86)\McAfee\VirusScan Enterprise\scan32.exe";
            //"C:\\Program Files\\AVG\\AVG2012\\avgscanx.exe";


            string path = '"' + "" + Server.MapPath(@"~\upload\") + "" + FileUpload1.FileName + "" + '"';
            string report = '"' + "" + Server.MapPath(@"~\upload\Report.txt") + "" + '"';
            string myprocarg = "/SCAN=" + path + " /REPORT=" + report;
            //" /REPORT=C:\\Upload\\Temp\\Report.txt";
            myProcess.StartInfo.Arguments = myprocarg;
            myProcess.StartInfo.CreateNoWindow = true;

            //   myProcess.StartInfo.UseShellExecute = false;
            // myProcess.StartInfo.RedirectStandardOutput = true;

            myProcess.Start();
            myProcess.WaitForExit(); //wait for the scan to complete                
            //add some time for report to be written to file
            int j = 0;
            int y = 0;
            for (j = 0; j <= 1000000; j++)
            {
                y = y + 1;
            }
            Thread.Sleep(10000);

            //Get a StreamReader class that can be used to read the file
            StreamReader objStreamReader = default(StreamReader);
            objStreamReader = File.OpenText(Server.MapPath(@"~\upload\Report.txt"));
            String reportVerbose = objStreamReader.ReadToEnd().Trim();
            if (reportVerbose.Length > 0 && !reportVerbose.Contains("Found infections    :    0"))
            {
                IsValid = false;
                File.Delete(Server.MapPath(@"~\upload\") + "" + FileUpload1.FileName);
            }
            objStreamReader.Close();
            if (IsValid)
            {
                try
                {
                    if (!Directory.Exists(Server.MapPath("~/upload/")))
                        Directory.CreateDirectory(Server.MapPath("~/upload/"));
                    if (
                        !File.Exists(
                            Server.MapPath(@"~\upload\" +
                                           System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName))))
                    {
                        FileUpload1.SaveAs(Server.MapPath(@"~\DataFiles\") + FileUpload1.FileName);
                    }
                    else
                    {
                        try
                        {
                            File.Delete(
                                Server.MapPath(@"~\upload\" +
                                               System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)));
                            FileUpload1.SaveAs(Server.MapPath(@"~\DataFiles\") + FileUpload1.FileName);
                        }
                        catch (System.IO.IOException)
                        {
                        }
                    }
                }
                catch (System.IO.IOException)
                {
                }

            }
            else
            {
            }

           
          

            myProcess.Close();
        }
        catch (System.IO.IOException)
        {
        }

        return IsValid;
    }
  

   
}