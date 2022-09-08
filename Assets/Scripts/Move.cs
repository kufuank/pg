using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using StarterAssets;

public class Move : MonoBehaviour
{
    [SerializeField] private PhotonView view;
   
    [SerializeField] private ThirdPersonController personController;
    void Update()
    {
        if (view.IsMine)
        {
            personController.enabled = true;
        }
        else
        {
            personController.enabled = false;
        }
    }
}