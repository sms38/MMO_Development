using System;
using System.Collections.Generic;
using System.IO;
using Photon.SocketServer;
using log4net;
using log4net.Config;
using ExitGames.Logging.Log4Net;

namespace RuneSlinger.Server
{
    class Application : ApplicationBase 
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Application));

        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            Log.InfoFormat("Peer created at {0}:{1}", initRequest.RemoteIP, initRequest.RemotePort);
            return new RunePeer(initRequest);
        }

        protected override void Setup()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(BinaryPath, "log4net.config")));
            ExitGames.Logging.LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);

            Log.Info("Application Started");
        }

        protected override void TearDown()
        {

        }
    }
} 
