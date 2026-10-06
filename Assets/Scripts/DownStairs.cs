using UnityEngine;
using UnityEngine.SceneManagement;

public class DownStairs : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("DownStairs");
        }
    }
}
