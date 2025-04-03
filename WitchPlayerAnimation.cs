using SplashKitSDK;
using System.Numerics;

namespace NitsMercernary
{
    public class WitchPlayerAnimation : Player
    {
        public PlayerInterface Interface;
        public Bitmap witch;
        public Bitmap witchATTACK;
        public Bitmap witchwalk;
        public Animation WitchIdleAni;
        public Animation WitchAttackAni;
        public Animation WitchWalkAni;
        DrawingOptions WitchIdleOpt;
        DrawingOptions WitchAttackOpt;
        DrawingOptions WitchWalkOpt;
        public bool idle;
        public int i;
        private int x, y;
        public WitchPlayerAnimation(string name, string desc, int X, int Y) : base(name, desc, X, Y)
        {
            witch = SplashKit.LoadBitmap("witch", "images/B_witch_idle.png");
            witchATTACK = SplashKit.LoadBitmap("witchatk", "images/B_witch_attack.png");
            witchwalk = SplashKit.LoadBitmap("witchwalk", "images/witch_walk.png");

            witch.SetCellDetails(64, 96, 1, 6, 6);
            witchATTACK.SetCellDetails(208, 92, 1, 9, 9);
            witchwalk.SetCellDetails(64, 96, 2, 8, 16);

            AnimationScript WitchIdleScript = SplashKit.LoadAnimationScript("witchidle", "witchidle.txt");
            AnimationScript WitchAttackScript = SplashKit.LoadAnimationScript("witchattack", "witchattack.txt");
            AnimationScript WitchWalkScript = SplashKit.LoadAnimationScript("witchwalk", "witchwalk.txt");

            WitchIdleAni = WitchIdleScript.CreateAnimation("idle");
            WitchAttackAni = WitchAttackScript.CreateAnimation("noanim");
            WitchWalkAni = WitchWalkScript.CreateAnimation("noanima");

            i = 0;
            idle = true;

            x = X;
            y = Y;
        }
        public override void Update()
        {

            if (!idle)
            {
                i += 1;
            }

            if ((!idle) && (i % 80 == 0))
            {
                idle = true;
                WitchIdleAni.Assign("idle");
                Console.WriteLine("idle");
                WitchAttackAni.Assign("noanim");
            }
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Console.WriteLine("atk");
                WitchIdleAni.Assign("noani");
                WitchAttackAni.Assign("attack");
                idle = false;
            }
            if ((SplashKit.KeyTyped(KeyCode.RightKey)) || (SplashKit.KeyTyped(KeyCode.DKey)))
            {

                Console.WriteLine("walkright");
                WitchIdleAni.Assign("noani");
                WitchAttackAni.Assign("noanim");
                WitchWalkAni.Assign("walkright");

            }
            if ((SplashKit.KeyReleased(KeyCode.RightKey)) || (SplashKit.KeyReleased(KeyCode.DKey)))
            {
                WitchIdleAni.Assign("idle");
                WitchWalkAni.Assign("noanima");
            }
            if ((SplashKit.KeyTyped(KeyCode.LeftKey)) || (SplashKit.KeyTyped(KeyCode.AKey)))
            {
                Console.WriteLine("walkleft");
                WitchIdleAni.Assign("noani");
                WitchAttackAni.Assign("noanim");
                WitchWalkAni.Assign("walkleft");
            }
            if ((SplashKit.KeyReleased(KeyCode.LeftKey)) || (SplashKit.KeyReleased(KeyCode.AKey)))
            {
                WitchIdleAni.Assign("idle");
                WitchWalkAni.Assign("noanima");
            }
            PlayerMovement();
            WitchIdleAni.Update();
            WitchAttackAni.Update();
            WitchWalkAni.Update();
        }

        public void PlayerMovement()
        {
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
            WitchIdleOpt = SplashKit.OptionWithAnimation(WitchIdleAni);
            WitchAttackOpt = SplashKit.OptionWithAnimation(WitchAttackAni);
            WitchWalkOpt = SplashKit.OptionWithAnimation(WitchWalkAni);

            SplashKit.DrawBitmap(witch, X - 20, Y - 40, WitchIdleOpt);
            SplashKit.DrawBitmap(witchATTACK, X - 10, Y - 35, WitchAttackOpt);
            SplashKit.DrawBitmap(witchwalk, X - 10, Y - 35, WitchWalkOpt);
        }

        public override int X { get { return x; } set { x = value; } }
        public override int Y { get { return y; } set { y = value; } }

    }
}