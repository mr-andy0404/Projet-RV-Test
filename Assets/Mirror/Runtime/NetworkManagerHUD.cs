// vis2k: GUILayout instead of spacey += ...; removed Update hotkeys to avoid
// confusion if someone accidentally presses one.
using UnityEngine;

namespace Mirror
{
    /// <summary>Shows NetworkManager controls in a GUI at runtime.</summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Network/NetworkManagerHUD")]
    [RequireComponent(typeof(NetworkManager))]
    [HelpURL("https://mirror-networking.gitbook.io/docs/components/network-manager-hud")]
    public class NetworkManagerHUD : MonoBehaviour
    {
        NetworkManager manager;

        public int offsetX;
        public int offsetY;


        void Awake()
        {
            manager = GetComponent<NetworkManager>();
        }

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10 + offsetX, 40 + offsetY, 800, 800));
            if (!NetworkClient.isConnected && !NetworkServer.active)
            {
                StartButtons();
            }
            else
            {
                StatusLabels();
            }

            // client ready
            if (NetworkClient.isConnected && !NetworkClient.ready)
            {
                if (GUILayout.Button("Client Ready", GUILayout.Width(200), GUILayout.Height(100)))
                {
                    NetworkClient.Ready();
                    if (NetworkClient.localPlayer == null)
                    {
                        NetworkClient.AddPlayer();
                    }
                }
            }

            StopButtons();

            GUILayout.EndArea();
        }

        void StartButtons()
        {
            if (!NetworkClient.active)
            {
                // Server + Client
                if (Application.platform != RuntimePlatform.WebGLPlayer)
                {
                    if (GUILayout.Button("Host", GUILayout.Width(200), GUILayout.Height(100)))
                    {
                        manager.StartHost();
                    }
                }

                // Client + IP
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Client", GUILayout.Width(200), GUILayout.Height(100)))
                {
                    manager.StartClient();
                }
                manager.networkAddress = GUILayout.TextField(manager.networkAddress, GUILayout.Width(200), GUILayout.Height(100));
                GUILayout.EndHorizontal();

                // Server Only
                if (Application.platform == RuntimePlatform.WebGLPlayer)
                {
                    // cant be a server in webgl build
                    GUILayout.Box("(  WebGL cannot be server  )", GUILayout.Width(200), GUILayout.Height(100));
                }
                else
                {
                    if (GUILayout.Button("Server Only", GUILayout.Width(200), GUILayout.Height(100))) manager.StartServer();
                }
            }
            else
            {
                // Connecting
                GUILayout.Label($"Connecting to {manager.networkAddress}..", GUILayout.Width(200), GUILayout.Height(100));
                if (GUILayout.Button("Cancel Connection Attempt", GUILayout.Width(200), GUILayout.Height(100)))
                {
                    manager.StopClient();
                }
            }
        }

        void StatusLabels()
        {
            // host mode
            // display separately because this always confused people:
            //   Server: ...
            //   Client: ...
            if (NetworkServer.active && NetworkClient.active)
            {
                GUILayout.Label($"<b>Host</b>: running via {Transport.activeTransport}", GUILayout.Width(200), GUILayout.Height(100));
            }
            // server only
            else if (NetworkServer.active)
            {
                GUILayout.Label($"<b>Server</b>: running via {Transport.activeTransport}", GUILayout.Width(200), GUILayout.Height(100));
            }
            // client only
            else if (NetworkClient.isConnected)
            {
                GUILayout.Label($"<b>Client</b>: connected to {manager.networkAddress} via {Transport.activeTransport}", GUILayout.Width(200), GUILayout.Height(100));
            }
        }

        void StopButtons()
        {
            // stop host if host mode
            if (NetworkServer.active && NetworkClient.isConnected)
            {
                if (GUILayout.Button("Stop Host", GUILayout.Width(200), GUILayout.Height(100)))
                {
                    manager.StopHost();
                }
            }
            // stop client if client-only
            else if (NetworkClient.isConnected)
            {
                if (GUILayout.Button("Stop Client", GUILayout.Width(200), GUILayout.Height(100)))
                {
                    manager.StopClient();
                }
            }
            // stop server if server-only
            else if (NetworkServer.active)
            {
                if (GUILayout.Button("Stop Server", GUILayout.Width(200), GUILayout.Height(100)))
                {
                    manager.StopServer();
                }
            }
        }
    }
}
