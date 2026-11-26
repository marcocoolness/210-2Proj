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
    GameObject HiArcRef, StopCheck, Point, skillmeter, Scene1;
    string[] textToType11= { "" };

    void Start()
    {
        //System.Array.Clear(textToType11, 0, textToType11.Length);
        //System.Array.Resize(ref textToType11, 1);
        string[] textToType11 = { "Who would you like to meet with?" };
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        position = GetComponent<RectTransform>();
        posref=position.anchoredPosition;//Debug.Log(position.anchoredPosition);
        position.anchoredPosition = new Vector2(posref.x, moveoutypos);
        text = GetComponentInChildren<TMP_Text>();
        StopCheck=GameObject.Find("pie");
        Point=GameObject.Find("pointer");
        skillmeter = GameObject.Find("skillcheck");
        Scene1 = GameObject.Find("Triangle");
        //DontDestroyOnLoad(StopCheck.gameObject);
        //DontDestroyOnLoad(Point.gameObject);
        //DontDestroyOnLoad(skillmeter.gameObject);
        //DontDestroyOnLoad(text.gameObject);
        //DontDestroyOnLoad(Scene1.gameObject);
        skillpos = skillmeter.GetComponent<RectTransform>();
        if (sceneName == "OutsideScene")
        {
            System.Array.Clear(textToType11, 0, textToType11.Length);
            System.Array.Resize(ref textToType11, 20);
            textToType11[0]="Hello Alexander!";
            textToType11[1]="Hello Jack, how's your day going?";
            textToType11[2]="My day could get better, I've just been focusing on my daily tasks is all!";
            textToType11[3]="Oh really? What makes you say that?";
            textToType11[4]="Well...";
            textToType11[5] = "I've been... thinking about things that's been making me feel like I have to be aware of my concious at all times...";
            textToType11[6] = "Hmm... That sounds interesting...";
            textToType11[7] = "You know, I've been having somewhat of the same feeling as you";
            textToType11[8] = "Oh, that so?";
            textToType11[9] = "Yeah, I'd always have these thoughts that'd traverse in my mind.";
            textToType11[10] = "Hello Alexander!";
            textToType11[11] = "Hello Jack, how's your day going?";
            textToType11[12] = "My day could get better, I've just been focusing on my daily tasks is all!";
            textToType11[13] = "Oh really? What makes you say that?";
            textToType11[14] = "Well...";
            textToType11[15] = "I've been... thinking about things that's been making me feel like I have to be aware of my concious at all times...";
            textToType11[16] = "Hmm... That sounds interesting...";
            textToType11[17] = "You know, I've been having somewhat of the same feeling as you";
            textToType11[18] = "Oh, that so?";
            textToType11[19] = "Yeah, I'd always have these thoughts that'd traverse in my mind.";
            string buffer = "";
            foreach (string textToType in textToType11)
            {
                buffer = buffer + " " + textToType;
                }
                Debug.Log(buffer);
            HiArcRef = GameObject.Find("Player");
        if (HiArcRef!=null)
        {
            playerid=HiArcRef.GetComponent<PlayerMovement>();
        }
        }
    }

    // Update is called once per frame
    public void MoveIn()
    {
        //skillpos.anchoredPosition=new Vector2(0f,0f);
        //StartCoroutine(Skillcheck(1f));
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
        position.anchoredPosition += new Vector2(0f, .6f);// transform.position
        posref = position.anchoredPosition;
        }
        while (posref.y <= moveinypos);
        position.anchoredPosition = new Vector2(posref.x, moveinypos);
        string buffer = "";
        foreach (string textToType in textToType11)
        {
            buffer = buffer + " " + textToType;
        }
        Debug.Log(buffer);
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
IEnumerator Skillcheck(float Speed, float S_Timer){
    HiArcRef= GameObject.Find("Player");
        if (HiArcRef!=null)
        {
            playerid=HiArcRef.GetComponent<PlayerMovement>();
        }
        RectTransform rectt = StopCheck.GetComponent<RectTransform>();
        RectTransform rectt2 = Point.GetComponent<RectTransform>();
        rectt.rotation= Quaternion.Euler(0f,0f,Random.Range(-180f, 180f));

        yield return new WaitForSeconds(.25f); 
        float incre=0f;
do
        {
           rectt2.rotation= Quaternion.Euler(0f,0f,incre);
           yield return new WaitForSeconds(.004f); 
           incre+=Speed;
        }
        while (!playerid.interactable);//180f+width && 180f-width
        Debug.Log("StopCheck Rotation: "+ (rectt.eulerAngles.z) + " Point: " + (rectt2.eulerAngles.z));//+180f
        if ((rectt.eulerAngles.z+15 >=rectt2.eulerAngles.z || (rectt.eulerAngles.z + 15f)%360f >= rectt2.eulerAngles.z ) &&(rectt.eulerAngles.z - 15f<=rectt2.eulerAngles.z || (rectt.eulerAngles.z - 15f)%360f <= rectt2.eulerAngles.z )){
Debug.Log("Win");
        }
        else{
            Debug.Log("Lose!");
        }
        yield return new WaitForSeconds(.25f);
    }
}