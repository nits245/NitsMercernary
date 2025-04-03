using SplashKitSDK;

namespace NitsMercernary
{
    public class CartoonPlayerAnimation : Player
    {
        public Bitmap cartoon;
        public Animation test;
        public DrawingOptions opt;
        private int x;
        private int y;

        public CartoonPlayerAnimation(string name, string desc, int X, int Y) : base(name, desc, X, Y)
        {
            cartoon = SplashKit.LoadBitmap("cartoon", "images/character.png");
            cartoon.SetCellDetails(48, 48, 4, 4, 16);
            AnimationScript Walk = SplashKit.LoadAnimationScript("", "test.txt");
            test = Walk.CreateAnimation("walkback");
            x = X;
            y = Y;
        }
        public override void Update()
        {

            if (SplashKit.KeyDown(KeyCode.PKey))
            { test.Assign("Dance"); }
            if ((SplashKit.KeyTyped(KeyCode.UpKey)) || (SplashKit.KeyTyped(KeyCode.WKey)))
            {
                test.Assign("GoWalkBack");
                Console.WriteLine(test);
            }
            if ((SplashKit.KeyReleased(KeyCode.UpKey)) || (SplashKit.KeyReleased(KeyCode.WKey)))
            {
                test.Assign("WalkBack"); 
            }
            if ((SplashKit.KeyTyped(KeyCode.DownKey)) || (SplashKit.KeyTyped(KeyCode.SKey)))
            {
                test.Assign("GoWalkFront");
            }
            if ((SplashKit.KeyReleased(KeyCode.DownKey)) || (SplashKit.KeyReleased(KeyCode.SKey)))
            { 
                test.Assign("WalkFront");
            }
            if ((SplashKit.KeyTyped(KeyCode.RightKey)) || (SplashKit.KeyTyped(KeyCode.DKey)))
            {
                { test.Assign("GoWalkRight"); }
            }
            if ((SplashKit.KeyReleased(KeyCode.RightKey)) || (SplashKit.KeyReleased(KeyCode.DKey)))
            {
                { test.Assign("WalkRight"); }
            }
            if ((SplashKit.KeyTyped(KeyCode.LeftKey)) || (SplashKit.KeyTyped(KeyCode.AKey)))
            {
                { test.Assign("GoWalkLeft"); }
            }
            if ((SplashKit.KeyReleased(KeyCode.LeftKey)) || (SplashKit.KeyReleased(KeyCode.AKey)))
            {
                { test.Assign("WalkLeft"); }
            }
            PlayerMovement();
            test?.Update();
        }

        public void PlayerMovement()
        {
            if ((SplashKit.KeyDown(KeyCode.UpKey)) || (SplashKit.KeyDown(KeyCode.WKey)))
            {
                if (Y >= 3)
                { Y -= 3; }
                else { Y = 0; }
            }
            if ((SplashKit.KeyDown(KeyCode.DownKey)) || (SplashKit.KeyDown(KeyCode.SKey)))
            {
                if (Y <= 550)
                { Y += 3; }
                else { Y = 555; }
            }
            if ((SplashKit.KeyDown(KeyCode.RightKey)) || (SplashKit.KeyDown(KeyCode.DKey)))
            {
                if (X <= 550)
                { X += 3; }
                else { X = 555; }
            }
            if ((SplashKit.KeyDown(KeyCode.LeftKey)) || (SplashKit.KeyDown(KeyCode.AKey)))
            {
                if (X >= 5)
                { X -= 3; }
                else { X = 0; }
            }
        }

        public override void Draw()
        {
            opt = SplashKit.OptionWithAnimation(test);
            SplashKit.DrawBitmap(cartoon, X, Y, opt);
        }

        public override int X { get { return x; } set { x = value; } }
        public override int Y { get { return y; } set { y = value; } }
    }
}
