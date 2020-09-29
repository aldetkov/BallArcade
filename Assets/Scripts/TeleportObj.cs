using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObj : MonoBehaviour
{
    public Transform objToTeleport;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TeleportObj"))
        {
            Rigidbody rbPlayer = other.GetComponent<Rigidbody>();
            rbPlayer.position = objToTeleport.transform.position;
        }
    }

}
