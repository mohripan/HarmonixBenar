using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    [SerializeField] private PlayerVelocity playerVelocity;

    private bool performance;

    private void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if(!performance)
        {
            if (playerVelocity.playerMovement.collisionDirection.below && FirstLight.instance.readyPlaying)
            {
                transform.localScale = new Vector3(1, 1, 1);
                performance = true;
            }
        }
        else
        {
            if (playerVelocity.directionalInput.x != 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
