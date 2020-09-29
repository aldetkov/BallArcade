using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObj : MonoBehaviour
{
    public Transform objToFollow;
    Vector3 objPosition;
    // Start is called before the first frame update
    void Start()
    {
        objPosition = transform.position - objToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objToFollow.position + objPosition;        
    }
}

