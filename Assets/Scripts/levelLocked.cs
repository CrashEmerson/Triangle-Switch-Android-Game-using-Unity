using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelLocked : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject levelLockedUI;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void LevelLocked_OK()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelectUI");
        anim.SetBool("IsOkClicked", true);
        StartCoroutine(WaitForTime());
        
    }
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(.5f);
        if (levelLockedUI != null) levelLockedUI.SetActive(false);
    }
}
