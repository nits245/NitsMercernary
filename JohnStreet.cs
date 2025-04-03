using SplashKitSDK;

namespace NitsMercernary
{
    public class JohnStreet:Room
    {
        private string name;
        private Bitmap _bitmap;
        private Bitmap _BA_Building;
        private Bitmap _Library;
        private Bitmap _ATC_Building;
        private Bitmap DungeonRoom;
        public JohnStreet(string[]ids,string Name) : base(ids, Name) 
        {
            name = Name;
            _bitmap = SplashKit.LoadBitmap("grass", "images/JohnStreet.png");
            _Library = SplashKit.LoadBitmap("Library", "images/Library.png");
            _BA_Building = SplashKit.LoadBitmap("BA", "images/BA_Building.png");
            _ATC_Building = SplashKit.LoadBitmap("ATC", "images/ATC_Building.png");
            DungeonRoom = SplashKit.LoadBitmap("Dungeon", "images/building.png");
        }

        public override void Draw()
        {
            _bitmap.Draw(0, 0);
            _Library.Draw(260, -10);
            _BA_Building.Draw(-20, 150);
            _ATC_Building.Draw(450, 100);
            DungeonRoom.Draw(355, 330);
        }

        public override void PlayerStartingPos(Player player, int x, int y)
        {
            player.X = x;
            player.Y = y;

        }

        public string Name { get { return name; } }
    }
}
