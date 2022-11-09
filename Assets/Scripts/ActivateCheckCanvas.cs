using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheckCanvas : MonoBehaviour
{
    [SerializeField] GameObject CameraCheckCanvas;
    [SerializeField] Camera MyCamera;
    public void ActivateCanvas()
    {
        var obj = Instantiate(CameraCheckCanvas);
        obj.GetComponent<Canvas>().worldCamera = MyCamera;
    }
}
