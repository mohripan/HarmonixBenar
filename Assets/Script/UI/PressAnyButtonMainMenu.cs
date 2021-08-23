using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButtonMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject showButton;
    [SerializeField] private GameObject fade;

    private void Start()
    {
        showButton.SetActive(false);
        fade.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            showButton.SetActive(true);
            gameObject.SetActive(false);
            fade.SetActive(true);
        }
    }
}
