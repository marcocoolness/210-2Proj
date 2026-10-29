using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private GameObject whirlpool;
    GlobalVariables scene11;

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
            if(scene11.optionScript=1)
            {
                transform.position=new Vector2(-.6f,-2.48f);
                //AutoMove1 Courotine
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
}
