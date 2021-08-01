using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SideButtonHighlight : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    [SerializeField] private GameObject sideImage;
    public void OnPointerEnter(PointerEventData eventData)
    {
        sideImage.SetActive(true);
    }

    public void OnSelect(BaseEventData eventData)
    {
        sideImage.SetActive(true);
    }

    private void Update()
    {
        sideImage.SetActive(false);
    }
}
