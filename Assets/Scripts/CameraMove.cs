using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Поворачивает камеру свайпами левой кнопкой мыши
/// </summary>
public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // отключение курсора
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {

         _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3; 
        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}


   
 