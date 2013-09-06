using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCONManager {
    public class ServerPlayer {
        //*****************************
        // Variables
        //*****************************
        public string name { get; set; }
        public string id { get; set; }
        public string ip { get; set; }

        //*****************************
        // CTor
        //*****************************
        public ServerPlayer(string userName, string userId, string userIp) {
            name = userName;
            id = userId;
            ip = userIp;
        }

        //*****************************
        // Methods
        //*****************************
        public override string ToString() {
            return name;
        }
    }
}