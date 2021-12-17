//usingディレクティブ
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MyNamespace
{
    //メインクラス
    class MainFunction
    {
        //マウスポジション
        static Win32Point mousePosition;
        // メソッドを識別するID
        private static IntPtr _mouseHookId = IntPtr.Zero;
        private static IntPtr _keyboardHookId = IntPtr.Zero;
        // デリゲート
        private static readonly NativeMethods.LowLevelMouseKeyboardProc _mouseProc = MouseInputCallback;
        private static readonly NativeMethods.LowLevelMouseKeyboardProc _keyboardProc = KeyboardInputCallback;

        //コンストラクタ
        MainFunction()
        {
            mousePosition = new Win32Point();

            using (Process currentProcess = Process.GetCurrentProcess ())
            using (ProcessModule currentModule = currentProcess.MainModule) {
                // メソッドをマウスのイベントに紐づける。
                _mouseHookId = NativeMethods.SetWindowsHookEx (
                    NativeMethods.WH_MOUSE_LL,
                    _mouseProc,
                    NativeMethods.GetModuleHandle (currentModule.ModuleName),
                    0
                );
                
                // メソッドをキーボードのイベントに紐づける。
                _keyboardHookId = NativeMethods.SetWindowsHookEx (
                    (int)NativeMethods.WH_KEYBOARD_LL,
                    _keyboardProc,
                    NativeMethods.GetModuleHandle (currentModule.ModuleName),
                    0
                );
            }
        }

        //メイン関数
        static void Main(string[] args)
        {
            int Loop = 0;
            int[] X = new int[3];
            int[] Y = new int[3];
            //プリプロセス----------------------------------------------------------------------------------------------
            if( args.Length == 7 )
            {
                Loop = int.Parse(args[0]);
                X[0] = int.Parse(args[1]);
                Y[0] = int.Parse(args[2]);
                X[1] = int.Parse(args[3]);
                Y[1] = int.Parse(args[4]);
                X[2] = int.Parse(args[5]);
                Y[2] = int.Parse(args[6]);
            }

            // マウスポインタの現在位置を取得する。
            NativeMethods.GetCursorPos (ref mousePosition);

            // マウスポインタの現在位置でマウスの左ボタンの押し下げ・押し上げを連続で行うためのパラメータを設定する。
            INPUT[] inputs = new INPUT[]
            {
                new INPUT {
                    type = NativeMethods.INPUT_MOUSE,
                    ui = new INPUT_UNION {
                        mouse = new MOUSEINPUT {
                            dwFlags = NativeMethods.MOUSEEVENTF_LEFTDOWN,
                            dx = mousePosition.X,
                            dy = mousePosition.Y,
                            mouseData = 0,
                            dwExtraInfo = IntPtr.Zero,
                            time = 0
                        }
                    }
                },
                new INPUT {
                    type = NativeMethods.INPUT_MOUSE,
                    ui = new INPUT_UNION {
                        mouse = new MOUSEINPUT {
                            dwFlags = NativeMethods.MOUSEEVENTF_LEFTUP,
                            dx = mousePosition.X,
                            dy = mousePosition.Y,
                            mouseData = 0,
                            dwExtraInfo = IntPtr.Zero,
                            time = 0
                        }
                    }
                }
            };

            //ここから処理-----------------------------------------------------------------------------------------

            System.Console.WriteLine("({1},{2}) -> ({3},{4}) -> ({5},{6})を{0}回押します",Loop,X[0],Y[0],X[1],Y[1],X[2],Y[2]);

            //初回挙動前に3秒待機
            System.Threading.Thread.Sleep(3000);

            for(int loop = 0 ; loop < Loop ; loop++)
            {
                //デバッグ表示
                System.Console.WriteLine("{0}回目",loop+1);

                //1クリック目
                //カーソル移動
                NativeMethods.SetCursorPos(X[0], Y[0]);
                //左クリック
                NativeMethods.SendInput (2, ref inputs[0], Marshal.SizeOf (inputs[0]));
                //1秒待機
                System.Threading.Thread.Sleep(500);

                //2クリック目
                //カーソル移動
                NativeMethods.SetCursorPos(X[1], Y[1]);
                //左クリック
                NativeMethods.SendInput (2, ref inputs[0], Marshal.SizeOf (inputs[0]));
                //1秒待機
                System.Threading.Thread.Sleep(1000);               

                //3クリック目
                //カーソル移動
                NativeMethods.SetCursorPos(X[2], Y[2]);
                //左クリック
                NativeMethods.SendInput (2, ref inputs[0], Marshal.SizeOf (inputs[0]));
                //1秒待機
                System.Threading.Thread.Sleep(500);
            }

            System.Console.WriteLine("終了");
        }

        //デストラクタでアンフック
        ~MainFunction()
        {
            NativeMethods.UnhookWindowsHookEx(_mouseHookId);
            NativeMethods.UnhookWindowsHookEx(_keyboardHookId);
        }

        // マウス操作のイベントが発生したら実行されるメソッド
        private static IntPtr MouseInputCallback (int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0) {
                // マウスのイベントに紐付けられた次のメソッドを実行する。メソッドがなければ処理終了。
                return NativeMethods.CallNextHookEx (_mouseHookId, nCode, wParam, lParam);
            }

            MSLLHOOKSTRUCT param = Marshal.PtrToStructure<MSLLHOOKSTRUCT> (lParam);

            // 現在のマウスポインタの位置を取得する。以降の処理で使いたい場合は使う。
            NativeMethods.GetCursorPos (ref mousePosition);

            // マウスのどのようなイベントが発生したのかで処理を分岐する。
            switch ((NativeMethods.MouseMessage) wParam) {
                case NativeMethods.MouseMessage.WM_LBUTTONDOWN:
                
                    // マウスの左ボタンが押し下げられたときに実行したい処理をここに書く。
                    break;
                case NativeMethods.MouseMessage.WM_LBUTTONUP:
                    // マウスの左ボタンが押し上げられたときに実行したい処理をここに書く
                    break;
                case NativeMethods.MouseMessage.WM_MOUSEMOVE:
                    // マウスポインタが移動したときに実行したい処理をここに書く。
                    break;
                case NativeMethods.MouseMessage.WM_MOUSEWHEEL:
                    // マウスホイールが回転されたときに実行したい処理をここに書く。
                    // 例
                    //int wheelAmount = (param.mouseData >> 16) / 120;
                    // ホイールの回転量はparam.mouseDataの値を見れば分かる。
                    // wheelAmountの値が2の場合、ホイールが上（手前から奥）へカクカクッと2段階回転したことを意味する。
                    // wheelAmountの値が-1の場合、ホイールが下（奥から手前）へカクッと1段階回転したことを意味する。
                    
                    break;
                case NativeMethods.MouseMessage.WM_RBUTTONDOWN:
                    // マウスの右ボタンが押し下げられたときに実行したい処理をここに書く。
                    break;
                case NativeMethods.MouseMessage.WM_RBUTTONUP:
                    // マウスの右ボタンが押し上げられたときに実行したい処理をここに書く。
                    break;
                case NativeMethods.MouseMessage.WM_MBUTTONDOWN:
                    // マウスの中央ボタンが押し下げられたときに実行したい処理をここに書く。
                    break;
                case NativeMethods.MouseMessage.WM_MBUTTONUP:
                    // マウスの中央ボタンが押し上げられたときに実行したい処理をここに書く。
                    break;
                default:
                    break;
            }

            // マウスのイベントに紐付けられた次のメソッドを実行する。メソッドがなければ処理終了。
            return NativeMethods.CallNextHookEx (_mouseHookId, nCode, wParam, lParam);
        }

        // キーボード操作のイベントが発生したら実行されるメソッド
        private static IntPtr KeyboardInputCallback (int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                // キーボードのイベントに紐付けられた次のメソッドを実行する。メソッドがなければ処理終了。
                return NativeMethods.CallNextHookEx (_keyboardHookId, nCode, wParam, lParam);
            }
            
            // キーコードを取得する。
            KBDLLHOOKSTRUCT param = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);
            
            switch ((NativeMethods.KeyboardMessage) wParam)
            {
                case NativeMethods.KeyboardMessage.WM_KEYDOWN:
                    // キーが押し下げられたときに実行したい処理をここに書く。
                    // キーコードはparam.vkCode（int型）で得られる。
                    // System.Windows.Forms.Keys列挙体にキャストして利用もできる。
                    break;
                case NativeMethods.KeyboardMessage.WM_KEYUP:
                    // キーが押し上げられたときに実行したい処理をここに書く。
                    // キーコードはparam.vkCode（int型）で得られる。
                    // System.Windows.Forms.Keys列挙体にキャストして利用もできる。
                    break;
                default:
                    break;
            }

            // キーボードのイベントに紐付けられた次のメソッドを実行する。メソッドがなければ処理終了。
            return NativeMethods.CallNextHookEx (_keyboardHookId, nCode, wParam, lParam);
        }
    }

    ///// APIの利用に必要な構造体・共用体の定義　ここから /////
    [StructLayout(LayoutKind.Sequential)]
    public struct Win32Point
    {
        public Int32 X;
        public Int32 Y;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public int mouseData;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public short wVk;
        public short wScan;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    };

    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT_UNION
    {
        [FieldOffset(0)] public MOUSEINPUT mouse;
        [FieldOffset(0)] public KEYBDINPUT keyboard;
        [FieldOffset(0)] public HARDWAREINPUT hardware;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        public int type;
        public INPUT_UNION ui;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct MSLLHOOKSTRUCT
    {
        internal Win32Point pt;
        internal int mouseData;
        internal int flags;
        internal int time;
        internal IntPtr dwExtraInfo;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct KBDLLHOOKSTRUCT
    {
        internal int vkCode;
        internal int scanCode;
        internal int flags;
        internal int time;
        internal IntPtr dwExtraInfo;
    };

    ///// APIの利用に必要な構造体・共用体の定義　ここまで /////

    public static class NativeMethods
    {
        // 定数の定義
        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;
        public const int INPUT_HARDWARE = 2;

        public const int MOUSEEVENTF_MOVE = 0x1;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int MOUSEEVENTF_LEFTDOWN = 0x2;
        public const int MOUSEEVENTF_LEFTUP = 0x4;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLEUP = 0x40;
        public const int MOUSEEVENTF_WHEEL = 0x800;
        public const int WHEEL_DELTA = 120;

        public const int KEYEVENTF_KEYDOWN = 0x0;
        public const int KEYEVENTF_KEYUP = 0x2;
        public const int KEYEVENTF_EXTENDEDKEY = 0x1;

        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL    = 14;

        internal enum MouseMessage
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208
        }

        internal enum KeyboardMessage
        {
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105
        }

        internal delegate IntPtr LowLevelMouseKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // APIの読み込み
        #region user32.dll

        [DllImport ("user32.dll")]
        public static extern bool GetCursorPos (ref Win32Point pt);

        [DllImport ("user32.dll")]
        public static extern bool SetCursorPos (int X, int Y);

        [DllImport ("user32.dll")]
        public static extern void SendInput (int nInputs, ref INPUT pInputs, int cbsize);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        #endregion

        #region kernel32.dll

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }
}


//EOF
//参考文献
    //インクルードするディレクティブ
    //https://whoopsidaisies.hatenablog.com/entry/2013/03/22/142031

    //クリック処理について
    //https://slash-mochi.net/?p=3354

    //マウスポインタ移動
    //https://slash-mochi.net/?p=3352

    //マウス・キーボード入力処理について
    //https://slash-mochi.net/?p=3368

    //時間待機について
    //https://dobon.net/vb/dotnet/process/sleep.html

