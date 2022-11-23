using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDB : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] Image imagePlace;

    public void GetImage()
    {
        var image = DataBaseManager.GetSignImage(input.text.Trim());
        imagePlace.sprite = image;
    }
}
