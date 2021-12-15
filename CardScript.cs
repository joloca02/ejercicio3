using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public bool volteada = false;
    public Sprite front;
    public Sprite back;
    SpriteRenderer spriteRenderer;
    GameObject gameManager;
    public int puntuacion = 0;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {

        gameManager.GetComponent<GameManager>().clickOnCard(name, puntuacion);
        if (volteada == false)
        {
            spriteRenderer.sprite = front;
            volteada = true;
        }

        else
        {
            spriteRenderer.sprite = back;
            volteada = false;
        }
    }
  
}
