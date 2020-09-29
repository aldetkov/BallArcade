using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Переход на новый уровень
/// </summary>
public class LevelComplite : MonoBehaviour
{
    public string newScene;
    AudioSource winSound;
    private void Awake()
    {
        winSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        winSound.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(newScene, LoadSceneMode.Single);
    }
}
