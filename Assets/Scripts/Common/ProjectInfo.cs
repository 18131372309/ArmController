using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class ProjectInfo
{
    private List<string> todayProjectName;
    private List<string> weekProjectName;
    private List<string> earlyProjectName;

    private Transform todayProjectParent;
    private Transform weekProjectParent;
    private Transform earlyProjectParent;

    private GameObject projectItemPrefab;

    public static ProjectInfo _instance;
    private string projectInfo_url = string.Empty;
    public static ProjectInfo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProjectInfo();

            }

            return _instance;
        }
    }
    //加载项目信息的配置
    public void SetProjectInfo()
    {
        InitData();
        ConfigManager.Instance.GetStringOnLine(projectInfo_url, (msg) =>
        {

            Debug.Log(msg);
            JsonData data = JsonMapper.ToObject(msg);
            for (int i = 0; i < data["ProjectInfo"].Count; i++)
            {
                int time = int.Parse(data["ProjectInfo"][i]["time"].ToString());
                if (time == 0)
                {
                    Debug.Log(time);
                    Debug.Log(data["ProjectInfo"][i]["name"].ToString());
                    todayProjectName.Add(data["ProjectInfo"][i]["name"].ToString());
                }

                if (time < 7)
                {
                    weekProjectName.Add(data["ProjectInfo"][i]["name"].ToString());
                }
                if (time > 7)
                {
                    earlyProjectName.Add(data["ProjectInfo"][i]["name"].ToString());
                }

            }

            BornProjectItem(todayProjectName, todayProjectParent);
            BornProjectItem(weekProjectName, weekProjectParent);
            BornProjectItem(earlyProjectName, earlyProjectParent);
        });
    }

    void BornProjectItem(List<string> names, Transform parent)
    {
        for (int i = 0; i < names.Count; i++)
        {
            GameObject go = GameObject.Instantiate(projectItemPrefab, Vector3.zero, Quaternion.identity, parent);
            go.GetComponentInChildren<Text>().text = names[i];
        }
    }

    void InitData()
    {

        if (projectItemPrefab == null)
        {

            projectItemPrefab = Resources.Load("projectContButton") as GameObject;
            todayProjectParent = GameObject.Find("todayProjectParent").transform;
            weekProjectParent = GameObject.Find("weekProjectParent").transform;
            earlyProjectParent = GameObject.Find("earlyProjectParent").transform;
            todayProjectName = new List<string>();
            weekProjectName = new List<string>();
            earlyProjectName = new List<string>();
        }
        projectInfo_url = "file:///" + Application.dataPath + "/Config/ProjectInfo.txt";

        todayProjectName.Clear();
        weekProjectName.Clear();
        earlyProjectName.Clear();

        //parent子节点清空，扩展
        todayProjectParent.DestoryAllChild();
        weekProjectParent.DestoryAllChild();
        earlyProjectParent.DestoryAllChild();
    }
}

