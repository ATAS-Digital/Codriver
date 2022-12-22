using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBaseManager
{
    public static Sprite GetSignImage(string id)
    {
        var sprite = Resources.Load<Sprite>($"Signs\\{id}");
        if (sprite == null)
        {
            return Resources.Load<Sprite>("empty"); ;
        }
        return sprite;
    }

    public static string GetSignName(string id)
    {
        var file = Resources.Load<TextAsset>("names");
        var lines = file.text.Split('\n');

        foreach (var el in lines)
        {
            var parts = el.Split('|');
            if (parts[0] == id) return parts[1];
        }
        return "Nothing found";
    }
}
