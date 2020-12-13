using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public static Controls Instance;
    public static bool Forward
    {
        get
        {
            return Input.GetKey(KeyCode.W);
        }
    }
    public static bool Left
    {
        get
        {
            return Input.GetKey(KeyCode.A);
        }
    }
    public static bool Right
    {
        get
        {
            return Input.GetKey(KeyCode.D);
        }
    }
    public static bool Back
    {
        get
        {
            return Input.GetKey(KeyCode.S);
        }
    }
    public static bool Pause
    {
        get
        {
            return Input.GetKeyDown(KeyCode.P);
        }
    }
}