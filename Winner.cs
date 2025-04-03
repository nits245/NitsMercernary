using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitsMercernary
{
    public class Winner : Room
    {
        private Bitmap WinnerRoom;
        private int x, y;
        public Winner(string[] ids, string name) : base(ids, name)
        {
            WinnerRoom = SplashKit.LoadBitmap("Winner", "images/winningscreen.jpg");
        }

        public override void Draw()
        {
            WinnerRoom.Draw(0, 0);
        }

        public override void PlayerStartingPos(Player player, int x, int y)
        {
            player.X = x;
            player.Y = y;
        }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
    }
}
