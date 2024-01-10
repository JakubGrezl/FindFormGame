using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFormGame
{
    internal class Singleton
    {
        public List<Form> forms = new List<Form>();
        private static Singleton _instance;

        public static Singleton Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance; }
        }

        public void Won(Form1 form)
        {
            onWon?.Invoke(form);
        }

        public void Lost()
        {
            // brickni pc
        }

        public event Action<Form1> onWon = (form) =>
        {
            form.Visible = true;
            
        };
    }
}
