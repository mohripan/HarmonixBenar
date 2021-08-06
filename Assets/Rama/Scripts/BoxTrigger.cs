using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("masuk bos");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("char didalem box");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("charnya keluar box");
    }
}
