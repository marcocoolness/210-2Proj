using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int optionScript = 0;
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int Reference()
    {
        return optionScript;
    }
}
