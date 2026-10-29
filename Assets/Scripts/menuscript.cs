using UnityEngine;
using System.Collections;

public class menuscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    RectTransform position;
    float moveinypos = 12f;
    float moveoutypos = 80f;
    Vector2 posref;
    void Start()
    {
        position = GetComponent<RectTransform>();
        posref=position.anchoredPosition;//Debug.Log(position.anchoredPosition);
        position.anchoredPosition = new Vector2(posref.x, moveoutypos);
        //transform.position=
    }

    // Update is called once per frame
    public void MoveIn()
    {
          StartCoroutine(DelayedAction());
          //transform
    }
    public void MoveOut()
    {
          StartCoroutine(DelayedAction2());

    }

    IEnumerator DelayedAction()
    {
        posref = position.anchoredPosition;
        do
        {
        yield return new WaitForSeconds(.01f);
        position.anchoredPosition += new Vector2(0f, -.6f);// transform.position
        posref = position.anchoredPosition;
        }
        while (posref.y >= moveinypos);
        position.anchoredPosition = new Vector2(posref.x, moveinypos);
    }
    IEnumerator DelayedAction2()
    {
        posref = position.anchoredPosition;
        do
        {
           yield return new WaitForSeconds(.01f);
        position.anchoredPosition += new Vector2(0f, .6f);// transform.position
        posref = position.anchoredPosition;
        }
        while (posref.y <= moveoutypos);//transform
        position.anchoredPosition = new Vector2(posref.x, moveoutypos);
    }
}

