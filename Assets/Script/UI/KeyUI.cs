using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private bool performance;

    private void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if(!performance)
        {
            if (playerController.grounded)
            {
                transform.localScale = new Vector3(1, 1, 1);
                performance = true;
            }
        }
        else
        {
            if (playerController.animator.GetFloat("moveX") != 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
