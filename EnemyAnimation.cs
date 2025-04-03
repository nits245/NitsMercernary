using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitsMercernary
{
    public class EnemyAnimation : Player
    {
        public Bitmap Enemy;
        public Bitmap EnemyAttack;
        public Bitmap EnemyWalk;
        public Bitmap EnemyDie;

        public Animation EnemyIdleAni;
        public Animation EnemyAttackAni;
        public Animation EnemyWalkAni;
        public Animation EnemyDieAni;

        DrawingOptions EnemyIdleOpt;
        DrawingOptions EnemyAttackOpt;
        DrawingOptions EnemyWalkOpt;
        DrawingOptions EnemyDieOpt;

        public bool respawn;
        public int i;
        private int x, y;

        EnemyDirection enemyDirection = EnemyDirection.Left;
        private enum EnemyDirection
        {
            Left,
            Right,
            Dead
        }
        public EnemyAnimation(string name, string desc, int X, int Y) : base(name, desc, X, Y)
        {
            Enemy = SplashKit.LoadBitmap("enemy", "images/EnemyIdle.png");
            EnemyAttack = SplashKit.LoadBitmap("enemyattack", "images/EnemyAttack.png");
            EnemyWalk = SplashKit.LoadBitmap("enemywalk", "images/EnemyRun.png");
            EnemyDie = SplashKit.LoadBitmap("enemydie", "images/EnemyDie.png");

            Enemy.SetCellDetails(80, 64, 7, 1, 7);
            EnemyAttack.SetCellDetails(80, 64, 10, 1, 10);
            EnemyWalk.SetCellDetails(80, 64, 8, 2, 16);
            EnemyDie.SetCellDetails(80, 64, 15, 1, 15);

            AnimationScript EnemyIdleScript = SplashKit.LoadAnimationScript("enemyidle", "enemyidle.txt");
            AnimationScript EnemyAttackScript = SplashKit.LoadAnimationScript("enemyattack", "enemyattack.txt");
            AnimationScript EnemyWalkScript = SplashKit.LoadAnimationScript("enemywalk", "enemywalk.txt");
            AnimationScript EnemyDieScript = SplashKit.LoadAnimationScript("enemydie", "enemydie.txt");

            EnemyIdleAni = EnemyIdleScript.CreateAnimation("noanimation");
            EnemyAttackAni = EnemyAttackScript.CreateAnimation("noanimation1");
            EnemyWalkAni = EnemyWalkScript.CreateAnimation("walkleft1");
            EnemyDieAni = EnemyDieScript.CreateAnimation("noanimation3");

            i = 0;
            respawn = false;
            x = X;
            y = Y;
        }
        public override void Update()
        {
            if (X < 295 && !Dead)
            { enemyDirection = EnemyDirection.Right; X = 300; EnemyWalkAni.Assign("walkright1"); }
            else if (X > 550 && !Dead)
            { enemyDirection = EnemyDirection.Left; X = 545; EnemyWalkAni.Assign("walkleft1"); }
            else if (Dead)
            { enemyDirection = EnemyDirection.Dead; }

            if (respawn) 
            {
                i += 1;
            }

            switch (enemyDirection) 
            {
                case EnemyDirection.Left:
                    X -= 1;
                    break;
                case EnemyDirection.Right:
                    X += 1;
                    break;                        
                case EnemyDirection.Dead:

                    if (i % 1000 == 0) 
                    {
                    EnemyDieAni.Assign("noanimation3");
                    enemyDirection = EnemyDirection.Right; EnemyWalkAni.Assign("walkright1");
                    }                        
                    respawn = true;                  

                    Dead = false;
                    break;
            }
            EnemyWalkAni.Update();
            EnemyIdleAni.Update();
            EnemyAttackAni.Update();
            EnemyDieAni.Update();
        }
        public override void Draw()
        {
            EnemyIdleOpt = SplashKit.OptionWithAnimation(EnemyIdleAni);
            EnemyAttackOpt = SplashKit.OptionWithAnimation(EnemyAttackAni);
            EnemyWalkOpt = SplashKit.OptionWithAnimation(EnemyWalkAni);
            EnemyDieOpt = SplashKit.OptionWithAnimation(EnemyDieAni);

            SplashKit.DrawBitmap(Enemy, X - 20, Y - 40, EnemyIdleOpt);
            SplashKit.DrawBitmap(EnemyAttack, X - 10, Y - 35, EnemyAttackOpt);
            SplashKit.DrawBitmap(EnemyWalk, X - 10, Y - 35, EnemyWalkOpt);
            SplashKit.DrawBitmap(EnemyDie, X - 10, Y - 35, EnemyDieOpt);
        }

        public override int X { get { return x; } set { x = value; } }
        public override int Y { get { return y; } set { y = value; } }

    }
}
