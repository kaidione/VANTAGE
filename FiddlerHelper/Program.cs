using Fiddler;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace FiddlerHelper
{
    public class FiddlerAgent
    {
        static string sSecureEndpointHostname;
        static int iSecureEndpointPort;
        BlockingCollection<Session> trafficListCaptured;
        public BlockingCollection<Session> TrafficListCaptured
        {
            get
            {
                return trafficListCaptured;
            }

            set
            {
                trafficListCaptured = value;
            }
        }
        public FiddlerAgent(string endPointHostName = "localhost", int endpointPort = 12345)
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                    throw new Exception("trusted root cert is not generated");

                if (!CertMaker.trustRootCert())
                    throw new Exception("trusted root cert is not added");
            }
            sSecureEndpointHostname = endPointHostName;
            iSecureEndpointPort = endpointPort;
        }
        public void DoQuit()
        {
            FiddlerApplication.Shutdown();
            Thread.Sleep(500);
        }
        public void StartMonitor(string appName, string url, string noDecryptList = "")
        {
            SetPassTraffic(appName);
            MonitorSessionByUrl(url, noDecryptList);
        }
        private void SetPassTraffic(string appName)
        {
            var acList = LoopUtil.PI_NetworkIsolationEnumAppContainers();
            foreach (var item in acList)
            {
                if (item.displayName.Contains(appName))
                {
                    LoopUtil.SID_AND_ATTRIBUTES arr = new LoopUtil.SID_AND_ATTRIBUTES();
                    int count = 0;
                    LoopUtil.AppContainer app = new LoopUtil.AppContainer(item.appContainerName, item.displayName, item.workingDirectory, item.appContainerSid);
                    arr.Attributes = 0;
                    //TO DO:
                    IntPtr ptr;
                    LoopUtil.ConvertStringSidToSid(app.StringSid, out ptr);
                    arr.Sid = ptr;
                    count++;
                    LoopUtil.NetworkIsolationSetAppContainerConfig(1, new LoopUtil.SID_AND_ATTRIBUTES[] { arr });
                }
            }
        }
        private void MonitorSessionByUrl(string url, string noDecryptList = "")
        {
            trafficListCaptured = new BlockingCollection<Session>();
            List<Session> allSessions = new List<Session>();
            FiddlerApplication.SetAppDisplayName("FiddlerCoreDemoApp");
            CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            FiddlerApplication.BeforeRequest += delegate (Session oS)
            {
                System.Diagnostics.Debug.WriteLine(oS.fullUrl + "    " + oS.hostname + "   " + oS.isHTTPS);
                System.Diagnostics.Debug.WriteLine(oS.GetRequestBodyAsString());
                if (oS.HTTPMethodIs("CONNECT") && !oS.HostnameIs(url))
                {
                    oS["x-no-decrypt"] = "do not care.";
                }
                oS.bBufferResponse = false;
                Monitor.Enter(allSessions);
                allSessions.Add(oS);
                Monitor.Exit(allSessions);
                if (oS.fullUrl.Contains("PCJson"))
                {
                    trafficListCaptured.Add(oS);
                }

            };
            FiddlerCoreStartupFlags oFCSF = FiddlerCoreStartupFlags.Default;
            FiddlerApplication.Startup(iSecureEndpointPort, oFCSF);
        }
    }
}

