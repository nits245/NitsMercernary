using SplashKitSDK;

namespace NitsMercernary
{
    public class ATC : Room
    {
        private int x, y;
        private Bitmap _ATC_Building_In;
        public ATC(string[]ids ,string name) : base(ids,name)
        {
            _ATC_Building_In = SplashKit.LoadBitmap("ATC_In", "images/ATC_Building_In.png");
        }

        public override void Draw()
        {
            _ATC_Building_In.Draw(0, 0);
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
