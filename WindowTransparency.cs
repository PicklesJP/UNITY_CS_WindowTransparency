using UnityEngine; using System; using System.Runtime.InteropServices; //可読性は考慮せずに行数を極限まで減らしていますコメントを消した場合の文字数は710文字です
public class WindowTransparency : MonoBehaviour //名前を指定しています
{
    [DllImport("User32.dll")] static extern IntPtr GetActiveWindow(); //Windows APIのDLLインポート
    [DllImport("User32.dll")] static extern int SetWindowLong(IntPtr h, int i, int v); //h=hWnd,i=nIndex,v=dwNewLong,c=crKey,b=bAlpha,f=dwFlagsとして省略
    [DllImport("user32.dll")] static extern int GetWindowLong(IntPtr h, int i); //上記同じ
    [DllImport("user32.dll")] static extern bool SetLayeredWindowAttributes(IntPtr h, uint c, byte b, uint f); //上記同じ
    void Awake(){ //デフォルトの装飾子がprivateのため省略,上記同理由
#if !UNITY_EDITOR //.exeに出力した時のみ機能する,エディターの動作が壊れます
        IntPtr h = GetActiveWindow(); //単語を=にして省略
        SetWindowLong(h, -20, 0x80000); //ウィンドウ設定,0x00080000は=0x80000なので省略
        SetWindowLong(h, -16, GetWindowLong(h, -16) ^ 0xC00000); //タイトルバー削除,上記と同じ理由で省略
        SetLayeredWindowAttributes(h, 0, 0, 1); //ウィンドウを透過,=にした単語から代入
#endif
    }
}
