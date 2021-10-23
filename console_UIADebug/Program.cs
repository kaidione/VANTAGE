using interop.UIAutomationCore;
using LenovoVantageTest.Utility.UIAImplementation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace console_UIADebug
{
    class Program
    {
        static CUIAutomation8 cUIAutomation8 = new CUIAutomation8();
        static IUIAutomationTreeWalker rawTreeWalker = cUIAutomation8.CreateTreeWalker(cUIAutomation8.RawViewCondition);
        public static void Main(string[] _args)
        {
            //printVantage();
            SearchName(_args);
        }
        static void SearchName(string[] _args)
        {
            Console.WriteLine("Usage:MyProgram <FunctionName> arg1 arg2 ...");
            Console.WriteLine("Example: SearchNameUsingWindowNameInAnApp \"window name\" \"TimeoutInSeconds\" \"an name\" ");
            Console.WriteLine("Example:SetValue4ElementUsingCustomXPath \"/Window[@Name=['aName']//*[@AutomationId='aId']\" \"10\" \"value to input\"");
            Console.WriteLine("Example:ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition TimeoutInSeconds \"/Window[@Name='Lenovo Vantage']//*[@AutomationId='1']\" \"/Window[@Name='Lenovo Vantage']//*[@AutomationId='2']\" \"/Window[@Name='Lenovo Vantage']//*[@AutomationId='N']\"  ");
            Console.WriteLine("Example: MouseFocusElementUsingCustomXPath \"/Window[@Name='xx']//*[@Name='yy']\" \"TimeoutInSeconds\"");
            Console.WriteLine("Example: SimulateMouseClickGUIElement \"/Window[@Name='xx']//*[@Name='yy']\" \"TimeoutInSeconds\"");
            Console.WriteLine("Example:SearchNameUsingProcessIdInAnApp \"ProcessId4App\" \"Searching Name\"");
            Console.WriteLine("Example: ElementExistUsingCustomXPath \"/Window[@Name='xx']//*[@AutomationId='a id']\" \"TimeoutInSeconds\"");
            Console.WriteLine($"Usage1: ClickElementUsingCustomXPath \"/Window[@Name='xxx']//*[@AutomationId='aId']\" \"TimeoutInSeconds\"");
            Console.WriteLine("Example:ElementIsToggleedUsingCustomXPath \"/Window[@Name='AnotherAPPName']//*[@AutomationId='AId']\"");
            if (_args.Length < 2)
            {
                Console.WriteLine("arg0 must be function name , case insensitive.  arg1 to arg N are passed in parameters");
                Environment.Exit(-100);
            }
            bool result = false; int toggle = -1;
            switch (_args[0])
            {
                case "SearchNameUsingProcessIdInAnApp":
                    Console.WriteLine("Usage1: SearchNameUsingProcessIdInAnApp \"ProcessId\" \"the name\" \"TimeoutInSeconds\"");
                    Console.WriteLine("Usage2: SearchNameUsingProcessIdInAnApp \"ProcessId\" \"the name\"");
                    if (_args.Length < 3)
                    {
                        Console.WriteLine("At least 2 args are reqired");
                        break;
                    }
                    if (System.IO.File.Exists(_args[3]))
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(_args[3], System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(fs, Encoding.UTF8))
                        {
                            string searchName = sr.ReadToEnd().Replace("\r\n", "\n");//Marcus: on text control ,the string shows with \n , NOT \r\n
                            result = _args.Length == 3 ? RawTreeTraverser.SearchNameInAnApp(Convert.ToInt32(_args[1]), _args[2]) : RawTreeTraverser.SearchNameInAnApp(Convert.ToInt32(_args[1]), searchName, Convert.ToInt32(_args[3]));
                            Console.WriteLine($"Searching Process={_args[1]} , Searching name for element={searchName}");
                        }
                    }
                    else
                    {
                        result = _args.Length == 3 ? RawTreeTraverser.SearchNameInAnApp(Convert.ToInt32(_args[1]), _args[2]) : RawTreeTraverser.SearchNameInAnApp(Convert.ToInt32(_args[1]), _args[2], Convert.ToInt32(_args[3]));
                        Console.WriteLine($"Searching Process={_args[1]} , Searching name for element={_args[2]}");
                    }


                    Console.WriteLine("Search result=" + result);
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }

                    break;
                case "SearchNameUsingWindowNameInAnApp":

                    if (_args.Length < 3)
                    {
                        Console.WriteLine("At least 2 arg is reqired");
                        break;
                    }

                    if (System.IO.File.Exists(_args[3]))
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(_args[3], System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(fs, Encoding.UTF8))
                        {
                            string searchName = sr.ReadToEnd().Replace("\r\n", "\n");//Marcus: on text control ,the string shows with \n , NOT \r\n
                            result = _args.Length == 3 ? RawTreeTraverser.SearchNameInAnApp(_args[1], _args[2]) : RawTreeTraverser.SearchNameInAnApp(_args[1], searchName, Convert.ToInt32(_args[2]));
                            Console.WriteLine($"Searching APP={_args[1]} , Searching name for element={searchName}");
                        }
                    }
                    else
                    {
                        result = _args.Length == 3 ? RawTreeTraverser.SearchNameInAnApp(_args[1], _args[2]) : RawTreeTraverser.SearchNameInAnApp(_args[1], _args[3], Convert.ToInt32(_args[2]));
                        Console.WriteLine($"Searching APP={_args[1]} , Searching name for element={_args[2]}");
                    }

                    Console.WriteLine("Search result=" + result);
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }

                    break;
                case "ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition":

                    if (_args.Length < 3)
                    {
                        Console.WriteLine("2 args are reqired");
                        break;
                    }
                    int parsedInt;
                    if (!int.TryParse(_args[1], out parsedInt))
                    {
                        Console.WriteLine("1st parameter must be timeout unit , like 10");
                        break;
                    }
                    int timeoutInSeconds = Convert.ToInt32(_args[1]);
                    string[] xpathes = new string[_args.Length - 2];
                    for (int i = 2; i < _args.Length; i++)
                    {
                        xpathes[i - 2] = _args[i];
                    }
                    int whichOneMeet = -1;
                    whichOneMeet = UIAHelper.ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(xpathes, timeoutInSeconds);
                    Console.WriteLine($"which element meet requirement={whichOneMeet}");
                    if (whichOneMeet > -1)
                    {
                        Environment.Exit(whichOneMeet);
                    }
                    else
                    {
                        Environment.Exit(-1);
                    }
                    break;

                case "MouseFocusElementUsingCustomXPath":

                    Console.WriteLine("Usage2: MouseFocusElementUsingCustomXPath \"/Window[@Name='xx']//*[@Name='yy']\"");
                    if (_args.Length < 2)
                    {
                        Console.WriteLine("At least 1 arg is reqired");
                        break;
                    }
                    Console.WriteLine($"MouseFocusElementUsingCustomXPath ,Id={_args[1]} ");
                    result = _args.Length == 2 ? UIAHelper.MouseFocusElementUsingCustomXPath(_args[1]).ToLower().Equals("true") : UIAHelper.MouseFocusElementUsingCustomXPath(_args[1], Convert.ToInt32(_args[2])).ToLower().Equals("true");
                    Console.WriteLine($"result={result}");
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;
                case "SimulateMouseClickGUIElement":

                    Console.WriteLine("Usage2: SimulateMouseClickGUIElement \"/Window[@Name='xx']//*[@Name='yy']\"");
                    if (_args.Length < 2)
                    {
                        Console.WriteLine("At least 1 arg is reqired");
                        break;
                    }
                    Console.WriteLine($"SimulateMouseClickGUIElement ,Id={_args[1]} ");
                    result = _args.Length == 2 ? UIAHelper.SimulateMouseClickGUIElement(_args[1]) : UIAHelper.SimulateMouseClickGUIElement(_args[1], Convert.ToInt32(_args[2]));
                    Console.WriteLine($"result={result}");
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;

                case "ElementExistUsingCustomXPath":

                    Console.WriteLine($"Usage: ElementExistUsingCustomXPath \"/Window[@Name='xx']//*[@AutomationId='a id']\"");
                    if (_args.Length < 2)
                    {
                        Console.WriteLine("At least 1 arg is reqired");
                        break;
                    }
                    Console.WriteLine($"ElementExistUsingCustomXPath , XPath={_args[1]}");
                    result = _args.Length == 2 ? UIAHelper.ElementExistUsingCustomXPath(_args[1]) : UIAHelper.ElementExistUsingCustomXPath(_args[1], Convert.ToInt32(_args[2]));

                    Console.WriteLine($"result={result}");
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;
                case "ElementExistUsingCustomXPathInSecondsWithSpecificProcessName":
                    if (_args.Length < 4)
                    {
                        Console.WriteLine("3 args are reqired: arg1-XPath like /Window[@ProcessId='{0}']//Button arg2-TimeoutInSecons arg3-processName");
                        break;
                    }
                    Console.WriteLine($"ElementExistUsingCustomXPathInSecondsWithSpecificProcessName , XPath={_args[1]} , ProcessName={_args[3]}");
                    result = UIAHelper.ElementExistUsingCustomXPathInSecondsWithSpecificProcessName(_args[1], Convert.ToInt32(_args[2]), _args[3]);

                    Console.WriteLine($"result={result}");
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;
                case "ClickElementUsingCustomXPath":

                    Console.WriteLine($"Usage2: ClickElementUsingCustomXPath \"/Window[@Name='xxx']//*[@AutomationId='aId']\"");
                    if (_args.Length < 2)
                    {
                        Console.WriteLine("At least 1 arg is reqired");
                        break;
                    }
                    Console.WriteLine($"ClickElementUsingCustomXPath , XPath={_args[1]}");
                    result = _args.Length == 2 ? UIAHelper.ClickElementUsingCustomXPath(_args[1]).ToLower().Equals("true") : UIAHelper.ClickElementUsingCustomXPath(_args[1], Convert.ToInt32(_args[2])).ToLower().Equals("true");

                    Console.WriteLine($"result={result}");
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;
                case "ClickElementUsingCustomXPathWithSpecificProcessName":
                    Console.WriteLine("Usage: ClickElementUsingCustomXPathWithSpecificProcessName \"/Window[@ProcessId='{0}']//Button\" \"TimeoutInSeconds\" \"processName\"");
                    if (_args.Length < 4)
                    {
                        Console.WriteLine("3 args are reqired: arg1-XPath like /Window[@ProcessId='{0}']//Button arg2-TimeoutInSecons arg3-processName");
                        break;
                    }
                    Console.WriteLine($"ClickElementUsingCustomXPathWithSpecificProcessName , XPath={_args[1]} , ProcessName={_args[3]}");
                    result = UIAHelper.ClickElementUsingCustomXPathWithSpecificProcessName(_args[1], Convert.ToInt32(_args[2]), _args[3]).ToLower().Equals("true");

                    Console.WriteLine($"result={result}");
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;
                case "ElementIsToggleedUsingCustomXPath":
                    Console.WriteLine("Usage:ElementIsToggleedUsingCustomXPath \"YourCustomXPath\" \"TimeoutInSeconds\"");
                    Console.WriteLine("Usage:ElementIsToggleedUsingCustomXPath \"/Window[@Name=['aName']//*[@AutomationId='aId']\" \"10\"");
                    Console.WriteLine($"ElementIsToggleedUsingCustomXPath , XPath={_args[1]}");
                    toggle = _args.Length == 2 ? UIAHelper.ElementIsToggledUsingCustomXPath(_args[1]) : UIAHelper.ElementIsToggledUsingCustomXPath(_args[1], Convert.ToInt32(_args[2]));

                    Console.WriteLine($"result={toggle}");
                    Environment.Exit(toggle);
                    break;
                case "SetValue4ElementUsingCustomXPath":

                    if (_args.Length < 4)
                    {
                        Console.WriteLine("at least 3 args");
                        break;
                    }
                    Console.WriteLine($"SetValue4ElementUsingCustomXPath , XPath={_args[1]} value={_args[3]}");

                    result = UIAHelper.SetValue4ElementUsingCustomXPath(_args[1], _args[3], Convert.ToInt32(_args[2])).ToLower().Equals("true");

                    Console.WriteLine($"result={result}");
                    if (result)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;
                case "GetElementsInformationByXPath":
                    Console.WriteLine($"Usage: GetElementsInformationByXPath \"c:\\users\\<YourAccountName>\\AppData\\Local\\Temp\\UIAElementsInformation.json\" 10 \"/Window[@Name='xx']//*[@AutomationId='a id']\"");
                    if (_args.Length < 2)
                    {
                        Console.WriteLine("At least 3 arg is reqired , 1st is the file where information is saved , 2nd is timeout to search UI elements , 3rd is XPath to search");
                        break;
                    }
                    Console.WriteLine($"GetElementsInformationByXPath , XPath={_args[2]}");
                    List<IUIAutomationElement> elements = UIAHelper.SearchForElementsAndDoSth(_args[3], Convert.ToInt32(_args[2]));

                    Console.WriteLine($"found {elements} matched GUI elements");
                    if (elements.Count > 0)
                    {
                        if (OutPutInformaiont(_args[1], elements))
                        {
                            Environment.Exit(0);
                        }

                    }
                    Environment.Exit(1);
                    break;
                default:
                    throw new Exception("wrong function number !!");
            }

            Environment.Exit(-1);
        }
        static bool OutPutInformaiont(string _filepath, List<IUIAutomationElement> _elements)
        {
            try
            {
                if (File.Exists(_filepath))
                {
                    File.Delete(_filepath);
                }
                JArray jArray = new JArray();
                foreach (var item in _elements)
                {
                    JObject jObject = new JObject();
                    jObject["CurrentNativeWindowHandle"].Replace((JToken)item.CurrentNativeWindowHandle.ToInt32());
                    jArray.Add(jObject);
                }
                using (FileStream fs = new FileStream(_filepath, FileMode.Open, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(jArray.ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        static void printVantage()
        {
            IUIAutomationElement app = rawTreeWalker.GetFirstChildElement(cUIAutomation8.GetRootElement());
            printAPP(app);
            Console.Read();
        }
        static void printAPP(IUIAutomationElement _app)
        {
            if (!_app.CurrentName.Equals("Lenovo Vantage"))
            {
                IUIAutomationElement nextAPP = rawTreeWalker.GetNextSiblingElement(_app);
                printAPP(nextAPP);
            }
            else
            {
                IUIAutomationElement firstChild = rawTreeWalker.GetFirstChildElement(_app);
                printAllChildren(firstChild);
            }

        }
        static void printAllChildren(IUIAutomationElement _element)
        {
            /*先打印可用于debug的info*/
            if (_element.CurrentName != null && !_element.CurrentName.Equals("") && _element.CurrentAutomationId != null && !_element.CurrentAutomationId.Equals(""))
            {
                Console.WriteLine($"CurrentName={_element.CurrentName} , AutomationId={_element.CurrentAutomationId}");
            }
            else if ((_element.CurrentName == null || _element.CurrentName.Equals("")) && _element.CurrentAutomationId != null && !_element.CurrentAutomationId.Equals(""))
            {
                Console.WriteLine($"CurrentName=null , AutomationId= {_element.CurrentAutomationId}");
            }
            else if (_element.CurrentName != null && !_element.CurrentName.Equals("") && (_element.CurrentAutomationId == null || _element.CurrentAutomationId.Equals("")))
            {
                Console.WriteLine($"CurrentName={_element.CurrentName} , AutoamtionId=null");
            }
            else
            {
                Console.WriteLine($"CurrentName=null , AutoamtionId=null");

            }
            /*深度优先*/
            /*先看看有没有children，有的话继续找children，一直到最深的那个child*/
            IUIAutomationElement child = rawTreeWalker.GetFirstChildElement(_element);
            if (child != null)
            {
                printAllChildren(child);
            }
            /*广度第二，此时从最深的那个child往上，看看有没有sibling，有的话检查每个sibling以及他们的children*/
            IUIAutomationElement sibling = rawTreeWalker.GetNextSiblingElement(_element);
            if (sibling != null)
            {
                printAllChildren(sibling);
            }



        }
    }
}
