using UnityEngine;

public class gamepause : MonoBehaviour
{
    public bool GAME_PAUSE=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
