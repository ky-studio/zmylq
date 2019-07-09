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
        //以下是实现淡入效果代码的调用
        GameObject.Find("block").transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        Debug.Log("是fadeinout instance的问题");
        //while (fadeinout.instance.isfadein == false)
        fadeinout.instance.fadeinset();

        

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
