using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    public Rigidbody rb;
    public float force;
    public float maxForce;
    public float jumpForce;
    public AudioSource gameOverSound;
    private bool jump = false;
    public int life;
    public bool IsDead { get; set; }

    public GameObject Respawn { get; set; }

    GameObject[] obj;

    void Start()
    {
        IsDead = false;
        obj  = GameObject.FindGameObjectsWithTag("Disappearing");

    }


    void FixedUpdate()
    {
        Wasd();
        MaxSpeed();
    }

    void Update()
    {
        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            GetComponent<AudioSource>().Play();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = true;
        }


        // действия после смерти
        if (IsDead)
        {
            life--;
            // если количество жизней равно 0, то начинаем игру заново
            if (life == 0)
            {

                StartCoroutine(GameOver());
            }
            else
            {
            transform.position = Respawn.transform.position + Vector3.up;
            rb.velocity = Vector3.zero;
            StartCoroutine(ResetPlatform()); // Восстановление исчезнувших платформ через 3 секунды после старта
            BoxReset();
            Debug.Log(life);
            }
            IsDead = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        jump = false;
    }



/// <summary>
/// установка максимальной скорости в случае превышения её значений
/// </summary>
private void MaxSpeed()
    {
        if (rb.velocity.z > maxForce) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxForce);
        if (rb.velocity.z < -maxForce) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxForce);
        if (rb.velocity.x > maxForce) rb.velocity = new Vector3(maxForce, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.x < -maxForce) rb.velocity = new Vector3(-maxForce, rb.velocity.y, rb.velocity.z);
    }
    /// <summary>
    /// Управление - вперед, назад, вправо, влево
    /// </summary>
    private void Wasd()
    {
        // Управление вперед, назад, влево, вправо
        if (Input.GetKey(KeyCode.W) && rb.velocity.z <= maxForce)
        {
            rb.AddForce(new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z)
                * force
                * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S) && rb.velocity.z >= -maxForce)
        {
            rb.AddForce(new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z)
                * -force
                * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D) && rb.velocity.x <= maxForce)
        {
            rb.AddForce(new Vector3(mainCamera.transform.right.x, 0, mainCamera.transform.right.z)
                * force
                * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A) && rb.velocity.x >= -maxForce)
        {
            rb.AddForce(new Vector3(mainCamera.transform.right.x, 0, mainCamera.transform.right.z)
                * -force
                * Time.fixedDeltaTime);
        }
    }

    /// <summary>
    /// Восстанавливает упавшие ящики
    /// </summary>
    private void BoxReset()
    {
        ResetAffterDeath.IsDeath = true;
        StartCoroutine(EndResetObj());
    }
    IEnumerator EndResetObj()
    {
        yield return new WaitForSeconds(0.05f);
        ResetAffterDeath.IsDeath = false;
    }

    /// <summary>
    /// Восстанавливает исчезнувшие платформы с тегом Disappearing
    /// </summary>
    IEnumerator ResetPlatform()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(true);
            if (obj[i].GetComponent<DisableWaitObjSelf>() != null)
            obj[i].transform.position = obj[i].GetComponent<DisableWaitObjSelf>().StartPosition;
        }
    }

    // Начинает игру сначала
    IEnumerator GameOver()  
    {
        gameOverSound.Play();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
}
