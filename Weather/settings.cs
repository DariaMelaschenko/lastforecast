using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Mediator
{
    public class settings
    {
        public bool[] _RadioButtons = new bool[7];

        public string _units;

        public string mode;

        public int days ;
        public string AppID;

        public settings()
        {
            mode = "&mode=json";
            days = 7;
            AppID = "&APPID=4d68cd16f5ceecb97a2993c77075d6bf";

            _units = "&units=metric";

            _RadioButtons[1] = true;
            _RadioButtons[6] = true;
        }
    }
}
