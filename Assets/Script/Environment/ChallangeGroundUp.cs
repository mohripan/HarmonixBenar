using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangeGroundUp : MonoBehaviour
{
    private bool valid;
    [SerializeField] private PlayerSinging playerSinging;
    [SerializeField] private float speed;
    [SerializeField] private Transform transform;
    [SerializeField] private float maxY;
    [SerializeField] private GameObject singOrHumming;

    private Vector2 oldPosition;

    private void Start()
    {
        singOrHumming.SetActive(false);
        oldPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            singOrHumming.SetActive(true);
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
            if (playerSinging.valPitch > 0)
                singOrHumming.SetActive(false);
            Physics2D.SyncTransforms();
            float yPosition = Mathf.Min(oldPosition.y + (playerSinging.valPitch / 35), oldPosition.y+maxY);
            Vector2 groundUp = new Vector2(oldPosition.x, yPosition);

            transform.position = Vector2.MoveTowards(transform.position, groundUp, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, oldPosition, speed * Time.deltaTime);
        }
    }
}
