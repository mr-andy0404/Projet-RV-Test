using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/guides/networkbehaviour
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

// NOTE: Do not put objects in DontDestroyOnLoad (DDOL) in Awake.  You can do that in Start instead.

public class ConnectingStatus : NetworkBehaviour
{
	public Text status;
    public InputField ipAddress;
    NetworkManager manager;

    private void Start()
    {
        manager = GetComponent<NetworkManager>();
    }

    private void Update()
    {
        if (!NetworkClient.active)
        {
            manager.networkAddress = ipAddress.text;
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                status.text = "(  WebGL cannot be server  )";
            }
        }
        else
        {
            status.text = $"Connecting to {manager.networkAddress}..";

        }

        if (NetworkServer.active && NetworkClient.active)
        {
            status.text = $"<b>Host</b>: running via {Transport.activeTransport}";
        }
        // server only
        else if (NetworkServer.active)
        {
            status.text = $"<b>Server</b>: running via {Transport.activeTransport}";
        }
        // client only
        else if (NetworkClient.isConnected)
        {
            status.text = $"<b>Client</b>: connected to {manager.networkAddress} via {Transport.activeTransport}";
        }
    }

}
