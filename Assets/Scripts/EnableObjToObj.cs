using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjToObj : MonoBehaviour
{
    public GameObject gameObjectEnable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwitchEnableObj")) gameObjectEnable.SetActive(true);
    }
}
