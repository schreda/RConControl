using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCONManager {
    public class GlobalConstants {
        public const string AUTORUN_REGKEY = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public const string PATH_CONFIGS = "configs";
        public const string RCONCMD_STATUS = "status";
        public const string STRING_COMMENT = "//";

        public const string RCONMSG_FILTER_STATUS = "userid";
        public const string RCONMSG_FILTER_USERS = "STEAM_";
        public const int RCON_RECEIVE_WAIT = 100;
        public const int RCON_RECEIVE_TRIES = 10;

        public const string RCON_DEFAULT_KICKMSG = "kicked from server";

    }
}
