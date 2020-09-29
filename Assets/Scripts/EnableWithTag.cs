using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// При столкновении с триггером включает объекты по заданному тегу
/// </summary>
public class EnableWithTag : MonoBehaviour
{
    GameObject[] gameObjects;
    public string tagObj;

    private void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag(tagObj);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
}
