using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


/// <summary>
/// Уничтожает объект после ожидания
/// </summary>
public class RemoveObjWithWait : MonoBehaviour
{
    public float seconds;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (gameObject.CompareTag("StoneWall")) gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject, seconds);
        }
    }

}
