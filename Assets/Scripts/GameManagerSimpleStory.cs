using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManagerSimpleStory : MonoBehaviour
{
    // Start is called before the first frame update
    public Text name;//一次只显示一个人说的话，所以不需要两个人的名字
    public Text talk;//对话的内容
    public Image background;//背景图片
    //public Image left;//左边的图片
    //public Image right;//右边的图片
   // public LoadScripts ls;
    void Start()
    {
        Debug.Log("a");
         LoadScripts.instance.LoadSripcts("simplestory1.txt");
        Debug.Log("b");
        //ls.LoadSripcts("simplestory1.txt");
        handleData(LoadScripts.instance.LoadNext());
       // handleData(ls.LoadNext());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0)&&LoadScripts.instance.isnull==false)
        {
            Debug.Log("正确处理");
            handleData(LoadScripts.instance.LoadNext());
            //handleData(ls.LoadNext());
        }*/
    }
    public void OnClickWholeNext()
    {
        if (Input.GetMouseButtonDown(0) && LoadScripts.instance.isnull == false)
        {
            Debug.Log("正确处理");
            handleData(LoadScripts.instance.LoadNext());
            //handleData(ls.LoadNext());
        }
    }
    public void setText(Text text,string content)
    {
        print(content);
        text.text = content;
    }
    public void setImage(Image image,string picName)
    {
        image.sprite = loadPicture("Assets/background/" + picName);
    }
    public Sprite loadPicture(string picPath)
    {
        //创建文件读取流
        FileStream fileStream = new FileStream(picPath, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        //创建Texture
        int width = Screen.width;
        int height = Screen.height;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);

        //创建Sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return sprite;
    

    }
    public void handleData(ScriptData data)
    {
        if (null == data)
            return;
        if(0==data.type)
        {
            setImage(background, data.picName);
            print(data.picName);
            handleData(LoadScripts.instance.LoadNext());
            //handleData(ls.LoadNext());
        }
        else if(1==data.type)
        {
            /*//要这个暂时没有用处，因为左边和右边暂时没有图片
            if (data.pos.CompareTo("left") == 0)
            {
                left.gameObject.SetActive(true);
                setImage(left, data.picName);
                right.gameObject.SetActive(false);
            }
            else
            {
                right.gameObject.SetActive(true);
                setImage(right, data.picName);
                left.gameObject.SetActive(false);
            }*/
            setText(name, data.name);
            setText(talk, data.talk);


        }
    }
}
