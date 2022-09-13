using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using StarterAssets;
using TMPro;

public class Move : MonoBehaviour
{
    [SerializeField] private PhotonView view;
    public TextMeshPro playerName;
    [SerializeField] private ThirdPersonController personController;
    void Update()
    {
        if (view.IsMine)
        {
            playerName.text = PhotonNetwork.NickName;
            personController.enabled = true;
        }
        else
        {
            playerName.text = view.Owner.NickName;
            personController.enabled = false;
        }
    }
}