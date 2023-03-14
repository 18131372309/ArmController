using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;


public class NetWorkManager : MonoBehaviour
{

    public static NetWorkManager Instance;

    public delegate void textCallBack(string text);

    public delegate void textureCallBack(Texture texture);

    public delegate void getBytesCallBack(byte[] bytes);

    public delegate void postCallBack(string text);

    public delegate void postBytesCallBack(string text);

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// http Get请求获取文本信息
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callBack">回调事件，参数string </param>
    public void GetHttpRequestText(string url, textCallBack callBack)
    {
        StartCoroutine(IGetHttpRequestText(url, callBack));
    }

    IEnumerator IGetHttpRequestText(string url, textCallBack callBack)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            string text = webRequest.downloadHandler.text;
            callBack(text);
        }

    }

    /// <summary>
    /// http Get请求获取图片Texture
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callBack">回调事件，参数Texture</param>
    public void GetHttpRequestTexture(string url, textureCallBack callBack)
    {
        StartCoroutine(IGetHttpRequestTexture(url, callBack));
    }

    IEnumerator IGetHttpRequestTexture(string url, textureCallBack callBack)
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
        yield return webRequest.SendWebRequest();
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
            callBack(texture);
        }
    }

    /// <summary>
    /// 获取AudioClip
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callBack"></param>
    public void GetHttpRequestAudioClip(string url, UnityAction<AudioClip> callBack)
    {
        StartCoroutine(IGetHttpRequestAudioClip(url, callBack));
    }

    IEnumerator IGetHttpRequestAudioClip(string url, UnityAction<AudioClip> callBack)
    {
        UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
        yield return webRequest.SendWebRequest();
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(webRequest);
            callBack(clip);
        }
    }

    /// <summary>
    /// http Get请求获取bytes数据
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callBack"></param>
    public void GetHttpRequestBytes(string url, getBytesCallBack callBack)
    {
        StartCoroutine(IGetHttpRequestBytes(url, callBack));
    }

    IEnumerator IGetHttpRequestBytes(string url, getBytesCallBack callBack)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            byte[] bytes = webRequest.downloadHandler.data;
            callBack(bytes);
        }
    }

    /// <summary>
    /// http post发送表单数据
    /// </summary>
    /// <param name="url"></param>
    /// <param name="formData"></param>
    /// <param name="callBack"></param>
    public void PostHttpRequest(string url, List<IMultipartFormSection> formData, postCallBack callBack)
    {
        StartCoroutine(IPostFormHttpRequest(url, formData, callBack));
    }

    IEnumerator IPostFormHttpRequest(string url, List<IMultipartFormSection> formData, postCallBack callBack)
    {
        UnityWebRequest webRequest = UnityWebRequest.Post(url, formData);

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            string msg = webRequest.downloadHandler.text;
            callBack(msg);
        }

    }

    /// <summary>
    /// http post发送原始数据bytes
    /// </summary>
    /// <param name="url"></param>
    /// <param name="bytes"></param>
    /// <param name="callBack"></param>
    public void PostBytesHttpRequest(string url, byte[] bytes, postBytesCallBack callBack)
    {
        StartCoroutine(IPostBytesHttpRequest(url, bytes, callBack));
    }

    IEnumerator IPostBytesHttpRequest(string url, byte[] bytes, postBytesCallBack callBack)
    {
        UnityWebRequest webRequest = UnityWebRequest.Put(url, bytes);
        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            string msg = webRequest.downloadHandler.text;
            callBack(msg);
        }
    }


}
