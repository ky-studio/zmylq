using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControl : MonoBehaviour
{
    public bool isscene1;
    // Start is called before the first frame update
    void Start()
    {
        isscene1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickBackgroundSkip()
    {
        SceneManager.LoadScene("scene2");
        
        
    }
    public void OnClickButtonReturnMenu()
    {
        SceneManager.LoadScene("scene0");
    }
    public void OnClickButtonSaveLoad()
    {
        SceneManager.LoadScene("sceneSaveLoad",LoadSceneMode.Additive);
    }
}
