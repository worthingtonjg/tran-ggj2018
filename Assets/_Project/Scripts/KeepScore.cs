using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class KeepScore : MonoBehaviour
{
    public Text Player1ScoreText;
    public Text Player2ScoreText;
    public static int Player1Score;
    public static int Player2Score;

    private static KeepScore _instance;
	
    public static KeepScore Instance { get { return _instance; } }

	public Text WinText;
	public Flowchart fungus;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            print("destroy extra");
            Destroy(this.gameObject);
        } 
        else 
        {
            _instance = this;
            print("use existing");
        }

        print(KeepScore.Player1Score);
        print(KeepScore.Player2Score);        
    }

    void Start()
    {
        UpdateScores(0, 0);
    }

    public void UpdateScores(int player1points, int player2points)
    {
        KeepScore.Player1Score += player1points;
        KeepScore.Player2Score += player2points;

        KeepScore.Instance.Player1ScoreText.text = Player1Score.ToString();
        KeepScore.Instance.Player2ScoreText.text = Player2Score.ToString();
    }

    public void CheckForWin()
    {
        bool win = false;
        if(KeepScore.Player1Score >= 10 )
        {
            WinText.text = "Player 1 wins!";
            win = true;
        }
        else if(KeepScore.Player2Score >= 10)
        {
            WinText.text = "Player 2 wins!";
            win = true;
        }

        if(win)
        {
            fungus.ExecuteBlock("EndLevel");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
