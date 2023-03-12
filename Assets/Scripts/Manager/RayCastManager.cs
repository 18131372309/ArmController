using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Material test1;
    // Start is called before the first frame update
    void Start()
    {
        test1 = Resources.Load("Materials/Mat1") as Material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(hit.collider.name);
                MatManager.Instance.SetMeshMat(hit.collider.gameObject, new Material[] { test1 });
            }
        }
    }
}
