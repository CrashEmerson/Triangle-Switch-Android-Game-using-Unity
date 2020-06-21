using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    [SerializeField] Sprite[] ball; // 0 -> FIreBall   1 -> Normal Ball
    SpriteRenderer spriteRenderer;
    [SerializeField] TrailRenderer trail;
    [SerializeField] Sprite LanternLight;
    bool fireBallActive = false;
    [SerializeField] GameObject sparks;
    LevelDealer levelDealer;
    [SerializeField] LevelScript Level;
    ParticleSystem AcquireSparkVFX;
    int laternCount;

    private void Start()
    {
        levelDealer = FindObjectOfType<LevelDealer>();
        AcquireSparkVFX = Level.GetAcquireSparkVFX();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        FindObjectOfType<AudioManager>().Stop("IntroGameTheme");
        FindObjectOfType<AudioManager>().Stop("LevelCompletedSFX");
        FindObjectOfType<AudioManager>().Play("GamePlayTheme");
    }
    private void Update()
    {
        laternCount = levelDealer.laternCount;
        transform.Rotate(0, 0, 20 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fireball"))
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Ring")
        {
            if(sparks.activeSelf == true) FindObjectOfType<AudioManager>().Play("SparkSFX");
            if (ball[0] != null)
            {
                ShowAcquireSparkVFX();
                spriteRenderer.sprite = ball[0]; // fireball
                trail.startColor = Color.red;
                fireBallActive = true;
            }
            sparks.SetActive(false);
        }
        if(fireBallActive == true)
        {
            if (other.gameObject.tag == "Lantern")
            {
                GameObject latern = other.gameObject as GameObject;
                latern.GetComponent<SpriteRenderer>().sprite = LanternLight;
                fireBallActive = false;
            }
        }
        if(fireBallActive == false)
        {
            if (laternCount > 1)
            {
                sparks.SetActive(true);
                if (ball != null) spriteRenderer.sprite = ball[1]; // normal ball
                trail.startColor = Color.yellow;
            }
            if (laternCount == 0) sparks.SetActive(false);
        }
    }

    void ShowAcquireSparkVFX()
    {
        if(sparks.activeSelf == true)
        {
            ParticleSystem sparkVFX = Instantiate(AcquireSparkVFX, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(sparkVFX.gameObject, 1f);
        }
    }
}