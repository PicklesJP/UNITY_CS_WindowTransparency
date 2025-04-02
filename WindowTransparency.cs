using UnityEngine; using System; using System.Runtime.InteropServices;
public class WindowTransparency : MonoBehaviour
{
    [DllImport("User32.dll")] static extern IntPtr GetActiveWindow(); //WindowsAPI DLL
    [DllImport("User32.dll")] static extern int SetWindowLong(IntPtr h, int i, int v); //h=hWnd,i=nIndex,v=dwNewLong,c=crKey,b=bAlpha,f=dwFlags
    [DllImport("user32.dll")] static extern int GetWindowLong(IntPtr h, int i);
    [DllImport("user32.dll")] static extern bool SetLayeredWindowAttributes(IntPtr h, uint c, byte b, uint f);
    void Awake(){ //default private
#if !UNITY_EDITOR //.exe only work, not work in UnityEditor
        IntPtr h = GetActiveWindow();
        SetWindowLong(h, -20, 0x80000);
        SetWindowLong(h, -16, GetWindowLong(h, -16) ^ 0xC00000);
        SetLayeredWindowAttributes(h, 0, 0, 1); //代入
#endif
    }
}
