
using SplashKitSDK;
using System.Security.Cryptography.X509Certificates;

namespace NitsMercernary
{
    public class Program
    {
        private enum RoomType
        {
            JohnStreet,
            Library,
            BA,
            ATC,
            Dungeon,
            Winner
        }

        private enum PlayerType
        {
            cartoon,
            witch
        }
        public static void Main()
        {
            Player player;
            Window window = new Window("NitsAdeventure", 600, 600);

            int score = 0;

            bool Entered;

            Font font = SplashKit.LoadFont("score", "fonts/arial.ttf");
            Music BackgroundMusic = SplashKit.LoadMusic("background", "songs/song.mp3");
            SplashKit.PlayMusic(BackgroundMusic, -1);

            RoomType CurrentRoomType = RoomType.JohnStreet;
            PlayerType CurrentPlayerType = PlayerType.cartoon;

            WitchPlayerAnimation witchplayerani = new("witch", "witch player animation", 300, 550);
            CartoonPlayerAnimation cartoonplayerani = new("cartoon", "cartoon player animation", 300, 550);
            EnemyAnimation enemyani = new("enemy", "enemy animation", 550, 540); //enemy in ATC
            EnemyAnimation enemyani2 = new("enemy", "enemy animation", 10, 340); //enemy in ATC
            EnemyAnimation enemyani3 = new("enemy", "enemy animation", 550, 373); //enemy in library
            EnemyAnimation enemyani4 = new("enemy", "enemy animation", 300, 430); // enemy in BA
            EnemyAnimation enemyani5 = new("enemy", "enemy animation", 300, 490); // enemy in Dungeon
            List<EnemyAnimation> enemies = new List<EnemyAnimation>();
            enemies.Add(enemyani);
            enemies.Add(enemyani2);
            enemies.Add(enemyani3);
            enemies.Add(enemyani4);
            enemies.Add(enemyani5);

            Room JohnStreet = new JohnStreet(new string[] { "JohnStreet" }, "JohnStreet");
            Room Library = new Library(new string[] { "Library" }, "Library");
            Room ATC = new ATC(new string[] { "ATC" }, "ATC");
            Room BA = new BA(new string[] { "BA" }, "BA");
            Room Dungeon = new Dungeon(new string[] { "Dungeon" }, "Dungeon");
            Room Winner = new Winner(new string[] { "Winner" }, "Winner");

            // to create a point between player and enemy to discern distance between them
            Player player1 = new("witchboundary","witchboundary",0,0);
            player = cartoonplayerani;

            PlayerInterface playerInterface;
            playerInterface = player1;
            do
            {
                Room CurrentRoom;
                player1.X = witchplayerani.X + 20;

                //Keep track if a user has entered or exited a room
                Entered = false;

                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                window.Clear(Color.White);
                CurrentRoom = new JohnStreet(new string[] { "JohnStreet" }, "JohnStreet");

                //diplay score
                string ScoreText = $"GOLD {score.ToString()}G";


                //if the player enters a certain coordiantes it changes current room to the new room it entered or exited
                if ((cartoonplayerani.PlayerIsAt(270, 90, 380, 0)) && (CurrentRoomType == RoomType.JohnStreet))
                {
                    Entered = true;
                    CurrentRoomType = RoomType.Library;
                }
                if ((cartoonplayerani.PlayerIsAt(0, 320, 110, 120)) && (CurrentRoomType == RoomType.JohnStreet))
                {
                    Entered = true;
                    CurrentRoomType = RoomType.BA;
                }
                if ((cartoonplayerani.PlayerIsAt(490, 320, 600, 120)) && (CurrentRoomType == RoomType.JohnStreet))
                {
                    Entered = true;
                    CurrentRoomType = RoomType.ATC;
                }
                if ((cartoonplayerani.PlayerIsAt(380, 394, 470, 340)) && (CurrentRoomType == RoomType.JohnStreet))
                {
                    Entered = true;
                    CurrentRoomType = RoomType.Dungeon;
                }
                // exits room to go back to john street
                if ((witchplayerani.PlayerIsAt(97, 530, 127, 446)) && (CurrentRoomType == RoomType.ATC) && (SplashKit.KeyDown(KeyCode.SpaceKey)))
                {
                    Entered = true;
                    CurrentRoomType = RoomType.JohnStreet;
                    CurrentRoom.PlayerStartingPos(cartoonplayerani, 470, 300);
                }
                if ((witchplayerani.PlayerIsAt(20, 420, 60, 370)) && (CurrentRoomType == RoomType.BA) && (SplashKit.KeyDown(KeyCode.SpaceKey)))
                {
                    Entered = true;
                    CurrentRoomType = RoomType.JohnStreet;
                    CurrentRoom.PlayerStartingPos(cartoonplayerani, 131, 228);
                }
                if ((witchplayerani.PlayerIsAt(9, 363, 39, 310)) && (CurrentRoomType == RoomType.Library) && (SplashKit.KeyDown(KeyCode.SpaceKey)))
                {
                    Entered = true;
                    CurrentRoomType = RoomType.JohnStreet;
                    CurrentRoom.PlayerStartingPos(cartoonplayerani, 335, 99);
                }
                if ((witchplayerani.PlayerIsAt(50, 480, 90, 430)) && (CurrentRoomType == RoomType.Dungeon) && (SplashKit.KeyDown(KeyCode.SpaceKey)))
                {
                    Entered = true;
                    CurrentRoomType = RoomType.JohnStreet;
                    CurrentRoom.PlayerStartingPos(cartoonplayerani, 378, 412);
                }
                if (score >= 100) 
                {
                    Entered = true;
                    CurrentRoomType = RoomType.Winner;
                }

                //when a new room is assigned it changes the room object and player type object
                switch (CurrentRoomType)
                {
                    case RoomType.JohnStreet:
                        CurrentRoom = JohnStreet;
                        CurrentPlayerType = PlayerType.cartoon;
                        player.Room = CurrentRoom;
                        break;
                    case RoomType.Library:
                        CurrentRoom = Library;
                        CurrentPlayerType = PlayerType.witch;
                        player.Room = enemyani3.Room = CurrentRoom;
                        if (Entered) { CurrentRoom.PlayerStartingPos(witchplayerani, 29, 363); }
                        break;
                    case RoomType.ATC:
                        CurrentRoom = ATC;
                        CurrentPlayerType = PlayerType.witch;
                        player.Room = enemyani.Room = enemyani2.Room =CurrentRoom;
                        if (Entered) { CurrentRoom.PlayerStartingPos(witchplayerani, 100, 530);}
                        break;
                    case RoomType.BA:

                        CurrentRoom = BA;
                        CurrentPlayerType = PlayerType.witch;
                        player.Room = enemyani4.Room = CurrentRoom;
                        if (Entered) { CurrentRoom.PlayerStartingPos(witchplayerani, 20, 420);}
                        break;
                    case RoomType.Dungeon:
                        CurrentRoom = Dungeon;
                        CurrentPlayerType = PlayerType.witch;
                        player.Room = enemyani5.Room = CurrentRoom;
                        if (Entered) { CurrentRoom.PlayerStartingPos(witchplayerani, 40, 480); }
                        break;
                    case RoomType.Winner:
                        CurrentRoom = Winner;
                        CurrentPlayerType = PlayerType.witch;
                        player.Room = CurrentRoom;
                        if (Entered) { CurrentRoom.PlayerStartingPos(witchplayerani, 100, 500); }
                        break;
                }
                CurrentRoom.Draw();

                // Draws current player type
                if (CurrentPlayerType == PlayerType.cartoon)
                {
                    player = cartoonplayerani;
                    cartoonplayerani.Draw();
                    cartoonplayerani.Update();
                }
                if (CurrentPlayerType == PlayerType.witch &&((CurrentRoomType == RoomType.BA || CurrentRoomType == RoomType.ATC || CurrentRoomType == RoomType.Library || CurrentRoomType == RoomType.Dungeon )))
                {
                        foreach (var enemy in enemies)
                        {
                        if (enemy.Room == CurrentRoom)
                        {
                            enemy.Draw();
                            enemy.Update();
                            player1.Y = enemy.Y + 5;
                            //animation of enemy changes to death when distance between enemy and player are close and skill is used by pressing mouse left click
                            if (player1.PlayerIsAt(player.X, player.Y + 20, enemy.X, enemy.Y) && SplashKit.MouseClicked(MouseButton.LeftButton) && (enemy.X - player.X <= 170) && (player.Y - enemy.Y <= 30) && !enemy.Dead)
                            {
                                enemy.EnemyWalkAni.Assign("noanimation2");
                                enemy.EnemyDieAni.Assign("dies");
                                enemy.Dead = true;
                                score += 10;
                            }
                            // player is dead if enemy touches player and player respawns
                            else if (player1.PlayerIsAt(player.X, player.Y + 20, enemy.X, enemy.Y) && (enemy.X - player.X <= 20) && (player.Y - enemy.Y <= 30)) 
                            {
                                for (int i = 0; i < 1000000000; i++)
                                {
                                    i += 1;
                                }
                                if (CurrentRoomType == RoomType.ATC)
                                {
                                    CurrentRoom.PlayerStartingPos(witchplayerani, 100, 530);
                                }
                                if (CurrentRoomType == RoomType.BA)
                                {
                                    CurrentRoom.PlayerStartingPos(witchplayerani, 20, 420);
                                }
                                if (CurrentRoomType == RoomType.Library)
                                {
                                    CurrentRoom.PlayerStartingPos(witchplayerani, 29, 363);
                                }
                                if (CurrentRoomType == RoomType.Dungeon)
                                {
                                    CurrentRoom.PlayerStartingPos(witchplayerani, 40, 480);
                                }
                                score = 0;
                            } 
                        }                   
                        }
                    player = witchplayerani;
                    witchplayerani.Draw();
                    witchplayerani.Update();               
                }

                SplashKit.DrawText(ScoreText, Color.Gold, font, 25 , 430, 10);

                window.Refresh(60);

                // coordinates for debugging purposes

                //Console.WriteLine($"X: {player1.X} Y: {player1.Y}");
                //Console.WriteLine($"enemy X: {enemyani.X} enemy Y: {enemyani.Y}");
                //Console.WriteLine($"enemy2 X: {enemyani2.X} enemy2 Y: {enemyani2.Y}");
                //Console.WriteLine($"player X: {player.X} player Y: {player.Y} \n {enemyani.X - player.X}\n");
                //  Console.WriteLine($"X: {SplashKit.MousePosition().X} Y: {SplashKit.MousePosition().Y}");
            }
            while (!window.CloseRequested);
        }
    }
}