using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    [SerializeField] GameObject ObjectToToggle;
    private bool condition = true;

    public void ShowHideObject()
    {
        ObjectToToggle.SetActive(condition);
        condition = !condition;
    }
}
