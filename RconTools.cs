using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using RCONManager.Properties;

namespace RCONManager {
    public class RconTools {

        /// <summary>
        /// Load config
        /// </summary>
        /// <param name="rcon">rcon instance</param>
        /// <param name="config">config</param>
        public static void LoadConfigFile(RconConnection rcon, ConfigFile config) {
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
        /// <param name="rcon">rocn instance</param>
        /// <returns>List with players</returns>
        public static List<ServerPlayer> GetAllPlayers(RconConnection rcon) {
            List<ServerPlayer> players = new List<ServerPlayer>();
            
            string message = null;
            rcon.Send(GlobalConstants.RCONCMD_STATUS);
            try {
                message = Receive(rcon, GlobalConstants.RCONMSG_FILTER_STATUS);
            } catch (Exception ex) {
                throw ex;
            }

            StringReader readMessage = new StringReader(message);
            string line;

            while ((line = readMessage.ReadLine()) != null) {
                //#      2 "!#.viivii"         STEAM_0:X:XXXXX   26:35       40    0 active XX.XX.XX.XX:27005
                if (line.Contains(GlobalConstants.STEAMID_PREFIX)) {
                    bool success = false;
                    int firstNameIdx  = line.IndexOf("\"") + 1;
                    int firstIdIdx    = line.IndexOf(GlobalConstants.STEAMID_PREFIX);
                    int secondIpIdx   = line.LastIndexOf(":");

                    if (firstNameIdx != -1 && firstIdIdx != -1 && secondIpIdx != -1) {
                        int secondNameIdx = line.IndexOf("\"", firstNameIdx);
                        int secondIdIdx   = line.IndexOf(" ", firstIdIdx);
                        int firstIpIdx    = line.LastIndexOf(" ", secondIpIdx) + 1;

                        if (secondNameIdx != -1 && secondIdIdx != -1) {
                            string userName = line.Substring(firstNameIdx, secondNameIdx - firstNameIdx);
                            string userId   = line.Substring(firstIdIdx, secondIdIdx - firstIdIdx);
                            string userIp   = line.Substring(firstIpIdx, secondIpIdx - firstIpIdx);
                            
                            players.Add(new ServerPlayer(userName, userId, userIp));
                            success = true;
                        }
                    }
                    if (!success) throw new Exception("wrong message received");
                }
            }                        
            return players;
        }

        /// <summary>
        /// Check if zBlock is installed and active on server
        /// </summary>
        /// <param name="rcon">rcon instance</param>
        /// <returns>true if zBlock is installed and active</returns>
        public static List<string> GetAllMaps(RconConnection rcon) {
            List<string> resultList = new List<string>();

            string message = null;
            rcon.Send(GlobalConstants.RCONCMD_MAPS);
            try {
                message = Receive(rcon, GlobalConstants.MAPEXTENSION);
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
                    if (!success) throw new Exception("wrong message received");
                }
            }

            return resultList;
        }

        /// <summary>
        /// Receive message from server
        /// throws exception, if no message received
        /// </summary>
        /// <param name="rcon">rcon instance</param>
        /// <param name="filter">filter out message, leave empty for no filter</param>
        /// <returns>recieved message</returns>
        public static string Receive(RconConnection rcon, string filter = null) {
            string message = null;
            int tries = 0;
            bool msgReceived = false;

            while (!msgReceived && tries++ < GlobalConstants.RCON_RECEIVE_TRIES) {
                message = rcon.lastMessage;
                if (!String.IsNullOrEmpty(message)) {
                    if (!String.IsNullOrEmpty(filter) && message.Contains(filter)) {
                        msgReceived = true;
                    } else if (String.IsNullOrEmpty(filter)) {
                        msgReceived = true;
                    }
                }
                Thread.Sleep(GlobalConstants.RCON_RECEIVE_WAIT);
            }
            if (String.IsNullOrEmpty(message) || !msgReceived) throw new Exception("no answer from server");
            return message;
        }

        /// <summary>
        /// Kick player from server
        /// </summary>
        /// <param name="rcon">rcon instance</param>
        /// <param name="userId">steamid of user</param>
        /// <param name="message">message to kick (optional)</param>
        public static void KickPlayer(RconConnection rcon, string userId, string message = GlobalConstants.RCON_DEFAULT_KICKMSG) {
            rcon.Send(String.Format(GlobalConstants.RCONCMD_KICKID, userId, message));
        }

        /// <summary>
        /// Change map on server
        /// </summary>
        /// <param name="rcon">rcon instance</param>
        /// <param name="map">map</param>
        public static void ChangeMap(RconConnection rcon, string map) {
            rcon.Send(String.Format(GlobalConstants.RCONCMD_CHANGELEVEL, map));
        }

        /// <summary>
        /// Restart 3 times, self or zblock
        /// </summary>
        /// <param name="rcon">rcon instance</param>
        public static void Restart3(RconConnection rcon) {
            try {
                if (Settings.Default.UseZblock && CheckForZblock(rcon)) {
                    rcon.Send(GlobalConstants.RCONCMD_ZB_RESTART);
                } else {
                    Thread threadRestart = new Thread(delegate() { DoRestart3(rcon); });
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
        /// <param name="rcon">rcon instance</param>
        private static void DoRestart3(RconConnection rcon) {
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
        /// <param name="rcon">rcon instance</param>
        /// <returns>true if zBlock is installed and active</returns>
        private static bool CheckForZblock(RconConnection rcon) {
            bool result = false;

            string message = null;
            rcon.Send(GlobalConstants.RCONCMD_ZBLOCK);
            try {
                message = Receive(rcon, GlobalConstants.RCONCMD_ZBLOCK);
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
