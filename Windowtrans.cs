using UnityEngine;
using System;
using System.Runtime.InteropServices;
public class Windowtrans : MonoBehaviour
{
    [DllImport("User32.dll")] static extern IntPtr GetActiveWindow(); //Windows APIのインポート
    [DllImport("User32.dll")] static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    [DllImport("user32.dll")] static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    [DllImport("user32.dll")] static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

    void Awake(){ //デフォルトの装飾子がprivateのため省略
#if !UNITY_EDITOR //以下エディターでプログラムとして認識されると予期しない動作になる可能性あり(簡潔化の弊害)
        IntPtr window = GetActiveWindow();
        SetWindowLong(window, -20, 0x00080000); //ウィンドウ設定
        SetWindowLong(window, -16, GetWindowLong(window, -16) ^ 0x00C00000); //タイトルバー
        SetLayeredWindowAttributes(window, 0, 0, 1); //ウィンドウを透過
#endif
    }
}
