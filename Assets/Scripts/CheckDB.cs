using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDB : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] Image imagePlace;
    [SerializeField] Text namePlace;

    public void GetImage()
    {
        var image = DataBaseManager.GetSignImage(input.text.Trim());
        imagePlace.sprite = image;
    }

    public void GetName()
    {
        var name = DataBaseManager.GetSignName(input.text.Trim());
        namePlace.text = name;
    }
}
