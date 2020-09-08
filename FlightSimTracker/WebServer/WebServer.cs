using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FlightSimTracker
{
    public class WebServer
    {
        private readonly SimpleHTTPServer s;
        private readonly int port;

        public WebServer(int p)
        {
            this.port = p;
            s = new SimpleHTTPServer("C:\\WebServer", port);
        }
        public void Stop()
        {
            s.Stop();
        }
    }
}

