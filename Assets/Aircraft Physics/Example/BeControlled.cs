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
    private PositionControl PC;
    public float tauxDiminution = 0.0001f;
    public bool fire = false;

    private void Start()
    {
        AC = GetComponent<AirplaneController>();
    }

    private void Update()
    {
		if (controlledBy == null) return;
        if (PC == null) PC = controlledBy.GetComponent<PositionControl>();

        AC.Pitch = controlledBy.transform.position.x;
        AC.Roll = controlledBy.transform.position.y;
        AC.Yaw = controlledBy.transform.position.z;
        if (PC.MicLoudness > 0.001)
            AC.thrustPercent = 1;
        else if (PC.MicLoudness <= 0.001 && AC.thrustPercent > 0.1)
            AC.thrustPercent -= tauxDiminution;
        else if (PC.MicLoudness <= 0.001 && AC.thrustPercent <= 0.1)
            AC.thrustPercent = 0;

        if (PC.touch > 2) { AC.brakesTorque = 200; AC.thrustPercent = 0; }
        else { AC.brakesTorque = 0; }

        if (PC.touch > 0 && PC.touch < 3 && fire == false) { AC.Point(); fire = true; }
        else if (PC.touch == 0 && fire) { AC.Fire(); fire = false; }
    }
}
