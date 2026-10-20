using UnityEngine;
using System.Collections;

public class popup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    RectTransform position;
    float moveinypos = -30f;
    float moveoutypos = -50f;
    void Start()
    {
        position = GetComponent<RectTransform>();
        Debug.Log(position.anchoredPosition);
        position.anchoredPosition = new Vector2(position.right.x, moveoutypos);
        //transform.position=
    }

    // Update is called once per frame
    public void MoveIn()
    {
        do
        {
            StartCoroutine(DelayedAction());
        }
        while (position.up.y <= moveinypos);//transform
    }
    public void MoveOut()
    {
        do
        {
            StartCoroutine(DelayedAction2());
        }
        while (position.up.y >= moveinypos);//transform
    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(.1f);
        position.anchoredPosition += new Vector2(0f, -.3f);// transform.position
    }
    IEnumerator DelayedAction2()
    {
        yield return new WaitForSeconds(.1f);
        position.anchoredPosition += new Vector2(0f, .3f);// transform.position
    }
}