using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using System.IO;
using UnityEngine.Networking;
using System.Collections;
using CatFM;
using UnityEngine;

/// <summary>
/// Http封装
/// </summary>
public class HttpController : Singleton<HttpController>
{
    public void UnityGet(string url, Action<string> successCallback, Action failedCallback)
    {
        UnityWebRequest request = new UnityWebRequest(url, "GET");
        CatFM.GameLoop.StartCoroutine(UnityRequest(request, successCallback, failedCallback));
    }

    public void UnityPost(string url, Action<string> successCallback, Action failedCallback, byte[] data)
    {
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        CatFM.GameLoop.StartCoroutine(UnityRequest(request, successCallback, failedCallback, data));
    }

    public void DownloadFile(string url, byte[] fileName, Action<string, byte[]> successCallback, Action failedCallback)
    {
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        CatFM.GameLoop.StartCoroutine(Downloading(request, fileName, successCallback, failedCallback));
    }

    IEnumerator Downloading(UnityWebRequest request, byte[] data, Action<string, byte[]> successCallback, Action failedCallback)
    {
        request.uploadHandler = new UploadHandlerRaw(data);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Bug.Warning("http请求失败");
            failedCallback.Invoke();
        }
        else
        {
            Dictionary<string, string> headers = request.GetResponseHeaders();
            string fileName = headers["fileName"];
            successCallback.Invoke(fileName, request.downloadHandler.data);
        }
    }

    IEnumerator UnityRequest(UnityWebRequest request, Action<string> successCallback, Action failedCallback, byte[] data = null)
    {
        request.uploadHandler = new UploadHandlerRaw(data);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Bug.Warning("http请求失败");
            failedCallback.Invoke();
        }
        else
        {
            successCallback.Invoke(request.downloadHandler.text);
        }
    }

    [Obsolete]
    public void UnityWWW(string url, Action<byte[]> callback)
    {
        CatFM.GameLoop.StartCoroutine(WWWRequest(url, (data) => callback.Invoke(data)));
    }

    [Obsolete]
    IEnumerator WWWRequest(string url, Action<byte[]> callback)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.isDone)
        {
            Bug.Log("下载完成");
            byte[] bytes = www.bytes;
            callback.Invoke(bytes);
        }
    }
}