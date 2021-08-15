using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangeGroundUp : MonoBehaviour
{
    private bool valid;
    private float previousGravity;
    [SerializeField] private PlayerSinging playerSinging;
    [SerializeField] private float speed;
    [SerializeField] private Transform transformer;
    [SerializeField] private float maxY;
    [SerializeField] private PlayerVelocity playerVelocity;

    private Vector2 oldPosition;

    private void Start()
    {
        oldPosition = transformer.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            valid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            valid = false;
        }
    }

    private void Update()
    {
        if (valid)
        {
            Physics2D.SyncTransforms();

            float yPosition = Mathf.Min(oldPosition.y + (playerSinging.valPitch / 35), oldPosition.y+maxY);
            Vector2 groundUp = new Vector2(oldPosition.x, yPosition);

            transformer.position = Vector2.MoveTowards(transformer.position, groundUp, speed * Time.deltaTime);
        }
        else
        {
            transformer.position = Vector2.MoveTowards(transformer.position, oldPosition, speed * Time.deltaTime);
        }
    }
}
