using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    WebCamTexture texture;
    RawImage img;
    // Start is called before the first frame update
    public void CheckCamera()
    {
        //texture = new WebCamTexture();
        Debug.Log(texture);
        //GetComponent<Image>().material.color = new Color(255, 0, 0);
        GetComponent<Renderer>().material.mainTexture = texture;
        texture.Play();
    }

    private void Start()
    {
        texture = new WebCamTexture();
        Debug.Log(texture);
        //GetComponent<Image>().material.mainTexture = texture;
        //texture.Play();
    }

}
