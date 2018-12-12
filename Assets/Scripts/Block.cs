using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //Config params
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprite;

    //Cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; //TODO only serialized for debug purpose

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(tag == "Breakable")
        {
            HandleHit(collision);
        }
    }

    private void HandleHit(Collision2D collision)
    {
        timesHit++;
        maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock(collision);
        }
        else
        {
            showNextHitSprite();
        }
    }

    private void showNextHitSprite()
    {
        int indexHit = timesHit - 1;
        if(hitSprite[indexHit] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[indexHit];
        }
        else
        {
            Debug.LogError("Missing object name is " + gameObject.name);
        }
    }

    private void DestroyBlock(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().AddScore();
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        Destroy(gameObject);
        OnTriggerSparklesVFX();
        level.WinLose();
    }

    public void OnTriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
