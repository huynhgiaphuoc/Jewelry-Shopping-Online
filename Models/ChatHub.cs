//using System;
//using System.Web;
//using Microsoft.AspNet.SignalR;
//using Jewelly.Models;
//namespace Jewelly
//{
//    public class ChatHub : Hub
//    {
//        public JwelleyEntities db = new JwelleyEntities();
//        public void Send(string name, string message)
//        {
//            Clients.All.broadcastMessage(name, message);
//        }
//    }
//}