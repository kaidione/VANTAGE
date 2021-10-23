using LenovoVantageTest.Helper;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public class MultipleClientsSpecFlowFeatureSteps
    {
        [Given(@"Run Clients '(.*)' And Run Version '(.*)' Run Cat '(.*)'")]
        public void GivenRunClientsAndRunVersionRunCat(string p0, string p1, string p2)
        {
            try
            {
                string IP = p0;
                int port = 18888;
                IPAddress ip = IPAddress.Parse(IP);
                var clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                clientSocket.Connect(endPoint);
                string timeMark = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string runCase = string.Format(timeMark + ", " + "nunit3-console.exe C:\\LenovoVantageTest\\SpecflowTest\\LenovoVantageTest.dll --testparam \"{0}\" --where \"{1}\"", p1, p2, IP);
                Console.WriteLine("Begin Send Message: " + runCase);
                byte[] message = Encoding.ASCII.GetBytes(runCase);
                clientSocket.Send(message);
                Console.WriteLine("Send Message is :" + Encoding.ASCII.GetString(message));
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [When(@"Run Server On '(.*)' User make from DC to AC Use Server '(.*)' id")]
        public void WhenRunServerOnUserMakeFromDCToACUseServerId(string p0, string p1)
        {
            try
            {
                if (!VantageCommonHelper.JudgeInsertStatusIsOn())
                {
                    bool result = VantageCommonHelper.SendCommandToACDCServer(p0, p1);
                }
                Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn(), "Failed from DC to AC");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [When(@"Run Server On '(.*)' User make from AC to DC Use Server '(.*)' id")]
        public void WhenRunServerOnUserMakeFromACToDCUseServerId(string p0, string p1)
        {
            try
            {
                bool result = false;
                if (VantageCommonHelper.JudgeInsertStatusIsOn())
                {
                    result = VantageCommonHelper.SendCommandToACDCServer(p0, p1);
                }
                Assert.IsTrue(result, "Failed from AC to DC");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
