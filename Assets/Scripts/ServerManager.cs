using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.InteropServices;

public class ServerManager : MonoBehaviourPunCallbacks
{
    public List<GameObject> oyuncular = new List<GameObject>();
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public MobileDisableAutoSwitchControls switchControls;
    public UICanvasControllerInput controllerInput;
    public Camera cameraa;
    private Animator anim;
    public TextMeshProUGUI loadingText;
    public Slider slider;
    public Image loadingImage;
    public TextMeshProUGUI m_DeviceType;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        StartCoroutine(Loading());
        if (isMobile())
        {
            m_DeviceType.text = "Handheld";
        }
        else
        {
            m_DeviceType.text = "Desktop";
        }
    }
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
         return IsMobile();
#endif
        return false;
    }
    IEnumerator Loading()
    {
        slider.DOValue(100, 3f).OnUpdate(() =>
         loadingText.text = slider.value.ToString("F0")
        );
        yield return new WaitForSeconds(1.5f);
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
        GameObject obj = PhotonNetwork.Instantiate("Human", new Vector3(6.4f, 5, -14), Quaternion.identity, 0, null);
        loadingImage.gameObject.SetActive(false);
        oyuncular.Add(obj);
        Transform player = oyuncular[oyuncular.Count - 1].transform;
        cinemachineVirtualCamera.Follow = player.GetChild(0).transform;
        controllerInput.starterAssetsInputs = player.GetComponent<StarterAssetsInputs>();
        //switchControls.playerInput = player.GetComponent<PlayerInput>();
        //switchControls.DisableAutoSwitchControls();
        
        cameraa.upPoint = player.GetChild(3).gameObject;
        anim = player.GetComponent<Animator>();
    }
    public void HandShake()
    {
        anim.SetTrigger("HandShake");
    }
}