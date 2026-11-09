using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private GameObject whirlpool;

   
    
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
        if (collision.gameObject.CompareTag("Outside"))
            {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("Outside");
            Debug.Log("out");
            }
    }
}
