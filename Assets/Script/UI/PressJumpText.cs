using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressJumpText : MonoBehaviour
{
    [SerializeField] private GameObject spaceSize;

    private bool valid;

    private void Awake()
    {
        spaceSize.transform.localScale = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            spaceSize.transform.localScale = new Vector3(1, 1, 1);
            valid = true;
        }
    }

    private void Update()
    {
        if (valid)
        {
            if (Input.GetButtonDown("Jump"))
            {
                spaceSize.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
