using RCONManager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RCONManager {
    public class RconConnection {
        
        // Singleton
        private static RconConnection instance;
        public static RconConnection Instance {
            get {
                if (instance == null) {
                    instance = new RconConnection();
                }
                return instance;
            }
        }

        //*****************************
        // Variables
        //*****************************
        private SourceRcon.SourceRcon srcRcon = null;
        Thread ConnectThread;

        public string connectedIP { get; set; }
        public string lastMessage { get; set; }

        public delegate void StringHandler(string str);
        public delegate void VoidHandler();
        public delegate void StateHandler(OnlineState state);
        public event StringHandler ErrorEvent;
        public event VoidHandler OnlineStateEvent;

        public enum OnlineState {
            Connected,
            Connecting,
            Disconnected
        };

        //*****************************
        // CTor
        //*****************************
        private RconConnection() { }


        //***************************************
        // Methods
        //***************************************
        public void Connect() {
            if (!String.IsNullOrEmpty(Settings.Default.RconIP)) {
                connectedIP = Settings.Default.RconIP;
                srcRcon = null;
                srcRcon = new SourceRcon.SourceRcon();
                srcRcon.Errors += new SourceRcon.StringOutput(ErrorOutput);
                srcRcon.ServerOutput += new SourceRcon.StringOutput(ConsoleOutput);
                srcRcon.ConnectionSuccess += new SourceRcon.BoolInfo(ConnectionSuccessInfo);
                OnlineStateEvent();
                ConnectThread = new Thread(delegate() { srcRcon.Connect(new IPEndPoint(IPAddress.Parse(Settings.Default.RconIP), Settings.Default.RconPort), Settings.Default.RconPW); });
                ConnectThread.Start();
            }
        }

        public void Disconnect() {
            connectedIP = null;
            srcRcon = null;
            OnlineStateEvent();
        }

        public OnlineState GetState() {
            if (srcRcon != null && srcRcon.Connected) return OnlineState.Connected;
            if (srcRcon != null && !srcRcon.Connected) return OnlineState.Connecting;
            return OnlineState.Disconnected;
        }

        public void Send(string cmd) {
            srcRcon.ServerCommand(cmd);
        }

        //***************************************
        // Event Receivers
        //***************************************
        private void ErrorOutput(string output) {
             ErrorEvent(output);
        }

        private void ConsoleOutput(string output) {
            lastMessage = output;
        }

        private void ConnectionSuccessInfo(bool info) {
            if (info) OnlineStateEvent();
            else Disconnect();
        }
    }
}
