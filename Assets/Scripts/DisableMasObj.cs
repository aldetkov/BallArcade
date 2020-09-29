using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMasObj : MonoBehaviour
{
    public AudioSource destroyObjSounds;
    public GameObject[] platform;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            for (int i = 0; i < platform.Length; i++)
            {
                if (platform[i].activeSelf) destroyObjSounds.Play();
                platform[i].SetActive(false);
            }
        }
    }
}
