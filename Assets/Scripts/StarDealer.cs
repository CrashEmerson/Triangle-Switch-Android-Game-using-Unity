using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDealer : MonoBehaviour
{
    [SerializeField] Image[] LevelStars;
    [SerializeField] Sprite GotStarSprite;

    int starCount = 3;
    
    public void DecreaseStar()
    {
        starCount--;
        ChangeStarSprite();
    }
    void ChangeStarSprite()
    {
        LevelStars[starCount].sprite = GotStarSprite;
    }
    public int GetstarCount() { return starCount; }
}
