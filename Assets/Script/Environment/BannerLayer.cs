using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerLayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform player;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.sortingLayerName = player.position.x > transform.position.x ? "Front" : "Environment_Back";
    }
}
