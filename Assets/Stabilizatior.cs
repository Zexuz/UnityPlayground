using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizatior : MonoBehaviour
{
    public Camera Camera;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(
            transform.position + Camera.transform.rotation * Vector3.forward,
            Camera.transform.rotation * Vector3.up
        );
    }
}