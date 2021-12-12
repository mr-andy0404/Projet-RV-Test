using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PositionControl : NetworkBehaviour
{
    private AvionGyroscope AG;
    // Start is called before the first frame update
    void Start()
    {
        AG = GetComponent<AvionGyroscope>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        transform.position = new Vector3(-AG.pitch, AG.roll, AG.yaw);
    }


}
