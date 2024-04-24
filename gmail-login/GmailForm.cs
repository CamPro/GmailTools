using AutoIt;
using Leaf.xNet;
using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace sun_bm
{
    public partial class GmailForm : Form
    {
        public GmailForm()
        {
            InitializeComponent();
            readKey();
            checkFile("email.txt");
            checkFile("email_runned.txt");
        }

        private readonly Random _random = new Random();


        static Bitmap continueBit1 = new Bitmap("icon/tiep_theo1.png");
        static Bitmap emailOfPhone = new Bitmap("icon/emailOfPhone.png");
        static Bitmap warnBit = new Bitmap("icon/warn.png");
        


        ConcurrentQueue<string> emailQueue = new ConcurrentQueue<string>();

        private void button3_Click(object sender, EventArgs e)
        {
            CreateThreadAuto();
        }


        private void CreateThreadAuto()
        {
            Thread myNewThread = new Thread(() => RegEmailAuto());
            myNewThread.Start();
        }

        private void RegEmailAuto()
        {
            List<Account> listItem = new List<Account>();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                object obj = dataGridView.Rows[i].Cells["status"].Value;
                String thisStatus = null;
                if (obj != null)
                {
                    thisStatus = obj.ToString();
                }
                if (!"Xong".Equals(thisStatus))
                {
                    String user = (String) dataGridView.Rows[i].Cells["Email"].Value;
                    String pass = (String)dataGridView.Rows[i].Cells["Pass"].Value;
                    String emailRecover = (String)dataGridView.Rows[i].Cells["EmailRecover"].Value;
                    if(user!= null  && user.Length >3)
                    {
                        listItem.Add(new Account(user, pass, emailRecover));

                    }
                }
            }
             
            foreach(Account acc in listItem)
            {
                startRegMail(acc);

            }

        }


        private void loadEmail()
        {

            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            HashSet<string> runnedSet = new HashSet<string>();
            HashSet<string> outputSet = new HashSet<string>();
            string itemQ;
            while (emailQueue.TryDequeue(out itemQ))
            {
            }

            string[] emaillines = System.IO.File.ReadAllLines("email.txt");
            foreach (string iline in emaillines)
            {
                outputSet.Add(iline);
            }

            foreach (string item in outputSet)
            {
                emailQueue.Enqueue(item);
            }

            lblNumberEmail.Text = "" + emailQueue.Count;
            addGridView(outputSet, "");

        }

        private void addGridView(HashSet<string> outputSet, string status = "")
        {

           

            List<Account> AccountList = new List<Account>();
            foreach (String s in outputSet)
            {
                String user = "";
                String pass = "";
                String rec = "";
                String[] myArr = s.Split('|');
                user = myArr[0];
                pass = myArr[1];
                if(myArr.Length >2)
                {
                    rec = myArr[2];
                }

                AccountList.Add(new Account(user, pass, rec));


            }

            if (this.InvokeRequired)
            {
                dataGridView.Invoke((MethodInvoker)(() =>
                {
                    int i = 1;
                    foreach (Account acc in AccountList)
                    {
                        
                        object[] myArray = new object[] { "" + i, acc.user, acc.pass, acc.emailRecover, status };
                        dataGridView.Rows.Add(myArray);
                        i++;
                    }
               
                }
                ));
            }
            else
            {
                int i = 1;
                foreach (Account acc in AccountList)
                {

                    object[] myArray = new object[] { "" + i, acc.user, acc.pass, acc.emailRecover, status };
                    dataGridView.Rows.Add(myArray);
                    i++;
                }
            }
        }

        private void updateGridView(String email, String status)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                //Use when column names known
                object obj = dataGridView.Rows[i].Cells["Email"].Value;
                String ipTable = "";
                if (obj != null)
                {
                    ipTable = obj.ToString();
                }

                if (email.Equals(ipTable))
                {
                    if (this.InvokeRequired)
                    {
                        dataGridView.Invoke((MethodInvoker)(() =>
                        {
                            dataGridView.Rows[i].Cells["Status"].Value = status;
                        }));
                    }
                    else
                    {
                        dataGridView.Rows[i].Cells["Status"].Value = status;
                    }
                }
            }
        }

        private void startRegMail(Account acc)
        {
            
            
            //email = "duydan662vn";
            //email = "emmalynnlawrence689vn";
            String mobile = "";
            string webUrl = "https://accounts.google.com/signin/v2/identifier?service=accountsettings&continue=https%3A%2F%2Fmyaccount.google.com%2F&ec=GAlAwAE&flowName=GlifWebSignIn&flowEntry=AddSession&hl=en --start-maximized";      


            Process.Start("chrome.exe", webUrl);

            Thread.Sleep(2000);
            AutoItX.Send("^a");
            AutoItX.Send("{DEL}");

            AutoItX.Send(acc.user);
            searchClick(continueBit1, 5, 1000, "continueBit1");
           
            Thread.Sleep(1000);
            bool checkUser= searchCheck(warnBit, 5, 500, "warnBit");
            if(checkUser)
            {
                updateGridView(acc.user, "Sai UserName");
                return;
            }
           
            //Password
            String outStatus = null;
            Thread.Sleep(1000);

            AutoItX.Send("^a");
            AutoItX.Send("{DEL}");
            AutoItX.Send(acc.pass);

            searchClick(continueBit1, 5, 1000, "continueBit2");
            checkUser = searchCheck(warnBit, 5, 500, "warnBit");
            if (checkUser)
            {
                updateGridView(acc.user, "Sai Password");
                return;
            }

            Thread.Sleep(3000);
           // AutoItX.Send("^w");

            if(outStatus == null)
            {
                outStatus = "Xong";
            }
            updateGridView(acc.user, outStatus);
            //File.AppendAllText($"KetQua_Success.txt", $"{email}|hanoi2020|{mobile}\n");
        }

      
        private bool searchClick(Bitmap tim_kiem, int solan, int sleep)
        {
            return searchClick(tim_kiem, solan, sleep, null);
        }
        private bool searchClick(Bitmap tim_kiem, int solan, int sleep, String name)
        {
            for (int i = 0; i < solan; i++)
            {
                var screenShoot = (Bitmap)KAutoHelper.CaptureHelper.CaptureScreen();
                var clickpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, tim_kiem);
                if (clickpoint != null)
                {
                    AutoItX.MouseClick("left", clickpoint.Value.X, clickpoint.Value.Y, 1, 0);
                    Console.WriteLine("Tim kiem duoc " + name);
                    return true;
                }
                Thread.Sleep(sleep);
            }
            return false;
        }
        private bool searchCheck(Bitmap tim_kiem, int solan, int sleep, String name)
        {
            for (int i = 0; i < solan; i++)
            {
                var screenShoot = (Bitmap)KAutoHelper.CaptureHelper.CaptureScreen();
                var clickpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, tim_kiem);
                if (clickpoint != null)
                {         
                    return true;
                }
                Thread.Sleep(sleep);
            }
            return false;
        }

        private void sendAndSleep(String key)
        {
            AutoItX.Send(key);
            AutoItX.Send("{TAB}");
            AutoItX.Sleep(100);
        }
        private void Send(String key)
        {
            AutoItX.Send(key);
        }

     
        private void saveKey(String key, String value)
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SunGmailSettings");
            regKey.SetValue(key, value);
            regKey.Close();
        }

        private void readKey()
        {
            //opening the subkey  
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SunGmailSettings");

            //if it does exist, retrieve the stored values  
            if (key != null)
            {
               // textOtpSim.Text = (string)key.GetValue(Constants.OTP_SIM);
                //textChoThueSim.Text = (string)key.GetValue(Constants.CHOTHUE_SIMCODE);
                key.Close();
            }
        }

      
        private void btnImportEmail_Click(object sender, EventArgs e)
        {
            loadEmail();
        }

        void checkFile(String fileName)
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine("");
                }
            }
        }

        private void btnOpenEmail_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "email.txt");

        }
    }
}

