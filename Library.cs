using SplashKitSDK;

namespace NitsMercernary
{
    public class Library : Room
    {
        private Bitmap _Library_Building_In;
        private int x, y;
        public Library(string[] ids, string name):base(ids, name)
        {
            _Library_Building_In = SplashKit.LoadBitmap("Library_In", "images/Library.jpg");
        }

        public override void Draw()
        {
            _Library_Building_In.Draw(0,0);
        }

        public override void PlayerStartingPos(Player player,int x,int y)
        {
            player.X = x;
            player.Y = y;
        }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
    }
}
