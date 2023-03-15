using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;// zdes sozdajem peremuju skorosti
    private Rigidbody rb; //zdes my delajem ssylku na rigidbody
    private float movementX;
    private float movementY;
    public AudioSource soundtrack;
    public AudioSource collectMusic;
    public int wallet;
    public Text scoreText;
    public GameObject finishText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreText.text = "My score: " + wallet;
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finish")
        {
            finishText.SetActive(true);
        }
        if (other.gameObject.tag == "collect") 
        {
            other.gameObject.SetActive(false);
            collectMusic.Play();
            wallet++;
            scoreText.text = "My score: " + wallet;
            if (wallet <= 0)
            {
                wallet = 0;
                scoreText.text = "My score: " + wallet;
            }
        }

        if (other.gameObject.tag == "pirat")
        {
            other.gameObject.SetActive(false);
            collectMusic.Play();
            wallet--;
            scoreText.text = "My score: " + wallet;
            if (wallet <= 0)
            {
                wallet = 0;
                scoreText.text = "My score: " + wallet;
            }
        }


        if (other.gameObject.tag == "respawn")
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (other.gameObject.tag == "music1")
        {
            soundtrack.Play();
        }

    }

}
