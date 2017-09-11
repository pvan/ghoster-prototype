using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ghoster
{
    public partial class Form1 : Form
    {





        const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        const int SET_FEATURE_ON_PROCESS = 0x00000002;

        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(int FeatureEntry,
                                                      [MarshalAs(UnmanagedType.U4)] int dwFlags,
                                                      bool fEnable);

        static void DisableClickSounds()
        {
            CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, true);
        }


        class Win32
        {


            [DllImport("user32.dll")]
            public static extern IntPtr GetFocus();



            public static int WM_RBUTTONDOWN = 0x0204;
            public static int WM_RBUTTONUP = 0x0205;


            public static int WM_TIMER = 0x0113;

            public static int WM_LBUTTONDBLCLK = 0x203;

            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern short GetKeyState(int nVirtKey);


            public static int WM_KEYDOWN = 0x0100;
            public static int WM_KEYUP = 0x0101;


            public static IntPtr HWND_MESSAGE = new IntPtr(-3);


            [DllImport("GDI32.DLL", EntryPoint = "CreateRectRgn")]
            public static extern int CreateRectRgn(int x1, int y1, int x2, int y2);


            [DllImport("user32.DLL", EntryPoint = "SetWindowRgn")]
            public static extern int SetWindowRgn(int hWnd, int hRgn, int bRedraw);



            public enum GWL
            {
                ExStyle = -20
            }

            public enum WS_EX
            {
                Transparent = 0x20,
                Layered = 0x80000
            }

            public enum LWA
            {
                ColorKey = 0x1,
                Alpha = 0x2
            }

            [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
            public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

            [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
            public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

            [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
            public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);




            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);


            [DllImport("user32.dll")]
            public static extern IntPtr LoadCursorFromFile(string lpFileName);

            [DllImport("user32.dll")]
            public static extern IntPtr SetCursor(IntPtr hCursor);

            [DllImport("user32.dll")]
            public static extern bool SetSystemCursor(IntPtr hcur, uint id);

            public const uint OCR_NORMAL = 32512;



            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


            public static int WM_CAPTURECHANGED = 0x0215;


            public static uint WM_EXITSIZEMOVE = 0x232;


            public static uint WM_MOUSEMOVE = 0x0200;
            public static uint WM_LBUTTONDOWN = 0x201;
            public static uint WM_LBUTTONUP = 0x0202;


            public static uint HTCAPTION = 0x2;

            public static uint WM_NCLBUTTONDOWN = 0xA1;
            public static uint WM_NCMOUSEMOVE = 0xA0;


            public static IntPtr MakeLParam(int LoWord, int HiWord)
            {
                return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
            }

            public static int LoWord(IntPtr param)
            {
                return ((int)param & 0xffff);
            }
            public static int HiWord(IntPtr param)
            {
                return (((int)param >> 16) & 0xffff);
            }

            [DllImport("user32.dll")]
            public static extern IntPtr SetCapture(IntPtr hWnd);


            [DllImport("user32.dll")]
            public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, UIntPtr wParam, IntPtr lParam);


            [DllImport("user32.dll")]
            public static extern bool ReleaseCapture();


            public static uint WM_SYSCOMMAND = 0x112;
            public static uint MOUSE_MOVE = 0xF012;



            public static int
                HTLEFT = 10,
                HTRIGHT = 11,
                HTTOP = 12,
                HTTOPLEFT = 13,
                HTTOPRIGHT = 14,
                HTBOTTOM = 15,
                HTBOTTOMLEFT = 16,
                HTBOTTOMRIGHT = 17,
                HTCLIENT = 1;


            public enum MouseMessages
            {
                WM_LBUTTONDOWN = 0x0201,
                WM_LBUTTONUP = 0x0202,
                WM_MOUSEMOVE = 0x0200,
                WM_MOUSEWHEEL = 0x020A,
                WM_RBUTTONDOWN = 0x0204,
                WM_RBUTTONUP = 0x0205,
                WM_LBUTTONDBLCLK = 0x0203,
                WM_MBUTTONDOWN = 0x0207,
                WM_MBUTTONUP = 0x0208
            }

            public static int HTTRANSPARENT = -1;

            public static int WM_MOVING = 0x216;
            public static int WM_ENTERSIZEMOVE = 0x0231;
            public static int WM_SIZE = 0x0005;

            public static int WM_NCHITTEST = 0x84;

            public static int WM_SETCURSOR = 0x20;


        }




        /// <summary>
        /// Managed equivalent of the Win32 <code>RECT</code> structure.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct LtrbRectangle
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public LtrbRectangle(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }

            public static LtrbRectangle FromRectangle(Rectangle rect)
            {
                return new LtrbRectangle(rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
            }

            public override string ToString()
            {
                return "{Left=" + Left + ",Top=" + Top + ",Right=" + Right + ",Bottom=" + Bottom + "}";
            }
        }



        public class MaskPanel : TransparentPanel
        {
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                base.OnPaintBackground(e);
                e.Graphics.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
            }
        }

        public class OpaqueButClickThroughPanel : Panel
        {
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == Win32.WM_NCHITTEST)
                {
                    m.Result = (IntPtr)Win32.HTTRANSPARENT;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
        }

        public class TransparentPanel : Panel
        {

            protected override CreateParams CreateParams
            {
                get
                {
                    if (!Form1.optionDebugShowPanels)
                    {
                        CreateParams cp = base.CreateParams;
                        cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                        return cp;
                    }
                    else return base.CreateParams;
                }
            }
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                //base.OnPaintBackground(e);
                if (Form1.optionDebugShowPanels)
                {
                    base.OnPaintBackground(e);
                    //e.Graphics.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
                }
            }

            public bool clickThrough = false;

            protected override void WndProc(ref Message m)
            {
                if (clickThrough)
                {
                    if (m.Msg == Win32.WM_NCHITTEST)
                    {
                        m.Result = (IntPtr)Win32.HTTRANSPARENT;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
        }


        public enum Spot
        {
            TL, T, TR,
            L, R,
            BL, B, BR
        }


        public class ResizePanel : TransparentPanel
        {
            public Spot mySpot;

            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);

                if (e.Button == MouseButtons.Left) //also check if parent form is maximsed?
                {
                    IntPtr dir = (IntPtr)Win32.HTTOPLEFT;
                    if (mySpot == Spot.TL) dir = (IntPtr)Win32.HTTOPLEFT;
                    if (mySpot == Spot.TR) dir = (IntPtr)Win32.HTTOPRIGHT;
                    if (mySpot == Spot.BL) dir = (IntPtr)Win32.HTBOTTOMLEFT;
                    if (mySpot == Spot.BR) dir = (IntPtr)Win32.HTBOTTOMRIGHT;

                    if (mySpot == Spot.T) dir = (IntPtr)Win32.HTTOP;
                    if (mySpot == Spot.L) dir = (IntPtr)Win32.HTLEFT;
                    if (mySpot == Spot.R) dir = (IntPtr)Win32.HTRIGHT;
                    if (mySpot == Spot.B) dir = (IntPtr)Win32.HTBOTTOM;

                    Win32.ReleaseCapture();
                    Win32.SendMessage(this.FindForm().Handle, Win32.WM_NCLBUTTONDOWN, dir, (IntPtr)0);
                }
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (mySpot == Spot.TL) this.Cursor = Cursors.SizeNWSE;
                if (mySpot == Spot.BR) this.Cursor = Cursors.SizeNWSE;
                if (mySpot == Spot.TR) this.Cursor = Cursors.SizeNESW;
                if (mySpot == Spot.BL) this.Cursor = Cursors.SizeNESW;

                if (mySpot == Spot.T) this.Cursor = Cursors.SizeNS;
                if (mySpot == Spot.B) this.Cursor = Cursors.SizeNS;
                if (mySpot == Spot.L) this.Cursor = Cursors.SizeWE;
                if (mySpot == Spot.R) this.Cursor = Cursors.SizeWE;

                // these two should also go together..

                // disable vid from flickering our mouse cursor
                ((Control)((Form1)FindForm()).webBrowser1).Enabled = false;

                // enable hitbox for turning vid back on
                ((Form1)FindForm()).checkIfDoneResizingPanel.BringToFront();
            }
        }



        void SetupResizeArea(ResizePanel resizePanel, Spot resizeSpot)
        {

            int pad = RESIZE_PAD;
            Rectangle thisBounds = new Rectangle(0, 0, pad, pad); // shouldnt ever be used
            if (resizeSpot == Spot.TL) thisBounds = new Rectangle(0, 0, pad, pad);
            if (resizeSpot == Spot.TR) thisBounds = new Rectangle(this.ClientSize.Width - pad, 0, pad, pad);
            if (resizeSpot == Spot.BL) thisBounds = new Rectangle(0, this.ClientSize.Height - pad, pad, pad);
            if (resizeSpot == Spot.BR) thisBounds = new Rectangle(this.ClientSize.Width - pad, this.ClientSize.Height - pad, pad, pad);

            if (resizeSpot == Spot.L) thisBounds = new Rectangle(0, pad, pad, this.ClientSize.Height - pad * 2);
            if (resizeSpot == Spot.R) thisBounds = new Rectangle(this.ClientSize.Width - pad, pad, pad, this.ClientSize.Height - pad * 2);
            if (resizeSpot == Spot.T) thisBounds = new Rectangle(pad, 0, this.ClientSize.Width - pad * 2, pad);
            if (resizeSpot == Spot.B) thisBounds = new Rectangle(pad, this.ClientSize.Height - pad, this.ClientSize.Width - pad * 2, pad);

            AnchorStyles anchor = AnchorStyles.None;
            if (resizeSpot == Spot.TL) anchor = AnchorStyles.Top | AnchorStyles.Left;
            if (resizeSpot == Spot.TR) anchor = AnchorStyles.Top | AnchorStyles.Right;
            if (resizeSpot == Spot.BL) anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            if (resizeSpot == Spot.BR) anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            if (resizeSpot == Spot.T) anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            if (resizeSpot == Spot.B) anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            if (resizeSpot == Spot.L) anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            if (resizeSpot == Spot.R) anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            //// debug anchors..
            //if (resizeSpot == Spot.TL || resizeSpot == Spot.L || resizeSpot == Spot.BL) anchor = anchor | AnchorStyles.Left;
            //if (resizeSpot == Spot.TR || resizeSpot == Spot.R || resizeSpot == Spot.BR) anchor = anchor | AnchorStyles.Right;
            //if (resizeSpot == Spot.TL || resizeSpot == Spot.T || resizeSpot == Spot.TR) anchor = anchor | AnchorStyles.Top;
            //if (resizeSpot == Spot.BL || resizeSpot == Spot.B || resizeSpot == Spot.BR) anchor = anchor | AnchorStyles.Bottom;

            Color debugColor = Color.MediumOrchid;
            if (resizeSpot == Spot.L || resizeSpot == Spot.R || resizeSpot == Spot.T || resizeSpot == Spot.B)
                debugColor = Color.Coral;

            resizePanel = new ResizePanel();
            resizePanel.Bounds = thisBounds;
            resizePanel.Anchor = anchor;
            resizePanel.BackColor = debugColor;
            this.Controls.Add(resizePanel);
            resizePanel.BringToFront();
            resizePanel.mySpot = resizeSpot;
        }




        static bool optionDebugShowPanels = false;

        static bool optionAllowJSErrors = false;


        static bool optionRandomStartVid = false;
        static bool optionNoStartVid = false;


        static bool optionLockRatio = false;

        static bool optionAlwaysOnTop = false; // since there is no launch option to disable yet, just default to off

        static bool optionGhostMode = false;

        static double optionOpacity = 0.7;

        static int optionStartWidth = 640;
        static int optionStartHeight = 360;  //16:9


        static string optionStartVidURL = String.Empty;




        ResizePanel resizeTL;
        ResizePanel resizeTR;
        ResizePanel resizeBL;
        ResizePanel resizeBR;
        ResizePanel resizeT;
        ResizePanel resizeB;
        ResizePanel resizeL;
        ResizePanel resizeR;



        // should be const but tired of these unreachable code warnings
        static int RESIZE_PAD = 7;        // how big are our resize handles?
        static int RESIZE_OVERFLOW = 0;   // how many pixels do the the resize controls pass outside the video rect?
        // EX_TRANSPARENT seems to be a bit buggy, not using overflow for now


        public TransparentPanel checkIfDoneResizingPanel;


        public void checkIfDoneResizingPanel_MouseMove(object sender, EventArgs e)
        {
            EnableWebHideResizePanel();
        }

        void EnableWebHideResizePanel()
        {
            // these two should always go together
            ((Control)webBrowser1).Enabled = true;
            checkIfDoneResizingPanel.SendToBack();
        }



        WebBrowser webBrowser1;

        void CreateCompletelyNewWebBrowserObject()
        {
            // Console.WriteLine("creating web brow, allowing nav");
            // allowNavigation = true;


            if (webBrowser1 != null)
            {
                webBrowser1.Dispose();
            }


            webBrowser1 = new WebBrowser();
            webBrowser1.Dock = DockStyle.Fill;
            this.Controls.Add(webBrowser1);
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);


            //webBrowser1.Dock = DockStyle.Fill;
            webBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;


            Rectangle shrinkForResize = this.ClientRectangle; // webBrowser1.Bounds;
            if (RESIZE_OVERFLOW != 0)
                shrinkForResize.Inflate(-RESIZE_OVERFLOW, -RESIZE_OVERFLOW); // don't shrink fully, allowing some resize grab outside of video area
            webBrowser1.Bounds = shrinkForResize;



            if (!optionAllowJSErrors)
                webBrowser1.ScriptErrorsSuppressed = true;
        }



        Icon thisIcon;



        void SetOptionsBasedOnCommandLineArguments()
        {
            string[] args = System.Environment.GetCommandLineArgs();

            foreach (string arg in args)
            {
                if (arg.StartsWith("-o"))
                {
                    int val;
                    if (int.TryParse(arg.TrimStart('-', 'o'), out val))
                    {
                        optionOpacity = (double)val / 100.0;
                    }
                }
                else if (arg.StartsWith("-w"))
                {
                    int val;
                    if (int.TryParse(arg.TrimStart('-', 'w'), out val))
                    {
                        optionStartWidth = val;
                    }
                }
                else if (arg.StartsWith("-h"))
                {
                    int val;
                    if (int.TryParse(arg.TrimStart('-', 'h'), out val))
                    {
                        optionStartHeight = val;
                    }
                }
                else if (arg == "-lock" || arg == "-lar") optionLockRatio = true;
                else if (arg == "-top" || arg == "-aot" || arg == "-t") optionAlwaysOnTop = true;
                else if (arg == "-ghost" || arg == "-gm") optionGhostMode = true;
                else if (arg == "-debug" || arg == "-colors" || arg == "-hitboxes" || arg == "-panels") optionDebugShowPanels = true;
                else if (arg == "-debug" || arg == "-errors" || arg == "-js") optionAllowJSErrors = true;
                else if (arg == "-novid" || arg == "-blank") optionNoStartVid = true;
                //   else if (arg == "-random" || arg == "-imfeelinglucky") optionRandomStartVid = true;  // not supported yet, method used was too slow
                // else if (arg == "-help" || arg == "-?" || arg == "/?") { Console.WriteLine(helpText); }  // now handled in program.cs
                else if (GetVideoId(arg) != "") { optionStartVidURL = arg; }
                else Console.WriteLine("argument: " + arg + " not recognized, bad switch or url?");
            }

        }


        // TODO:
        // [ ] idea for getting time? (from old notes)
                //ytplayer = document.getElementById("movie_player");
                //ytplayer.getCurrentTime();
        // [/]double left click maximize (sort of works now)
        // [x]lock aspect ratio
        // [x]starting location and size parameters
        // [-]X to close button appears in top right? (or maybe just custom right click menu with an exit)
        // [ ]dragging from full screen is broken (by snapping code i think --erp maybe not)
        // [?]do contorls hide better on the old version?
        // [x]our own right click menu?
        //   [ ]get current time fom api possible? (need postmessage! ;_;)
        //   [ ]autoplay next recomendation option
        //   [ ]loop same video option
        //   [x]two right clicks on video are sort of broken

        public Form1()
        {
            InitializeComponent();



            SetOptionsBasedOnCommandLineArguments();





            DisableClickSounds();


            // WebBrowser.CheckForIllegalCrossThreadCalls = true;





            // could use a timer like this for other things?
            recentDoubleClickTimer = new Timer();
            recentDoubleClickTimer.Interval = recentDoubleClickTick;
            recentDoubleClickTimer.Tick += new EventHandler(recentDoubleClickTimer_Tick);





            thisIcon = GetRandomIcon();
            this.Icon = thisIcon;
            //this.Icon = Icon.FromHandle(Properties.Resources.icon.GetHicon());



            int pad = RESIZE_PAD;
            checkIfDoneResizingPanel = new TransparentPanel();
            checkIfDoneResizingPanel.Bounds = new Rectangle(pad, pad, this.ClientSize.Width - pad * 2, this.ClientSize.Height - pad * 2);
            checkIfDoneResizingPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            checkIfDoneResizingPanel.BackColor = Color.LemonChiffon;
            this.Controls.Add(checkIfDoneResizingPanel);
            checkIfDoneResizingPanel.BringToFront();
            checkIfDoneResizingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkIfDoneResizingPanel_MouseMove);

            // also handle drag drop on this panel
            checkIfDoneResizingPanel.AllowDrop = true;
            checkIfDoneResizingPanel.DragOver += new DragEventHandler(checkIfDoneResizingPanel_DragOver);
            checkIfDoneResizingPanel.DragDrop += new DragEventHandler(checkIfDoneResizingPanel_DragDrop);




            // borders are on top so create last..

            SetupResizeArea(resizeTL, Spot.TL);
            SetupResizeArea(resizeTR, Spot.TR);
            SetupResizeArea(resizeBL, Spot.BL);
            SetupResizeArea(resizeBR, Spot.BR);
            SetupResizeArea(resizeT, Spot.T);
            SetupResizeArea(resizeB, Spot.B);
            SetupResizeArea(resizeL, Spot.L);
            SetupResizeArea(resizeR, Spot.R);


            // mask out the resize panels overflowing behond the vid
            if (RESIZE_OVERFLOW > 0)
            {
                mL = new MaskPanel();
                mR = new MaskPanel();
                mT = new MaskPanel();
                mB = new MaskPanel();
                mL.Bounds = new Rectangle(0, 0, RESIZE_OVERFLOW, this.ClientSize.Height);
                mR.Bounds = new Rectangle(this.ClientSize.Width - RESIZE_OVERFLOW, 0, RESIZE_OVERFLOW, this.ClientSize.Height);
                mT.Bounds = new Rectangle(RESIZE_OVERFLOW, 0, this.ClientSize.Width - RESIZE_OVERFLOW * 2, RESIZE_OVERFLOW);
                mB.Bounds = new Rectangle(RESIZE_OVERFLOW, this.ClientSize.Height - RESIZE_OVERFLOW, this.ClientSize.Width - RESIZE_OVERFLOW * 2, RESIZE_OVERFLOW);
                mL.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
                mR.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                mT.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                mB.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                mL.BackColor = Color.SeaGreen;
                mR.BackColor = Color.SeaGreen;
                mT.BackColor = Color.SeaGreen;
                mB.BackColor = Color.SeaGreen;
                this.Controls.Add(mL);
                this.Controls.Add(mR);
                this.Controls.Add(mT);
                this.Controls.Add(mB);
                mL.clickThrough = true;
                mR.clickThrough = true;
                mT.clickThrough = true;
                mB.clickThrough = true;
                mL.BringToFront();
                mR.BringToFront();
                mT.BringToFront();
                mB.BringToFront();

                if (!Form1.optionDebugShowPanels)
                {
                    this.TransparencyKey = Color.SeaGreen;
                }
            }





            this.FormBorderStyle = FormBorderStyle.None;




            this.MinimumSize = new Size(50, 50); // good amount or no? decrese if we allow grab to move on play button etc

            this.Opacity = optionOpacity;

            // bug here? (dont now at bottom)
            this.TopMost = optionAlwaysOnTop;

            if (Form1.optionGhostMode)
            {
                // do after setting othe form options above since they can override thid
                EnableGhostMode();
            }





            SetBrowserFeatureControl();

            CreateCompletelyNewWebBrowserObject();





            if (optionNoStartVid)
            {
                SetNoVideo();

                if (optionRandomStartVid)
                    Console.WriteLine("no video option overriding random start video option");

                if (optionStartVidURL != "")
                    Console.WriteLine("no video option overriding specified url video");
            }
            else
            {
                if (optionStartVidURL != "")
                {
                    SetVidByURL(optionStartVidURL);

                    if (optionRandomStartVid)
                        Console.WriteLine("passing in video url overriding random video option");
                }
                else
                {
                    if (optionRandomStartVid)
                    {
                        SetVidById(LookForValidRandomId()); // risky amirite!
                    }
                    else
                    {
                        SetVidById(GetRandomDefaultId());
                    }
                }
            }




            SetupTaskbarMenu();



            textOverlay = new Plexiglass(this);


            Width = optionStartWidth;
            Height = optionStartHeight;


            // seems like doing last is necessary
            this.TopMost = optionAlwaysOnTop;

        }

        //async Task<string> LookForValidRandomId()
        //{
        //    for (int i = 0; i < 100; i++) // this can be pretty slow!
        //    {
        //        string testId = RandomId();
        //        await Task.Delay(80);
        //        if (GetTitle(testId) != "")
        //        {
        //            return testId;
        //        }
        //    }
        //    return RandomId(); //none found, this probably wont be valid either
        //}
        string LookForValidRandomId()
        {
            for (int i = 0; i < 5; i++) // this can be pretty slow!
            {
                string testId = RandomId();
                if (GetTitle(testId) != "")
                {
                    return testId;
                }
            }
            return RandomId(); //none found, this probably wont be valid either
        }

        string RandomId()
        {
            string result = "";
            Random rand = new Random();
            string validChars = "_-0987654321qwertyuiopsadfghjklzxcvbnmQWERTYUIOPSADFGHJKLZXCVBNM";
            for (int i = 0; i < 11; i++)
            {
                int r = rand.Next(0, validChars.Length);
                result = result + validChars[r];
            }
            Console.WriteLine("random video:" + result);
            return result;
        }

        Plexiglass textOverlay;

        MaskPanel mL;
        MaskPanel mR;
        MaskPanel mT;
        MaskPanel mB;


        // ----


        // could use something like this to handle drag drop to...

        class Plexiglass : Form
        {
            public Plexiglass(Form tocover)
            {
                this.BackColor = Color.Gray;
                this.Opacity = 0.0;      // Tweak as desired
                this.FormBorderStyle = FormBorderStyle.None;
                this.ControlBox = false;
                this.ShowInTaskbar = false;
                this.StartPosition = FormStartPosition.Manual;
                this.AutoScaleMode = AutoScaleMode.None;
                this.Location = tocover.PointToScreen(Point.Empty);
                this.ClientSize = tocover.ClientSize;
                tocover.LocationChanged += Cover_LocationChanged;
                tocover.ClientSizeChanged += Cover_ClientSizeChanged;
                this.Show(tocover);
                tocover.Focus();
                // Disable Aero transitions, the plexiglass gets too visible
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    int value = 1;
                    DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
                }

                //  this.TransparencyKey = Color.WhiteSmoke;

                label1 = new ClickThroughLabel();
                label1.Dock = DockStyle.Fill;
                label1.Text = "";
                label1.ForeColor = Color.White;
                label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label1.Font = new Font("Segoe UI", 21, FontStyle.Regular); // Segoe UI Lucida Console Euphemia Estrangelo Edessa
                //label1.Font = new Font("Lucida Console", 12, FontStyle.Regular); // Segoe UI Lucida Console Euphemia Estrangelo Edessa
                //label1.Font = new Font("Euphemia", 18, FontStyle.Italic); // Segoe UI Lucida Console Euphemia Estrangelo Edessa
                //label1.Font = new Font("Euphemia", 18, FontStyle.Regular); // Segoe UI Lucida Console Euphemia Estrangelo Edessa
                //label1.Font = new Font("Estrangelo Edessa", 24, FontStyle.Italic); // Segoe UI Lucida Console Euphemia Estrangelo Edessa
                label1.BackColor = System.Drawing.Color.Transparent;
                this.Controls.Add(label1);
            }
            private void Cover_LocationChanged(object sender, EventArgs e)
            {
                // Ensure the plexiglass follows the owner
                this.Location = this.Owner.PointToScreen(Point.Empty);
            }
            private void Cover_ClientSizeChanged(object sender, EventArgs e)
            {
                // Ensure the plexiglass keeps the owner covered
                this.ClientSize = this.Owner.ClientSize;
            }
            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                // Restore owner
                this.Owner.LocationChanged -= Cover_LocationChanged;
                this.Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
                if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
                {
                    int value = 1;
                    DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
                }
                base.OnFormClosing(e);
            }
            protected override void OnActivated(EventArgs e)
            {
                // Always keep the owner activated instead
                this.BeginInvoke(new Action(() => this.Owner.Activate()));
            }
            private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
            [DllImport("dwmapi.dll")]
            private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);


            ClickThroughLabel label1;


            /// <summary>TimeBeginPeriod(). See the Windows API documentation for details.</summary>

            [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod", SetLastError = true)]
            public static extern uint TimeBeginPeriod(uint uMilliseconds);

            /// <summary>TimeEndPeriod(). See the Windows API documentation for details.</summary>

            [DllImport("winmm.dll", EntryPoint = "timeEndPeriod", SetLastError = true)]
            public static extern uint TimeEndPeriod(uint uMilliseconds);


            public async void DisplayTextForABit(string msg, int interval = 16)
            {
                // if (this.Opacity != 0.0) return; // dont have more than one thing going?

                //  Console.WriteLine("once!");

                string spacedMsg = msg.Aggregate(string.Empty, (c, i) => c + i + ' ');
                label1.Text = spacedMsg.TrimEnd(' ');

                this.Opacity = 0.50;

                double decaySpeed = 0.15 / interval;

                TimeBeginPeriod(1);// necessary?

                // slow fade out
                while (this.Opacity > 0.0)
                {
                    await Task.Delay(interval);

                    this.Opacity -= decaySpeed;

                    //Console.WriteLine(this.Opacity);
                }
                Form1.allowAnotherFade = true;
                this.Opacity = 0.0; //make fully invisible 
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == Win32.WM_NCHITTEST)
                {
                    m.Result = (IntPtr)Win32.HTTRANSPARENT;
                    return;
                }
                base.WndProc(ref m);
            }

        }

        static bool allowAnotherFade = true;

        class ClickThroughLabel : Label
        {
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == Win32.WM_NCHITTEST)
                {
                    m.Result = (IntPtr)Win32.HTTRANSPARENT;
                    return;
                }
                base.WndProc(ref m);
            }
        }

        // ----

        TextPanel overlayText;
        class TextPanel : TransparentPanel
        {
            string text = "";
            public void DisplayText(string newText)
            {
                text = newText;
            }
            protected override void OnPaintBackground(PaintEventArgs e)
            {
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                this.BringToFront();

                //base.OnPaint(e);

                // Call the OnPaint method of the base class.
                //   base.OnPaint(e);
                // Call methods of the System.Drawing.Graphics object.
                //  e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);
                //    e.Graphics.DrawString(text, new Font("Arial", 20), new SolidBrush(Color.FromArgb(256, Color.Red)), 0, 0);

                string drawString = text ?? "Value";
                Font drawFont = new Font("Segoe UI", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                Rectangle rect1 = new Rectangle(0, 0, Width, Height);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(drawString, drawFont, drawBrush, rect1, stringFormat);
                drawFont.Dispose();
                drawBrush.Dispose();


            }
        }


        // ----

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenu1;
        private IContainer components2;

        ToolStripMenuItem menuExit;
        ToolStripMenuItem menuGoto;
        ToolStripMenuItem menuGhost;
        ToolStripMenuItem menuOnTop;
        ToolStripMenuItem menuLockRatio;
        ToolStripMenuItem menuSetIcon;
        ToolStripMenuItem menuCopy;
        ToolStripMenuItem menuReload;
        ToolStripMenuItem menuFullscreen;

        TrackBarMenuItem menuOpacity;


        bool contextMenuOpened = false;
        private async void contextMenu1_Close(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //Console.WriteLine("closed");

            await Task.Delay(100);
            contextMenuOpened = false;
        }
        private void contextMenu1_Open(object sender, EventArgs e)
        {
            contextMenuOpened = true;
           // Console.WriteLine("opened");
        }

        void SetupTaskbarMenu()
        {

            components2 = new Container();
            contextMenu1 = new ContextMenuStrip();


            contextMenu1.Closed += new ToolStripDropDownClosedEventHandler(contextMenu1_Close);
            contextMenu1.Opened += new EventHandler(contextMenu1_Open);


            menuFullscreen = new ToolStripMenuItem();
            menuFullscreen.Text = "&Fullscreen";
            menuFullscreen.Click += new EventHandler(this.menuFullscreen_Click);
            menuFullscreen.Checked = false;
            contextMenu1.Items.Add(menuFullscreen);
            


            menuReload = new ToolStripMenuItem();
            menuReload.Text = "&Reload Video";
            menuReload.Click += new EventHandler(this.menuReload_Click);
            menuReload.Checked = false;
            contextMenu1.Items.Add(menuReload);



            menuCopy = new ToolStripMenuItem();
            menuCopy.Text = "&Copy URL (No Time Yet)";
            menuCopy.Click += new EventHandler(this.menuCopy_Click);
            contextMenu1.Items.Add(menuCopy);


            menuGoto = new ToolStripMenuItem();
            menuGoto.Text = "&Paste Clipboard URL";
            menuGoto.Click += new EventHandler(this.menuGoto_Click);
            menuGoto.Checked = false;
            contextMenu1.Items.Add(menuGoto);


          //  contextMenu1.Items.Add(new ToolStripSeparator());


            contextMenu1.Items.Add(new ToolStripSeparator());
        




            menuSetIcon = new ToolStripMenuItem();
            menuSetIcon.Text = "Choose &Icon";
            menuSetIcon.DropDownItems.Add("Blinky", Properties.Resources.r1, new EventHandler((sender, e) => setIcon_Click(sender, e, "Blinky")));
            menuSetIcon.DropDownItems.Add("Pinky", Properties.Resources.p1, new EventHandler((sender, e) => setIcon_Click(sender, e, "Pinky")));
            menuSetIcon.DropDownItems.Add("Inky", Properties.Resources.c1, new EventHandler((sender, e) => setIcon_Click(sender, e, "Inky")));
            menuSetIcon.DropDownItems.Add("Clyde", Properties.Resources.y1, new EventHandler((sender, e) => setIcon_Click(sender, e, "Clyde")));
            contextMenu1.Items.Add(menuSetIcon);




            menuOpacity = new TrackBarMenuItem();
            menuOpacity.Label = "Opacity";
            menuOpacity.ValueChanged += new EventHandler(this.menuOpacity_ValueChanged);
            menuOpacity.TickFrequency = 1;
            menuOpacity.Minimum = 0;
            menuOpacity.Maximum = 100;
            menuOpacity.Value = (int)(optionOpacity * 100);
            contextMenu1.Items.Add(menuOpacity);




            menuLockRatio = new ToolStripMenuItem();
            menuLockRatio.Text = "Lock &Aspect Ratio";
            menuLockRatio.Click += new EventHandler(this.menuLockRatio_Click);
            menuLockRatio.Checked = optionLockRatio;
            contextMenu1.Items.Add(menuLockRatio);

            menuOnTop = new ToolStripMenuItem();
            menuOnTop.Text = "Always On &Top";
            menuOnTop.Click += new EventHandler(this.menuOnTop_Click);
            menuOnTop.Checked = optionAlwaysOnTop;
            contextMenu1.Items.Add(menuOnTop);


            menuGhost = new ToolStripMenuItem();
            menuGhost.Text = "&Ghost Mode";
            menuGhost.Click += new EventHandler(this.menuGhost_Click);
            menuGhost.Checked = optionGhostMode;
            contextMenu1.Items.Add(menuGhost);


            contextMenu1.Items.Add(new ToolStripSeparator());

            menuExit = new ToolStripMenuItem();
            menuExit.Text = "E&xit";
            menuExit.Click += new EventHandler(this.menuExit_Click);
            menuExit.Checked = false;
            contextMenu1.Items.Add(menuExit);



            // Create the NotifyIcon.
            this.notifyIcon1 = new NotifyIcon(this.components2);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon1.Icon = thisIcon;//  GetRandomIcon();// Properties.Resources.Icon1;

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon1.ContextMenuStrip = this.contextMenu1;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            UpdateVideoName();
            //string popupName = GetTitle(rememberOurVidID);
            //if (popupName == "") popupName = "Ghost Vision";
            //notifyIcon1.Text = popupName;
            notifyIcon1.Visible = true;

            notifyIcon1.DoubleClick += new EventHandler(this.notifyIcon1_DoubleClick);
            notifyIcon1.MouseUp += new MouseEventHandler(this.notifyIcon1_MouseUp);
        }


        void UpdateVideoName()
        {
            string popupName = GetTitle(rememberOurVidID);
            if (popupName == "") popupName = "Ghost Vision [no video]"; //no video";

            if (notifyIcon1 != null)
            {
                if (popupName.Length <= 63)
                    notifyIcon1.Text = popupName;
                else
                    notifyIcon1.Text = popupName.Substring(0, Math.Min(popupName.Length, 63));
            }

            this.Text = popupName;
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {

            // toggle ghost mode on left click...
            if (e.Button == MouseButtons.Left)
            {
                menuGhost_Click(sender, e);
            }

            //// show whole menu on left click....
            //if (e.Button == MouseButtons.Left)
            //{
            //    MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            //    mi.Invoke(notifyIcon1, null);
            //}
        }
        private void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.
            this.Activate();
        }

        
        private void menuFullscreen_Click(object Sender, EventArgs e)
        {
            ToggleFullscreen();
        }
        private void ToggleFullscreen()
        {
            ToggleFullScreen2();  // no idea why this is eneded
        }

        private void menuReload_Click(object Sender, EventArgs e)
        {
            SetVidById(rememberOurVidID);
        }
        private void menuCopy_Click(object Sender, EventArgs e)
        {
           // MessageBox.Show("Not supported yet.\nNeed postmessage workaround to use yt api\nor time the video ourselves and hope for sync!");

            System.Windows.Forms.Clipboard.SetText(@"http://www.youtube.com/watch?v=" + rememberOurVidID);


            ////webBrowser1.Document.InvokeScript("setCachedTime");
            ////string time = webBrowser1.Document.InvokeScript("eval", new object[] { "cachedTime" }).ToString();

            //string startSeconds = "";

            //string timeVar = webBrowser1.Document.InvokeScript("testFunc").ToString();
            ////var timeVar = webBrowser1.Document.InvokeScript("eval", new object[] { "player.getCurrentTime()" });
            ////var timeVar = webBrowser1.Document.InvokeScript("player.getCurrentTime()");
            //if (timeVar == null)
            //{
            //    Console.WriteLine("error getting current time of video");
            //    startSeconds = "";
            //}
            //else
            //{
            //    startSeconds = timeVar.ToString();
            //}

            //MessageBox.Show(startSeconds);
        }
        private void menuOpacity_ValueChanged(object Sender, EventArgs e)
        {
            optionOpacity = menuOpacity.Value;
            //Console.WriteLine("new opacity:" + optionOpacity);

            // reset opacity by calling whatever ghost mode we are already in
            if (optionGhostMode)
            {
                if (optionOpacity == 100)
                    optionOpacity = 99; // little hack to avoid ghost + 100 opac = invisible
                EnableGhostMode();
            }
            else
            {
                DisableGhostMode();
            }
        }

        private void menuLockRatio_Click(object Sender, EventArgs e)
        {
            if (!menuLockRatio.Checked)
                EnableLockedAspectRatio();
            else
                DisableLockedAspectRatio();
        }
        private void menuOnTop_Click(object Sender, EventArgs e)
        {
            if (!menuOnTop.Checked)
                EnableAlwaysOnTop();
            else
                DisableAlwaysOnTop();
        }
        private void menuGhost_Click(object Sender, EventArgs e)
        {
            if (!menuGhost.Checked)
                EnableGhostMode();
            else
                DisableGhostMode();
        }
        private void menuGoto_Click(object Sender, EventArgs e)
        {
            string clipboardString = "";
            if (Clipboard.ContainsText())
                clipboardString = Clipboard.GetText();
            else
                textOverlay.DisplayTextForABit("no url");
            if (clipboardString != "")
                SetVidByURL(clipboardString);
        }
        private void menuExit_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.Close();
        }

        private void setIcon_Click(object Sender, EventArgs e, string ghost)
        {
            Random rand = new Random();
            int dir = rand.Next(1, 5);

            Bitmap bmp = Properties.Resources.zzb;
            if (ghost == "Blinky")
            {
                if (dir == 1) bmp = Properties.Resources.r1;
                if (dir == 2) bmp = Properties.Resources.r2;
                if (dir == 3) bmp = Properties.Resources.r3;
                if (dir == 4) bmp = Properties.Resources.r4;
            }
            if (ghost == "Pinky")
            {
                if (dir == 1) bmp = Properties.Resources.p1;
                if (dir == 2) bmp = Properties.Resources.p2;
                if (dir == 3) bmp = Properties.Resources.p3;
                if (dir == 4) bmp = Properties.Resources.p4;
            }
            if (ghost == "Inky")
            {
                if (dir == 1) bmp = Properties.Resources.c1;
                if (dir == 2) bmp = Properties.Resources.c2;
                if (dir == 3) bmp = Properties.Resources.c3;
                if (dir == 4) bmp = Properties.Resources.c4;
            }
            if (ghost == "Clyde")
            {
                if (dir == 1) bmp = Properties.Resources.y1;
                if (dir == 2) bmp = Properties.Resources.y2;
                if (dir == 3) bmp = Properties.Resources.y3;
                if (dir == 4) bmp = Properties.Resources.y4;
            }
            thisIcon = Icon.FromHandle(bmp.GetHicon());
            notifyIcon1.Icon = thisIcon;
            this.Icon = thisIcon;
        }







        void EnableAlwaysOnTop()
        {
            if (menuOnTop != null) menuOnTop.Checked = true;
            optionAlwaysOnTop = true;
            TopMost = true;
        }
        void DisableAlwaysOnTop()
        {
            if (menuOnTop != null) menuOnTop.Checked = false;
            optionAlwaysOnTop = false;
            TopMost = false;
        }




        void EnableGhostMode()
        {
            if (menuGhost != null) menuGhost.Checked = true;
            optionGhostMode = true;

            // set ghost icon
            Bitmap bmp = Properties.Resources.zzw;
            notifyIcon1.Icon = Icon.FromHandle(bmp.GetHicon());
            this.Icon = Icon.FromHandle(bmp.GetHicon());


            int wl = Win32.GetWindowLong(this.Handle, Win32.GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;  // WS_EX_LAYERED and WS_EX_TRANSPARENT
            Win32.SetWindowLong(this.Handle, Win32.GWL.ExStyle, wl);
            Win32.SetLayeredWindowAttributes(this.Handle, 0, (byte)(256.0 * (optionOpacity / 100.0)), Win32.LWA.Alpha);

            // we never disable this so once we go here we perm limit our region
            // just drop it for now since i think it was to fix a bug with resize overflow which we aren't using
            //// since we can't move the window in this mode (i think? on keyboard method or anything right?)
            //// we can just set the region to disable the resize overflow area
            //int over = RESIZE_OVERFLOW;
            //int region = Win32.CreateRectRgn(over, over, (this.ClientSize.Width - over), (this.ClientSize.Height - over));
            //Win32.SetWindowRgn((int)this.Handle, region, 1);
        }

        void DisableGhostMode()
        {
            if (menuGhost != null) menuGhost.Checked = false;
            optionGhostMode = false;

            // set back to regular icon
            if (thisIcon != null && notifyIcon1 != null)
            {
                this.Icon = thisIcon;
                notifyIcon1.Icon = thisIcon;
            }

            this.FormBorderStyle = FormBorderStyle.None;

           // this.MinimumSize = new Size(50, 50); // good amount or no? decrese if we allow grab to move on play button etc

            double newOpacity = (double)optionOpacity / 100.0;
            if (newOpacity <= 0) newOpacity = 0.01;
            this.Opacity = newOpacity;
        }



        WbInternal wb;

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Document.Body.InnerHtml != null)
            {

                if (webBrowser1.Document.Body.InnerHtml.StartsWith("<h3></h3>"))
                {
                    Console.WriteLine("done loading valid site (either blank or vid)");
                    //blackoutPanel.SendToBack();
                    //((Control)webBrowser1).Enabled = true;
                    // captionPanel.SendToBack();
                }
                else
                {
                    // not valid site, reload a different one?
                    SetNoVideo();
                    //if (!optionAllowAnySite)
                    //{
                    //    Console.WriteLine("done loading invalid site, redirecting to valid empty page");
                    //    SetNoVideo();
                    //    //SetVidById("1234567890_");
                    //    //SetVidById("OJpQgSZ49tk");
                    //    //((Control)webBrowser1).Enabled = true;
                    //    textOverlay.DisplayTextForABit("invalid url");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("done loading invalid site, options allow it");
                    //    blackoutPanel.SendToBack();
                    //    //((Control)webBrowser1).Enabled = true;
                    //}
                }


                //webBrowser1.PreviewKeyDown += new PreviewKeyDownEventHandler(wb_PreviewKeyDown);
                //webBrowser1.Document.Body.KeyUp += new HtmlElementEventHandler(wb_KeyUp);


                webBrowser1.AllowWebBrowserDrop = true;

                webBrowser1.Navigating += new WebBrowserNavigatingEventHandler(webBrowser1_BeforeNavigate);



                IntPtr wbHandle = Win32.FindWindowEx(webBrowser1.Handle, IntPtr.Zero, "Shell Embedding", IntPtr.Zero);
                wbHandle = Win32.FindWindowEx(wbHandle, IntPtr.Zero, "Shell DocObject View", IntPtr.Zero);
                wbHandle = Win32.FindWindowEx(wbHandle, IntPtr.Zero, "Internet Explorer_Server", IntPtr.Zero);
                wb = new WbInternal(wbHandle);
                wb.parentForm = this;
            }
        }


        // much better drag drop behavior...
        // now we reject all urls except embedded yt (the requests the api makes i think)
        // and forward any valid yt urls to our own vidset (canceling the nav in this case too)
        //
        // another idea to do drag drop is have a dragdrop panel always on top 
        // (show when mouseleave etc, like resizepanel)
        // then hide it right away if mouse1 is up (not dragging)
        private void webBrowser1_BeforeNavigate(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.ToString();

            Console.WriteLine("naving to " + url);

            // cancel any "valid" youtube links... (our embedded links should go through)
            if (GetVideoId(url) != "")
            {
                e.Cancel = true;
                SetVidByURL(url); // set by url to use any start time as well
            }
            else if (!url.StartsWith("https://www.youtube.com/embed/") && url != "about:blank")
            {
                e.Cancel = true;
                if (allowAnotherFade)
                {
                    allowAnotherFade = false;
                    textOverlay.DisplayTextForABit("invalid url");
                }
            }


        }

        void checkIfDoneResizingPanel_DragDrop(object sender, DragEventArgs e)
        {
            // just in case someone is fast enough for this, or dragover is never called or whatever..
            string stringData = e.Data.GetData(typeof(string)) as string;
            Console.WriteLine("dragdrop: " + stringData);
            SetVidByURL(stringData);
        }

        void checkIfDoneResizingPanel_DragOver(object sender, DragEventArgs e)
        {
            // coudl just find an effect that matches when draging over video
            // but why not just hide this and have all the drag drop handled the same
            e.Effect = DragDropEffects.All;
            EnableWebHideResizePanel();
        }



        // ----


        bool hasMouseCapture = false;

        protected override void WndProc(ref Message m)
        {
            //Console.WriteLine(m);

            if (m.Msg == Win32.WM_CAPTURECHANGED)
            {
                if (m.LParam == this.Handle)
                {
                    // Console.WriteLine("form got cap, probable mdown");
                    hasMouseCapture = true;
                }
                else if (m.LParam == (IntPtr)0)
                {
                    // Console.WriteLine("cap set to 0.. potential mup");

                    if (hasMouseCapture)
                    {
                        OnlyOnMouseUpAMIRITE();
                    }

                    hasMouseCapture = false;

                }
                else
                {
                    //Console.WriteLine("not sure what got cap...");
                    hasMouseCapture = false;
                }
            }

            if (m.Msg == Win32.WM_ENTERSIZEMOVE || m.Msg == Win32.WM_SIZE)
            {
                _dragOffsetX = Cursor.Position.X - Left;
                _dragOffsetY = Cursor.Position.Y - Top;
            }

            if (m.Msg == Win32.WM_MOVING)
            {
                //LtrbRectangle boundsLtrb = Marshal.PtrToStructure<LtrbRectangle>(m.LParam);  // vs 2015, was it a newer .net?
                LtrbRectangle boundsLtrb = (LtrbRectangle)Marshal.PtrToStructure(m.LParam, typeof(LtrbRectangle));
                Rectangle bounds = boundsLtrb.ToRectangle();
                // This is where the window _would_ be located if snapping
                // had not occurred. This prevents the cursor from sliding
                // off the title bar if the snap distance is too large.
                Rectangle effectiveBounds = new Rectangle(
                    Cursor.Position.X - _dragOffsetX,
                    Cursor.Position.Y - _dragOffsetY,
                    bounds.Width,
                    bounds.Height);
                _snapAnchor = FindSnap(ref effectiveBounds);
                LtrbRectangle newLtrb = LtrbRectangle.FromRectangle(effectiveBounds);
                Marshal.StructureToPtr(newLtrb, m.LParam, false);
                m.Result = new IntPtr(1);
            }


            //if (m.Msg == 0x214)
            //{ // WM_MOVING || WM_SIZING
            //    // Keep the window square
            //    RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
            //    int w = rc.Right - rc.Left; // get width
            //    int h = rc.Bottom - rc.Top; // get height
            //    int z = w > h ? w : h; // z is greatest of the two (w/h)
            //    switch ((int)m.WParam)
            //    {
            //        case 1: //left
            //            rc.Bottom = rc.Top + w;//define width
            //            rc.Top = rc.Top + (h - (rc.Bottom - rc.Top)) / 2;//define width
            //            break;
            //        case 2: //right
            //            rc.Bottom = rc.Top + w;//define width
            //            rc.Top = rc.Top + (h - (rc.Bottom - rc.Top)) / 2;//define width
            //            break;
            //        case 3: //top
            //            rc.Right = rc.Left + h;//define width
            //            rc.Left = rc.Left + (w - (rc.Right - rc.Left)) / 2;//define width
            //            break;
            //        case 4:
            //            rc.Top = rc.Bottom - z;//define height
            //            rc.Left = rc.Right - z;//define width
            //            break;
            //        case 5:
            //            rc.Top = rc.Bottom - z;//define height
            //            rc.Right = rc.Left + z;//define width
            //            break;
            //        case 6:
            //            rc.Right = rc.Left + h;//define width
            //            rc.Left = rc.Left + (w - (rc.Right - rc.Left)) / 2;//define width
            //            break;
            //        case 7:
            //            rc.Bottom = rc.Top + z;//define height
            //            rc.Left = rc.Right - z;//define width
            //            break;
            //        case 8:
            //            rc.Bottom = rc.Top + z;//define height
            //            rc.Right = rc.Left + z;//define width
            //            break;
            //        default:
            //            break;
            //    }
            //    Marshal.StructureToPtr(rc, m.LParam, false);
            //    m.Result = (IntPtr)1;
            //    return;
            //}

            if (optionLockRatio)
            {
                if (m.Msg == WM_SIZING)
                {
                    RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));

                    int w = rc.Right - rc.Left - chromeWidth;
                    int h = rc.Bottom - rc.Top - chromeHeight;

                    switch (m.WParam.ToInt32()) // Resize handle
                    {
                        case WMSZ_LEFT:
                        case WMSZ_RIGHT:
                            // Left or right handles, adjust height                        
                            rc.Bottom = rc.Top + chromeHeight + (int)(constantHeight * w / constantWidth);
                            break;

                        case WMSZ_TOP:
                        case WMSZ_BOTTOM:
                            // Top or bottom handles, adjust width
                            rc.Right = rc.Left + chromeWidth + (int)(constantWidth * h / constantHeight);
                            break;

                        case WMSZ_LEFT + WMSZ_TOP:
                        case WMSZ_LEFT + WMSZ_BOTTOM:
                            // Top-left or bottom-left handles, adjust width
                            rc.Left = rc.Right - chromeWidth - (int)(constantWidth * h / constantHeight);
                            break;

                        case WMSZ_RIGHT + WMSZ_TOP:
                            // Top-right handle, adjust height
                            rc.Top = rc.Bottom - chromeHeight - (int)(constantHeight * w / constantWidth);
                            break;

                        case WMSZ_RIGHT + WMSZ_BOTTOM:
                            // Bottom-right handle, adjust height
                            rc.Bottom = rc.Top + chromeHeight + (int)(constantHeight * w / constantWidth);
                            break;
                    }

                    Marshal.StructureToPtr(rc, m.LParam, true);
                }
            }


            base.WndProc(ref m);

            // should only get here when youtube is disabled?
            // or if we have a mouse capture??
            if (m.Msg == Win32.WM_NCHITTEST)
            {
                Console.Write("form test!");
                m.Result = (IntPtr)Win32.HTCAPTION;
            }



        }

        private float constantWidth = 16;
        private float constantHeight = 9;

        private int chromeWidth;
        private int chromeHeight;

        // From Windows SDK
        private const int WM_SIZING = 0x214;

        private const int WMSZ_LEFT = 1;
        private const int WMSZ_RIGHT = 2;
        private const int WMSZ_TOP = 3;
        private const int WMSZ_BOTTOM = 6;


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        const int _ = 10; // you can rename this variable if you like

        Rectangle T2 { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        Rectangle L2 { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
        Rectangle B2 { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        Rectangle R2 { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }

        Rectangle TL2 { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TR2 { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BL2 { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BR2 { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }


        Timer recentDoubleClickTimer;
        int msSinceRecentDoubleClick = 0;
        int recentDoubleClickTick = 100;
        bool allowAnotherDoubleClick = true;
        void recentDoubleClickTimer_Tick(object sender, EventArgs e)
        {
            msSinceRecentDoubleClick += recentDoubleClickTick;
            if (msSinceRecentDoubleClick > 400)
            {
                recentDoubleClickTimer.Stop();
                msSinceRecentDoubleClick = 0;
                allowAnotherDoubleClick = true;
            }
        }



        void DoSingleClickAction()
        {
            Point mouseInScreen = Cursor.Position;
            Point marshalWarning = wb.screenPointOfClick;
            int dx = marshalWarning.X - mouseInScreen.X;
            int dy = marshalWarning.Y - mouseInScreen.Y;

            int limit = 4;

            //Console.WriteLine("mouse up: " + mouseInScreen);
            //Console.WriteLine("muose moved: " + dx + ", " + dy);

            if (dx < limit && dx > -limit && dy < limit && dy > -limit)
            {
                // process click on video as usual
                Point pos = PointToClient(Cursor.Position);
                Win32.SendMessage(wb.Handle, Win32.WM_LBUTTONUP, (IntPtr)0, Win32.MakeLParam(pos.X, pos.Y));
            }
        }

        void OnlyOnMouseUpAMIRITE()
        {

            //if (Win32.GetFocus() != this.Handle) 
            if (contextMenuOpened)
            {
               // Console.WriteLine("ignore click2");
                contextMenuOpened = false;
                return;
            }

            DoSingleClickAction();

            Win32.ReleaseCapture(); // do anything?

            wb.lButtonDown = false;

        }

        // ----

        // snapping

        private SnapLocation _snapAnchor;
        private int _dragOffsetX;
        private int _dragOffsetY;

        /// <summary>
        /// Flags specifying which edges to anchor the form at.
        /// </summary>
        [Flags]
        public enum SnapLocation
        {
            None = 0,
            Left = 1 << 0,
            Top = 1 << 1,
            Right = 1 << 2,
            Bottom = 1 << 3,
            All = Left | Top | Right | Bottom
        }

        /// <summary>
        /// How far from the screen edge to anchor the form.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(0)]
        [Description("The distance from the screen edge to anchor the form.")]
        public int AnchorDistance = -RESIZE_OVERFLOW;

        /// <summary>
        /// Gets or sets how close the form must be to the
        /// anchor point to snap to it. A higher value gives
        /// a more noticable "snap" effect.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(20)]
        [Description("The maximum form snapping distance.")]
        public int SnapDistance = 25;

        /// <summary>
        /// Re-snaps the control to its current anchor points.
        /// This can be useful for re-positioning the form after
        /// the screen resolution changes.
        /// </summary>
        public void ReSnap()
        {
            SnapTo(_snapAnchor);
        }

        /// <summary>
        /// Forces the control to snap to the specified edges.
        /// </summary>
        /// <param name="anchor">The screen edges to snap to.</param>
        public void SnapTo(SnapLocation anchor)
        {
            Screen currentScreen = Screen.FromPoint(Location);
            Rectangle workingArea = currentScreen.WorkingArea;
            if ((anchor & SnapLocation.Left) != 0)
            {
                Left = workingArea.Left + AnchorDistance;
            }
            else if ((anchor & SnapLocation.Right) != 0)
            {
                Left = workingArea.Right - AnchorDistance - Width;
            }
            if ((anchor & SnapLocation.Top) != 0)
            {
                Top = workingArea.Top + AnchorDistance;
            }
            else if ((anchor & SnapLocation.Bottom) != 0)
            {
                Top = workingArea.Bottom - AnchorDistance - Height;
            }
            _snapAnchor = anchor;
        }

        private bool InSnapRange(int a, int b)
        {
            return Math.Abs(a - b) < SnapDistance;
        }

        private SnapLocation FindSnap(ref Rectangle effectiveBounds)
        {
            Screen currentScreen = Screen.FromPoint(effectiveBounds.Location);
            Rectangle workingArea = currentScreen.WorkingArea;
            SnapLocation anchor = SnapLocation.None;
            if (InSnapRange(effectiveBounds.Left, workingArea.Left + AnchorDistance))
            {
                effectiveBounds.X = workingArea.Left + AnchorDistance;
                anchor |= SnapLocation.Left;
            }
            else if (InSnapRange(effectiveBounds.Right, workingArea.Right - AnchorDistance))
            {
                effectiveBounds.X = workingArea.Right - AnchorDistance - effectiveBounds.Width;
                anchor |= SnapLocation.Right;
            }
            if (InSnapRange(effectiveBounds.Top, workingArea.Top + AnchorDistance))
            {
                effectiveBounds.Y = workingArea.Top + AnchorDistance;
                anchor |= SnapLocation.Top;
            }
            else if (InSnapRange(effectiveBounds.Bottom, workingArea.Bottom - AnchorDistance))
            {
                effectiveBounds.Y = workingArea.Bottom - AnchorDistance - effectiveBounds.Height;
                anchor |= SnapLocation.Bottom;
            }
            return anchor;
        }





        // ----

        internal static string GetVideoId(string input)
        {
            string YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
            var regex = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
            foreach (Match match in regex.Matches(input))
            {
                //Console.WriteLine(match);
                foreach (var groupdata in match.Groups.Cast<Group>().Where(groupdata => !groupdata.ToString().StartsWith("http://") && !groupdata.ToString().StartsWith("https://") && !groupdata.ToString().StartsWith("youtu") && !groupdata.ToString().StartsWith("www.")))
                {
                    return groupdata.ToString();
                }
            }
            return string.Empty;
        }

        void SetNoVideo()
        {
            rememberOurVidID = "";
            UpdateVideoName(); //updates title bar name and context menu popup name

            // it seems we need the iframe to work right (match youtube player)
            // i think because more messages are send/processed that way? and
            // probaly our mouse grabbing code compensates for getting twice the messagse without me realizing thats what it does
            webBrowser1.DocumentText = @"<h3></h3><body bgcolor=""#000000""><iframe style=""border:none; background-color:black; width:0; height:0;""></iframe></body>";

            // old style had bug after loading a novid page:
            //webBrowser1.DocumentText = @"<h3></h3><body bgcolor=""#000000"">";
        }

        void SetVidById(string id, string startSeconds = "")
        {
            rememberOurVidID = id;
            UpdateVideoName(); //updates title bar name and context menu popup name

            string optionalStartString = "";
            if (startSeconds != "")
                optionalStartString = "start: " + startSeconds + ",";

            //width: '"+this.Bounds.Width+ @"',
            //height: '" + this.Bounds.Height + @"',

            string fill = @"position:fixed; top:0px; left:0px; bottom:0px; right:0px; width:100%; height:100%; border:none; margin:0; padding:0; overflow:hidden; z-index:999999;";

            /* 
                js notes, snippets:
             

                <head>
                    <meta http-equiv=""X-UA-Compatible"" content=""IE=11"">
                </head>
                
                function pause() { player.pauseVideo(); }

                ondragstart=""return false;"" ondrop=""return false;""

            
                ondragover = function () {
                    window.external.DragStarted(event);
                    return true; 

    
                document.addEventListener(""dragstart"", function( event ) {
                    alert(""test"");
                    // store a ref. on the dragged elem
                    //dragged = event.target;
                    // make it half transparent
                    //event.target.style.opacity = .5;
                }, false);


                Events fired on the draggable target (the source element):
                ondragstart - occurs when the user starts to drag an element
                ondrag - occurs when an element is being dragged
                ondragend - occurs when the user has finished dragging the element

                Events fired on the drop target:
                ondragenter - occurs when the dragged element enters the drop target
                ondragover - occurs when the dragged element is over the drop target
                ondragleave - occurs when the dragged element leaves the drop target
                ondrop - occurs when the dragged element is dropped on the drop target
                
                function mydrag(event)
                {
                 //   alert(""test"");
                }

                </script>

                <body  ondragenter=""mydrag(event)"">
                <div id=""player"" style=""" + fill + @"""></div>
                </body>

            */


            // h3 h3 here is our way to make sure we are on a valid page 
            // (countign on the rarity of that ever happening.. could intentionally use it to load other pages i guess)
            webBrowser1.DocumentText =
            @"<h3></h3>

                <script src=""https://www.youtube.com/iframe_api""></script>

                <script>
                var player;
                function onYouTubeIframeAPIReady() {
                    player = new YT.Player('player', {
                        videoId: '" + id + @"',
                        playerVars: {
                            controls: 1,
                            autoplay: 1,
                            disablekb: 1,
                            enablejsapi: 1,
                            iv_load_policy: 3,
                            modestbranding: 1,
                            " + optionalStartString + @"
                            showinfo: 0
                        }
                    });
                }
                </script>

                <div id=""player"" style=""" + fill + @"""></div>


            ";

        }




        // ----

        string rememberOurVidID;

        void SetVidByURL(string vidURL)
        {
            string id = GetVideoId(vidURL);

            if (id == "")
            {
                // Console.WriteLine("url not recognized");
                textOverlay.DisplayTextForABit("invalid url");
                return;
            }

            string timeInSeconds = "";
            timeInSeconds = GetStartInSeconds(vidURL);

            if (timeInSeconds != "")
            {
                SetVidById(id, timeInSeconds);
            }
            else
            {
                SetVidById(id);
            }
        }



        string GetStartInSeconds(string url)
        {
            string timeRaw = "";
            string[] timeTokens = { "?t=", "&t=", "#t=", "?start=", "&start=", "#start=" };
            foreach (string tok in timeTokens)
            {
                if (url.Contains(tok))
                {
                    timeRaw = GetEverythingAfterIfExists(url, tok);
                    break;
                }
            }

            if (timeRaw == "")
                return "";

            timeRaw.ToLower();

            // strip out s as well, assume anything left at end of parsing is seconds
            timeRaw = StripEverythingAfterFirstBadChar(timeRaw, "0123456789hm");

            string timeAsParsed = timeRaw;

            int hours = 0;
            if (timeAsParsed.Contains("h"))
            {
                int index = timeAsParsed.IndexOf("h");
                hours = Convert.ToInt32(timeAsParsed.Substring(0, index));
                if (index < timeAsParsed.Length)
                    timeAsParsed = timeAsParsed.Substring(index + 1, timeAsParsed.Length - (index + 1));
            }

            int minutes = 0;
            if (timeAsParsed.Contains("m"))
            {
                int index = timeAsParsed.IndexOf("m");
                minutes = Convert.ToInt32(timeAsParsed.Substring(0, index));
                if (index < timeAsParsed.Length)
                    timeAsParsed = timeAsParsed.Substring(index + 1, timeAsParsed.Length - (index + 1));
            }

            int seconds = Convert.ToInt32(timeAsParsed);

            string resultInSeconds = ((hours * 3600) + (minutes * 60) + seconds).ToString();

            return resultInSeconds;
        }
        string GetEverythingAfterIfExists(string searchIn, string lookFor)
        {
            string result = searchIn;
            if (searchIn.Contains(lookFor))
            {
                result = searchIn.Substring(searchIn.IndexOf(lookFor) + lookFor.Length);
            }
            return result;
        }
        string StripEverythingAfterFirstBadChar(string searchIn, string whiteList)
        {
            string result = searchIn;
            for (int i = 0; i < searchIn.Length; i++)
            {
                if (!whiteList.Contains(searchIn[i]))
                {
                    result = result.Substring(0, i);
                    break;
                }
            }
            return result;
        }

        // ----

        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }


        static UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 0;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            if (browserVersion < 7)
            {
                throw new ApplicationException("Unsupported version of Microsoft Internet Explorer!");
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. 

            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. 
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. 
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.                    
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10.
                    break;
            }

            return mode;
        }



        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            // this seemed to do the trick
            // see:
            // http://stackoverflow.com/questions/18333459/c-sharp-webbrowser-ajax-call/18333982#18333982
            // http://stackoverflow.com/questions/28526826/web-browser-control-emulation-issue-feature-browser-emulation/28626667#28626667
            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            //SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            //SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            //SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            //SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            //SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            //SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            //SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            //SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            //SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            //SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }


        // ----


        // ----

        bool alreadyTryingPaste = false;


        // use this to overwrite wndproc for "Internet Explorer_Server"
        class WbInternal : NativeWindow
        {
            public WbInternal(IntPtr handle)
            {
                this.AssignHandle(handle);
            }



            const int _ = 10; // you can rename this variable if you like

            Rectangle T2 { get { return new Rectangle(0, 0, parentForm.ClientSize.Width, _); } }
            Rectangle L2 { get { return new Rectangle(0, 0, _, parentForm.ClientSize.Height); } }
            Rectangle B2 { get { return new Rectangle(0, parentForm.ClientSize.Height - _, parentForm.ClientSize.Width, _); } }
            Rectangle R2 { get { return new Rectangle(parentForm.ClientSize.Width - _, 0, _, parentForm.ClientSize.Height); } }

            Rectangle TL2 { get { return new Rectangle(0, 0, _, _); } }
            Rectangle TR2 { get { return new Rectangle(parentForm.ClientSize.Width - _, 0, _, _); } }
            Rectangle BL2 { get { return new Rectangle(0, parentForm.ClientSize.Height - _, _, _); } }
            Rectangle BR2 { get { return new Rectangle(parentForm.ClientSize.Width - _, parentForm.ClientSize.Height - _, _, _); } }

            Rectangle EntireClient { get { return new Rectangle(0, 0, parentForm.ClientSize.Width, parentForm.ClientSize.Height); } }


            public ghoster.Form1 parentForm;

            Rectangle trackingBar { get { return new Rectangle(0, parentForm.ClientSize.Height - 53, parentForm.ClientSize.Width, 53 - 30); } }
            Rectangle volumeBar { get { return new Rectangle(92, parentForm.ClientSize.Height - 53, 150 - 92, 53); } }
            //bar Y (from bottom):
            // 30
            // 53
            //vol slider X
            // 92
            // 143 (150 better?)

            bool ctrlDown = false; // couldn't this be changed outside the window?

            protected override void WndProc(ref Message m)
            {

                // -- "in addition to base" --
                if (m.Msg == Win32.WM_KEYDOWN)
                {
                    if (m.WParam == (IntPtr)0x1B) // escape
                    {
                        if (parentForm.WindowState == FormWindowState.Maximized)
                            parentForm.WindowState = FormWindowState.Normal;
                    }

                    if (m.WParam == (IntPtr)0x56) // V
                    {
                        // Console.WriteLine("v down");

                        if (ctrlDown)
                        {

                            // Console.WriteLine("ctrl v down");

                            if (!parentForm.alreadyTryingPaste)
                            {
                                parentForm.alreadyTryingPaste = true;
                                string clipboardString = "";
                                if (Clipboard.ContainsText())
                                    clipboardString = Clipboard.GetText();
                                if (clipboardString != "")
                                    parentForm.SetVidByURL(clipboardString);

                                // Console.WriteLine("set vid 1");
                            }
                        }

                    }

                    if (m.WParam == (IntPtr)0x11) // ctrl
                    {
                        ctrlDown = true;
                        // Console.WriteLine("ctrl down");
                    }
                }

                if (m.Msg == Win32.WM_KEYUP)
                {
                    //MessageBox.Show("keyuip");
                    if (m.WParam == (IntPtr)0x56) // V
                    {
                        //Console.WriteLine("v up");
                        parentForm.alreadyTryingPaste = false;
                    }
                    if (m.WParam == (IntPtr)0x11) // ctrl
                    {
                        ctrlDown = false;
                        //Console.WriteLine("ctrl up");
                    }
                }


                // -- normal behavior / potential overwrite base --

                if (m.Msg == Win32.WM_RBUTTONDOWN)
                {
                    IntPtr xy = m.LParam;
                    int x = unchecked((short)(long)xy);
                    int y = unchecked((short)((long)xy >> 16));
                    Point paramPos = new Point(x, y);
                    Point mouseInScreen = parentForm.PointToScreen(paramPos);

                    Point spawnPoint = mouseInScreen;
                    //spawnPoint.X -= parentForm.contextMenu1.Width;
                    //spawnPoint.Y -= parentForm.contextMenu1.Height;

                    parentForm.menuFullscreen.Checked = (parentForm.WindowState == FormWindowState.Maximized);
                    parentForm.contextMenu1.Show(mouseInScreen);

                }
                else if (m.Msg == Win32.WM_LBUTTONDBLCLK)
                {
                    parentForm.recentDoubleClickTimer.Start();

                    if (parentForm.allowAnotherDoubleClick)
                    {
                        parentForm.allowAnotherDoubleClick = false;

                        parentForm.ToggleFullScreen2();
                    }

                    // i believe giving the vid this this will undo whatever pause/unpause a single click did
                    // pretty awkward though!
                    base.WndProc(ref m);
                }
                else if (m.Msg == Win32.WM_LBUTTONUP)
                {
                    // Console.WriteLine("m up vid");

                    lButtonDown = false;
                    base.WndProc(ref m);
                }
                else if (m.Msg == Win32.WM_LBUTTONDOWN)
                {

                    // doesn't quite work right
                    //if (Win32.GetFocus() != this.Handle)
                    //{
                    //    Console.WriteLine("activation click");
                    //    return;
                    //}

                    var cursor = parentForm.PointToClient(Cursor.Position);
                    if (trackingBar.Contains(cursor) || volumeBar.Contains(cursor))
                    {
                        // if no video loaded, process all clicks the same
                        if (parentForm.rememberOurVidID != "")
                        {
                            base.WndProc(ref m);
                            return;
                        }
                    }


                    // ---

                    // Console.WriteLine("m down vid");

                    lButtonDown = true;

                    IntPtr xy = m.LParam;
                    int x = unchecked((short)(long)xy);
                    int y = unchecked((short)((long)xy >> 16));
                    Point paramPos = new Point(x, y);

                    // used for checking for click in mouse up
                    Point mouseInScreen = parentForm.PointToScreen(paramPos);
                    screenPointOfClick = mouseInScreen;

                    // never send m down messages to vid, wait to see what kind of input it is
                    // actually it seems we need this for clicks to work?
                    base.WndProc(ref m);

                    // Win32.ReleaseCapture();
                    //Win32.PostMessage(parentForm.Handle, Win32.WM_NCLBUTTONDOWN, (IntPtr)Win32.HTCAPTION, (IntPtr)0);
                    // i think it's standard to release capture before this?
                    Win32.DefWindowProc(parentForm.Handle, Win32.WM_SYSCOMMAND, (UIntPtr)Win32.MOUSE_MOVE, IntPtr.Zero);
                    Win32.SetCapture(parentForm.Handle); // messages will be processed by form

                }
                else
                {
                    //// if we're in resize area, don't send any messages to video
                    //var cursor = parentForm.PointToClient(Cursor.Position);
                    //if (TL2.Contains(cursor)) return;
                    //else if (TR2.Contains(cursor)) return;
                    //else if (BL2.Contains(cursor)) return;
                    //else if (BR2.Contains(cursor)) return;
                    //else if (T2.Contains(cursor)) return;
                    //else if (L2.Contains(cursor)) return;
                    //else if (R2.Contains(cursor)) return;
                    //else if (B2.Contains(cursor)) return;

                    base.WndProc(ref m);
                }
            }

            // where was mouse down, check on mouse up to see if drag or click
            public Point screenPointOfClick;
            public bool lButtonDown;

        }


        // ----


        public string GetTitle(string id)
        {
            //string id = GetVideoId(url);
            WebClient client = new WebClient();
            try
            {
                return GetArgs(client.DownloadString("http://youtube.com/get_video_info?video_id=" + id), "title", '&');
            }
            catch
            {
                Console.Write("Internet down?");
                return "";
            }
        }

        private string GetArgs(string args, string key, char query)
        {
            int iqs = args.IndexOf(query);
            string querystring = null;

            try
            {
                if (iqs != -1)
                {
                    querystring = (iqs < args.Length - 1) ? args.Substring(iqs + 1) : String.Empty;

                    Dictionary<string, string> dicQueryString = querystring.Split('&').ToDictionary(c => c.Split('=')[0], c => Uri.UnescapeDataString(c.Split('=')[1]));

                    //string userId = dicQueryString["userID"];

                    //NameValueCollection nvcArgs = System.Net.WebUtility.ParseQueryString(querystring);
                    return dicQueryString[key];
                }
            }
            catch
            {
                Console.WriteLine("error getting video title");
            }
            return String.Empty; // or throw an error
        }


        // ----


        Icon GetRandomIcon()
        {
            Bitmap bmp = Properties.Resources.r1;

            Random rand = new Random();
            int r = rand.Next(0, 160);

            if (r < 10) bmp = Properties.Resources.c1;
            else if (r < 20) bmp = Properties.Resources.c2;
            else if (r < 30) bmp = Properties.Resources.c3;
            else if (r < 40) bmp = Properties.Resources.c4;
            else if (r < 50) bmp = Properties.Resources.r1;
            else if (r < 60) bmp = Properties.Resources.r2;
            else if (r < 70) bmp = Properties.Resources.r3;
            else if (r < 80) bmp = Properties.Resources.r4;
            else if (r < 90) bmp = Properties.Resources.y1;
            else if (r < 100) bmp = Properties.Resources.y2;
            else if (r < 110) bmp = Properties.Resources.y3;
            else if (r < 120) bmp = Properties.Resources.y4;
            else if (r < 130) bmp = Properties.Resources.p1;
            else if (r < 140) bmp = Properties.Resources.p2;
            else if (r < 150) bmp = Properties.Resources.p3;
            else if (r < 160) bmp = Properties.Resources.p4;
            //  else if (r <165) bmp = Properties.Resources.zzb; // deciding to reserve, maybe for debug/crash/novid
            //  else if (r <166) bmp = Properties.Resources.zzw; // conflicts with "ghost mode" icon now!

            return Icon.FromHandle(bmp.GetHicon());
        }




        // ----


        public class TrackBarWithLabel : TrackBar
        {

            public string Label;


            private Rectangle trackRectangle = new Rectangle();
            private Rectangle thumbRectangle = new Rectangle();
            private bool thumbClicked = false;
            private TrackBarThumbState thumbState = TrackBarThumbState.Normal;

            public TrackBarWithLabel()
                : base()
            {

                this.LargeChange = 0; //disable this and manually set position when click

                //this.Location = new Point(10, 10);
                //this.Size = new Size(150, 40);
                //this.numberTicks = 100;
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.Transparent;
                this.DoubleBuffered = true;


                SetStyle(ControlStyles.UserPaint, true);
                //SetStyle(ControlStyles.AllPaintingInWmPaint, true);

                //SetStyle(ControlStyles.UserPaint |
                //     ControlStyles.AllPaintingInWmPaint |
                //     ControlStyles.DoubleBuffer, true);
            }

            int pad = 6; // even for best results, this is really Xpad

            protected override void OnPaint(PaintEventArgs e)
            {
               // base.OnPaint(e); //need?

                double valueAsPercent = (double)this.Value / (double)this.Maximum; //assumes 0 min
                int valueAsX = pad + (int)(valueAsPercent * ((double)ClientRectangle.Width - pad * 2));


                // Calculate the size of the track bar.
                Rectangle trackRectangle = ClientRectangle;

                //trackRectangle.X = ClientRectangle.X + pad;
                //trackRectangle.Width = ClientRectangle.Width - pad * 2;
                trackRectangle.X = ClientRectangle.X + pad;
                trackRectangle.Width = ClientRectangle.Width - pad * 2;

                //trackRectangle.Y = ClientRectangle.Y + Height / 2 - 2;
                //trackRectangle.Height = 4;
                trackRectangle.Y = 1;
                trackRectangle.Height = Height - 3;

                TrackBarRenderer.DrawHorizontalTrack(e.Graphics, trackRectangle);



                Rectangle shadedRect = ClientRectangle;
                shadedRect.X = trackRectangle.X;
                shadedRect.Width = valueAsX;
                shadedRect.Y = trackRectangle.Y;
                shadedRect.Height = trackRectangle.Height;
                shadedRect.Inflate(-1, -1);

                //Pen pen = new Pen(Color.Gray, );
                Brush brush = new SolidBrush(Color.LightBlue);
                e.Graphics.FillRectangle(brush, shadedRect);
                brush.Dispose();



                // Calculate the size of the thumb.
                Rectangle thumbRect = ClientRectangle;
                //Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)this.Value / this.Maximum) * rect.Width), rect.Height);
                //thumbRectangle2.Location = new Point((int)((double)this.Value / (double)this.Maximum), 0);

                thumbRect.Size = TrackBarRenderer.GetBottomPointingThumbSize(e.Graphics, TrackBarThumbState.Normal);
                thumbRect.Inflate(-1, -1);

                //double percent = (double)this.Value / (double)this.Maximum; //assumes 0 min
                thumbRect.Location = new Point(valueAsX - thumbRect.Width / 2, 1);

                TrackBarRenderer.DrawVerticalThumb(e.Graphics, thumbRect, thumbState);
                //TrackBarRenderer.DrawBottomPointingThumb(e.Graphics, thumbRect, thumbState);

                thumbRectangle = thumbRect;

                //rect.Inflate(-3, -3);
                //Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)this.Value / this.Maximum) * rect.Width), rect.Height);
                //ProgressBarRenderer.DrawHorizontalChunks(e.Graphics, clip);



                string drawString = Label + " " + Value.ToString();
                Font drawFont = new Font("Segoe UI", 9f); // not context menu font?
                //Font drawFont = System.Drawing.SystemFonts.DefaultFont;
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                Rectangle rect1 = new Rectangle(0, 0, Width, Height);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Near;

                e.Graphics.DrawString(drawString, drawFont, drawBrush, rect1, stringFormat);
                drawFont.Dispose();
                drawBrush.Dispose();
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                Invalidate();
            }

            // Determine whether the user has clicked the track bar thumb.
            protected override void OnMouseDown(MouseEventArgs e)
            {
                double dblValue = ((double)e.X - (double)pad) / ((double)Width - (double)pad * 2) * (double)Maximum;
                Value = Math.Max(Math.Min(Convert.ToInt32(dblValue), 100), 0);

                thumbClicked = true;
                thumbState = TrackBarThumbState.Pressed;


                this.Invalidate();
            }

            // Redraw the track bar thumb if the user has moved it.
            protected override void OnMouseUp(MouseEventArgs e)
            {

                if (thumbClicked == true)
                {
                    if (e.Location.X > trackRectangle.X &&
                        e.Location.X < (trackRectangle.X +
                        trackRectangle.Width - thumbRectangle.Width))
                    {
                        thumbClicked = false;
                        thumbState = TrackBarThumbState.Hot;
                        this.Invalidate();
                    }

                    thumbClicked = false;
                }
            }

            // Track cursor movements.
            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (!TrackBarRenderer.IsSupported)
                    return;

                // The user is moving the thumb.
                if (thumbClicked == true)
                {
                    double dblValue = ((double)e.X - (double)pad) / ((double)Width - (double)pad * 2) * (double)Maximum;
                    Value = Math.Max(Math.Min(Convert.ToInt32(dblValue), 100), 0);
                }

                // The cursor is passing over the track.
                else
                {
                    thumbState = thumbRectangle.Contains(e.Location) ?
                        TrackBarThumbState.Hot : TrackBarThumbState.Normal;
                }

                Invalidate();
            }

        }

        public class TrackBarMenuItem : ToolStripControlHost
        {
            private TrackBarWithLabel trackBar;

            public TrackBarMenuItem() : base(new TrackBarWithLabel())
            {
                this.trackBar = this.Control as TrackBarWithLabel;
                this.trackBar.TickStyle = TickStyle.None;
                this.trackBar.TickFrequency = 1;
                this.trackBar.Minimum = 0; // "i'll allow it"
                this.trackBar.Maximum = 100;

                this.trackBar.AutoSize = false;
                this.trackBar.Width = 150;
                this.trackBar.Height = 20;

               // this.trackBar.
            }

            public int Value
            {
                get { return trackBar.Value; }
                set { trackBar.Value = value; }
            }
            public int TickFrequency
            {
                get { return trackBar.TickFrequency; }
                set { trackBar.TickFrequency = value; }
            }
            public int Minimum
            {
                get { return trackBar.Minimum; }
                set { trackBar.Minimum = value; }
            }
            public int Maximum
            {
                get { return trackBar.Maximum; }
                set { trackBar.Maximum = value; }
            }
            //public int Width
            //{
            //    get { return trackBar.Width; }
            //    set { trackBar.Width = value; }
            //}
            //public int Height
            //{
            //    get { return trackBar.Height; }
            //    set { trackBar.Height = value; }
            //}

            public string Label
            {
                get { return trackBar.Label; }
                set { trackBar.Label = value; }
            }

            //public override int Height
            //{
            //    get { return trackBar.Height; }
            //    set { trackBar.Height = value; }
            //}

            public event EventHandler ValueChanged
            {
                add { trackBar.ValueChanged += value; }
                remove { trackBar.ValueChanged -= value; }
            }



        }


        // ----

        string GetRandomDefaultId()
        {
            // move to external file?
            string[] ids = {
                               "OJpQgSZ49tk",  // music video
                               "dzUNFqOwjfA",  // timelapse
                               "Pi8k1lTqrkQ",  // music video
                               "gRAw5wsAKik",  // music video
                               "rpWUDU_GEL4",  // little sadie
                               "NVb5GV6lntU",  // psychill mix
                               "8t3XYNxnUBs",  // psychill mix
                               "3WLNhLs5sFg",  // ambient sunrise
                               "P5_GlAOCHyE",  // space
                               "DgPaCWJL7XI",  // deep dream grocery
                               "FFoPYw55C_c",  // pixel music vid
                               "iYUh88gr7DI",  // popeye tangerine dream
                               "9wPb07EPDD4",  // "visual project"
                               "XxfNqvoXRug",  // porches
                               "UW8tpjJt0xc",  // rabbit hole 2 mix
							   "APmBT96ETJk",  // kiki mix
							   "XKDGZ-VWLMg",  // raining in tokyo
							   "lJJW0dE5GF0",  // aria
							   "EyPyjprGvW0",  // dragon roost
							   "hqXpaTu8UrM",  // gymnopedie take five
							   "qpMIijaTePA",  // samantha fish
							   "pC0HpEq-rb0",  // music video
							   "aB4M9rl8GvM",  // charade
							   "uieM18rZdHY",  // fox in space
                               "wA2APi0cTYY",  // satantango
                               "F0O_6nMvqiM",  // yule log
                               "aia3bqQfXNk",  // l'eclisse
                               // "xfSJEWNTvo4",  // Prisencolinensinainciusol
                               // "KT_li-WHcII",  // tarkovsky candle (lets blame the witness for getting this one blocked)
							   // train?
                           };
            Random rand = new Random();
            return ids[rand.Next(0, ids.Length)];
        }

        // ----

        internal void ToggleFullScreen2()  // no idea why this is needed
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                // dont bother with this since it works ok without disable?
                //DisableLockedAspectRatio(); //remember that we disabled it to re-enable?
                WindowState = FormWindowState.Maximized;
            }
            menuFullscreen.Checked = (WindowState == FormWindowState.Maximized);
        }

        void EnableLockedAspectRatio()
        {
            if(menuLockRatio != null) menuLockRatio.Checked = true;
            optionLockRatio = true;
            SetSizeToAspectRatio();
        }
        void DisableLockedAspectRatio()
        {
            if (menuLockRatio != null) menuLockRatio.Checked = false;
            optionLockRatio = false;
        }

        void SetSizeToAspectRatio()
        {
            double aspectRatio = 16.0 / 9.0;
            double desiredHeight = (double)Width / aspectRatio;
            double desiredWidth = (double)Height * aspectRatio;

            if (desiredHeight < Height)
            {
                double heightChange = Height - desiredHeight;
                Top += (int)(heightChange / 2.0);
                Height = (int)desiredHeight;
            }
            else
            {
                double widthChange = Width - desiredWidth;
                Left += (int)(widthChange / 2.0);
                Width = (int)desiredWidth;
            }

        }

        // ----


    }

}
