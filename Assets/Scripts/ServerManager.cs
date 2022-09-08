using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Cinemachine;

public class ServerManager : MonoBehaviourPunCallbacks
{
    public List<GameObject> oyuncular = new List<GameObject>();
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Servere baðlanýldý");
        Debug.Log("Lobiye baðlanýlýyor");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Lobiye baðlanýldý");
        Debug.Log("Odaya baðlanýlýyor");
        PhotonNetwork.JoinOrCreateRoom("Odaismi", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Odaya baðlanýldý");
        Debug.Log("Karakter oluþturuluyor...");
        GameObject obj = PhotonNetwork.Instantiate("Human", new Vector3(-10, 5, -5), Quaternion.identity, 0, null);
        oyuncular.Add(obj);
        cinemachineVirtualCamera.Follow = oyuncular[oyuncular.Count - 1].transform.GetChild(0).transform;


    }
}