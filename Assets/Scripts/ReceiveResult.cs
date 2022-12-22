using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour
{

    [SerializeField]
    GameObject Text;

    TextMeshPro textMeshPro;

    void Start()
    {
        textMeshPro = Text.GetComponent<TextMeshPro>();
        textMeshPro.text = "Вам нужно подключение к Интернету...";
    }

    void onActivityResult(string recognizedText)
    {
        char[] delimiterChars = { '~' };
        string[] result = recognizedText.Split(delimiterChars);

        //You can get the number of results with result.Length
        //And access a particular result with result[i] where i is an int
        //I have just assigned the best result to UI text
        textMeshPro.text = result[0];

    }
}
