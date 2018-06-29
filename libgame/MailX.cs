using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libgame
{
    [Serializable]
    public class MailX
    {
        public string ids = string.Empty;
        public int ID = 0;
        static int id = 0;
        public string Name = string.Empty;
        public List<String> Body = new List<string>();
        public bool isReaded = false;

        public MailX(string name)
        {
            ID = id++;
            Name = name;
            
        }

        public void AddText(string text)
        {
            Body.Add(text);
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as MailX).ID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
