using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatManager
{
    private static MatManager _instance;

    public static MatManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MatManager();
            }

            return _instance;
        }
    }

    public void SetMeshMat(GameObject target, Material[] mats)
    {
        if (target.GetComponent<MeshRenderer>() != null && target.GetComponent<MeshFilter>() != null)
        {
            target.GetComponent<MeshRenderer>().materials = mats;
        }
    }
}
