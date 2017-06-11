using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.UI
{
    public static class UIHelper
    {
        public static void DrawLine(int length)
        {
            for (int i = 0; i < length - 1; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("-");
        }

        public static void DrawTitle(string title)
        {
            Console.Clear();
            DrawLine(title.Length);
            Console.WriteLine(title);
            DrawLine(title.Length);
        }
    }
}
