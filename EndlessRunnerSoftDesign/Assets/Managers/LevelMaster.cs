using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    private float elapsedSeconds;
    public TimeSpan PlayTime//time the player has played the the game (gamescene)
    {
        get
        {
            return TimeSpan.FromSeconds(elapsedSeconds);//gets the passed time from elapsed seconds
        }
        private set
        {
            PlayTime = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        elapsedSeconds = 0;//set the elapsed seconds to 0 at the start of the level
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneMaster.getIsGamePaused())//if game is not paused (if game is running)
        {
            elapsedSeconds += Time.deltaTime;
        }
    }

}