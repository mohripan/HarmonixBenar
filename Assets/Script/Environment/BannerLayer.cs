using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerLayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform player;
    [SerializeField] private bool isground;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isground)
        {
            spriteRenderer.sortingLayerName = player.position.x > transform.position.x ? "Front" : "Environment_Back";
        }
        else
        {
            spriteRenderer.sortingOrder = player.position.x > transform.position.x ? -16 : -19;
        }
        
    }
}
