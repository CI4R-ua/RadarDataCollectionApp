﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AutoIt;
using System.IO;
using System.Speech.Synthesis;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {


        private int Action = 0;
        private int Angle = 0;
        private int Person = 0;
        private int[] Iteration;
        private SpeechSynthesizer speaker;
        Process SDRGUI;
        Process matlab;
        Process specto;

        private int prevRadar = 0;
        private int prevAction = 0;
        private int prevAngle = 0;
        private int prevPerson = 0;
        private int[] prevIteration;
        private string prevFileName = "";
        private bool heartbeat = false;
        private int seconds;
        // Receive buffer.  
        private static byte[] buffer = new byte[100];
        //Client Handling Sockets
        private static List<Socket> clients = new List<Socket>();
        //Bool for heartbeat
        private List<bool> isAlive = new List<bool>();
        //Client Listening Socket
        private static Socket _socket;
        //Local EndPoint
        private static IPEndPoint localEndPoint;
        //Socket Number for device; 99 for local;100 for not available
        const int num_devices = 10;
        private device[] device;
        private bool kinect_conn = false;
        private bool firstServer = true;
        String it;
        private bool matlabrun = false;

        public Form1()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            button5.Enabled = false;

            device = new device[num_devices];
            for (int i = 0; i < num_devices; i++)
            {
                device[i] = new WindowsFormsApplication1.device();
                /*    switch (i) {
                        case 0 :
                            device[i].record = Record_Ancortek98;
                            device[i].delete = Delete_Ancortek98;
                            break;
                        case 1:
                            device[i].record = Record_Ancortek25;
                            device[i].delete = Delete_Ancortek25;
                            break;
                        case 2:
                            device[i].record = Record_Kinect;
                            device[i].delete = Delete_Kinect;
                            break;
                        case 3:
                            device[i].record = Record_Xethru;
                            device[i].delete = Delete_Xethru;
                            break;
                        case 4:
                            device[i].record = Record_RFBeam;
                            device[i].delete = Delete_RFBeam;
                            break;
                  }*/
            }
            //Setting Ancortek and Kinect to local
            device[1].soc = 99;
           // device[2].soc = 99; Removed due to second Kinect networked
            Iteration = new int[num_devices];
            prevIteration = new int[num_devices];
            SDRGUI = Process.Start(@"C:\Program Files (x86)\Ancortek SDR\SDR-GUI.exe", "");
            
           
            SetForegroundWindow(SDRGUI.MainWindowHandle);
            


            PopulatePerson();
            PopulateMotion();
            
            
           // GetAppWindow();
            // speaker.Speak("Specify Action");
        }

        private void GetAppWindow()
        {
            Invoke(new Action(() =>
            {
                SetForegroundWindow(Handle);
            }));
        }
        private void GetRadarWindow()
        {
            SetForegroundWindow(SDRGUI.MainWindowHandle);

        }
        private void GetXethruWindow()
        {
            _WinWaitActivate("MATLAB R2017a - academic use", "", 15);
            AutoItX.MouseClick("left", 540, 690,1);
        }

        
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person = listBox1.SelectedIndex;
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Action = listBox2.SelectedIndex;
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Angle = listBox3.SelectedIndex;
        }

        private void PopulatePerson()
        {

            string[] lines = System.IO.File.ReadAllLines(directory.Text+"names.txt");
            try
            {
                listBox1.Items.Clear();


                for (int index = 0; index < lines.Length; index++)
                {

                    listBox1.Items.Add(lines[index]);
                }

            }
            catch
            {
            }

        }
        private void PopulateMotion()
        {

            string[] lines = System.IO.File.ReadAllLines(directory.Text+"motions.txt");
            try
            {
                listBox2.Items.Clear();


                for (int index = 0; index < lines.Length; index++)
                {

                    listBox2.Items.Add(lines[index]);
                }

            }
            catch
            {
            }

        }

        //Get Iteration and update Iteration from file
        void GetIteration()
        {
            

        }

        //Add New Subject
        private void button1_Click(object sender, EventArgs e)
        { //Function for adding new subject

            DialogResult dr = new DialogResult();
            Form2 frm2 = new Form2();
            dr = frm2.ShowDialog();
            if (dr == DialogResult.OK)
            {
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(directory.Text+"names.txt", true))
                {
                    file.WriteLine(frm2.name);

                }
                PopulatePerson(); //update Names on Form

                //Create new Iteration Log for new subject
                int person_num = listBox1.Items.Count;

                int action_num = listBox2.Items.Count;
                int angle_num = listBox3.Items.Count;
                int radar_num = num_devices;

                FileStream F = new FileStream(@"C:\Users\RSL\Documents\GestureDataRepo\" + (person_num - 1).ToString() + ".txt", FileMode.Create, FileAccess.ReadWrite, FileShare.Write);
                StreamWriter writer = new StreamWriter(F);
                for (int i = 0; i < radar_num; i++)
                {
                    for (int j = 0; j < action_num; j++)
                    {
                        for (int k = 0; k < angle_num; k++)
                        {
                            string text = i.ToString() + " " + j.ToString() + " " + k.ToString() + " " + 0.ToString();
                            writer.WriteLine(text);

                        }
                    }
                }
                writer.Close();
            }


        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void _WinWaitActivate(string title, string text, int timeout)
        {
            AutoItX.WinWait(title, text, timeout);
            if (AutoItX.WinActive(title, text) == 0)
            {
                AutoItX.WinActivate(title, text);
            }

            AutoItX.WinWaitActive(title, text, timeout);
        }

        //Start Recording
        private void button2_Click(object sender, EventArgs e)
        {

            //Sending record signal to all connected client sockets
            //   var ch = new Thread(command_thread);
            //    ch.Start();
            it = ((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString().Split('.')[0];
            int[] radar_sel = new int[num_devices];
            radar_sel[0] = Ancortek98.Checked ? 1 : 0;
            radar_sel[1] = Ancortek25.Checked ? 1 : 0;
            radar_sel[2] = Kinect.Checked ? 1 : 0;
            radar_sel[3] = Xethru.Checked ? 1 : 0;
            radar_sel[4] = RFBeam.Checked ? 1 : 0;
            radar_sel[5] = Ancortek58.Checked ? 1 : 0;
            radar_sel[6] = Xethru1.Checked ? 1 : 0;
            radar_sel[9] = LeapMotion.Checked ? 1 : 0;
            seconds = Convert.ToInt32(textBox1.Text);
            //Starting recording threads for selected devices
            for (int i = num_devices-1; i >=0; i--)
            {
                if (radar_sel[i] == 1)
                {
                    switch (i)
                    {
                        case 0:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Record_Ancortek98));
                            // ThreadPool.QueueUserWorkItem(new WaitCallback(Delete_Ancortek98));
                            break;
                        case 1:
                            GetRadarWindow();
                            Thread.Sleep(1750);
                            AutoItX.MouseClick("left", 145, 400,1);
                            AutoItX.Sleep(100);
                            AutoItX.Send("^a");
                            AutoItX.Send(seconds.ToString());
                            AutoItX.MouseClick("left", 131, 470,1);
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Record_Ancortek25));
                            // ThreadPool.QueueUserWorkItem(new WaitCallback(Delete_Ancortek25));
                            break;
                        case 2:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Record_Kinect));
                            // ThreadPool.QueueUserWorkItem(new WaitCallback(Delete_Kinect));
                            break;
                        case 3:
                            GetXethruWindow();
                            AutoItX.Send(@"cd 'C:\Users\RSL\Documents\Xethru\matlab\examples\'");
                            AutoItX.Send("{ENTER}");
                            matlabrun = true;
                            AutoItX.Send("X4record("+seconds.ToString()+",\'temp\')");
                            AutoItX.Send("{ENTER}");
                            GetAppWindow();
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Record_Xethru));
                            //   ThreadPool.QueueUserWorkItem(new WaitCallback(Delete_Xethru));
                            break;
                        case 4:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Record_RFBeam));
                            //    ThreadPool.QueueUserWorkItem(new WaitCallback(Delete_RFBeam));
                            break;
                        case 5:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Record_Ancortek58));
                            //    ThreadPool.QueueUserWorkItem(new WaitCallback(Delete_RFBeam));
                            break;
                        
                        case 6:
                            string path = @"C:\Users\RSL\Documents\Xethru\lib64";
                            Process x = new Process();
                            x.StartInfo = new ProcessStartInfo("X4record2.exe");
                            x.StartInfo.Arguments = textBox1.Text + " 17 15 16 \"C:\\Users\\RSL\\Desktop\\Xethru\"";
                            x.StartInfo.WorkingDirectory = path;
                            x.StartInfo.CreateNoWindow = true;
                            x.EnableRaisingEvents = true;
                            x.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            x.Exited += new EventHandler(Record_Xethru123);
                            x.Start();

                            //ThreadPool.QueueUserWorkItem(new WaitCallback(Record_Xethru123));
                            //   ThreadPool.QueueUserWorkItem(new WaitCallback(Delete_Xethru));
                            break;
                        case 9:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Record_LeapMotion));

                            break;
                    }

                }
            }

        }

        public void Record_Ancortek98(Object stateinfo)
        {
            /*      byte[] send_data = new byte[10];
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)20), 0, send_data, 0, 2);
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)3), 0, send_data, 2, 2);
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)Person), 0, send_data, 4, 2);
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)Action), 0, send_data, 6, 2);
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)Angle), 0, send_data, 8, 2);
                  Send(clients[i], send_data); */
            //  int it = GetIteration(0);
            byte[] send_data = new byte[12];
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)20), 0, send_data, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)4), 0, send_data, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Person), 0, send_data, 4, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Action), 0, send_data, 6, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Angle), 0, send_data, 8, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)0), 0, send_data, 10, 2);
            Send(clients[device[0].soc], send_data);
            NetLog("Finished send info to Ancortek98");
        }
        private void Delete_Ancortek98(Object stateinfo)
        {
            //to be filled
        }
        public void Record_Ancortek58(Object stateinfo)
        {
            /*      byte[] send_data = new byte[10];
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)20), 0, send_data, 0, 2);
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)3), 0, send_data, 2, 2);
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)Person), 0, send_data, 4, 2);
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)Action), 0, send_data, 6, 2);
                  Buffer.BlockCopy(BitConverter.GetBytes((ushort)Angle), 0, send_data, 8, 2);
                  Send(clients[i], send_data); */
            //  int it = GetIteration(0);
            byte[] send_data = new byte[12];
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)20), 0, send_data, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)4), 0, send_data, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Person), 0, send_data, 4, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Action), 0, send_data, 6, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Angle), 0, send_data, 8, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)5), 0, send_data, 10, 2);
            Send(clients[device[5].soc], send_data);
            NetLog("Finished send info to Ancortek58");
        }
        private void Delete_Ancortek58(Object stateinfo)
        {
            //to be filled
        }
        private void Record_Ancortek25(Object stateinfo)
        {


            string name = getzero((1).ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + it;
            prevAction = Action;
            prevAngle = Angle;
            prevPerson = Person;
            prevIteration[2] = Iteration[4];
            prevRadar = 1;
            prevFileName = name + ".dat";
            Thread.Sleep(seconds*1000);
           _WinWaitActivate("Save Recorded Session", "", 30);
            
            AutoItX.Send(name);

            for (int i = 0; i < 6; i++)
            {
                AutoItX.Send("{TAB}");
            }
            AutoItX.Send("{ENTER}");
            AutoItX.Send(directory.Text);
            AutoItX.Send("{ENTER}");
            for (int i = 0; i < 9; i++)
            {
                AutoItX.Send("{TAB}");
            }
            AutoItX.Send("{ENTER}");
           // _WinWaitActivate("Radar", "Action:", 15);
            //  speaker.Speak("Recording Complete");
        }
        private void Delete_Ancortek25(Object stateinfo)
        {
            string path = @"C:\Users\RSL\Documents\GestureDataRepo\" + prevFileName;
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\RSL\Documents\GestureDataRepo\" + prevPerson.ToString() + ".txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split();
                if (Convert.ToInt32(words[0]) == 1 && Convert.ToInt32(words[1]) == prevAction && Convert.ToInt32(words[2]) == prevAngle)
                {
                    prevIteration[1] = Convert.ToInt32(words[3]);

                    words[3] = (prevIteration[1] - 1).ToString();
                    lines[i] = words[0] + ' ' + words[1] + ' ' + words[2] + ' ' + words[3];

                }

                System.IO.File.WriteAllLines(@"C:\Users\RSL\Documents\GestureDataRepo\" + prevPerson.ToString() + ".txt", lines);

            }
        }
        private void Record_Kinect(Object stateinfo)
        { 
            string path = directory.Text;
            // filename for only color video
            //string name = getzero((2).ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + it;
            // filename for xef file
            string name = path + getzero((2).ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + it + ".xef";
            Process kinect;
            kinect = new Process();
            kinect.StartInfo.FileName = "cmd.exe";
            kinect.StartInfo.RedirectStandardInput = true;
            kinect.StartInfo.UseShellExecute = false;
            kinect.StartInfo.CreateNoWindow = true;
            kinect.Start();
            using (StreamWriter sw = kinect.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    // command for xef recording
                    sw.WriteLine(@"cd " + path);
                    //sw.WriteLine(@"echo KSUtil.exe /record " + name + " " + seconds + " /stream color depth ir body 1> camlog.txt 2>&1");
                    sw.WriteLine(@"KSUtil.exe /record " + name + " " + seconds + " /stream color depth ir body 1> camlog2.txt 2>&1");

                    // command for only video recording
                    //sw.WriteLine(@"cd "+path);
                    // //ffmpeg -f dshow -rtbufsize 1024M -i video="Kinect V2 Video Sensor" -t 10 out2.mp4
                    //sw.WriteLine("C:\\ffmpeg\\bin\\ffmpeg.exe -f dshow -rtbufsize 2048M -i video=\"Kinect V2 Video Sensor\" -t " + seconds + " " + name + ".mp4 > camlog.txt");
                    // //System.Diagnostics.Debug.WriteLine(@"cd " + path);
                    // //System.Diagnostics.Debug.WriteLine("ffmpeg -f dshow -rtbufsize 2048M -i video=\"Kinect V2 Video Sensor\" -t " + seconds + " " + name + ".mp4");
                }
            }
           
        }

        private void Record_LeapMotion(Object stateinfo) {
            
            byte[] send_data = new byte[16];
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)20), 0, send_data, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)6), 0, send_data, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Person), 0, send_data, 4, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Action), 0, send_data, 6, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Angle), 0, send_data, 8, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)10), 0, send_data, 10, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Iteration[9]), 0, send_data, 12, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)seconds), 0, send_data, 14, 2);
            Send(clients[device[9].soc], send_data);
            NetLog("Finished send info to LeapMotion");
            /*
            string path = @"C:\Users\RSL\Documents\LeapMotion";// BodyBasics-WPF.exe";
            Process kinect;
            kinect = new Process();
            kinect.StartInfo.FileName = "cmd.exe";
            kinect.StartInfo.RedirectStandardInput = true;
            kinect.StartInfo.UseShellExecute = false;
            kinect.Start();
            string name = @"C:\Users\RSL\Documents\GestureDataRepo\" + getzero((10).ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + getzero(Iteration[9].ToString()) + ".txt";
            using (StreamWriter sw = kinect.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine(@"cd " + path);
                    sw.WriteLine("leapmotion_record.exe -dir " + name + " -time " + seconds);
                }
            }*/

        }
        private void Delete_Kinect(Object stateinfo)
        {  //to be filled
        }
        private void Record_Xethru(Object stateinfo)
        {  //to be filled

            string new_file_name = getzero((3).ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + getzero(Iteration[3].ToString()) + ".dat";
            while (!Directory.Exists(@"C:\Users\RSL\Desktop\Xethru\temp"))
            {
                Thread.Sleep(400);
            }

            while (System.IO.Directory.GetDirectories(@"C:\Users\RSL\Desktop\Xethru\temp").Length == 0)
            {
                Thread.Sleep(400);
            }
            GetAppWindow();
            string[] folder = Directory.GetDirectories(@"C:\Users\RSL\Desktop\Xethru\temp");
            string[] files = Directory.GetFiles(folder[0], "t*");
           
            System.IO.File.Copy(files[0], @"C:\Users\RSL\Documents\GestureDataRepo\" + new_file_name);
            while (!File.Exists(@"C:\Users\RSL\Documents\GestureDataRepo\" + new_file_name))
            {
                Thread.Sleep(400);
            }
            Delete:
                try
                {
                  Directory.Delete(@"C:\Users\RSL\Desktop\Xethru\temp", true);
                }
                catch (IOException ex) {
                goto Delete;
                }
            matlabrun = false;
            //  AutoItX.MouseClick("left",540, 700);
            //  AutoItX.Send("{F5}"); 
        }

        private void Record_Xethru123(object sender, System.EventArgs e)
        {  //Start routine to copy files from default folder to correct folder, rename files, and clean default folder

            string new_file_name1 = getzero((6).ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + it + ".dat";
            string new_file_name2 = getzero((7).ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + it + ".dat";
            string new_file_name3 = getzero((8).ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + it + ".dat";
            //  Thread.Sleep((Convert.ToInt16(textBox1.Text) +12) * 1000);
            while (!Directory.Exists(@"C:\Users\RSL\Desktop\Xethru\1\Sevgi"))
            {
                Thread.Sleep(400);
            }
            while (!Directory.Exists(@"C:\Users\RSL\Desktop\Xethru\2\Sevgi"))
            {
                Thread.Sleep(400);
            }
            while (!Directory.Exists(@"C:\Users\RSL\Desktop\Xethru\3\Sevgi"))
            {
                Thread.Sleep(400);
            }

            while (System.IO.Directory.GetDirectories(@"C:\Users\RSL\Desktop\Xethru\1\Sevgi").Length == 0)
            {
                Thread.Sleep(400);
            }
            while (System.IO.Directory.GetDirectories(@"C:\Users\RSL\Desktop\Xethru\2\Sevgi").Length == 0)
            {
                Thread.Sleep(400);
            }
            while (System.IO.Directory.GetDirectories(@"C:\Users\RSL\Desktop\Xethru\3\Sevgi").Length == 0)
            {
                Thread.Sleep(400);
            }

            GetAppWindow();
            string[] folder1 = Directory.GetDirectories(@"C:\Users\RSL\Desktop\Xethru\1\Sevgi");
            string[] files1 = Directory.GetFiles(folder1[0], "x*");
            int ind1 = 0;
            if (files1[ind1] == "xethru_recording_meta.dat") ind1 = 1;

            System.IO.File.Copy(files1[0], directory.Text + new_file_name1);
            //  Thread.Sleep(1500);
            while (!File.Exists(directory.Text + new_file_name1))
            {
                Thread.Sleep(400);
            }
        Delete1:
            try
            {
                Directory.Delete(@"C:\Users\RSL\Desktop\Xethru\1\Sevgi", true);
            }
            catch (IOException ex)
            {
                goto Delete1;
            }

            string[] folder2 = Directory.GetDirectories(@"C:\Users\RSL\Desktop\Xethru\2\Sevgi");

            string[] files2 = Directory.GetFiles(folder2[0], "x*");


            int ind2 = 0;
            if (files2[ind2] == "xethru_recording_meta.dat") ind2 = 1;

            System.IO.File.Copy(files2[0], directory.Text + new_file_name2);
            //      Thread.Sleep(1500);
            while (!File.Exists(directory.Text + new_file_name2))
            {
                Thread.Sleep(400);
            }
        Delete2:
            try
            {
                Directory.Delete(@"C:\Users\RSL\Desktop\Xethru\2\Sevgi", true);
            }
            catch (IOException ex)
            {
                goto Delete2;
            }

            string[] folder3 = Directory.GetDirectories(@"C:\Users\RSL\Desktop\Xethru\3\Sevgi");
            string[] files3 = Directory.GetFiles(folder3[0], "x*");
            int ind3 = 0;
            if (files3[ind3] == "xethru_recording_meta.dat") ind3 = 1;

            System.IO.File.Copy(files3[0], directory.Text + new_file_name3);
            //     Thread.Sleep(1500);
            while (!File.Exists(directory.Text + new_file_name3))
            {
                Thread.Sleep(400);
            }
        Delete3:
            try
            {
                Directory.Delete(@"C:\Users\RSL\Desktop\Xethru\3\Sevgi", true);
            }
            catch (IOException ex)
            {
                goto Delete3;
            }

            //  AutoItX.MouseClick("left",540, 700);
            //  AutoItX.Send("{F5}");
        }

        private void Delete_Xethru(Object stateinfo)
        {  //to be filled
        }
        private void Record_RFBeam(Object stateinfo)
        {
            //       int it = GetIteration(4);
            byte[] send_data = new byte[22];
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)20), 0, send_data, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)5), 0, send_data, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Person), 0, send_data, 4, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Action), 0, send_data, 6, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)Angle), 0, send_data, 8, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)4), 0, send_data, 10, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)seconds), 0, send_data, 12, 2);
            Buffer.BlockCopy(BitConverter.GetBytes((long)Convert.ToInt64(it)),0, send_data,14,4);
            Send(clients[device[4].soc], send_data);

        }
        private void Delete_RFBeam(Object stateinfo)
        {  //to be filled

        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
        private string getzero(string s)
        {
            if (s.Length == 1)
            {
                return "0" + s;
            }
            else return s;
        }

        private void show_spectogram(string filename) {
            while (matlabrun == true) Thread.Sleep(200);
            GetXethruWindow();
            AutoItX.Send(@"cd 'C:\Users\RSL\Documents\Xethru\matlab\examples\'");
            AutoItX.Send("{ENTER}");
            AutoItX.Send("specpreview('" + filename + "')");
            AutoItX.Send("{ENTER}");
            GetAppWindow();
           
        }

        //Delayed Start Recording
        private void button3_Click(object sender, EventArgs e)
        {
            int delay = Convert.ToInt32(textBox2.Text);
            System.Threading.Thread.Sleep(delay * 1000);
            speaker.Speak("Perform action after the beep");
            System.Threading.Thread.Sleep(200);
            Console.Beep();
            button2_Click(sender, e);
        }

        //Add New Action
        private void button4_Click(object sender, EventArgs e)
        { // Function for adding new gesture

            DialogResult dr = new DialogResult();
            Form2 frm2 = new Form2();
            dr = frm2.ShowDialog();
            if (dr == DialogResult.OK)
            {
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(directory.Text + "motions.txt", true))
                {
                    file.WriteLine(frm2.name);

                }
                PopulateMotion(); //update motions on Form

                
            }
        }

        //Delete Previous Recording
        private void button5_Click(object sender, EventArgs e)
        {




        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Heartbeat Thread
        private void HeartbeatThread()
        {

            while (heartbeat)
            {

                for (int i = 0; i < clients.Count; i++)
                {    //Send Heartbeat




                    if (isAlive[i] == true)
                    {//Keep count of alive connections
                        Send(clients[i], BitConverter.GetBytes((ushort)1));
                        isAlive[i] = false;

                    }
                    else
                    {
                        //Disconnect socket
                        clients[i].Shutdown(SocketShutdown.Both);
                        clients[i].Close();
                        clients.Remove(clients[i]);
                        isAlive.Remove(isAlive[i]);
                        for (int j = 0; j < num_devices; j++)
                        {
                            //Set device socket to 100 for disconnected
                            if (device[j].soc == i)
                            {
                                device[j].soc = 100;
                                DisableDevice(j);
                            }
                        }
                        i--;
                        break;
                    }
                    //Set is isAlive to false and hope Client pings back and makes it true in time
                    isAlive[i] = false;
                }
                Thread.Sleep(700);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NetworkEnableButton_Click(object sender, EventArgs e)
        {
            NetworkEnableButton.Enabled = false;
            NetworkDisableButton.Enabled = true;
            NetworkStatusLabel.Text = "Enabled";
            NetworkStatusLabel.BackColor = Color.LawnGreen;
            NetLog("Networking Enabled...");

            string hostname = String.Empty;
            hostname = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostByName(hostname);
            IPAddress[] addr = ipEntry.AddressList;
            NetworkStatusLabel.Text = addr[0].ToString();
            NetLog("Server IPv4 Address: " + addr[0].ToString());
            NetLog("Port: 11000");

            SetupServer();

            for (int i = 0; i < device.Length; i++)
            {
                if (device[i].soc != 99)
                {
                    device[i].soc = 100;
                    if (i == 0)
                    {
                        Ancortek98.Enabled = false;
                        Ancortek98C.Text = "Not Connected";
                        Ancortek98C.BackColor = Color.Orange;
                        Ancortek98.Checked = false;
                    }
                    else if (i == 3)
                    {
                        Xethru.Enabled = false;
                        XethruC.Text = "Not Connected";
                        XethruC.BackColor = Color.Orange;
                        Xethru.Checked = false;
                    }
                    else if (i == 4)
                    {
                        RFBeam.Enabled = false;
                        RFBeamC.Text = "Not Connected";
                        RFBeamC.BackColor = Color.Orange;
                        RFBeam.Checked = false;
                    }
                    else if (i == 5)
                    {
                        Ancortek58.Enabled = false;
                        Ancortek58C.Text = "Not Connected";
                        Ancortek58C.BackColor = Color.Orange;
                        Ancortek58.Checked = false;
                    }
                }
            }

        }

        private void NetworkDisableButton_Click(object sender, EventArgs e)
        {
            NetworkEnableButton.Enabled = true;
            NetworkDisableButton.Enabled = false;
            NetworkStatusLabel.Text = "Networking Disabled";
            NetworkStatusLabel.BackColor = Color.Red;
            NetLog("Networking Disabled...");


            for (int i = 0; i < device.Length; i++)
            {
                if (device[i].soc != 99)
                {
                    if (i == 0)
                    {
                        Ancortek98.Enabled = false;
                        Ancortek98C.Text = "No Network";
                        Ancortek98C.BackColor = Color.Red;
                        Ancortek98.Checked = false;
                    }
                    else if (i == 3)
                    {
                        Xethru.Enabled = false;
                        XethruC.Text = "No Network";
                        XethruC.BackColor = Color.Red;
                        Xethru.Checked = false;
                    }
                    else if (i == 4)
                    {
                        RFBeam.Enabled = false;
                        RFBeamC.Text = "No Network";
                        RFBeamC.BackColor = Color.Red;
                        RFBeam.Checked = false;
                    }
                    else if (i == 5)
                    {
                        Ancortek58.Enabled = false;
                        Ancortek58C.Text = "No Network";
                        Ancortek58C.BackColor = Color.Red;
                        Ancortek58.Checked = false;
                    }
                }
            }
            for (int i = 0; i < device.Length; i++)
            {
                if (device[i].soc != 99) device[i].soc = 100;
            }

            heartbeat = false;
            byte[] killdata = BitConverter.GetBytes((ushort)2);
            for (int i = 0; i < clients.Count; i++)
            {
                Send(clients[i], killdata);
                clients[i].Shutdown(SocketShutdown.Both);
                clients[i].Close();
                clients.Remove(clients[i]);
                isAlive.Remove(isAlive[i]);
                i--;
            }

            _socket.Close();

        }

        //TCP Socket Server Setup
        private void SetupServer()
        {


            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(IPAddress.Any, 11000));
            _socket.Listen(100);




            StartListening();
            var th = new Thread(HeartbeatThread);
            th.IsBackground = true;
            heartbeat = true;
            th.Start();

        }

        private void StartListening()
        {

            NetLog("Ready for new connection");
            _socket.BeginAccept(new AsyncCallback(AcceptCallback), _socket);

        }

        private void AcceptCallback(IAsyncResult AR)
        {

            Socket listener = (Socket)AR.AsyncState;
            if (heartbeat)
            {
                Socket handler = listener.EndAccept(AR);


                NetLog("New connection received...");


                //Initial Contact with newly connected device
                if (handler != null)
                {
                    handler.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReadCallback), handler);

                    StartListening();
                }
                else
                {
                    NetLog("Handler not received. Please restart network. Aborting... ");

                }
            }
        }

        private void Receive(Socket client)
        {
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReadCallback), client);

        }

        private void ReadCallback(IAsyncResult AR)
        {

            Socket handler = (Socket)AR.AsyncState;

            if (handler.Connected)
            {
                int data_size = handler.EndReceive(AR);
                byte[] data = new byte[data_size];
                Array.Copy(buffer, data, data_size);
                ushort command = BitConverter.ToUInt16(data, 0);
               
                if (command == 2)
                {
                    isAlive[clients.IndexOf(handler)] = false;

                }
                else
                {
                    Receive(handler);
                    if (command == 1)
                    {
                        isAlive[clients.IndexOf(handler)] = true;


                        return;
                    }

                    ushort message_size = BitConverter.ToUInt16(data, 2);

                    if (command == 15)
                    {
                        NetLog("New devices available for recording");
                        Send(handler, BitConverter.GetBytes((ushort)1));
                        clients.Add(handler);
                        isAlive.Add(true);


                        for (int i = 0; i < (int)message_size; i++)
                        {
                            ushort device_id = BitConverter.ToUInt16(data, 4 + i * 2);
                            EnableDevice((int)device_id);
                            device[device_id].soc = clients.Count - 1;

                        }


                    }
                }
            }

        }

        private void NetLog(string text)
        {
            Invoke(new Action(() =>
            {
                NetworkLog.Text = NetworkLog.Text + "\r\n" + text;
            }));
        }

        private void EnableDevice(int device_id)
        {
            Invoke(new Action(() =>
            {
                if (device_id == 0)
                {
                    Ancortek98.Enabled = true;
                    Ancortek98C.Text = "Connected";
                    Ancortek98C.BackColor = Color.LawnGreen;
                    NetLog("Ancortek 9.8 Hz Connected...");
                }
                if (device_id == 3)
                {
                    Xethru.Enabled = true;
                    XethruC.Text = "Connected";
                    XethruC.BackColor = Color.LawnGreen;
                    NetLog("Xethru Connected...");
                }
                if (device_id == 4)
                {
                    RFBeam.Enabled = true;
                    RFBeamC.Text = "Connected";
                    RFBeamC.BackColor = Color.LawnGreen;
                    NetLog("RFBeam Connected...");
                }
                if (device_id == 5)
                {
                    Ancortek58.Enabled = true;
                    Ancortek58C.Text = "Connected";
                    Ancortek58C.BackColor = Color.LawnGreen;
                    NetLog("Ancortek 5.8 Hz Connected...");
                }
            }));
        }

        private void DisableDevice(int device_id)
        {
            Invoke(new Action(() =>
            {
                if (device_id == 0)
                {
                    Ancortek98.Enabled = false;
                    Ancortek98.Checked = false;
                    Ancortek98C.Text = "Disonnected";
                    Ancortek98C.BackColor = Color.Orange;
                    NetLog("Ancortek 9.8 Hz Disconnected...");
                }
                if (device_id == 3)
                {
                    Xethru.Enabled = false;
                    Xethru.Checked = false;
                    XethruC.Text = "Disconnected";
                    XethruC.BackColor = Color.Orange;
                    NetLog("Xethru Disconnected...");
                }
                if (device_id == 4)
                {
                    RFBeam.Enabled = false;
                    RFBeam.Checked = false;
                    RFBeamC.Text = "Disconnected";
                    RFBeamC.BackColor = Color.Orange;
                    NetLog("RFBeam Disconnected...");
                }
                if (device_id == 5)
                {
                    Ancortek58.Enabled = false;
                    Ancortek58.Checked = false;
                    Ancortek58C.Text = "Disconnected";
                    Ancortek58C.BackColor = Color.Orange;
                    NetLog("Ancortek 5.8 Hz Disconnected...");
                }
            }));
        }

        private void Send(Socket handler, byte[] byteData)
        {
            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;
            if (handler.Connected)
            {
                // Retrieve the socket from the state object.  


                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);

            }

        }



        private void XethruC_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void directory_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PopulatePerson();
            PopulateMotion();
        }
    }
    public delegate void rec();
    public delegate void del();

    public class device
    {
        public int person;
        public int action;
        public int angle;
        public int iteration;
        public int radar;
        public bool can_del;
        public int soc;
       
        

        public device() {
            person = new int();
            action = new int(); 
            angle = new int();
            iteration = new int();
            radar = new int();
            soc = new int();
            can_del = new bool();

            person = action = angle = iteration = radar = 0;
          
            
        }
    }
}
