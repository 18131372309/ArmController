using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        string projectInfo_url = "file:///" + Application.dataPath + "/Config/ProjectInfo.txt";
        // StartCoroutine(GetConfigInfoText(projectInfo_url));
        string camTexture_url = "file:///" + Application.dataPath + "/Config/camTexture.png";
    }

    public void GetStringOnLine(string url, UnityAction<string> callback)
    {
        StartCoroutine(GetConfigInfoText(url, callback));
    }

    public void GetTextureOnLine(string url, UnityAction<Texture> callback)
    {
        StartCoroutine(GetCamTexture(url, callback));

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetConfigInfoText(string url, UnityAction<string> callback)
    {

        Debug.Log(url);
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            string result = webRequest.downloadHandler.text;
            Debug.Log("GetProjectInfo:" + result);
            callback(result);
        }
        else
        {
            Debug.Log(webRequest.error);
        }
    }


    IEnumerator GetCamTexture(string url, UnityAction<Texture> callback)
    {

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            callback(myTexture);
        }
    }
}
