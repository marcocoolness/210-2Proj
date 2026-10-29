using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public int optionScript = 0;
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
    public void SetSceneVar(int Scene)
    {
        optionScript=Scene;
    }
}
