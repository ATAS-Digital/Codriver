using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] GameObject ObjectToDestroy;

    public void DestroyMyObject()
    {
        Destroy(ObjectToDestroy);
    }
}
