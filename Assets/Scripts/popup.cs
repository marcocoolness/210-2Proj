using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class popup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    RectTransform position,skillpos;
    float moveinypos = -40f;
    float moveoutypos = -80f;
    Vector2 posref;
    TMP_Text text;
    PlayerMovement playerid;
    GameObject HiArcRef, StopCheck, Point, skillmeter;
    string[] textToType11={"Who would you like to meet with?"};

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        position = GetComponent<RectTransform>();
        posref=position.anchoredPosition;//Debug.Log(position.anchoredPosition);
        position.anchoredPosition = new Vector2(posref.x, moveoutypos);
        text = GetComponentInChildren<TMP_Text>();
        StopCheck=GameObject.Find("pie");
        Point=GameObject.Find("pointer");
        skillmeter=GameObject.Find("skillcheck");
        skillpos=skillmeter.GetComponent<RectTransform>();
        if (sceneName == "OutsideScene")
        {
            System.Array.Clear(textToType11, 0, textToType11.Length);
            System.Array.Resize(ref textToType11, 5);
            textToType11[0]="Message1";
            textToType11[1]="Message1";
            textToType11[2]="Message1";
            textToType11[3]="Message1";
            textToType11[4]="Message1";
        HiArcRef= GameObject.Find("Player");
        if (HiArcRef!=null)
        {
            playerid=HiArcRef.GetComponent<PlayerMovement>();
        }
        }
    }

    // Update is called once per frame
    public void MoveIn()
    {
        skillpos.anchoredPosition=new Vector2(0f,0f);
        StartCoroutine(Skillcheck(1f));
          //StartCoroutine(DelayedAction());
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
        position.anchoredPosition += new Vector2(0f, .6f);// transform.position
        posref = position.anchoredPosition;
        }
        while (posref.y <= moveinypos);
        position.anchoredPosition = new Vector2(posref.x, moveinypos);
        StartCoroutine(TypeText(textToType11));
    }
    IEnumerator DelayedAction2()
    {
        posref = position.anchoredPosition;
        do
        {
           yield return new WaitForSeconds(.01f);
        position.anchoredPosition += new Vector2(0f, -.6f);// transform.position
        posref = position.anchoredPosition;
        }
        while (posref.y >= moveoutypos);//transform
        position.anchoredPosition = new Vector2(posref.x, moveoutypos);
    }
    IEnumerator TypeText(string[] textref) {
   
        foreach (string textToType in textref){
      string buffer = "";   
        foreach (char c in textToType) {
            buffer += c;
            text.text = buffer;
            yield return new WaitForSeconds(.05f);
        }
        if (textref.Length!=1){
        float triangleposy=-15f;
        float alpha=0f;
        GameObject Scene1=GameObject.Find("Triangle");
        do
        {
           triangleposy-=.05f;
           SpriteRenderer GetColor=Scene1.GetComponent<SpriteRenderer>();
                if (GetColor!=null) {
                Color colorchange = new Color(GetColor.color.r, GetColor.color.g, GetColor.color.b, alpha);
                GetColor.color=colorchange;}
            if (triangleposy<-20)
            {
triangleposy=-15f;
            }
            RectTransform position2 = Scene1.GetComponent<RectTransform>();
        Vector2 posref2=position2.anchoredPosition;//Debug.Log(position.anchoredPosition);
        position2.anchoredPosition = new Vector2(posref2.x, triangleposy);
           yield return new WaitForSeconds(.01f); 
        }
        while (!playerid.interactable);
        }
    }
}
IEnumerator Skillcheck(float Speed){
    HiArcRef= GameObject.Find("Player");
        if (HiArcRef!=null)
        {
            playerid=HiArcRef.GetComponent<PlayerMovement>();
        }
        RectTransform rectt = StopCheck.GetComponent<RectTransform>();
        RectTransform rectt2 = Point.GetComponent<RectTransform>();
        rectt.rotation= Quaternion.Euler(0f,0f,Random.Range(0f, 360f));
        yield return new WaitForSeconds(.5f); 
        float incre=0f;
do
        {
           rectt2.rotation= Quaternion.Euler(0f,0f,incre);
           yield return new WaitForSeconds(.01f); 
           incre+=Speed;
        }
        while (!playerid.interactable);
        if ((rectt2.rotation.z-15)%360f>=rectt.rotation.z&&(rectt2.rotation.z+15)%360f<=rectt.rotation.z){
Debug.Log("Win");
        }
        else{
            Debug.Log("Lose!");
        }
    }
}