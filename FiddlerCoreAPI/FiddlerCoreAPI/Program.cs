/*
* This demo program shows how to use the FiddlerCore library.
*/
using Fiddler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace FiddlerCoreAPIWrap
{
    public class FiddlerAgent
    {
        // NOTE: In the next line, you can pass 0 for the port (instead of 8877) to have FiddlerCore auto-select an available port
        private const ushort fiddlerCoreListenPort = 8877;

        public readonly ICollection<Session> sessions = new List<Session>();
        private readonly ReaderWriterLockSlim sessionsLock = new ReaderWriterLockSlim();

        private string fullurlToMonitor = "";

        private static readonly string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private string _givenurl = "";

        private string _ingoreList = "";
        private void Main()
        {
            AttachEventListeners();

            EnsureRootCertificate();

            StartupFiddlerCore();

            ExecuteUserCommands();

            Quit();
        }

        public void StartMonitor()
        {
            EnsureRootCertificate();
            StartupFiddlerCore();
            //fullurlToMonitor = url;        
        }

        //not used
        public void AttachEventListeners()
        {
            FiddlerApplication.OnNotification += (o, nea) => Console.WriteLine($"** NotifyUser: {nea.NotifyString}");

            FiddlerApplication.Log.OnLogString += (o, lea) => Console.WriteLine($"** LogString: {lea.LogString}");

            FiddlerApplication.BeforeRequest += session =>
            {
                session["X-AutoAuth"] = "(default)";
                System.Diagnostics.Debug.WriteLine(session.fullUrl + "    " + session.hostname + "   " + session.isHTTPS);
                System.Diagnostics.Debug.WriteLine(session.GetRequestBodyAsString());

                session.bBufferResponse = true;
                try
                {
                    sessionsLock.EnterWriteLock();
                    sessions.Add(session);
                }
                finally
                {
                    sessionsLock.ExitWriteLock();
                }

            };

            FiddlerApplication.AfterSessionComplete += session =>
            {
                Console.WriteLine($"Finished session: {session.fullUrl}");
                string requestOutput = ReadRequestFromSession(session);
                string responseOutput = ReadResponseFromSession(session);
                if (requestOutput != string.Empty)
                {
                    Console.WriteLine($"Request : {requestOutput}");
                }
                if (responseOutput != string.Empty)
                {
                    Console.WriteLine($"Response : {responseOutput}");
                }
            };
        }

        public void AttachEventListenersGivenUrl(string url, string noDecriptionList = "")
        {
            _givenurl = url;
            _ingoreList = noDecriptionList;
            FiddlerApplication.BeforeRequest += new SessionStateHandler(EventHandleGivenUrl);

        }

        public void EventHandleGivenUrl(Session session)
        {
            session["X-AutoAuth"] = "(default)";
            System.Diagnostics.Debug.WriteLine(session.fullUrl + "    " + session.hostname + "   " + session.isHTTPS);
            System.Diagnostics.Debug.WriteLine(session.GetRequestBodyAsString());
            session.bBufferResponse = true;
            if (session.HTTPMethodIs("CONNECT") && !isInList(session.hostname, _givenurl))
            {
                if (!isInList(session.hostname, _ingoreList))
                {
                    session["x-no-decrypt"] = "do not care.";
                }
            }
            bool isInlist = isInList(session.hostname, _givenurl);
            bool isFullurl = session.fullUrl.Contains("http://chifsr.lenovomm.com:443");
            string line = session.hostname + "-->" + _givenurl + "result-->" + isInlist + "\r\n"
                + session.fullUrl + "-->" + _givenurl + " result-->" + isFullurl + "\r\n";
            File.AppendAllText("c:\\filder_bj.txt", line);
            if (isInlist && isFullurl)
            {
                try
                {
                    sessionsLock.EnterWriteLock();
                    sessions.Add(session);
                }
                finally
                {
                    sessionsLock.ExitWriteLock();
                }
            }
        }

        public void AttachEventListenerForAutoResponse(string url, int responseCode)
        {
            FiddlerApplication.BeforeResponse += session =>
            {
                System.Diagnostics.Debug.WriteLine("BeforeResponse" + session.fullUrl);
                if (session.fullUrl.Contains(url))
                {
                    System.Diagnostics.Debug.WriteLine("BeforeResponse" + url + "403");
                    session.responseCode = responseCode;
                }
            };
        }
        public string ReadRequestFromSession(Session session)
        {
            string _requestInfo = string.Empty;
            if (string.IsNullOrEmpty(fullurlToMonitor) || session.fullUrl.Contains(fullurlToMonitor))
            {

                if (session.RequestMethod == "CONNECT")
                {
                    return _requestInfo;
                }

                if (session == null || session.oRequest == null || session.oRequest.headers == null)
                {
                    return _requestInfo;
                }
                // Request
                string headers = session.oRequest.headers.ToString();
                var reqBody = session.GetRequestBodyAsString();


                // replace the HTTP line to inject full URL
                string firstLine = session.RequestMethod + " " + session.fullUrl + " " + session.oRequest.headers.HTTPVersion;
                int at = headers.IndexOf("\r\n");
                if (at < 0)
                    return _requestInfo;
                headers = firstLine + "\r\n" + headers.Substring(at + 1);

                _requestInfo = headers + "\r\n" +
                                (!string.IsNullOrEmpty(reqBody) ? reqBody + "\r\n" : string.Empty) + "\r\n";

            }
            return _requestInfo;
        }


        public string ReadResponseFromSession(Session session)
        {
            string _responseInfo = string.Empty;
            if (string.IsNullOrEmpty(fullurlToMonitor) || session.fullUrl.Contains(fullurlToMonitor))
            {
                if (session.RequestMethod == "CONNECT")
                {
                    return _responseInfo;
                }

                if (session == null || session.oResponse == null || session.oResponse.headers == null)
                {
                    return _responseInfo;
                }
                // Response
                var resHeaders = session.oResponse.headers.ToString();
                var resBody = session.GetResponseBodyAsString();

                // if you wanted to capture the response
                string respHeaders = session.oResponse.headers.ToString();
                var respBody = session.GetResponseBodyAsString();

                _responseInfo = respHeaders + "\r\n" +
                                     (!string.IsNullOrEmpty(respBody) ? respBody + "\r\n" : string.Empty) + "\r\n\r\n";

            }
            return _responseInfo;
        }
        private static void EnsureRootCertificate()
        {
            BCCertMaker.BCCertMaker certProvider = new BCCertMaker.BCCertMaker();
            CertMaker.oCertProvider = certProvider;

            // On first run generate root certificate using the loaded provider, then re-use it for subsequent runs.
            string rootCertificatePath = Path.Combine(assemblyDirectory, "..", "..", "RootCertificate.p12");
            string rootCertificatePassword = "S0m3T0pS3cr3tP4ssw0rd";
            if (!File.Exists(rootCertificatePath))
            {
                certProvider.CreateRootCertificate();
                certProvider.WriteRootCertificateAndPrivateKeyToPkcs12File(rootCertificatePath, rootCertificatePassword);
            }
            else
            {
                certProvider.ReadRootCertificateAndPrivateKeyFromPkcs12File(rootCertificatePath, rootCertificatePassword);
            }

            // Once the root certificate is set up, ensure it's trusted.
            if (!CertMaker.rootCertIsTrusted())
            {
                CertMaker.trustRootCert();
            }
        }

        public void Quit()
        {
            if (FiddlerApplication.oProxy != null)
            {
                FiddlerApplication.oProxy.Detach();
            }
            FiddlerApplication.Shutdown();
            FiddlerApplication.BeforeRequest -= new SessionStateHandler(EventHandleGivenUrl);
            Thread.Sleep(1000);
        }

        private static void StartupFiddlerCore()
        {
            FiddlerCoreStartupSettings startupSettings =
                new FiddlerCoreStartupSettingsBuilder()
                    .ListenOnPort(fiddlerCoreListenPort)
                    .RegisterAsSystemProxy()
                    .ChainToUpstreamGateway()
                    .DecryptSSL()
                    .MonitorAllConnections()
                    .OptimizeThreadPool()
                    .Build();

            FiddlerApplication.Startup(startupSettings);
            FiddlerApplication.Log.LogString($"Created endpoint listening on port {CONFIG.ListenPort}");
        }

        private void ExecuteUserCommands()
        {
            bool done = false;
            do
            {
                Console.WriteLine("Enter a command [C=Clear; L=List; W=write SAZ; R=read SAZ; Q=Quit]:");
                Console.Write(">");
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                switch (char.ToLower(cki.KeyChar))
                {
                    case 'c':
                        try
                        {
                            sessionsLock.EnterWriteLock();
                            sessions.Clear();
                        }
                        finally
                        {
                            sessionsLock.ExitWriteLock();
                        }

                        Console.Title = $"Session list contains: 0 sessions";

                        WriteCommandResponse("Clear...");
                        FiddlerApplication.Log.LogString("Cleared session list.");
                        break;

                    case 'l':
                        WriteSessions(sessions);
                        break;

                    case 'w':
                        string password = null;
                        Console.WriteLine("Password Protect this Archive (Y/N)?");
                        ConsoleKeyInfo yesNo = Console.ReadKey();
                        if ((yesNo.KeyChar == 'y') || (yesNo.KeyChar == 'Y'))
                        {
                            Console.WriteLine($"{Environment.NewLine}Enter the password:");
                            password = Console.ReadLine();
                        }

                        Console.WriteLine();

                        SaveSessionsToDesktop(sessions, password);
                        break;

                    case 'r':
                        ReadSessions(sessions);

                        int sessionsCount;
                        try
                        {
                            sessionsLock.EnterReadLock();
                            sessionsCount = sessions.Count;
                        }
                        finally
                        {
                            sessionsLock.ExitReadLock();
                        }

                        Console.Title = $"Session list contains: {sessionsCount} sessions";

                        break;

                    case 'q':
                        done = true;
                        break;
                }
            } while (!done);
        }


        private void SaveSessionsToDesktop(IEnumerable<Session> sessions, string password)
        {
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
                Path.DirectorySeparatorChar + DateTime.Now.ToString("hh-mm-ss") + ".saz";

            string response;
            try
            {
                sessionsLock.EnterReadLock();
                if (sessions.Any())
                {
                    bool success = Utilities.WriteSessionArchive(filename, sessions.ToArray(), password, false);
                    response = $"{(success ? "Wrote" : "Failed to save")}: {filename}";
                }
                else
                {
                    response = "No sessions have been captured.";
                }
            }
            catch (Exception ex)
            {
                response = $"Save failed: {ex.Message}";
            }
            finally
            {
                sessionsLock.ExitReadLock();
            }

            WriteCommandResponse(response);
        }

        private void ReadSessions(ICollection<Session> sessions)
        {
            string sazFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar +
                "ToLoad.saz";

            Session[] loaded = Utilities.ReadSessionArchive(sazFilename, false, "", (file, part) =>
            {
                Console.WriteLine($"Enter the password for { part } (or just hit Enter to cancel):");
                string sResult = Console.ReadLine();
                Console.WriteLine();
                return sResult;
            });

            if (loaded == null || loaded.Length == 0)
            {
                WriteCommandResponse($"Could not load sessions from {sazFilename}");
                return;
            }

            try
            {
                sessionsLock.EnterWriteLock();
                for (int i = 0; i < loaded.Length; i++)
                {
                    sessions.Add(loaded[i]);
                }
            }
            finally
            {
                sessionsLock.ExitWriteLock();
            }

            WriteCommandResponse($"Loaded: {loaded.Length} sessions.");
        }

        private void WriteCommandResponse(string s)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ForegroundColor = oldColor;
        }

        private void WriteSessions(IEnumerable<Session> sessions)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder sb = new StringBuilder($"Session list contains:{Environment.NewLine}");
            try
            {
                sessionsLock.EnterReadLock();
                foreach (Session s in sessions)
                {
                    sb.AppendLine($"{s.id} {s.oRequest.headers.HTTPMethod} {Ellipsize(s.fullUrl, 60)}");
                    sb.AppendLine($"{s.responseCode} {s.oResponse.MIMEType}{Environment.NewLine}");
                }
            }
            finally
            {
                sessionsLock.ExitReadLock();
            }

            Console.Write(sb.ToString());
            Console.ForegroundColor = oldColor;
        }

        private static string Ellipsize(string text, int length)
        {
            if (Equals(text, null)) throw new ArgumentNullException(nameof(text));

            const int minLength = 3;

            if (length < minLength) throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be less than {minLength}");

            if (text.Length <= length) return text;

            return text.Substring(0, length - minLength) + new string('.', minLength);
        }

        private bool isInList(string host, string list)
        {
            if (string.IsNullOrEmpty(list))
            {
                return false;
            }
            string[] strList = list.Split(';');
            foreach (string str in strList)
            {
                if (!string.IsNullOrEmpty(str) && str.Contains(host))
                {
                    return true;
                }
            }
            return false;
        }

    }
}

