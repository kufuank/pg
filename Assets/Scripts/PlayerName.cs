using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    private Transform mainCamera;
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position+mainCamera.rotation*Vector3.forward,mainCamera.rotation*Vector3.up);
    }
}
