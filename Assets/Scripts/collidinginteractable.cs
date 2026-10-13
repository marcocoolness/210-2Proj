using UnityEngine;
using System.Collections;

public class collidinginteractable : MonoBehaviour
{
    BoxCollider2D Collide;
    GameObject player;
    PlayerMovement playerid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collide= GetComponent<BoxCollider2D>();
        player= GameObject.Find("Player");
        if (player!=null)
        {
            playerid=player.GetComponent<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject==player && playerid.interactable)
        {
           
        }
    }
}
