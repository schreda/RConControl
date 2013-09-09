using RConControl.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RConControl {
    public class SourceRconConnection {
        
        // Singleton
        private static SourceRconConnection instance;
        public static SourceRconConnection Instance {
            get {
                if (instance == null) {
                    instance = new SourceRconConnection();
                }
                return instance;
            }
        }

        //*************************************************
        // Variables
        //*************************************************
        public string connectedIP { get; set; }
        public string lastMessage { get; set; }

        public delegate void StringHandler(string str);
        public delegate void VoidHandler();
        public delegate void StateHandler(State state);
        public event StringHandler ErrorEvent;
        public event VoidHandler OnlineStateEvent;

        public enum State {
            Connected,
            Connecting,
            Disconnected
        };

        private SourceRcon.SourceRcon srcRcon = null;
        private Language mLangMan = Language.Instance;
        private Thread threadConnect;
        private int reconnectTries = 0;
        private bool isConnected = false; // true, if server is really connected. false if under reconnecting

        //*************************************************
        // CTor
        //*************************************************
        private SourceRconConnection() { }

        //*************************************************
        // Methods
        //*************************************************
        public void Connect() {
            if (!String.IsNullOrEmpty(Settings.Default.RconIP)) {
                isConnected                = false;
                connectedIP                = Settings.Default.RconIP;
                srcRcon                    = null;
                srcRcon                    = new SourceRcon.SourceRcon();
                srcRcon.Errors            += new SourceRcon.StringOutput(OnError);
                srcRcon.ServerOutput      += new SourceRcon.StringOutput(ConsoleOutput);
                srcRcon.ConnectionSuccess += new SourceRcon.BoolInfo(ConnectionSuccessInfo);
                threadConnect = new Thread(delegate() { srcRcon.Connect(new IPEndPoint(IPAddress.Parse(Settings.Default.RconIP), Settings.Default.RconPort), Settings.Default.RconPW); });
                threadConnect.IsBackground = true;
                threadConnect.Start();
                OnlineStateEvent();
            }
        }

        public void Disconnect() {
            connectedIP    = null;
            srcRcon        = null;
            reconnectTries = 0;
            isConnected    = false;
            OnlineStateEvent();
        }

        public State GetState() {
            if (srcRcon != null) {
                if (isConnected) return State.Connected;
                else return State.Connecting;
            }
            return State.Disconnected;
        }

        public void Send(string cmd) {
            srcRcon.ServerCommand(cmd);
        }

        //*************************************************
        // Event Receivers
        //*************************************************
        private void OnError(string output) {
            if (srcRcon != null) {
                if (!srcRcon.Connected && reconnectTries == 0) {
                    Disconnect();
                    ErrorEvent(output);
                } else {
                    isConnected = false;
                    Reconnect();
                }
            }
        }

        private void ConsoleOutput(string output) {
            lastMessage = output;
        }

        private void Reconnect() {
            if (reconnectTries < GlobalConstants.RCON_RECONNECT_TRIES) {
                reconnectTries++;
                Connect();
                if (!isConnected) ErrorEvent(String.Format(mLangMan.GetString("Error_Reconnecting"), reconnectTries));
            } else {
                Disconnect();
                ErrorEvent(String.Format(mLangMan.GetString("Error_ReconnectFailed"), GlobalConstants.RCON_RECONNECT_TRIES));
            }
        }

        private void ConnectionSuccessInfo(bool info) {
            reconnectTries = 0;
            isConnected = true;
            OnlineStateEvent();
        }
    }
}
