using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] float minX = -7f;
    [SerializeField] float maxX = 7f;
    [SerializeField] float screenWidthUnits = 16f;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        float mousePosUnits = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosUnits, minX, maxX);
        transform.position = paddlePos;
	}
}
