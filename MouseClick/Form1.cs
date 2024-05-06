using System.Runtime.InteropServices;
namespace MouseClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClickMouse();

        }
        private void ClickMouse()
        {
            int c = 0;
            POINT p = new POINT();
            while (true)
            {
                GetCursorPos (ref p);
                ClientToScreen(Handle, ref p);
                DoMouseLeftClick(p.x, p.y);
                c++;
                Thread.Sleep(200);
                if (c == 50) break;
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pOINT);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        [DllImport ("user32.dll")]
        public static extern void mouse_event(int dsFlags, int dx, int dy,  int cButtons, int dcExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        private void DoMouseLeftClick(int x, int y)
        { 
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y,0,0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y,0,0);
        }
        private void DoMouseRightClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }
        private void DoMouseDobleLeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref POINT lpPoint);

    }

}
