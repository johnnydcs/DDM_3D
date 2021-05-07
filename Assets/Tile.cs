using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite RedRef;
    public Sprite BlueRef;
    public Sprite BlackRef;

    public SpriteRenderer spriteRenderer;
    
    // Awake is called before Start
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = BlackRef;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
