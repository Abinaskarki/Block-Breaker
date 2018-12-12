using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    
    //Config parameters
    [Range(0.1f,10f)] [SerializeField] float gameSpeed =1f;
    [SerializeField] int pointsPerBlockDestroyed = 20;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool isAutoPlayedEnabled = false;

    //State
    [SerializeField] int CurrentScore;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if(gameStatusCount >1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
           
        }
    }

    void Start()
    {
        scoreText.text = CurrentScore.ToString();
       
    }

	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddScore()
    {
        CurrentScore += pointsPerBlockDestroyed;
        scoreText.text = CurrentScore.ToString();
    }

    public void Reset()
    {
        Destroy(gameObject);
    }

    public bool isAutoPlayEnabled()
    {
        return isAutoPlayedEnabled;
    }
}
