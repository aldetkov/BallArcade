using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEnableObj : MonoBehaviour
{
    public GameObject gameObjectToSwitch;
    public bool isPlayer = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer && other.CompareTag("Player"))
        {
            OnAndOffObj();
        }

        if (!isPlayer && other.CompareTag("SwitchEnableObj"))
        {
            OnAndOffObj();
        }

    }
    /// <summary>
    /// Метод, выключающий или включающий сам объект или другие объекты при столкновении с ним
    /// </summary>
    private void OnAndOffObj()
    {
        switch (gameObject.tag)
        {
            case "SwitchSelf":
                gameObject.SetActive(!gameObject.activeInHierarchy);
                break;
            case "SwitchOther":
                gameObjectToSwitch.SetActive(!gameObjectToSwitch.activeInHierarchy);
                break;
        }
    }
}
