using System.Collections.Generic;
using UnityEngine;
using Mirror;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/guides/networkbehaviour
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

// NOTE: Do not put objects in DontDestroyOnLoad (DDOL) in Awake.  You can do that in Start instead.

public class BeControlled : NetworkBehaviour
{
	public GameObject controlledBy;
	private AirplaneController AC;

    private void Start()
    {
        AC = GetComponent<AirplaneController>();
    }

    private void Update()
    {
		if (controlledBy != null) Debug.Log(controlledBy.transform.position);
        AC.Pitch = -controlledBy.transform.position.x;
        AC.Roll = -controlledBy.transform.position.y;
        AC.Yaw = controlledBy.transform.position.z;
    }
}
