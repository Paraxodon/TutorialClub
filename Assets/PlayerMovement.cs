using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject loseScreen; //LACKING
    
    public float velocity;
    public float accelerationFactor;
    
    private Vector2 direction;
    public Rigidbody2D rb;

    private float deltaTime;

    private void Start()
    {
        loseScreen.SetActive(false);
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        direction.Set(x, y);
        direction.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.Lerp(rb.velocity, direction * velocity, accelerationFactor * Time.deltaTime);
    }

    public void Die()
    {
        int score = GameManager.Instance.score;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        
        loseScreen.SetActive(true);
        
        Destroy(gameObject);
    }
}
