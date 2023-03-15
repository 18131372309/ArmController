using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayCastManager : MonoBehaviour
{
    public static RayCastManager Instance;
    Ray ray;
    RaycastHit hit;
    // Material test1;
    private bool isCtrlOn = false;
    public Material mat;
    private List<MeshRenderer> selectMesh;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //test1 = Resources.Load("Materials/Mat1") as Material;
        selectMesh = new List<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCtrlOn = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCtrlOn = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!isCtrlOn)
            {
                ResetMat();
            }
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("weld"))
                {
                    selectMesh.Add(hit.collider.gameObject.GetComponent<MeshRenderer>());
                    // hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
                //MatManager.Instance.SetMeshMat(hit.collider.gameObject, new Material[] { test1 });
            }

            foreach (var v in selectMesh)
            {
                //TODO:Õ‚∑¢π‚
                v.material.color = Color.green;
            }

        }
    }

    void ResetMat()
    {
        foreach (var v in selectMesh)
        {
            v.material.color = mat.color;
        }
        selectMesh.Clear();

    }

    public List<MeshRenderer> GetSelectWeldsList()
    {
        return selectMesh;
    }
}
