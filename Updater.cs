using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RConControl {
    public class Updater {

        //*************************************************
        // Variables
        //*************************************************
        public string XmlUri { get; set; }

        private WebClient myWebClient = null;
        private XmlDocument xdoc = null;
        private Language mLangMan = Language.Instance;

        private bool Loaded {
            get { return xdoc != null; }
        }

        //*************************************************
        // Initialization
        //*************************************************
        public Updater(string xmlUri) {
            this.XmlUri = xmlUri;
            myWebClient = new WebClient();
            Load();
        }

        //*************************************************
        // Methods
        //*************************************************
        private void Load() {
            byte[] bytes = myWebClient.DownloadData(XmlUri);
            string xml;
            int codepage;
            int offset = 0;
            if (bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF) {
                codepage = 65001;   // UTF-8
                offset = 3;
            } else if (bytes[0] == 0xFF && bytes[1] == 0xFE) {
                codepage = 1200;   // UTF-16LE
                offset = 2;
            } else if (bytes[0] == 0xFE && bytes[1] == 0xFF) {
                codepage = 1201;   // UTF-16BE
                offset = 2;
            } else {
                codepage = 28591;  // ISO-8859-1
            }
            xml = Encoding.GetEncoding(codepage).GetString(bytes, offset, bytes.Length - offset);

            xdoc = new XmlDocument();
            try {
                xdoc.LoadXml(xml);
            } catch (XmlException ex) {
                xdoc = null;
                throw new ApplicationException(mLangMan.GetString("Updater_ErrorLoadingXML"), ex);
            }

            if (xdoc.DocumentElement == null) {
                xdoc = null;
                throw new ApplicationException(mLangMan.GetString("Updater_XMLIncomplete"));
            }
        }

        /// <summary>
        /// Returns the app name out of the XML file
        /// </summary>
        public string AppName {
            get {
                if (xdoc == null || xdoc.DocumentElement == null) return "";
                XmlNode appNode = xdoc.DocumentElement.SelectSingleNode("appname");
                if (appNode == null) return "";
                return appNode.InnerText;
            }
        }

        /// <summary>
        /// Returns the actual program version
        /// </summary>
        public string LatestVersion {
            get {
                if (xdoc == null || xdoc.DocumentElement == null) return "";
                XmlNode latestNode = xdoc.DocumentElement.SelectSingleNode("latest");
                if (latestNode == null) return "";
                return latestNode.InnerText;
            }
        }

        /// <summary>
        /// Returns true, if a newer version is available
        /// </summary>
        public bool NewerAvailable {
            get {
                Assembly me = Assembly.GetCallingAssembly();
                return me.GetName().Version.CompareTo(new Version(LatestVersion)) < 0;
            }
        }

        /// <summary>
        /// Compare a given version string with the latest available version and indicate whether
        /// the latest available is newer than the given compare string.
        /// </summary>
        public bool IsNewer(string compareTo) {
            if (LatestVersion == "") return false;
            if (compareTo == "") return true;
            return new Version(compareTo).CompareTo(new Version(LatestVersion)) < 0;
        }

        /// <summary>
        /// Returns the website out of the XML file
        /// </summary>
        public string Website {
            get {
                if (xdoc == null || xdoc.DocumentElement == null) return "";
                XmlNode websiteNode = xdoc.DocumentElement.SelectSingleNode("website");
                if (websiteNode == null) return "";
                return websiteNode.InnerText;
            }
        }

        /// <summary>
        /// Open the specific website
        /// </summary>
        public void OpenWebsite() {
            string uri = Website;
            if (uri.StartsWith("http://") || uri.StartsWith("https://"))
                Process.Start(uri);
            else
                throw new ApplicationException(mLangMan.GetString("Updater_InvalidWebsite") + ": " + uri);
        }
    }
}