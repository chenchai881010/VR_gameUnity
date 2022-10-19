using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_Controler : MonoBehaviour
{
    public VideoPlayer vPlayer;
    public GameObject playVd_view;
    public GameObject Playbutton;
    // Start is called before the first frame update

    public void playVD()
    {
        vPlayer.Play();
        vPlayer.loopPointReached += closeVD;
        Playbutton.SetActive(false);
    }
    public void closeVD(VideoPlayer source)
    {
        vPlayer.Stop();
        playVd_view.SetActive(false);
        Playbutton.SetActive(true);
    }

}
