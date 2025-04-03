

namespace NitsMercernary
{
    public abstract class Obj : IDgame
    {
        private string _description;
        private string _name; 
        public Obj(string[] ids,string name) : base(ids)
        {
            _name = name;
        }

        public string Name {  get { return _name; } }

        public virtual string FullDescription {  get { return _description;} }
    }
}
