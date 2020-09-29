using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObj : MonoBehaviour
{
    public GameObject gameObjectEnable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObjectEnable.SetActive(true); 
        }
    }
}
