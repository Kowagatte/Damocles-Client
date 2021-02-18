using System.Collections.Generic;

namespace Damocles.Networking {
    
    public class Client {
        
        public static readonly Client Instance = new Client();
        static Client() { }
        private Client() { }
        
        private Dictionary<NetworkEvents, Type> EventDictionary = new Dictionary<NetworkEvents, Type>();
        private readonly EventBasedNetListener _listener = new EventBasedNetListener();
        private NetDataWriter _globalWriter = new NetDataWriter();
        private NetManager _netManager;
        public bool IsStarted { get; private set; }
        
    }
}