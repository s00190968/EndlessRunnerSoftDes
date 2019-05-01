using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{

    public GameObject PauseScreen;
    public TMP_Text ScoreText;
    public TMP_Text PlayTimeText;
    string playtimeTxt;

    LevelMaster LevMas;

    // Start is called before the first frame update
    void Start()
    {
        LevMas = GameObject.Find("LevelMaster").GetComponent<LevelMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ScoreMaster.PlayScore.ToString();
        playtimeTxt = string.Format($"{LevMas.PlayTime.Minutes}:{LevMas.PlayTime.Seconds}");
        PlayTimeText.text = playtimeTxt;
    }

    public void PauseGame()
    {
        SceneMaster.PauseGame();
        PauseScreen.SetActive(true);
    }

    public void ContinueGame()
    {
        PauseScreen.SetActive(false);
        SceneMaster.ContinueGame();
    }        

    public void QuitGame()
    {
        SceneMaster.OpenMainMenu();
    }
}
