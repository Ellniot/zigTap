using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highscore1;
    public Text highscore2;

    void Awake()
    {
        if (instance == null) //if there is no instance, the instance will be assigned to this instance
        {                     //if there is an instance, another one will not be created (there will only be one instance)
            instance = this;
        }
    }

    void Start()
    {
        highscore1.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart()
    {
        
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("panelUp");

    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0); //0 = index of the scene
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
