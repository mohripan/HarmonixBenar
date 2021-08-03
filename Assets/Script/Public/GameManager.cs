using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float time;
    public Animator anims;
    public float animTime;

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
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(1);
        }
    }

    private IEnumerator WaitForAnimation(string sceneName)
    {
        anims.SetBool("isPlay", true);
        yield return new WaitForSeconds(animTime);
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneWithAnimation(string sceneName)
    {
        StartCoroutine(WaitForAnimation(sceneName));
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
