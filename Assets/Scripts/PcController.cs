using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcController : MonoBehaviour
{
    //public GameObject player;
    public ServerManager serverManager;
    public Camera cameraa;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            cameraa.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            serverManager.HandShake();
        }
    }
}
