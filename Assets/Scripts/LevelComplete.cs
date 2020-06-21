using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    StarDealer starDealer;
    [SerializeField] Image[] LevelCompletedCanvasStar; // 0 -> Left  1 -> Right  2 -> Center
    [SerializeField] LevelScript Level;

    private void Start()
    {
        starDealer = FindObjectOfType<StarDealer>();
    }
    private void Update()
    {
        int starcount = starDealer.GetstarCount();
        if (starcount == 2) {
            LevelCompletedCanvasStar[0].color = new Color32(255,255,255,255); } // left star
        if (starcount == 1) {
            LevelCompletedCanvasStar[0].color = new Color32(255, 255, 255, 255);
            LevelCompletedCanvasStar[1].color = new Color32(255, 255, 255, 255); } //right star
        if (starcount == 0) {
            LevelCompletedCanvasStar[0].color = new Color32(255, 255, 255, 255);
            LevelCompletedCanvasStar[1].color = new Color32(255, 255, 255, 255);
            LevelCompletedCanvasStar[2].color = new Color32(255, 255, 255, 255); } // center star
        SendStarDataToSave(starcount);
    }

    void SendStarDataToSave(int starcount)
    {
        if (starcount == 0) { starcount = 3; }
        else if (starcount == 1) { starcount = 2; }
        else if (starcount == 2) { starcount = 1; }
        else if (starcount == 3) { starcount = 0; }

        PlayerData.SaveStarData(Level.name, Level.GetStageName() ,starcount);
    }
}