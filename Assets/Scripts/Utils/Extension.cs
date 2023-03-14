using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static void DestoryAllChild(this Transform trans)
    {
        int childCount = trans.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject.Destroy(trans.GetChild(0).gameObject);
        }
    }
}
