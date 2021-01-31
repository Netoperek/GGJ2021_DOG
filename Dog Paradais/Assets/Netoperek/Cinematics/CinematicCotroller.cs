using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.Video;

public class CinematicCotroller : MonoBehaviour
{
    [SerializeField] GameObject hud; 
    [HideInInspector] [SerializeField] PlayerDialogue dialogue;
    [HideInInspector] [SerializeField] PlayerController playerController;
    [HideInInspector] [SerializeField] VideoPlayer videoIntro;
    [SerializeReference] GameObject entryCinematic;
    private void Awake()
    {
        Time.timeScale = 0f;
        dialogue.enabled = false;
        playerController.enabled = false;

    }
    private void Update()
    {
        Time.timeScale = 0f;
        if (videoIntro.isPrepared && !videoIntro.isPlaying)
        {
            IntroStop();
        }
    }
    void IntroStop()
    {
        dialogue.enabled = true;
        playerController.enabled = true;
        videoIntro.enabled = false;
        entryCinematic.SetActive(false);
        Time.timeScale = 1f;
        hud.SetActive(true);
        this.enabled = false;
    }
}
