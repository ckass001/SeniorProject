using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ReadInputText : MonoBehaviour
{
    public string userName;
    public int userAge;

    public void Start()
    {
        if (!File.Exists(@".\Files\UserInfo.json"))
        {
            File.Create(@".\Files\UserInfo.json");
        }
    }
    public void ReadName(string s)
    {
        Debug.Log(s);
        userName = s;
    }

    public void ReadAge(int i)
    {
        Debug.Log(i);
        userAge = i;
    }

    public void SaveToString()
    {
        File.WriteAllText(@".\Files\UserInfo.json", JsonUtility.ToJson(this, true));
    }
}
