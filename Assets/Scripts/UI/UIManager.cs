using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager _instance;
    private static ShowView showView;
    private static MoveCameraByMouse mcbm;


    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
                if (showView == null)
                {
                    showView = GameObject.FindObjectOfType<ShowView>();
                }
                if (mcbm == null)
                {
                    mcbm = GameObject.FindObjectOfType<MoveCameraByMouse>();
                }
            }

            return _instance;
        }
    }

    /*
    public void SetInitUI(bool state)
    {
        showView.SetInitUI(state);
    }
    */

    public void InitCameraMCBM(bool state)
    {
        mcbm.enabled = state;
    }

    public void ShowWeldingConfigUI(int index)
    {
        showView.ShowWeldingConfigUI(index);
    }

    public void ViewChange(int index)
    {
        switch (index)
        {
            case 0:
                mcbm.front();
                break;
            case 1:
                mcbm.left();
                break;
            case 2:
                mcbm.top();
                break;
            default:
                mcbm.front();
                break;
        }

    }

}
