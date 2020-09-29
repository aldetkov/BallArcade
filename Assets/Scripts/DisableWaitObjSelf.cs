using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWaitObjSelf : MonoBehaviour
{
    public float speedDown;
    bool isCollision = false;
    public bool isPlatform = true;
    public AudioSource drown;
    public Vector3 StartPosition { get; set; }

    public float seconds;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollision)
        {
            StartCoroutine(FalseActiveObj());
            isCollision = true;
            if (isPlatform) drown.Play();
        }
    }

    private void Start()
    {
        StartPosition = transform.position;
    }

    private void Update()
    {
        if (isCollision)
        {
            transform.position = transform.position + Vector3.down * speedDown * Time.deltaTime;
        }
    }


    IEnumerator FalseActiveObj()
    {
        yield return new WaitForSeconds(seconds);
        isCollision = false;
        gameObject.SetActive(false);
    }

}
