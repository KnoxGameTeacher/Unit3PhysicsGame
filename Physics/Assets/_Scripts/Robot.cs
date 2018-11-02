using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour 
{

    [SerializeField] bool isBreakable = false;
    [SerializeField] GameObject electricityVFX;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] damageSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isBreakable == true)
        {
            GetHit();

        }
    }

    private void GetHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            NextDamageSprite();
        }
    }

    private void NextDamageSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = damageSprite[spriteIndex];

    }

    private void DestroyBlock()
    {
        FindObjectOfType<_LevelManager>().AddToScore();
        GameObject electricity = Instantiate(electricityVFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position);
        Destroy(gameObject);


    }

}
