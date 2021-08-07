using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangeGroundUp : MonoBehaviour
{
    private bool valid;
    private bool oneTime;
    [SerializeField] private PlayerSinging playerSinging;
    [SerializeField] private float speed;
    [SerializeField] private Transform transform;
    [SerializeField] private float maxY;
    [SerializeField] private GameObject singOrHumming;

    private Vector2 oldPosition;

    private void Start()
    {
        SingHum(false);
        oldPosition = transform.position;
    }

    private void SingHum(bool validasi)
    {
        if (singOrHumming != null)
            singOrHumming.SetActive(validasi);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SingHum(!oneTime);
            valid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SingHum(false);
            valid = false;
        }
    }

    private void Update()
    {
        if (valid)
        {
            if (playerSinging.valPitch > 0 && singOrHumming != null)
            {
                oneTime = true;
                singOrHumming.SetActive(false);
            }
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
