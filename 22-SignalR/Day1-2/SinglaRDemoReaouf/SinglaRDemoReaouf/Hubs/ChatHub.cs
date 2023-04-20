using Microsoft.AspNetCore.SignalR;

namespace SinglaRDemoReaouf.Hubs
{
    public class ChatHub:Hub
    {

        //public override Task OnConnectedAsync()
        //{
        //    // await Clients.All.SendAsync ....... 
        //}

        // 1- Client calls this method in the server
        public void NewMessage (string name, string msg, int rate)
        {
            //logic
            //notify

            // Clients => holds all connected clients
            // Including the `caller` 

            // 2- NotifyNewMessge => a method we call on the client
            Clients.All.SendAsync("NotifyNewMessage",name,msg,rate); 
        }
        //SignalR client call RPC
        public void method1()
        {
            //Clients

            // All of this is `GET` 
            // as these values are set by the caller
            // Ex: javaScript. 

            //Context.User.Identity.Name
            //Context.User.Identity.IsAuthenticated

            // Write some loigc /DB 

            //3- Notify listening users.


                
        }

    }
}
