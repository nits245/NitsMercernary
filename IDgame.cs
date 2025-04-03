

namespace NitsMercernary
{
    public class IDgame
    {
        public List<string> _identifiers = new();

        public IDgame(string[] idents) 
        {
            _identifiers.AddRange(idents);
        }

        public bool AreYou(string id) 
        {
            foreach (string ident in _identifiers) 
            {
                if (ident.ToLower() == id.ToLower()) { return true; }
            }
            return false;
        }

        public void AddIdentifier(string id) 
        {
            _identifiers.Add(id.ToLower());
        }
       
    }
}
