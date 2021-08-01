using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButtonMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject showButton;

    private void Start()
    {
        showButton.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            showButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
