using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAffterDeath : MonoBehaviour
{
    public static bool IsDeath { get; set; }
    public Vector3 StartPosition { get; set; }


    // Start is called before the first frame update
    void Start()
    {
            StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDeath)
        {
            transform.position = StartPosition;
        }
    }
}
