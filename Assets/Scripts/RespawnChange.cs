using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnChange : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().Respawn != gameObject)
        {
            GetComponent<AudioSource>().Play();
        }
        collision.gameObject.GetComponent<PlayerController>().Respawn = gameObject;

    }
}
