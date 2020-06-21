using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanternScript : MonoBehaviour
{
    Rigidbody2D rb;
    float MoveSpeed = 100;
    SpriteRenderer spriteRenderer;
    private Animator anim;
    LevelDealer leveldealer;
    [SerializeField] LevelScript Level;
    GameObject lanternBurst;
    ShrinkDealer shrinkDealer;
    AudioManager audioManager;
    bool CanShrink;

    private void Start()
    {
        CanShrink = true;
        leveldealer = FindObjectOfType<LevelDealer>();
        shrinkDealer = FindObjectOfType<ShrinkDealer>();
        lanternBurst = Level.GetLaternBurst();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (spriteRenderer.sprite.name == "Lantern2_0")
        {
            anim.enabled = false;
            rb.velocity = new Vector2(0f, 2f * MoveSpeed * Time.deltaTime);
            if (CanShrink == true) { Shrink(); CanShrink = false; }
        }

        if (transform.position.y > 3)
        {
            Instantiate(lanternBurst, this.transform.position, Quaternion.identity);
            if (audioManager != null) FindObjectOfType<AudioManager>().Play("LanternBurstSFX");
            Destroy(this.gameObject);
            leveldealer.DecreaseLaternCount();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(audioManager != null ) FindObjectOfType<AudioManager>().Play("LanternShake");
            anim.SetBool("canLanternShake", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("canLanternShake", false);
        }
    }
    
    void Shrink()
    {
        if(shrinkDealer != null) shrinkDealer.ShrinkTriangle();
    }
}