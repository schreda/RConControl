using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCONManager {
    public class GlobalConstants {
        // Strings
        public const string AUTORUN_REGKEY        = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public const string PATH_CONFIGS          = "configs";
        public const string PATH_ERRORLOG         = "error.log";
        public const string STRING_COMMENT        = "//";
        public const string RCONCMD_STATUS        = "status";
        public const string RCONCMD_ZBLOCK        = "zb_active";
        public const string RCONCMD_MAPS          = "maps *";
        public const string RCONCMD_CHANGELEVEL   = "changelevel {0}";
        public const string RCONCMD_KICKID        = "kickid {0} {1}";
        public const string RCONCMD_ZB_RESTART    = "zb_lo3";
        public const string RCONCMD_RESTART       = "mp_restartgame {0}";
        public const string RCONCMD_CHATSAY       = "say {0}";
        public const string RCONMSG_FILTER_STATUS = "userid";
        public const string RCONMSG_FILTER_ZBLOCK = "zBlock";
        public const string MAPEXTENSION          = ".bsp";
        public const string RCON_DEFAULT_KICKMSG  = "kicked from server";
        public const string RESTARTMSG_HFGL       = "HF & GL";
        public const string STEAMID_PREFIX        = "STEAM_";
        public const string RCONCMD_BANID         = "banid {0} {1} {2}";
        public const string RCONCMD_BANIP         = "addip {0} {1}";
        public const string RCONCMD_WRITEID       = "writeid";
        public const string RCONCMD_WRITEIP       = "writeip";
        public const string HOTKEYID_RESTART      = "Restart";
        public const string HOTKEYID_LOADCFG      = "LoadCFG";
        
        // Values
        public const int ERROR_RESET_TIME     = 3000; // ms
        public const int RCON_RECEIVE_WAIT    = 100;
        public const int RCON_RECEIVE_TRIES   = 10;
        public const int RCON_RECONNECT_TRIES = 5;
    }
}
