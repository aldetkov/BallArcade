using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject gameObjectRemove;
    public AudioSource DestroySound;
    public string tagForSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(gameObject.CompareTag(tagForSound) && gameObjectRemove.activeSelf) DestroySound.Play();
            gameObjectRemove.SetActive(false);
            
        }
    }
}
