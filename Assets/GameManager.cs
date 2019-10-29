using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager me;

    public int timeSurvived;
    public int timeScore;
    public int candyFed;
    public int candyTaken;

    public int score;
    public int finalScore;
    public int highscore;

    public float scaredChildren;
    public float angryChildren;

    public List<AgentTerror> agents;
    public float tempTotalTerror;
    public float totalTerror;
    public float terrorStat;
    public float tempTotalAnger;
    public float totalAnger;
    public float angerStat;
    public float terrorBarNumb;
    public float angerBarNumb;

    public TextMesh scoreText;
    public TextMesh scText;
    public TextMesh acText;

    public TextMesh PPAmount;
    public TextMesh BBAmount;
    public TextMesh HSAmount;
    public TextMesh RWAmount;
    public TextMesh SPAmount;

    public TextMesh GameText;
    public TextMesh GameDesc1;
    public TextMesh GameDesc2;
    public TextMesh ControlsText;

    public CandyStorage PPCS;
    public CandyStorage BBCS;
    public CandyStorage HSCS;
    public CandyStorage RWCS;
    public CandyStorage SPCS;

    public bool GameOn;
    public bool GameStart;
    public bool GameOver;

    public SpriteRenderer sr;
    public Color clear;
    public Color pause;

    public BarManager terrorBar;
    public BarManager angerBar;



    private void Awake()
    {
        me = this;
        GameStart = true;
        GameOn = false;
        GameOver = false;
    }
    void Start()
    {
        GameStartFunc();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTextFunc();
        CandyAmountFunc();
        ScaredChildrenFunc();
        AngryChildrenFunc();
        Inputs();
        Background();
    }

    public void FixedUpdate()
    {
        TerrorLevelFunc();
        AngerLevelFunc();
        if (GameOn)
            TimeIncrease();
    }

    public void Inputs()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(GameStart == true)
            {
                GameStart = false;
                GameOn = true;
                NullText();
            }
            else if (GameOver == true)
            {
                RestartGame();
                NullText();
                GameOver = false;
                GameStart = true;
                GameStartFunc();
            }
        }
    }


    public void TerrorLevelFunc()
    {
        float j = 0;
        for (int i = 0; i < agents.Count; i++)
        {
            j += agents[i].terror;
        }
        totalTerror = j;
        terrorStat = totalTerror / agents.Count;
    }

    public void AngerLevelFunc()
    {
        float j = 0;
        for (int i = 0; i < agents.Count; i++)
        {
            j += agents[i].anger;
        }
        totalAnger = j;
        angerStat = totalAnger / agents.Count;
    }

    public void TimeIncrease()
    {
        timeSurvived++;
        if(timeSurvived > 600)
        {
            timeScore += 1000;
            timeSurvived = 0;
        }
        if (scaredChildren < 0)
        {
            scaredChildren = 0;
        }
        if (angryChildren < 0)
        {
            angryChildren = 0;
        }
        if(terrorStat > 15 || angerStat > 7.5f)
        {
            GameOverFunc();
        }
    }

    public void Background()
    {
        if (GameOn)
        {
            sr.color = clear;
        }
        else
        {
            sr.color = pause;
        }
    }

    public void ScoreTextFunc()
    {
        if (!GameOver)
        {
            score = timeScore + (candyFed * 100) + (candyTaken * 100);
            scoreText.text = ("Score : " + score);
        }
        else
        {
            scoreText.text = ("Score : " + finalScore);
        }
    }

    public void CandyAmountFunc()
    {
        PPAmount.text = ("00 = " + Judas.me.PP);
        BBAmount.text = ("00 = " + Judas.me.BB);
        RWAmount.text = ("00 = " + Judas.me.RW);
        HSAmount.text = ("00 = " + Judas.me.HS);
        SPAmount.text = ("00 = " + Judas.me.SP);
    }

    public void ScaredChildrenFunc()
    {
        terrorBarNumb = ((Mathf.Round(terrorStat * 66.66666666666666666666666666666666666666666666666f)) / 10);
        terrorBar.BarController(terrorBarNumb);
    }

    public void AngryChildrenFunc()
    {
        angerBarNumb = ((Mathf.Round(angerStat * 150f)) / 10);
        angerBar.BarController(angerBarNumb);
    }

    public void GameStartFunc()
    {
        GameText.text = ("Taking Candy from Babies");
        GameDesc1.text = ("Keep the kids happy by keeping your candy bins full!");
        GameDesc2.text = "Get candy back by scaring kids, but try not to traumatize too many of them!";
        ControlsText.text = ("WASD to Move Judas the Cat. Press Space to scare the Kids (and to start the game)!");
    }

    public void GameOverFunc()
    {
        GameOver = true;
        GameOn = false;
        if(score > highscore)
        {
            highscore = score;
        }
        finalScore = score;
        GameText.text = "Game Over";
        ControlsText.text = "Press Space to Restart";
        if (terrorBarNumb > 99)
        {
            GameDesc1.text = "You got shut down for scaring too many kids!";
        }
        if (angerBarNumb > 99)
        {
            GameDesc2.text = "You got your house TP'd for not having enough candy!";
        }        
    }

    public void NullText()
    {
        GameText.text = null;
        GameDesc1.text = null;
        GameDesc2.text = null;
        ControlsText.text = null;
    }

    public void RestartGame()
    {
        //Judas.me.pos = Judas.me.StartPos;
        //var agentss = GameObject.FindGameObjectsWithTag("Agent");
        //var PPcandy = GameObject.FindGameObjectsWithTag("PPobj");
        //var BBcandy = GameObject.FindGameObjectsWithTag("BBobj");
        //var RWcandy = GameObject.FindGameObjectsWithTag("RWobj");
        //var HScandy = GameObject.FindGameObjectsWithTag("HSobj");
        //var SPcandy = GameObject.FindGameObjectsWithTag("SPobj");
        //for (int i = 0; i < agentss.Length; i++)
        //{
        //    Destroy(agentss[i]);
        //}
        //for (int i = 0; i < PPcandy.Length; i++)
        //{
        //    Destroy(PPcandy[i]);
        //}
        //for (int i = 0; i < BBcandy.Length; i++)
        //{
        //    Destroy(BBcandy[i]);
        //}
        //for (int i = 0; i < RWcandy.Length; i++)
        //{
        //    Destroy(RWcandy[i]);
        //}
        //for (int i = 0; i < HScandy.Length; i++)
        //{
        //    Destroy(HScandy[i]);
        //}
        //for (int i = 0; i < SPcandy.Length; i++)
        //{
        //    Destroy(SPcandy[i]);
        //}
        //tempTotalAnger = 0;
        //totalTerror = 0;
        //tempTotalAnger = 0;
        //totalAnger = 0;
        //angerStat = 0;
        //terrorStat = 0;
        //score = 0;
        //PPCS.Amount = 20;
        //BBCS.Amount = 20;
        //RWCS.Amount = 20;
        //HSCS.Amount = 20;
        //SPCS.Amount = 20;
        //Judas.me.PP = 0;
        //Judas.me.BB = 0;
        //Judas.me.RW = 0;
        //Judas.me.SP = 0;
        //Judas.me.HS = 0;
        SceneManager.LoadScene("MainScene");
    }
}
