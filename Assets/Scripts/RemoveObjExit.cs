using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Уничтожает объект, после того как с ним закончилось соприкосновение
/// </summary>
public class RemoveObjExit : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) Destroy(gameObject);
    }
}
