using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    private GameObject animator;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.InitCameraMCBM(false);

        animator = GameObject.Find("StartAni");
        if (animator != null)
        {
            Invoke("HideAni", 2f);
        }
    }

    void HideAni()
    {

        animator.SetActive(false);
        //  InitUI();

    }

    void InitUI()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
