using SplashKitSDK;

namespace NitsMercernary
{
    public class BA : Room
    {
        private Bitmap _BA_Building_In;
        public BA(string[] ids, string name):base(ids, name) 
        {
            _BA_Building_In = SplashKit.LoadBitmap("BA_In", "images/BA_Building_inside.png");

        }

        public override void Draw()
        {
            _BA_Building_In.Draw(0, 0);
        }

        public override void PlayerStartingPos(Player player, int x, int y)
        {
            player.X = x;
            player.Y = y;
        }

    }
}
