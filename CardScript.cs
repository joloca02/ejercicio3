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
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        Debug.Log("carta " + name + " pulsada");
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
