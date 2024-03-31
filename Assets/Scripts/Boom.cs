using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private void Start()
    {
        Invoke("OnDestroy", 2);
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
