using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBackground : MonoBehaviour
{
    private SpriteRenderer[] sprites;
    private Transform[] transforms;

    private void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        transforms = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        for(int i=0; i < sprites.Length; i++)
        {
            int yMin = (int)(-transforms[i].position.y * 1000);
            sprites[i].sortingOrder = yMin;
        }
    }
}
