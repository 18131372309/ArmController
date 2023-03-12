using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowView : MonoBehaviour
{
    private Transform canvas;
    private GameObject gameInitUI;
    private GameObject gameAdminBtn;
    private GameObject gameAdminPanel;
    private GameObject admin_cancel_Button;
    private GameObject admin_ok_Button;
    private Button newProjectBtn;
    //private MoveCameraByMouse mm;
    private GameObject viewDropDowm;
    private GameObject weldingButton;
    private GameObject virtualButton;
    private GameObject weldingConfigToggle;
    private GameObject weldingConfigPanel;
    private GameObject weldingControl;
    private GameObject videoTexture;
    private GameObject weldingConfigUI;
    private GameObject weldingConfigSet;
    private GameObject setConfigButton;
    private GameObject startWeldButton;
    private GameObject weldingConfigsSetPanel;
    private GameObject weldingSetConfigOne;
    private GameObject weldingSetConfigTwo;
    private GameObject weldingConfigSetNextButton;
    private GameObject weldingConfigSetFinishButton;
    private GameObject pauseWeldButton;
    private GameObject endWeldButton;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        canvas = GameObject.Find("Canvas").transform;

        gameInitUI = canvas.Find("GameInitUI").gameObject;
        gameInitUI.SetActive(true);

        //登录panel
        gameAdminPanel = canvas.Find("GameAdmin/AdminLogin").gameObject;

        //登录按钮
        gameAdminBtn = canvas.Find("GameAdmin/AdminButton").gameObject;
        gameAdminBtn.SetActive(false);
        gameAdminBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (gameAdminPanel.activeInHierarchy)
            {
                gameAdminPanel.SetActive(false);
            }
            else
            {
                gameAdminPanel.SetActive(true);
            }
        });
        //登录取消按钮
        admin_cancel_Button = canvas.Find("GameAdmin/AdminLogin/admin_cancel_Button").gameObject;
        admin_cancel_Button.GetComponent<Button>().onClick.AddListener(() =>
        {
            gameAdminPanel.SetActive(false);
        });

        //登录确认按钮
        admin_ok_Button = canvas.Find("GameAdmin/AdminLogin/admin_ok_Button").gameObject;
        admin_ok_Button.GetComponent<Button>().onClick.AddListener(CheckAdmin);
        //注册事件后panel隐藏
        gameAdminPanel.SetActive(false);

        //新建项目按钮
        newProjectBtn = canvas.transform.Find("GameInitUI/BeginUse/NewProjectButton").GetComponent<Button>();
        newProjectBtn.onClick.AddListener(NewProject);

        //mm = Camera.main.gameObject.GetComponent<MoveCameraByMouse>();
        //mm.enabled = false;

        //视角调整
        viewDropDowm = canvas.transform.Find("GameModules/ViewDropdown").gameObject;
        viewDropDowm.SetActive(false);
        viewDropDowm.GetComponent<Dropdown>().onValueChanged.AddListener(ViewChange);

        //仿真焊接
        virtualButton = canvas.transform.Find("GameModules/virtualButton").gameObject;
        virtualButton.SetActive(false);
        virtualButton.GetComponent<Button>().onClick.AddListener(VirtualWelding);

        //启动焊接
        weldingButton = canvas.transform.Find("GameModules/weldingButton").gameObject;
        weldingButton.SetActive(false);
        weldingButton.GetComponent<Button>().onClick.AddListener(StartWelding);

        //焊接配置panel
        weldingConfigPanel = canvas.transform.Find("GameModules/weldingConfig").gameObject;
        weldingConfigUI = canvas.transform.Find("GameModules/weldingConfig/weldingConfigUI").gameObject;
        setConfigButton = canvas.transform.Find("GameModules/weldingConfig/weldingConfigUI/SetConfigButton").gameObject;
        startWeldButton = canvas.transform.Find("GameModules/weldingConfig/weldingConfigUI/StartWeldButton").gameObject;
        weldingConfigsSetPanel = canvas.transform.Find("GameModules/weldingConfig/weldingConfigSet").gameObject;
        weldingSetConfigOne = canvas.transform.Find("GameModules/weldingConfig/weldingConfigSet/setConfig1").gameObject;
        weldingSetConfigTwo = canvas.transform.Find("GameModules/weldingConfig/weldingConfigSet/setConfig2").gameObject;
        weldingConfigSetNextButton = canvas.transform.Find("GameModules/weldingConfig/weldingConfigSet/setConfig1/NextButton").gameObject;
        weldingConfigSetFinishButton = canvas.transform.Find("GameModules/weldingConfig/weldingConfigSet/setConfig2/FinishButton").gameObject;
        weldingConfigSetNextButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            weldingSetConfigOne.SetActive(false);
            weldingSetConfigTwo.SetActive(true);
        });
        weldingConfigSetFinishButton.GetComponent<Button>().onClick.AddListener(SetConfigFinish);

        weldingConfigsSetPanel.SetActive(false);
        startWeldButton.GetComponent<Button>().onClick.AddListener(StartWelding);
        setConfigButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            weldingConfigsSetPanel.SetActive(true);
            weldingSetConfigOne.SetActive(true);
            weldingSetConfigTwo.SetActive(false);
        });
        weldingConfigSet = canvas.transform.Find("GameModules/weldingConfig/weldingConfigSet").gameObject;


        weldingConfigUI.SetActive(false);
        weldingConfigSet.SetActive(false);
        weldingConfigPanel.SetActive(false);

        //焊接配置toggle
        weldingConfigToggle = canvas.transform.Find("GameModules/weldingConfigToggle").gameObject;
        weldingConfigToggle.SetActive(false);
        weldingConfigToggle.GetComponent<Toggle>().onValueChanged.AddListener((isOn) =>
        {
            if (isOn)
            {
                weldingConfigPanel.SetActive(true);
                weldingConfigUI.SetActive(false);
            }
            else
            {
                weldingConfigPanel.SetActive(false);
            }

        });

        //焊接控制面板
        weldingControl = canvas.transform.Find("GameModules/weldControl").gameObject;
        pauseWeldButton = canvas.transform.Find("GameModules/weldControl/pauseButton").gameObject;
        endWeldButton = canvas.transform.Find("GameModules/weldControl/endButton").gameObject;
        pauseWeldButton.GetComponent<Button>().onClick.AddListener(PauseWelding);
        endWeldButton.GetComponent<Button>().onClick.AddListener(EndWelding);

        weldingControl.SetActive(false);

        videoTexture = canvas.transform.Find("GameModules/videoTexture").gameObject;
        videoTexture.SetActive(false);
    }





    public void SetInitUI(bool state)
    {
        //   gameInitUI.SetActive(state);
    }

    public void ShowWeldingConfigUI(int index)
    {
        if (!weldingConfigUI.activeInHierarchy)
        {
            weldingConfigUI.SetActive(true);
        }
        Debug.Log("index: " + index + " 通知ShowWeldingConfigUI");
    }

    //点击新建项目
    public void NewProject()
    {

        //TODO: 加载项目
        gameInitUI.SetActive(false);
        UIManager.Instance.InitCameraMCBM(true);

        gameAdminBtn.SetActive(true);
        viewDropDowm.SetActive(true);
        virtualButton.SetActive(true);
        weldingButton.SetActive(true);
        weldingConfigToggle.SetActive(true);
    }

    //核对用户信息
    public void CheckAdmin()
    {
        if (true)
        {
            gameAdminPanel.SetActive(false);
        }
        else
        {
            //TODO：警告错误
        }
    }

    //视角调整
    public void ViewChange(int index)
    {
        Debug.Log("视角调整index:  " + index);
        UIManager.Instance.ViewChange(index);
    }

    //仿真焊接
    public void VirtualWelding()
    {
        Debug.Log("仿真焊接按下");
    }

    //启动焊接
    public void StartWelding()
    {
        Debug.Log("启动焊接按下");
        if (weldingConfigUI.activeInHierarchy)
        {
            weldingConfigUI.SetActive(false);
        }

        weldingControl.SetActive(true);
        videoTexture.SetActive(true);
    }

    //配置完成
    public void SetConfigFinish()
    {
        Debug.Log("配置参数完成按下");
        weldingConfigsSetPanel.SetActive(false);

        //TODO：记录
    }

    //暂停焊接
    public void PauseWelding()
    {
        Debug.Log("暂停焊接按下");
    }
    //停止焊接
    public void EndWelding()
    {
        videoTexture.SetActive(false);
        weldingControl.SetActive(false);
    }
}
