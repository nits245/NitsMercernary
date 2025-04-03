using SplashKitSDK;

namespace NitsMercernary
{
    public abstract class Room : Obj
    {
        private string _RoomName;
        public Room(string[]ids,string name) :base(ids, name) 
        { 
            _RoomName = name; 
        }
        public abstract void Draw();

        public abstract void PlayerStartingPos(Player player,int x, int y);

        public string RoomName { get { return _RoomName; } }
    }
}
