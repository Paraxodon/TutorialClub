using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float deathTime; //Tiempo que dura la explosion (la colision)
    private bool die = false;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(deathTime);
        die = true;
    }

    private void OnTriggerEnter2D(Collider2D other) //Matar jugador
    {
        if (!other.CompareTag("Player") || die) return;
        
        other.gameObject.GetComponent<PlayerMovement>().Die();
        
        GameManager.Instance.ShakeCamera(.2f, 1);
    }
}
