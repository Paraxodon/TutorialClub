using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public TMP_Text scoreText;
    public TMP_Text comboText;

    public int combo = 0;
    public int score;

    private Vector3 initialCameraPosition; //Para el camera shake

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AddScore(0);
        comboText.text = "";

        initialCameraPosition = Camera.main.transform.position;
    }

    public void AddScore(int add)
    {
        score += add;
        scoreText.text = "Score: " + score;
        
        if (score == 0) return;
        scoreText.GetComponent<Animator>().Play("GotPoints");
    }

    public void AddCombo()
    {
        combo++;
        comboText.text = "Combo: " + combo;
        
        
        if (combo == 0) return;
        comboText.GetComponent<Animator>().Play("GotPoints");
    }

    public void ResetCombo()
    {
        combo = 0;
        comboText.text = "";
    }

    public void ShakeCamera(float time, float intensity)
    {
        StartCoroutine(ShakeCamera_(time, intensity));
    }

    private IEnumerator ShakeCamera_(float time, float intensity)
    {
        Transform cam = Camera.main.transform;
        float t = 0;
        while (t < time)
        {
            cam.position = initialCameraPosition + new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), 0);
            t += Time.deltaTime;
            yield return null;
        }
        cam.position = initialCameraPosition;
    }
}
