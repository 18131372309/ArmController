using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldInfo
{
    public bool hasInit = false;
    public static WeldInfo _instance;
    public static WeldInfo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WeldInfo();

            }

            return _instance;
        }
    }

    public void SetWeldInfo()
    {
        if (hasInit) { return; };
        //TODO:½âÎöjson


        hasInit = true;

    }
    void BornWeldTypeInfoItem()
    {

    }

    void BornWeldItemInfoItem()
    {

    }

    void InitData()
    {

    }
}
