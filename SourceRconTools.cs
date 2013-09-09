using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using RConControl.Properties;
using System.Windows.Forms;

namespace RConControl {
    public class SourceRconTools {

        /// <summary>
        /// Server play class
        /// </summary>
        public class Player {
            public string name { get; set; }
            public string id { get; set; }
            public string ip { get; set; }

            public override string ToString() {
                return name;
            }
        }

        /// <summary>
        /// Load config
        /// </summary>
        /// <param name="config">config</param>
        public static void LoadConfigFile(ConfigFile config) {
            SourceRconConnection rcon = SourceRconConnection.Instance;
            StringReader reader = new StringReader(config.content);
            string line;
            while ((line = reader.ReadLine()) != null) {
                if (!String.IsNullOrEmpty(line) && !line.Contains(GlobalConstants.STRING_COMMENT)) {
                    rcon.Send(line);
                    //Thread.Sleep(10);
                }
            }
        }

        /// <summary>
        /// Get player list with IP, ID, and name
        /// throws exception if wrong message received
        /// </summary>
        /// <returns>List with players</returns>
        public static List<Player> GetAllPlayers() {
            SourceRconConnection rcon              = SourceRconConnection.Instance;
            List<Player> resultPlayers = new List<Player>();
            string message                   = null;

            rcon.Send(GlobalConstants.RCONCMD_STATUS);
            try {
                message = Receive(GlobalConstants.RCONMSG_FILTER_STATUS);
            } catch (Exception ex) {
                throw ex;
            }

            StringReader readMessage = new StringReader(message);
            string line;

            while ((line = readMessage.ReadLine()) != null) {
                //#      2 "!#.viivii"         STEAM_0:X:XXXXX   26:35       40    0 active XX.XX.XX.XX:27005
                if (line.Contains(GlobalConstants.STEAMID_PREFIX)) {
                    bool success     = false;
                    int firstNameIdx = line.IndexOf("\"") + 1;
                    int firstIdIdx   = line.IndexOf(GlobalConstants.STEAMID_PREFIX);
                    int secondIpIdx  = line.LastIndexOf(":");

                    if (firstNameIdx     != -1 && firstIdIdx != -1 && secondIpIdx != -1) {
                        int secondNameIdx = line.IndexOf("\"", firstNameIdx);
                        int secondIdIdx   = line.IndexOf(" ", firstIdIdx);
                        int firstIpIdx    = line.LastIndexOf(" ", secondIpIdx) + 1;

                        if (secondNameIdx  != -1 && secondIdIdx != -1) {
                            string userName = line.Substring(firstNameIdx, secondNameIdx - firstNameIdx);
                            string userId   = line.Substring(firstIdIdx, secondIdIdx - firstIdIdx);
                            string userIp   = line.Substring(firstIpIdx, secondIpIdx - firstIpIdx);

                            resultPlayers.Add(new Player { name = userName, id = userId, ip = userIp });
                            success = true;
                        }
                    }
                    if (!success) {
                        Exception ex = new Exception("wrong message received.");
                        ex.Data.Add("message", message);
                        throw ex;
                    }
                } 
            }           
            return resultPlayers;
        }

        /// <summary>
        /// Check if zBlock is installed and active on server
        /// </summary>
        /// <returns>true if zBlock is installed and active</returns>
        public static List<string> GetAllMaps() {
            SourceRconConnection rcon     = SourceRconConnection.Instance;
            List<string> resultList = new List<string>();
            string message          = null;

            rcon.Send(GlobalConstants.RCONCMD_MAPS);
            try {
                message = Receive(GlobalConstants.MAPEXTENSION);
            } catch (Exception ex) {
                throw ex;
            }

            //PENDING:   (fs) cs_assault.bsp
            StringReader readMessage = new StringReader(message);
            string line;
            while ((line = readMessage.ReadLine()) != null) {
                if (line.Contains(GlobalConstants.MAPEXTENSION)) {
                    bool success = false;
                    int secondIdx = line.LastIndexOf(GlobalConstants.MAPEXTENSION);
                    if (secondIdx != -1) {
                        int firstIdx = line.LastIndexOf(" ") + 1;
                        if (firstIdx < secondIdx) {
                            resultList.Add(line.Substring(firstIdx, secondIdx - firstIdx));
                            success = true;
                        }
                    }
                    if (!success) {
                        Exception ex = new Exception("wrong message received.");
                        ex.Data.Add("message", message);
                        throw ex;
                    }
                }
            }
            return resultList;
        }

        /// <summary>
        /// Receive message from server
        /// throws exception, if no message received
        /// </summary>
        /// <param name="filter">filter out message, leave empty for no filter</param>
        /// <returns>recieved message</returns>
        public static string Receive(string filter = null) {
            SourceRconConnection rcon = SourceRconConnection.Instance;
            string message      = null;
            int tries           = 0;
            bool msgReceived    = false;

            while (!msgReceived && tries++ < GlobalConstants.RCON_RECEIVE_TRIES) {
                message = rcon.lastMessage;
                if (!String.IsNullOrEmpty(message)) {
                    if (!String.IsNullOrEmpty(filter) && message.Contains(filter) || String.IsNullOrEmpty(filter)) {
                        msgReceived = true;
                    }
                }
                Thread.Sleep(GlobalConstants.RCON_RECEIVE_WAIT);
            }
            if (String.IsNullOrEmpty(message) || !msgReceived) {
                Exception ex = new Exception("wrong answer from server.");
                ex.Data.Add("filter", filter);
                ex.Data.Add("message", message);
                throw ex;
            }
            return message;
        }

        /// <summary>
        /// Kick player from server
        /// </summary>
        /// <param name="userId">steamid of user</param>
        /// <param name="message">message to kick (optional)</param>
        public static void KickPlayer(Player player, string message = GlobalConstants.RCON_DEFAULT_KICKMSG) {
            SourceRconConnection rcon = SourceRconConnection.Instance;
            rcon.Send(String.Format(GlobalConstants.RCONCMD_KICKID, player.id, message));
        }

        /// <summary>
        /// Ban player from server
        /// </summary>
        /// <param name="player">player to ban</param>
        /// <param name="banBy">0 = Ban ID, 1 = Ban IP, 2 = Ban IP+ID</param>
        /// <param name="time">time how long a player is banned (0 for permanent)</param>
        /// <param name="kick">kick player</param>
        public static void BanPlayer(Player player, int banBy, int time, bool kick) {
            SourceRconConnection rcon = SourceRconConnection.Instance;
            if (banBy == 0 || banBy == 2) {
                rcon.Send(String.Format(GlobalConstants.RCONCMD_BANID, time, player.id, (kick ? "kick" : "")));
                rcon.Send(String.Format(GlobalConstants.RCONCMD_WRITEID));
            } 
            if (banBy == 1 || banBy == 2) {
                rcon.Send(String.Format(GlobalConstants.RCONCMD_BANIP, time, player.id));
                rcon.Send(String.Format(GlobalConstants.RCONCMD_WRITEIP));
            }
        }

        /// <summary>
        /// Change map on server
        /// </summary>
        /// <param name="map">map</param>
        public static void ChangeMap(string map) {
            SourceRconConnection rcon = SourceRconConnection.Instance;
            rcon.Send(String.Format(GlobalConstants.RCONCMD_CHANGELEVEL, map));
        }

        /// <summary>
        /// Restart 3 times, self or zblock
        /// </summary>
        public static void Restart3() {
            SourceRconConnection rcon = SourceRconConnection.Instance;
            try {
                if (Settings.Default.UseZblock && CheckForZblock()) {
                    rcon.Send(GlobalConstants.RCONCMD_ZB_RESTART);
                } else {
                    Thread threadRestart = new Thread(delegate() { DoRestart3(); });
                    threadRestart.Start();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        //*************************************************
        // Private helpter methods
        //*************************************************

        /// <summary>
        /// Do a 3 times restart
        /// </summary>
        private static void DoRestart3() {
            SourceRconConnection rcon = SourceRconConnection.Instance;
            rcon.Send(String.Format(GlobalConstants.RCONCMD_RESTART, "1"));
            Thread.Sleep(1100);
            rcon.Send(String.Format(GlobalConstants.RCONCMD_RESTART, "1"));
            Thread.Sleep(1100);
            rcon.Send(String.Format(GlobalConstants.RCONCMD_RESTART, "3"));
            Thread.Sleep(3000);
            for (int i = 0; i < 8; i++) rcon.Send(String.Format(GlobalConstants.RCONCMD_CHATSAY, GlobalConstants.RESTARTMSG_HFGL));
        }

        /// <summary>
        /// Check if zBlock is installed and active on server
        /// </summary>
        /// <returns>true if zBlock is installed and active</returns>
        private static bool CheckForZblock() {
            SourceRconConnection rcon = SourceRconConnection.Instance;
            bool result = false;

            string message = null;
            rcon.Send(GlobalConstants.RCONCMD_ZBLOCK);
            try {
                message = Receive(GlobalConstants.RCONCMD_ZBLOCK);
            } catch (Exception ex) {
                throw ex;
            }

            //"zb_active" = "1" min. 0.000000 max. 1.000000
            if (message.Contains(GlobalConstants.RCONCMD_ZBLOCK) && message[15] == '1') {
                result = true;
            }

            return result;
        }
    }
}
