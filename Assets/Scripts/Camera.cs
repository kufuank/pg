using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    public CinemachineBrain cinemachine;
    public Camera cameraa;
    public GameObject player;
    bool look;
    Vector3 startCameraPos;
    public Transform[] closeObj;
    public Button button;
    private void Update()
    {
        
        if (look)
        {
            cameraa.transform.position = new Vector3(player.transform.position.x, cameraa.transform.position.y, player.transform.position.z);
        }
        
        
    }
    bool first = true;

    Vector3 cameraAfterRot;
    public void MoveUp()
    {
       
        if (first)
        {
            button.interactable = false;
            for (int i = 0; i < closeObj.Length; i++)
            {
                closeObj[i].gameObject.SetActive(false);
            }
            startCameraPos = cameraa.transform.position - player.transform.position;
            cameraAfterRot = cameraa.transform.rotation.eulerAngles;
            cinemachine.enabled = false;
            cameraa.transform.DOMove(transform.position, 3f).OnComplete(() => { look = true; button.interactable = true; } );
            cameraa.transform.DORotate(new Vector3(90, 0, 0), 3f);
            first = false;
            return;
        }
        else
        {
            button.interactable = false;
            look = false;


            cameraa.transform.DOMove((player.transform.position + startCameraPos), 3f).OnComplete(() =>
            {
                cinemachine.enabled = true;
                for (int i = 0; i < closeObj.Length; i++)
                {
                    closeObj[i].gameObject.SetActive(true);
                }
                button.interactable = true;
            });
            cameraa.transform.DORotate(cameraAfterRot, 3f);
            first=true;
        }
       

    }
}
