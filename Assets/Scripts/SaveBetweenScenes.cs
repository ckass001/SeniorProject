using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBetweenScenes : MonoBehaviour
{
    public static string authenticationToken;
    //public static string URL = "http://localhost:8000/graphql/";
    public static string URL = "http://cs411-f21-orange.student.cs.odu.edu:8000/graphql/";
    public static int playerBank;
    public static int playerMorale;
    public static int currentLesson = 1;
    public static float coffeeValue = 5;
}
