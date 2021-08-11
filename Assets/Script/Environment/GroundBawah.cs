using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBawah : MonoBehaviour
{
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private SpriteRenderer shadow;

    private void ChangeSorting(int pSorting, int sSorting, string name)
    {
        player.sortingOrder = pSorting;
        player.sortingLayerName = name;
        shadow.sortingOrder = sSorting;
        shadow.sortingLayerName = name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ChangeSorting(-17, -18, "Ground");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChangeSorting(1, 0, "Player");
        }
    }
}
