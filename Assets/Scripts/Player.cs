using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private GameObject whirlpool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
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
    }
}
