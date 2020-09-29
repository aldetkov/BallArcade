using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjSelf : MonoBehaviour
{
    public AudioSource destroySound;
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (destroySound != null)
            {
                destroySound.Play();
            }
            StartCoroutine(DestroyObj());
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Key"))
        {
            StartCoroutine(DestroyObj());
        }
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

}
