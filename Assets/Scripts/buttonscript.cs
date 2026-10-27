using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonscript : MonoBehaviour
{
    GlobalVariables refHead;
    public int Option;// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject Obref=GameObject.Find("VariableObject");
        if(Obref!=null)
        {
            refHead=Obref.GetComponent<GlobalVariables>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clicked()
    {
        //int Integer = refHead.optionScript;
        //Integer=Option;
        SceneManager.LoadScene("OutsideScene");
    }
}
