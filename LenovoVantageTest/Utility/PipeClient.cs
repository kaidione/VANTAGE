using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Text;

namespace LenovoVantageTest
{
    /// <summary>
    /// 主要代码来自Microsoft。
    /// </summary>
    /// <Author>Marcus</Author>
    class PipeClient
    {
        string lastErr = "";
        public PipeClient()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal windowsPrincipal = new WindowsPrincipal(identity);
                if (!windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    throw new Exception("This program requires administrator rights");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_sJsonContractSent2Server">要发给Vantage工具的命令</param>
        /// <param name="_callbackWhenReceivedACommandFromServer">从Vantage工具返回的结果</param>
        /// <returns></returns>
        public bool CommunicateWithServer(string _sJsonContractSent2Server, Action<string> _callbackWhenReceivedACommandFromServer)
        {


            var pipeClient =
                new NamedPipeClientStream(".", "testpipe",
                    PipeDirection.InOut, PipeOptions.None,
                    TokenImpersonationLevel.Impersonation);

            Console.WriteLine("Connecting to server...\n");
            try
            {
                pipeClient.Connect(5000);
                var ss = new StreamString(pipeClient);
                string commandFromServer = ss.ReadString();
                // Validate the server's signature string.
                if (commandFromServer.Equals("AutomationCommunicationStart"))
                {
                    // The client security token is sent with the first write.
                    // Send the name of the file whose contents are returned
                    // by the server.
                    ss.WriteString(_sJsonContractSent2Server);
                    commandFromServer = ss.ReadString();
                    if (_callbackWhenReceivedACommandFromServer != null)
                    {
                        _callbackWhenReceivedACommandFromServer(commandFromServer);
                    }
                }
                else
                {
                    Console.WriteLine("Server could not be verified.");
                    return false;
                }
            }
            catch (TimeoutException)
            {
                lastErr = "Timeout to connect 2 server , 1 second";
                return false;
            }
            catch (ServerClosedException)
            {
                lastErr = "Server Closed";
                return false;
            }
            finally
            {
                pipeClient.Close();
            }

            return true;
        }

    }

    // Defines the data protocol for reading and writing strings on our stream.
    public class StreamString
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len;
            len = ioStream.ReadByte() * 256;
            if (len < 0)
            {
                throw new ServerClosedException();
            }
            len += ioStream.ReadByte();
            var inBuffer = new byte[len];
            ioStream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            int len = outBuffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            ioStream.WriteByte((byte)(len / 256));
            ioStream.WriteByte((byte)(len & 255));
            ioStream.Write(outBuffer, 0, len);
            ioStream.Flush();

            return outBuffer.Length + 2;
        }
    }
    public class ServerClosedException : Exception
    {

    }
}
