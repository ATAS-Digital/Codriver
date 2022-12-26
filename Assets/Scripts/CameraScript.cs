using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    //WebCamTexture texture;
    RawImage img;
    // Start is called before the first frame update
    public void CheckCamera()
    {
        if(StaticData.texture == null)
        StaticData.texture = new WebCamTexture();

        //Texture2D photo = new Texture2D(texture.width, texture.height);
        //photo.SetPixels(texture.GetPixels());
        //photo.Apply();

        ////Encode to a PNG
        //byte[] bytes = photo.EncodeToJPG();


        Debug.Log(StaticData.texture);
        //GetComponent<Image>().material.color = new Color(255, 0, 0);
        GetComponent<Renderer>().material.mainTexture = StaticData.texture;
        StaticData.texture.Play();
    }

    private void Start()
    {
        //texture = new WebCamTexture();
        //Debug.Log(texture);
        //GetComponent<Renderer>().material.mainTexture = texture;
        //texture.Play();
    }

    public void OnDestroy()
    {
        //StaticData.texture?.Stop();
        GetComponent<Renderer>().material.mainTexture = null;
    }

}
