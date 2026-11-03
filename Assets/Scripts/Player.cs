using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    private GameObject whirlpool;
    GlobalVariables scene11;
    GameObject Scene1;
GameObject Scene2;
    GameObject Scene3;
    GameObject Friend;
    popup pop1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Scene currentScene = SceneManager.GetActiveScene();
    string sceneName = currentScene.name;
        GameObject Obref=GameObject.Find("VariableObject");
        if(Obref!=null)
        {
            scene11=Obref.GetComponent<GlobalVariables>();
        }
        
        if (sceneName == "OutsideScene")
        {
            Obref=GameObject.Find("Panel2");
        if (Obref!=null)
        {
            pop1=Obref.GetComponent<popup>();
        }
        Friend=GameObject.Find("Friend");
            Scene1 = GameObject.Find("S1");
            Scene2 = GameObject.Find("S2");
            Scene3 = GameObject.Find("S3");
            if (scene11.optionScript==1)
            {
                transform.position=new Vector2(-.6f,-4.48f);
                Friend.transform.position=new Vector2(-.6f,3.88f);
                SpriteRenderer GetColor=Scene1.GetComponent<SpriteRenderer>();
                if (GetColor!=null) {
                Color colorchange = new Color(GetColor.color.r, GetColor.color.g, GetColor.color.b, 1f);
                    GetColor.color=colorchange;
                }
                StartCoroutine(AutoMove1());
                pop1.MoveIn();
            }
            else if (scene11.optionScript == 2)
            {
                transform.position = new Vector2(2.14f, -4.44f);
                Friend.transform.position=new Vector2(2.14f,1.42f);
                SpriteRenderer GetColor = Scene2.GetComponent<SpriteRenderer>();
                if (GetColor != null)
                {
                    Color colorchange = new Color(GetColor.color.r, GetColor.color.g, GetColor.color.b, 1f);
                    GetColor.color = colorchange;
                }
                StartCoroutine(AutoMove2());
                pop1.MoveIn();
            }
            else
            {
                transform.position = new Vector2(-6.79f, -2.84f);
                Friend.transform.position=new Vector2(.71f,.82f);
                SpriteRenderer GetColor = Scene3.GetComponent<SpriteRenderer>();
                if (GetColor != null)
                {
                    Color colorchange = new Color(GetColor.color.r, GetColor.color.g, GetColor.color.b, 1f);
                    GetColor.color = colorchange;
                }
                StartCoroutine(AutoMove3());
                pop1.MoveIn();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Whirlpool"))
        {
            whirlpool = collision.gameObject;
            transform.parent = whirlpool.transform.parent;
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("BedRoom");
        }
        if (collision.gameObject.CompareTag("Downstairs"))
            {
                //Destroy(this.gameObject);
                SceneManager.LoadScene("DownStairs");
                Debug.Log("Down");
            }
        if (collision.gameObject.CompareTag("BedRoom"))
            {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("BedRoom");
            Debug.Log("Bed");
            }
    }
    IEnumerator AutoMove1()
    {
        Vector3 posref = transform.position;
        do
        {
            yield return new WaitForSeconds(.01f);
            transform.position += new Vector3(0f, .03f);// transform.position
            posref = transform.position;
        }
        while (posref.y <= -.64f);
        transform.position = new Vector3(posref.x, -.64f);
    }
    IEnumerator AutoMove2()
    {
        Vector3 posref = transform.position;
        do
        {
            yield return new WaitForSeconds(.01f);
            transform.position += new Vector3(0f, .03f);// transform.position
            posref = transform.position;
        }
        while (posref.y <= -1.26f);
        transform.position = new Vector3(posref.x, -1.26f);
    }
    IEnumerator AutoMove3()
    {
        Vector3 posref = transform.position;
        do
        {
            yield return new WaitForSeconds(.01f);
            transform.position += new Vector3(.03f, 0f);// transform.position
            posref = transform.position;
        }
        while (posref.x <= .66f);
        transform.position = new Vector3(.66f, posref.y);
    }
}
