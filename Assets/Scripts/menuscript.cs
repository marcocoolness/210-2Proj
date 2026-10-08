using UnityEngine;

public class menuscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    RectTransform position;
    float moveinypos = 0f;
        float moveoutypos = 0f;
    void Start()
    {
        position = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void MoveIn()
    {
       do { 
        StartCoroutine(DelayedAction());
        }
        while (position <= 10);
    }
    void MoveOut()
    {
        
    }
    

IEnumerator DelayedAction()
{
    yield return new WaitForSeconds(.1f);
        position.anchoredPosition += new Vector2(0, -.3);
    }
    IEnumerator DelayedAction2()
    {
        yield return new WaitForSeconds(.1f);
        position.anchoredPosition += new Vector2(0, .3);
    }
}

