using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    public CinemachineBrain cinemachine;
    public Transform cameraa;
    public GameObject upPoint;
    bool look;
    Vector3 startCameraPos;
    public Transform[] closeObj;
    public Transform closeMove;
    public Button button;
    public float Timer;
    public Ease ease;
    private void Update()
    {
        
        if (look)
        {
            cameraa.transform.position = new Vector3(upPoint.transform.position.x, cameraa.transform.position.y, upPoint.transform.position.z);
        }
        
        
    }
    bool first = true;

    Vector3 cameraAfterRot;
    public void MoveUp()
    {
       
        if (first)
        {
            button.interactable = false;
            closeMove.gameObject.SetActive(false);
            for (int i = 0; i < closeObj.Length; i++)
            {
                closeObj[i].gameObject.SetActive(false);
            }
            startCameraPos = cameraa.transform.position - upPoint.transform.position;
            cameraAfterRot = cameraa.transform.rotation.eulerAngles;
            cinemachine.enabled = false;
            cameraa.transform.DOMove(upPoint.transform.position, Timer).OnComplete(() => { look = true; button.interactable = true; closeMove.gameObject.SetActive(true); } ).SetEase(ease);
            cameraa.transform.DORotate(new Vector3(90, 0, 0), Timer).SetEase(ease);
            first = false;
            return;
        }
        else
        {
            closeMove.gameObject.SetActive(false);
            button.interactable = false;
            look = false;


            cameraa.transform.DOMove((upPoint.transform.position + startCameraPos), Timer).OnComplete(() =>
            {
                cinemachine.enabled = true;
                for (int i = 0; i < closeObj.Length; i++)
                {
                    closeObj[i].gameObject.SetActive(true);
                }
                button.interactable = true;
                closeMove.gameObject.SetActive(true);
            }).SetEase(ease);
            cameraa.transform.DORotate(cameraAfterRot, Timer).SetEase(ease);
            first=true;
        }
       

    }
}
