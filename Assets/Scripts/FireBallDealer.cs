using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireBallDealer : MonoBehaviour
{
    [SerializeField] LevelScript Level;
    GameObject ball;
    GameObject fireball;

    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject JoystickCanvas;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] TextMeshProUGUI GameOverMessage;
    LanternScript lanternScript;

    bool IsBallAvaliable;
    Coroutine spawnfireball;
    GameObject fireBall;
    private void Start()
    {
        
        fireball = Level.GetFireBallPrefab();
        ball = GameObject.Find("Ball");
        spawnfireball = StartCoroutine(SpawnFireBall());
    }
    
    IEnumerator SpawnFireBall()
    {
        if (ball != null)
        {
            while (true)
            {
                yield return new WaitForSeconds(Level.GetFireBallSpawnSeconds());
                if (ball != null)
                {
                    Vector2 FireBallPos = new Vector2(ball.transform.position.x, 6.0f);
                    FindObjectOfType<AudioManager>().Play("FireballSFX");
                    fireBall = Instantiate(fireball, FireBallPos, Quaternion.identity);
                }
            }
        }
        else yield return null;
    }

    private void Update()
    {
        lanternScript = FindObjectOfType<LanternScript>();
        if (ball == null) {
            if (lanternScript.GetComponent<SpriteRenderer>().sprite.name != "Lantern2_0")
            {
                StartCoroutine(ShowGameOverCanvas());
            }
        }
        //else if (ball != null) { IsBallAvaliable = true; }
    }

    IEnumerator ShowGameOverCanvas()
    {
        FindObjectOfType<AudioManager>().Play("GameOverSFX");
        yield return new WaitForSeconds(0.5f);
        PauseCanvas.SetActive(false);
        JoystickCanvas.SetActive(false);
        if(GameOverMessage != null) GameOverMessage.text = "Fireball is soo hot. Isn't it?";
        GameOverUI.SetActive(true);
        Destroy(gameObject);
    }

    public void StopSpawnFireBall() { Destroy(fireBall); StopCoroutine(spawnfireball); }
}