using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX=1.1f;
    [SerializeField] float maxX=14.1f;
    // Use this for initialization

    //Cached Reference
    GameStatus theGameStatus;
    Ball theBall;

	void Start () {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
	}

    // Update is called once per frame
    void Update()
    {
        float mousePointsInUnits =  Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePointsInUnits, minX, maxX);
        transform.position = paddlePos;

    }


    //To make the game played autoplayed. Use  paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX); for PaddlePos.x 
    private float GetXPos()
    {
        if (theGameStatus.isAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }

       
    }
}

