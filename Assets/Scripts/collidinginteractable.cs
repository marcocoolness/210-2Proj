using UnityEngine;
using System.Collections;

public class collidinginteractable : MonoBehaviour
{
    BoxCollider2D Collide;
    GameObject player;
    PlayerMovement playerid;
    GameObject Canva;
    menuscript menu1;
    bool incollision=false;
    GameObject PauseHandle;
    gamepause pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collide= GetComponent<BoxCollider2D>();
        player= GameObject.Find("Player");
        if (player!=null)
        {
            playerid=player.GetComponent<PlayerMovement>();
        }
        Canva=GameObject.Find("Panel");
        if (Canva!=null)
        {
            menu1=Canva.GetComponent<menuscript>();
        }
        PauseHandle=GameObject.Find("GamePauseHandle");
        if (PauseHandle!=null)
        {
            pause=PauseHandle.GetComponent<gamepause>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(incollision && playerid.interactable && !pause.GAME_PAUSE)
       {
        pause.GAME_PAUSE=true;
           menu1.MoveIn();
           Debug.Log("Moved");
       }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject==player)
        {
            incollision=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject==player)
        {
           incollision=false;
        }
    }
}
