using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConfigManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetProjectInfo());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetProjectInfo()
    {
        string url = "file:///" + Application.dataPath + "/Config/ProjectInfo.txt";
        Debug.Log(url);
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("GetProjectInfo:" + webRequest.downloadHandler.text);
        }
        else
        {
            Debug.Log(webRequest.error);
        }
    }
}
