using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Score;

    public GameObject StartGame;

    public GameObject Rule;

    public GameObject GameOver;

    public GameObject WinGame;

    public GameObject PlayAgain;

    public bool isGameStart = false;

    public int score = 0;

    public string mainColor;
    
    void Awake()
    {
        radomColor();
        Score.SetActive(false);
        StartGame.SetActive(true);
        Rule.SetActive(true);
        GameOver.SetActive(false);
        WinGame.SetActive(false);
        PlayAgain.SetActive(false);

    }
    private void radomColor(){
        string[] colors = new string[] {"Green", "Red", "Blue"};
        int index = Random.Range(0, colors.Length);
        mainColor = colors[index];
    }
    

    public void Play(){
        isGameStart = true;
        Score.SetActive(true);
        StartGame.SetActive(false);
        Rule.SetActive(false);
        GameOver.SetActive(false);
        WinGame.SetActive(false);
        PlayAgain.SetActive(false);
    }

    public void Again(){
        score = 0;
        GameObject.FindAnyObjectByType<SpawnDiamon>().numDiamonds = 0;
        GameObject.FindAnyObjectByType<Player>().Restart();
        radomColor();
        isGameStart = true;
        Score.SetActive(true);
        StartGame.SetActive(false);
        Rule.SetActive(false);
        GameOver.SetActive(false);
        WinGame.SetActive(false);
        PlayAgain.SetActive(false);
    }

    public void Over(){
        isGameStart = false;
        GameOver.SetActive(true);
        PlayAgain.SetActive(true);
    }

    public void Win(){
        isGameStart = false;
        WinGame.SetActive(true);
        PlayAgain.SetActive(true);
    }


    public void InscreaseScore(){
        score = score + 20;
        Score.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        if(score == 200){
            
            Win();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStart){
            Score.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        }
        
    }
}
