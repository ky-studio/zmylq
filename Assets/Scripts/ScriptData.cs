using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptData
{
    // Start is called before the first frame update
    public int type; //类型0代表载入背景图片，1代表载入人物对话，后期加入人物选择跳转剧本等
    public string pos;//角色位置，就是角色出现的位置，左边或者右边等等
    public string name;//角色的名字
    public string picName;//角色的图片
    public string talk;//对话内容
    //这里是采用txt保存剧本的

    public ScriptData(int type, string pos, string name, string talk, string picName)//这种方式暂时先保留
    {
        this.type = type;
        this.pos = pos;
        this.name = name;
        this.talk = talk;
        this.picName = picName;
    }
    public ScriptData(int type, string name, string talk)//只更新文本先
    {
        this.type = type;
        this.name = name;
        this.talk = talk;
    }
    public ScriptData(int type, string picName)
    {
        this.type = type;
        this.picName = picName;
    }
}
