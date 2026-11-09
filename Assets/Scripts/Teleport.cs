using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string sceneToLoad;
    public Animator fadeAnim;
    public float fadeTime = .5f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fadeAnim.Play("FadetoBlack");
            StartCoroutine(DelayFade());
            PauseController.SetPause(true);
        }
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneToLoad);
        PauseController.SetPause(false);
    }
}
