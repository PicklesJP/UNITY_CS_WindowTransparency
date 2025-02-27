using UnityEngine;
using System;
using System.Runtime.InteropServices;
public class WindowTransparency : MonoBehaviour
{
    [DllImport("User32.dll")] static extern IntPtr GetActiveWindow(); //Windows APIのDLLインポート
    [DllImport("User32.dll")] static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    [DllImport("user32.dll")] static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    [DllImport("user32.dll")] static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
    void Awake(){ //デフォルトの装飾子がprivateのため省略
#if !UNITY_EDITOR //.exeに出力した時のみ機能
        IntPtr window = GetActiveWindow();
        SetWindowLong(window, -20, 0x00080000); //ウィンドウ設定
        SetWindowLong(window, -16, GetWindowLong(window, -16) ^ 0x00C00000); //タイトルバー削除
        SetLayeredWindowAttributes(window, 0, 0, 1); //ウィンドウを透過
#endif
    }
}
