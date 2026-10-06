using UnityEngine;
using UnityEngine.Input;

public class collidinginteractable : MonoBehaviour
{
    PlayerInput player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {

        }
    }
}
