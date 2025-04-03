using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitsMercernary
{
    public class Dungeon : Room
    {
        private Bitmap DungeonRoom;
        private int x, y;
        public Dungeon(string[] ids, string name) : base(ids, name)
        {
            DungeonRoom = SplashKit.LoadBitmap("DungeonIn", "images/DungeonIn.jpg");
        }

        public override void Draw()
        {
            DungeonRoom.Draw(0, 0);
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
