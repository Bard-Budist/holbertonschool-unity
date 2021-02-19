using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    private int score = 0;
    public int health = 5;

    public Text scoreText;
    public Text healthText;
    public Text winText;
    public Image bgFinal;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        if (health == 0)
        {
            //Debug.Log("Game Over!");
            health = 5;
            score = 0;
            winText.text = "Game Over!";
            bgFinal.color = Color.red;
            winText.color = Color.white;
            bgFinal.gameObject.SetActive(true);
            SetScoreText();
            SetHealthText();
            StartCoroutine(LoadScene(3));

        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void Move()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health -= 1;
            SetHealthText();
            //Debug.Log("Health: " + health);
        }

        if (other.CompareTag("Goal"))
        {
            //Debug.Log("You win!");
            winText.text = "You Win!";
            bgFinal.color = Color.green;
            winText.color = Color.black;
            bgFinal.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    IEnumerator LoadScene(float seconds)
    {   
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}
