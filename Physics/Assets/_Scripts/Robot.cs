using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour 
{

    [SerializeField] bool isBreakable = false;
    [SerializeField] GameObject electricityVFX;
    [SerializeField] AudioClip explosionSFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isBreakable == true)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {

        GameObject electricity = Instantiate(electricityVFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position);
        Destroy(gameObject);


    }

}
