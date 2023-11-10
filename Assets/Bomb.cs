using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer = 3;
    public int score = 100;

    public Collider2D bombCollision;
    public ParticleSystem explosion;
    
    private IEnumerator Start()
    {
        bombCollision.enabled = true;

        yield return new WaitForSeconds(timer);
        
        bombCollision.enabled = false;
        GameManager.Instance.ResetCombo();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) //Recolectar bomba
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        GameManager.Instance.AddCombo();
        GameManager.Instance.AddScore(score * GameManager.Instance.combo);
        GameManager.Instance.ShakeCamera(.1f, .30f);
        Destroy(gameObject);
    }
}
