using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotation : MonoBehaviour
{   public Rigidbody rb;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(100, 100, 100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion quaternion = Quaternion.Euler(position * Time.deltaTime);
        rb.MoveRotation(quaternion * rb.rotation);
    }
}
