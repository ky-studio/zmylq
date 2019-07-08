using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadScripts : MonoBehaviour
{
    //按行读取文本文件来进行操作
    // Start is called before the first frame update
    public static LoadScripts instance;//静态唯一副本？
    public float a;
    int index;//代表当前读取的行数？
    public bool isnull;
    List<string> txt;
    
    private void Awake()
    {
        instance = this;
        index = 0;
        instance.isnull = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSripcts(string txtFileName)
    {
        Debug.Log("start");
        index = 0;
        txt = new List<string>();
        StreamReader stream = new StreamReader("Assets/StoryScripts/" + txtFileName);
        Debug.Log(txtFileName);

        while(!stream.EndOfStream)
        {
            txt.Add(stream.ReadLine());
        }
        stream.Close();
        instance.isnull = false;
        Debug.Log("end");
        //for(int i=0;i<txt.Count;i++)
        //    Debug.Log(txt[i]);
    }
    public ScriptData LoadNext()
    {
        if (index < txt.Count)
        {
           
            Debug.Log("count=:"+txt.Count);
            string[] datas = txt[index].Split(';');//这里采用分号更好，因为对话中可能有都好，而且应当是英文分号
            Debug.Log("index=:"+index);
            int type = int.Parse(datas[0]);
           
            if (0 == type)//就只有背景图片的设置
            {
                string picName = datas[1];
                index++;
                return new ScriptData(type, picName);

            }
            else if(1==type)//就只有type+名字+对话
            {
                string name = datas[1];
                string talk = datas[2];
                Debug.Log(datas[1]);
                Debug.Log(datas[2]);
                index++;
                return new ScriptData(type, name, talk);
            }
            else if (2 == type)
            {
                string pos = datas[1];
                string name = datas[2];
                string talk = datas[3];
                string picName = datas[4];
                index++;
                return new ScriptData(type, pos, name, talk, picName);
            }

            else
                return null;
        }
        else return null;
    }
}
