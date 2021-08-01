using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float time;

    private void Start()
    {
        StartCoroutine(ChangeToMain());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

    private IEnumerator ChangeToMain()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
