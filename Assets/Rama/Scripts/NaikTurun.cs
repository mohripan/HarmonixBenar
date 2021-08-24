using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaikTurun : MonoBehaviour
{
    private bool valid;

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
        if (collision.tag == "Player")
        {
            valid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            valid = false;
        }
    }

    private void Update()
    {
        ClassificationTrigger();
    }

    private void ClassificationTrigger()
    {
        if (valid && playerVelocity.playerMovement.collisionDirection.below)
        {
            CalculatePlatform();
        }
        else
        {
            transformer.position = Vector2.MoveTowards(transformer.position, oldPosition, speed * Time.deltaTime);
        }
    }

    private void CalculatePlatform()
    {
        Physics2D.SyncTransforms();

        float yPosition = Mathf.Min(oldPosition.y + playerSinging.valPitch / 35, oldPosition.y + maxY);
        Vector2 groundUp = new Vector2(oldPosition.x, yPosition);

        //Debug.Log(playerSinging.valPitch);

        transformer.position = Vector2.MoveTowards(transformer.position, groundUp, speed * Time.deltaTime);
    }
}
