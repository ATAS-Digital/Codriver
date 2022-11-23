using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBaseManager
{
    public static Sprite GetSignImage(string id)
    {
        var sprite = Resources.Load<Sprite>($"Signs\\{id}");
        if(sprite == null)
        {
            return Resources.Load<Sprite>("empty"); ;
        }
        return sprite;
    }
}
