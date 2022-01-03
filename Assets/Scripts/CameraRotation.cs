using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    public float rotationRadius = 15;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 6, -rotationRadius);
        transform.rotation = new Quaternion(1, 0, 0, 8);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(rotationSpeed * Time.unscaledTime) * rotationRadius, 6, Mathf.Cos(rotationSpeed * Time.unscaledTime) * rotationRadius);
        transform.Rotate(new Vector3(0, rotationSpeed * 0.065f, 0), Space.World);
    }
}
