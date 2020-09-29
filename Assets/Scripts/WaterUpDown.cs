using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUpDown : MonoBehaviour
{
    Vector2 offsetBaseMap;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offsetBaseMap = new Vector2(1 / speed, 1 / (speed*2));
       transform.GetComponent<Renderer>().material.SetTextureOffset("_BaseColorMap",
           transform.GetComponent<Renderer>().material.GetTextureOffset("_BaseColorMap") + offsetBaseMap);
    }

    // string[] str = transform.GetComponent<Renderer>().material.GetTexturePropertyNames();
    // foreach (var item in str)
    // {
    //     Debug.Log(item);
    // }

}
