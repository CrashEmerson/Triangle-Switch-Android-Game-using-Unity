using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStars : MonoBehaviour
{
    GameObject AcquireStarVFX;
    StarDealer starDealer;
    [SerializeField] LevelScript Level;
    AudioManager audioManager;

    private void Start()
    {
        starDealer = FindObjectOfType<StarDealer>();
        AcquireStarVFX = Level.GetAcquireStarVFX();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            starDealer.DecreaseStar();
            GameObject powerVFX = Instantiate(AcquireStarVFX,transform.position,Quaternion.identity) as GameObject;
            if(audioManager != null) audioManager.Play("AcquireStarSFX");
            Destroy(powerVFX, 1.0f);
            Destroy(gameObject);
        }
    }
}