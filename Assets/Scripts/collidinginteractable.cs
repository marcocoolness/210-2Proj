using UnityEngine;
using System.Collections;

public class collidinginteractable : MonoBehaviour
{
    BoxCollider2D Collide;
    PlayerMovement playerid;
    GameObject HiArcRef;
    GameObject player;
    menuscript menu1;
    popup pop1;
    bool incollision=false;
    gamepause pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collide= GetComponent<BoxCollider2D>();
        HiArcRef=player= GameObject.Find("Player");
        if (HiArcRef!=null)
        {
            playerid=HiArcRef.GetComponent<PlayerMovement>();
        }
        HiArcRef=GameObject.Find("Panel");
        if (HiArcRef!=null)
        {
            menu1=HiArcRef.GetComponent<menuscript>();
        }
        HiArcRef=GameObject.Find("Panel2");
        if (HiArcRef!=null)
        {
            pop1=HiArcRef.GetComponent<popup>();
        }
        HiArcRef=GameObject.Find("GamePauseHandle");
        if (HiArcRef!=null)
        {
            pause=HiArcRef.GetComponent<gamepause>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(incollision && playerid.interactable && !pause.GAME_PAUSE)
       {
        pause.GAME_PAUSE=true;
           menu1.MoveIn();
           pop1.MoveIn();
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
