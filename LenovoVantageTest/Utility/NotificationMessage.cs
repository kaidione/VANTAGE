using System.Collections.Generic;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;


namespace LenovoVantageTest.Utility
{
    public class NofifyMessInfo
    {
        public string title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
    }

    public class NotificationMessage
    {

        public NotificationMessage()
        {

        }

        public List<NofifyMessInfo> GetHistoryMessageList(string AppId)
        {
            var notifs = ToastNotificationManager.History.GetHistory(AppId);

            List<NofifyMessInfo> messinfoList = new List<NofifyMessInfo>();
            foreach (var noti in notifs)
            {
                NofifyMessInfo messInfo = new NofifyMessInfo();
                XmlDocument xml = noti.Content;
                XmlNodeList nodeList = xml.GetElementsByTagName("text");
                if (nodeList.Count == 1)
                {
                    messInfo.title = nodeList.Item(0).InnerText;
                }
                if (nodeList.Count == 2)
                {
                    messInfo.title = nodeList.Item(0).InnerText;
                    messInfo.Content = nodeList.Item(1).InnerText;
                }
                messinfoList.Add(messInfo);
            }
            return messinfoList;
        }

        public void ShowToastMessage(string appID)
        {

            var notifs = ToastNotificationManager.History.GetHistory(appID);
            NofifyMessInfo messInfo = new NofifyMessInfo();
            if (notifs.Count > 0)
            {
                ToastNotification tnotify = notifs[0];
                ToastNotificationManager.CreateToastNotifier(appID).Show(tnotify);
            }
        }
        public NofifyMessInfo GetLatestMessageInfo(string AppId)
        {
            var notifs = ToastNotificationManager.History.GetHistory(AppId);
            NofifyMessInfo messInfo = new NofifyMessInfo();
            if (notifs.Count > 0)
            {
                ToastNotification tnotify = notifs[0];
                XmlDocument xml = notifs[0].Content;
                XmlNodeList nodeList = xml.GetElementsByTagName("text");
                if (nodeList.Count == 1)
                {
                    messInfo.title = nodeList.Item(0).InnerText;
                }
                if (nodeList.Count == 2)
                {
                    messInfo.title = nodeList.Item(0).InnerText;
                    messInfo.Content = nodeList.Item(1).InnerText;
                }
                XmlNodeList nodeListIamge = xml.GetElementsByTagName("image");
                if (nodeListIamge.Count > 0)
                {
                    XmlElement element = (XmlElement)nodeListIamge.Item(0);
                    messInfo.ImagePath = element.GetAttribute("src");
                }
            }
            return messInfo;
        }

        public List<XmlDocument> GetNotificationToastList(string AppId)
        {
            var notifs = ToastNotificationManager.History.GetHistory(AppId);
            List<XmlDocument> docList = new List<XmlDocument>();
            foreach (var noti in notifs)
            {
                XmlDocument xmlDoc = noti.Content;
                docList.Add(xmlDoc);
            }
            return docList;
        }

        public void Clear(string AppId)
        {
            ToastNotificationManager.History.Clear(AppId);
        }

        public void Clear()
        {
            ToastNotificationManager.History.Clear();
        }

        ~NotificationMessage()
        {

        }
    }
}
