using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        //SceneManager.LoadScene("scene0");
    }
    public void OnClickButtonReturnMenu()
    {
        SceneManager.LoadScene("scene0");
    }
    public void OnClickButtonFile1()
    {
        ChooseFile(1);

    }
    public void OnClickButtonFile2()
    {
        ChooseFile(2);

    }
    public void OnClickButtonFile3()
    {
        ChooseFile(3);
    }
    public void OnClickButtonFile4()
    {
        ChooseFile(4);
    }
    public void OnClickButtonFile5()
    {
        ChooseFile(5);

    }
    public void OnClickButtonFile6()
    {
        ChooseFile(6);
    }
    public void ChooseFile(int index)
    {
        GameObject[] filesix=new GameObject[6];
        filesix[0] = GameObject.Find("file1");
        filesix[1] = GameObject.Find("file2");
        filesix[2] = GameObject.Find("file3");
        filesix[3] = GameObject.Find("file4");
        filesix[4] = GameObject.Find("file5");
        filesix[5] = GameObject.Find("file6");

        for(int i=0;i<6;i++)
        {
            if(i==index-1)
            {
                filesix[i].GetComponent<Image>().color = Color.red;
            }
            else
                filesix[i].GetComponent<Image>().color = Color.white;
        }

    }
}
