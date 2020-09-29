using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    AudioSource splash;
    private void Awake()
    {
        splash = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        splash.Play();
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().IsDead = true;
        }
        
    }

}
