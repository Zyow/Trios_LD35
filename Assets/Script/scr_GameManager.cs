using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scr_GameManager : MonoBehaviour
{

    public GameObject[] goScore;
    public int score;
    public Text txtScore;
  

	// Use this for initialization
	void Start ()
    {
        goScore = GameObject.FindGameObjectsWithTag("score");
        txtScore = GameObject.FindGameObjectWithTag("uiScore").GetComponent<Text>();

        score = goScore.Length;
        RefreshUI();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void TakeScore()
    {
        score--;
        RefreshUI();

        if (score <= 0)
            NextLevel();
    }

    void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
        print("win!");
    }

    public void RefreshUI()
    {
        txtScore.text = score.ToString();
    }
}
