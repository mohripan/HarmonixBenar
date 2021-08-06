using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;

    [SerializeField]
    private PlayerSinging singing;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (singing.valPitch != 0)
        {
            Instantiate(spawnee,new Vector3(spawnPos.position.x,spawnPos.position.y,spawnPos.position.z), Quaternion.identity);
            Debug.Log(singing.valPitch);
        }
    }
}
