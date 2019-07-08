using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int choosefilenum;//默认选择的操作对象
    public string preScene;//代表着原先的场景
    void Start()
    {
        choosefilenum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickButtonReturnGame()//返回游戏
    {
        //SceneManager.LoadScene("scene2",LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene2"));
       // SceneManager.UnloadScene(SceneManager.GetSceneByName("sceneSaveLoad"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("sceneSaveLoad"));
    }
    public void OnClickButtonFile1()
    {
        GameObject fbt1 = GameObject.Find("file1");
        Renderer rd = fbt1.GetComponent<Renderer>();
        rd.material.color = Color.red;
    }
    public void OnClickButtonFile2()
    {
        GameObject fbt1 = GameObject.Find("file2");
        Renderer rd = fbt1.GetComponent<Renderer>();
        rd.material.color = Color.red;
    }
    public void OnClickButtonFile3()
    {
        GameObject fbt1 = GameObject.Find("file3");
        Renderer rd = fbt1.GetComponent<Renderer>();
        rd.material.color = Color.red;
    }
    public void OnClickButtonFile4()
    {
        GameObject fbt1 = GameObject.Find("file4");
        Renderer rd = fbt1.GetComponent<Renderer>();
        rd.material.color = Color.red;
    }
    public void OnClickButtonFile5()
    {
        GameObject fbt1 = GameObject.Find("file5");
        Renderer rd = fbt1.GetComponent<Renderer>();
        rd.material.color = Color.red;

    }
    public void OnClickButtonFile6()
    {
        GameObject fbt1 = GameObject.Find("file6");
        Renderer rd = fbt1.GetComponent<Renderer>();
        rd.material.color = Color.red;
    }
}
