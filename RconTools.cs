using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace RCONManager {
    public class RconTools {

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
                if (line.Contains(GlobalConstants.RCONMSG_FILTER_USERS)) {
                    bool success = false;
                    int firstNameIdx  = line.IndexOf("\"") + 1;
                    int firstIdIdx    = line.IndexOf("STEAM_");
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

        public static string Receive(RconConnection rcon, string filter) {
            string message = null;
            int tries = 0;
            bool correctMsgReceived = false;

            while (!correctMsgReceived && tries < GlobalConstants.RCON_RECEIVE_TRIES) {
                message = rcon.lastMessage;
                if (!String.IsNullOrEmpty(message) && message.Contains(filter)) {
                    correctMsgReceived = true;
                } else {
                    Thread.Sleep(GlobalConstants.RCON_RECEIVE_WAIT);
                    tries++;
                }
            }
            if (String.IsNullOrEmpty(message) || !correctMsgReceived) throw new Exception("no answer from server");
            return message;
        }

        public static void KickPlayer(RconConnection rcon, string userId, string message = GlobalConstants.RCON_DEFAULT_KICKMSG) {
            rcon.Send("kickid " + userId + " " + message);
        }

    }
}
