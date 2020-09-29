using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpObj : MonoBehaviour
{
    public float speed;
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody objTransform = other.GetComponent<Rigidbody>();
        objTransform.useGravity = false;
    }
    private void OnTriggerStay(Collider other)
    {
        //Transform objTransform = other.GetComponent<Transform>();
        //objTransform.position += Vector3.up*speed;
        Rigidbody objTransform = other.GetComponent<Rigidbody>();
        objTransform.AddForce(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody objTransform = other.GetComponent<Rigidbody>();
        objTransform.useGravity = true;
    }



}
