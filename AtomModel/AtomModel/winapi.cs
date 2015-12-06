﻿/* 
 *This code is property of Vasily Tserekh
 *if you like it you can visit my personal dev blog
 *http://vasilydev.blogspot.com
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace AtomModel
{
    public struct Pointer
    {
        public int x;
        public int y;
    }

    public static class Winapi
    {
        [DllImport("GDI32.dll")]
        public static extern void SwapBuffers(uint hdc);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern void GetCursorPos(ref Pointer point);
    }
}
