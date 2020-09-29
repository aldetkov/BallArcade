using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform objToTeleport;
    AudioSource teleportSound;
    private void Awake()
    {
        teleportSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player"))
        {
            teleportSound.Play();
            Rigidbody rbPlayer = other.GetComponent<Rigidbody>();
            rbPlayer.position = objToTeleport.transform.position;
        }
    }
}
