/*
 * 该模块实现读档和存档的API 
 */

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class ArchivePoint
{
    public string sceneName;
    public string backgroundPath;
    public string plotChapter;
    public int fans;
    public int intelligence;
    public int[] favorability = new int[3];
}

public class SaveInfo
{
    public string username;
    public ArchivePoint point;
}


public static class SaveLoad
{
    // 存档目录，存档文件名为save1.sav~save6.sav
    public static string saveDir = Application.persistentDataPath;
    public static string secretKey = "zmylqzmylqzmylqzmylqzmylqzmylqzm";

    public static SaveInfo SetData(string username, string sceneName, string bgPath, string pChapter, int fans, int intlligence, int[] favor)
    {
        SaveInfo ret = new SaveInfo();
        ret.username = username;
        ret.point = new ArchivePoint();
        ret.point.sceneName = sceneName;
        ret.point.backgroundPath = bgPath;
        ret.point.plotChapter = pChapter;
        ret.point.fans = fans;
        ret.point.intelligence = intlligence;
        for (int i = 0; i < 3; i++)
        {
            ret.point.favorability[i] = favor[i];
        }
        return ret;
    }

    public static void Save(int saveId, SaveInfo pData)
    {
        if (!Directory.Exists(saveDir))
        {
            Directory.CreateDirectory(saveDir);
        }
        string saveStr = string.Empty;
        // 将SaveInfo类型对象序列化
        saveStr = JsonConvert.SerializeObject(pData);
        // 加密
        saveStr = RijndaelEncrypt(saveStr, secretKey);
        string filename = string.Format("{0}/save{1}.sav", saveDir, saveId);
        StreamWriter streamWriter = File.CreateText(filename);
        streamWriter.Write(saveStr);
        streamWriter.Close();
    }

    public static SaveInfo Load(int saveId)
    {
        string filename = string.Format("{0}/save{1}.sav", saveDir, saveId);
        if (!File.Exists(filename))
        {
            return null;
        }
        StreamReader streamReader = File.OpenText(filename);
        string loadStr = streamReader.ReadToEnd();
        streamReader.Close();
        // 解密
        loadStr = RijndaelDecrypt(loadStr, secretKey);
        // 反序列化返回SaveInfo类型的对象
        return JsonConvert.DeserializeObject<SaveInfo>(loadStr);
    }

    // Rijndael加密
    private static string RijndaelEncrypt(string pString, string pKey)
    {
        //密钥
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
        //待加密明文数组
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(pString);

        //Rijndael解密算法
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateEncryptor();

        //返回加密后的密文
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    // Rijndael解密
    private static String RijndaelDecrypt(string pString, string pKey)
    {
        //解密密钥
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
        //待解密密文数组
        byte[] toEncryptArray = Convert.FromBase64String(pString);

        //Rijndael解密算法
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateDecryptor();

        //返回解密后的明文
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
}
