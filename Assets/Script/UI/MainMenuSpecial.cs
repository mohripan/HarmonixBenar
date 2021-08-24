using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpecial : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void ChangeNewGame()
    {
        anim.SetBool("toNewGame", true);
    }
}
