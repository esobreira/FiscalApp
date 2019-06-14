using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalApp
{
    static class Program
    {
        //These Dll's will handle the hooks. Yaaar mateys!

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // The two dll imports below will handle the window hiding.

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        static MainForm mainForm = new MainForm();

        [STAThread]
        static void Main()
        {
            //var handle = GetConsoleWindow();

            // Hide
            //ShowWindow(handle, SW_HIDE);

            //_hookID = SetHook(_proc);

            //Application.Run();
            //UnhookWindowsHookEx(_hookID);

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(mainForm);

            //UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                //Console.WriteLine((Keys)vkCode);
                //StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                //sw.Write((Keys)vkCode);
                //sw.Close();

                //separeWords((Keys)vkCode);    // UNCOMMENT TO WORK
                //mainForm.txtBuffer.Text = _buffer.ToString();
                //mainForm.txtGarbage.Text = _garbage.ToString();
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public static StringBuilder _buffer = new StringBuilder();
        public static StringBuilder _garbage = new StringBuilder();
        public static string _lastWord = "";

        //private static void separeWords(Keys key)
        //{
        //    string stringValue = "";
        //    int keyval = (int)key;

        //    _garbage.AppendLine("Key: " + key.ToString() + ", KeyVal: " + keyval);

        //    switch (key)
        //    {
        //        case Keys.Oemtilde | Keys.LButton:
        //            _buffer.Append('/');
        //            break;

        //        case Keys.Oemtilde | Keys.RButton:
        //            _buffer.Append('/');
        //            break;

        //        case Keys.OemBackslash:
        //            _buffer.Append(@"\");
        //            break;

        //        case Keys.Tab:
        //        case Keys.Enter:
        //        case Keys.Space:
        //            _buffer.Append(" ");
        //            //_buffer.AppendLine(" ");

        //            // gets last whole word typed
        //            var words = _buffer.ToString().Split(new char[] { ' ' }).ToArray<string>();

        //            if (string.IsNullOrEmpty(words.Last()))
        //            {
        //                Program._lastWord = words[words.Length - 2]; // before the last one
        //            }
        //            else
        //            {
        //                Program._lastWord = words.Last();
        //            }

        //            LinkLabel ll = new LinkLabel();
        //            ll.Text = Program._lastWord;
        //            ll.ContextMenuStrip = mainForm.cntxLinkLabel;
        //            ll.Click += Ll_Click;

        //            mainForm.flwLastWords.Controls.Add(ll);

        //            break;

        //        case Keys.D0:
        //            stringValue = "0";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D1:
        //            stringValue = "1";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D2:
        //            stringValue = "2";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D3:
        //            stringValue = "3";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D4:
        //            stringValue = "4";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D5:
        //            stringValue = "5";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D6:
        //            stringValue = "6";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D7:
        //            stringValue = "7";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D8:
        //            stringValue = "8";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.D9:
        //            stringValue = "9";
        //            _buffer.Append(stringValue);
        //            break;

        //        case Keys.A:
        //        case Keys.B:
        //        case Keys.C:
        //        case Keys.D:
        //        case Keys.E:
        //        case Keys.F:
        //        case Keys.G:
        //        case Keys.H:
        //        case Keys.I:
        //        case Keys.J:
        //        case Keys.K:
        //        case Keys.L:
        //        case Keys.M:
        //        case Keys.N:
        //        case Keys.O:
        //        case Keys.P:
        //        case Keys.Q:
        //        case Keys.R:
        //        case Keys.S:
        //        case Keys.T:
        //        case Keys.U:
        //        case Keys.V:
        //        case Keys.W:
        //        case Keys.X:
        //        case Keys.Y:
        //        case Keys.Z:
        //            stringValue = Enum.GetName(typeof(Keys), key);
        //            _buffer.Append(stringValue);
        //            break;

        //        case Keys.Multiply:
        //            stringValue = "*";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.Add:
        //            stringValue = "+";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.Separator:
        //            stringValue = ".";
        //            break;
        //        case Keys.Subtract:
        //            stringValue = "-";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.Decimal:
        //            stringValue = ".";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.Divide:
        //            stringValue = "/";
        //            _buffer.Append(stringValue);
        //            break;

        //        case Keys.NumPad0:
        //            stringValue = "0";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad1:
        //            stringValue = "1";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad2:
        //            stringValue = "2";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad3:
        //            stringValue = "3";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad4:
        //            stringValue = "4";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad5:
        //            stringValue = "5";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad6:
        //            stringValue = "6";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad7:
        //            stringValue = "7";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad8:
        //            stringValue = "8";
        //            _buffer.Append(stringValue);
        //            break;
        //        case Keys.NumPad9:
        //            stringValue = "9";
        //            _buffer.Append(stringValue);
        //            break;
                    

        //        //case Keys.LButton:
        //        //    break;
        //        //case Keys.RButton:
        //        //    break;
        //        //case Keys.Cancel:
        //        //    break;
        //        //case Keys.MButton:
        //        //    break;
        //        //case Keys.XButton1:
        //        //    break;
        //        //case Keys.XButton2:
        //        //    break;
        //        //case Keys.Back:
        //        //    break;
        //        //case Keys.LineFeed:
        //        //    break;
        //        //case Keys.Clear:
        //        //    break;
        //        //case Keys.ShiftKey:
        //        //    break;
        //        //case Keys.ControlKey:
        //        //    break;
        //        //case Keys.Menu:
        //        //    break;
        //        //case Keys.Pause:
        //        //    break;
        //        //case Keys.Capital:
        //        //    break;
        //        //case Keys.Escape:
        //        //    break;
        //        //case Keys.Prior:
        //        //    break;
        //        ////case Keys.Next:
        //        ////    break;
        //        //case Keys.PageDown:
        //        //    break;
        //        //case Keys.End:
        //        //    break;
        //        //case Keys.Home:
        //        //    break;
        //        //case Keys.Left:
        //        //    break;
        //        //case Keys.Up:
        //        //    break;
        //        //case Keys.Right:
        //        //    break;
        //        //case Keys.Down:
        //        //    break;
        //        //case Keys.Select:
        //        //    break;
        //        //case Keys.Print:
        //        //    break;
        //        //case Keys.Execute:
        //        //    break;
        //        //case Keys.Snapshot:
        //        //    break;
        //        //case Keys.Insert:
        //        //    break;
        //        //case Keys.Delete:
        //        //    break;
        //        //case Keys.Help:
        //        //    break;
        //        //case Keys.LWin:
        //        //    break;
        //        //case Keys.RWin:
        //        //    break;
        //        //case Keys.Apps:
        //        //    break;
        //        //case Keys.Sleep:
        //        //    break;

        //        //case Keys.F1:
        //        //    break;
        //        //case Keys.F2:
        //        //    break;
        //        //case Keys.F3:
        //        //    break;
        //        //case Keys.F4:
        //        //    break;
        //        //case Keys.F5:
        //        //    break;
        //        //case Keys.F6:
        //        //    break;
        //        //case Keys.F7:
        //        //    break;
        //        //case Keys.F8:
        //        //    break;
        //        //case Keys.F9:
        //        //    break;
        //        //case Keys.F10:
        //        //    break;
        //        //case Keys.F11:
        //        //    break;
        //        //case Keys.F12:
        //        //    break;
        //        //case Keys.Scroll:
        //        //    break;
        //        //case Keys.LShiftKey:
        //        //    break;
        //        //case Keys.RShiftKey:
        //        //    break;
        //        //case Keys.LControlKey:
        //        //    break;
        //        //case Keys.RControlKey:
        //        //    break;
        //        //case Keys.LMenu:
        //        //    break;
        //        //case Keys.RMenu:
        //        //    break;
        //        //case Keys.ProcessKey:
        //        //    break;
        //        //case Keys.Packet:
        //        //    break;
        //        //case Keys.Attn:
        //        //    break;
        //        //case Keys.Crsel:
        //        //    break;
        //        //case Keys.Exsel:
        //        //    break;
        //        //case Keys.EraseEof:
        //        //    break;
        //        //case Keys.Play:
        //        //    break;
        //        //case Keys.Zoom:
        //        //    break;
        //        //case Keys.NoName:
        //        //    break;
        //        //case Keys.Pa1:
        //        //    break;
        //        //case Keys.OemClear:
        //        //    break;
        //        //case Keys.Shift:
        //        //    break;
        //        //case Keys.Control:
        //        //    break;
        //        //case Keys.Alt:
        //        //    break;

        //        default:
        //            //_garbage.AppendLine(key.ToString());
        //            break;
        //    }
        //}

        private static void Ll_Click(object sender, EventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            Clipboard.SetText(link.Text);
        }
    }
}
