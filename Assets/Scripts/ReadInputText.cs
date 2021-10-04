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
        if (!File.Exists(@".\Assets\Files\UserInfo.json"))
        {
            File.Create(@".\Assets\Files\UserInfo.json");
        }
    }
    public void ReadName(string s)
    {
        Debug.Log(s);
        userName = s;
    }

    public void ReadAge(string i)
    {
        Debug.Log(i);
        userAge = int.Parse(i);
    }

    public void SaveToString()
    {
        File.WriteAllText(@".\Assets\Files\UserInfo.json", JsonUtility.ToJson(this, true));
    }
}
