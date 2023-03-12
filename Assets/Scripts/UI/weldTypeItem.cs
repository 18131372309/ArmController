using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weldTypeItem : MonoBehaviour
{
    public int type = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            UIManager.Instance.ShowWeldingConfigUI(type);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
