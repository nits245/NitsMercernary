using SplashKitSDK;
using System.Transactions;

namespace NitsMercernary
{
    public class Player : Obj, PlayerInterface
    {
        private int x;
        private int y;

        private bool dead; 

        private Room room;
        public Player(string name, string desc, int X, int Y) : base(new string[] { "player" }, name)
        {
            x = X;
            y = Y;
            dead = false;
            room = new JohnStreet(new string[] { "JohnStreet" }, "JohnStreet");
        }
        public virtual void Draw()
        {
        }

        public virtual void Update()
        {
        }

        public bool PlayerIsAt(int x1, int y1, int x2, int y2)
        {
            if ((x1 <= X) && (x2 >= X))
            {
                if ((y1 >= Y) && (y2 <= Y)) { return true; }
            }
            return false;
        }
        public override string FullDescription { get { return $"{Name}, {base.FullDescription}\nYou are carrying:\n"; } }

        public virtual int X { get { return x; } set { x = value; } }
        public virtual int Y { get { return y; } set { y = value; } }

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }

        public bool Dead { get { return dead; } set { dead = value; } }
    }
}
