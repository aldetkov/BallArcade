using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherSound : MonoBehaviour
{
    AudioSource switcherClick;
    private void Awake()
    {
        switcherClick = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switcherClick.Play();
    }
}
