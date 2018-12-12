using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] int breakables;

    sceneLoader scene;

    private void Start()
    {
        scene = FindObjectOfType<sceneLoader>();
    }

    public void CountBlocks()
    {
        breakables++;
    }

    public void WinLose()
    {
        breakables--;

        if (breakables <= 0) { 
        scene.LoadNextScene();
        }

    }
}
