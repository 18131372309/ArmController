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

    private GameObject adminConfigPanel;
    private GameObject noticeText;
    private GameObject configDropDown;
    private GameObject closeAdminConfigButton;
    private GameObject lastButton;
    private GameObject nextButton;
    private GameObject checkCamMesButton;
    private GameObject nextButton_cam;
    private GameObject lastButton_cam;
    private GameObject takePicButton;
    private RawImage rawImageCamPic;

    private int currentAdminConfigPanelIndex = 0;
    private GameObject baseButton;
    private GameObject messageButton;
    private GameObject weldButton;
    private GameObject placeButton;
    private GameObject basePanel;
    private GameObject messagePanel;
    private GameObject weldPanel;
    private GameObject placePanel;
    private GameObject basePanel_cam;
    private GameObject handEyePanel_cam;

    private GameObject robotConfigPanel;
    private GameObject cameraConfigPanel;
    private GameObject frontBackToggle;
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

        //��¼panel
        gameAdminPanel = canvas.Find("GameAdmin/AdminLogin").gameObject;

        //��¼��ť
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
        //��¼ȡ����ť
        admin_cancel_Button = canvas.Find("GameAdmin/AdminLogin/admin_cancel_Button").gameObject;
        admin_cancel_Button.GetComponent<Button>().onClick.AddListener(() =>
        {
            gameAdminPanel.SetActive(false);
        });

        //��¼ȷ�ϰ�ť
        admin_ok_Button = canvas.Find("GameAdmin/AdminLogin/admin_ok_Button").gameObject;
        admin_ok_Button.GetComponent<Button>().onClick.AddListener(CheckAdmin);
        //ע���¼���panel����
        gameAdminPanel.SetActive(false);

        //����Ա���ý���
        adminConfigPanel = canvas.Find("GameAdmin/AdminConfig").gameObject;
        noticeText = canvas.Find("GameAdmin/AdminConfig/NoticeText").gameObject;
        robotConfigPanel = canvas.Find("GameAdmin/AdminConfig/RobotConfigPanel").gameObject;
        cameraConfigPanel = canvas.Find("GameAdmin/AdminConfig/CameraConfigPanel").gameObject;
        robotConfigPanel.SetActive(true);
        cameraConfigPanel.SetActive(false);
        configDropDown = canvas.Find("GameAdmin/AdminConfig/ConfigDropdown").gameObject;
        configDropDown.GetComponent<Dropdown>().onValueChanged.AddListener((index) =>
        {
            noticeText.GetComponent<Text>().text = index == 0 ? "����������" : "�������";

            if (index == 0)
            {
                robotConfigPanel.SetActive(true);
                cameraConfigPanel.SetActive(false);
            }
            else
            {
                robotConfigPanel.SetActive(false);
                cameraConfigPanel.SetActive(true);
            }
        });

        closeAdminConfigButton = canvas.Find("GameAdmin/AdminConfig/CloseButton").gameObject;
        closeAdminConfigButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            adminConfigPanel.SetActive(false);
        });
        lastButton = canvas.Find("GameAdmin/AdminConfig/RobotConfigPanel/LastButton").gameObject;
        currentAdminConfigPanelIndex = 0;
        lastButton.GetComponent<Button>().onClick.AddListener(LastAdminConfigStep);
        lastButton.SetActive(false);
        nextButton = canvas.Find("GameAdmin/AdminConfig/RobotConfigPanel/NextButton").gameObject;
        nextButton.GetComponent<Button>().onClick.AddListener(NextAdminConfigStep);
        basePanel = canvas.Find("GameAdmin/AdminConfig/RobotConfigPanel/BasePanel").gameObject;
        messagePanel = canvas.Find("GameAdmin/AdminConfig/RobotConfigPanel/MessagePanel").gameObject;
        weldPanel = canvas.Find("GameAdmin/AdminConfig/RobotConfigPanel/weldCPanel").gameObject;
        placePanel = canvas.Find("GameAdmin/AdminConfig/RobotConfigPanel/PlacePanel").gameObject;

        messagePanel.SetActive(false);
        weldPanel.SetActive(false);
        placePanel.SetActive(false);
        adminConfigPanel.SetActive(false);

        basePanel_cam = canvas.Find("GameAdmin/AdminConfig/CameraConfigPanel/BasePanel").gameObject;
        handEyePanel_cam = canvas.Find("GameAdmin/AdminConfig/CameraConfigPanel/HandEyePanel").gameObject;
        checkCamMesButton = canvas.Find("GameAdmin/AdminConfig/CameraConfigPanel/BasePanel/checkButton").gameObject;
        checkCamMesButton.GetComponent<Button>().onClick.AddListener(CheckCamMessage);
        nextButton_cam = canvas.Find("GameAdmin/AdminConfig/CameraConfigPanel/BasePanel/NextButton").gameObject;
        lastButton_cam = canvas.Find("GameAdmin/AdminConfig/CameraConfigPanel/HandEyePanel/lastButton").gameObject;
        takePicButton = canvas.Find("GameAdmin/AdminConfig/CameraConfigPanel/HandEyePanel/takePicButton").gameObject;
        rawImageCamPic = canvas.Find("GameAdmin/AdminConfig/CameraConfigPanel/HandEyePanel/RawImage").GetComponent<RawImage>();
        basePanel_cam.SetActive(true);
        handEyePanel_cam.SetActive(false);
        nextButton_cam.GetComponent<Button>().onClick.AddListener(() =>
        {
            basePanel_cam.SetActive(false);
            handEyePanel_cam.SetActive(true);
        });

        lastButton_cam.GetComponent<Button>().onClick.AddListener(() =>
        {
            basePanel_cam.SetActive(true);
            handEyePanel_cam.SetActive(false);
        });
        takePicButton.GetComponent<Button>().onClick.AddListener(TakeCamPicture);

        //�½���Ŀ��ť
        newProjectBtn = canvas.transform.Find("GameInitUI/BeginUse/NewProjectButton").GetComponent<Button>();
        newProjectBtn.onClick.AddListener(NewProject);

        //mm = Camera.main.gameObject.GetComponent<MoveCameraByMouse>();
        //mm.enabled = false;

        //ģ�ͷ�ת
        frontBackToggle = canvas.transform.Find("GameModules/FrontBackToggle").gameObject;
        frontBackToggle.GetComponent<Toggle>().onValueChanged.AddListener((isOn) =>
        {
            UIManager.Instance.FlipModel(isOn);
            if (isOn)
            {
                frontBackToggle.GetComponentInChildren<Text>().text = "����";
            }
            else
            {
                frontBackToggle.GetComponentInChildren<Text>().text = "����";
            }
        });
        frontBackToggle.SetActive(false);
        //�ӽǵ���
        viewDropDowm = canvas.transform.Find("GameModules/ViewDropdown").gameObject;
        viewDropDowm.SetActive(false);
        viewDropDowm.GetComponent<Dropdown>().onValueChanged.AddListener(ViewChange);

        //���溸��
        virtualButton = canvas.transform.Find("GameModules/virtualButton").gameObject;
        virtualButton.SetActive(false);
        virtualButton.GetComponent<Button>().onClick.AddListener(VirtualWelding);

        //��������
        weldingButton = canvas.transform.Find("GameModules/weldingButton").gameObject;
        weldingButton.SetActive(false);
        weldingButton.GetComponent<Button>().onClick.AddListener(StartWelding);

        //��������panel
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

        //��������toggle
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

        //���ӿ������
        weldingControl = canvas.transform.Find("GameModules/weldControl").gameObject;
        pauseWeldButton = canvas.transform.Find("GameModules/weldControl/pauseButton").gameObject;
        endWeldButton = canvas.transform.Find("GameModules/weldControl/endButton").gameObject;
        pauseWeldButton.GetComponent<Button>().onClick.AddListener(PauseWelding);
        endWeldButton.GetComponent<Button>().onClick.AddListener(EndWelding);

        weldingControl.SetActive(false);

        videoTexture = canvas.transform.Find("GameModules/videoTexture").gameObject;
        videoTexture.SetActive(false);


        UIManager.Instance.ProjectInfoInit();
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
        Debug.Log("index: " + index + " ֪ͨShowWeldingConfigUI");
    }

    //����½���Ŀ
    public void NewProject()
    {

        //TODO: ������Ŀ
        gameInitUI.SetActive(false);
        UIManager.Instance.InitCameraMCBM(true);

        gameAdminBtn.SetActive(true);
        frontBackToggle.SetActive(true);
        viewDropDowm.SetActive(true);
        virtualButton.SetActive(true);
        weldingButton.SetActive(true);
        weldingConfigToggle.SetActive(true);
    }

    //�˶��û���Ϣ
    public void CheckAdmin()
    {
        if (true)
        {

            gameAdminPanel.SetActive(false);
            //TODO:�Ƿ��ǹ���Ա
            adminConfigPanel.SetActive(true);
        }
        else
        {
            //TODO���������
        }
    }

    //�ӽǵ���
    public void ViewChange(int index)
    {
        Debug.Log("�ӽǵ���index:  " + index);
        UIManager.Instance.ViewChange(index);
    }

    //���溸��
    public void VirtualWelding()
    {
        Debug.Log("���溸�Ӱ���");
    }

    //��������
    public void StartWelding()
    {
        Debug.Log("�������Ӱ���");
        if (weldingConfigUI.activeInHierarchy)
        {
            weldingConfigUI.SetActive(false);
        }

        weldingControl.SetActive(true);
        videoTexture.SetActive(true);
    }

    //�������
    public void SetConfigFinish()
    {
        Debug.Log("���ò�����ɰ���");
        weldingConfigsSetPanel.SetActive(false);

        //TODO����¼
    }

    //��ͣ����
    public void PauseWelding()
    {
        Debug.Log("��ͣ���Ӱ���");
    }
    //ֹͣ����
    public void EndWelding()
    {
        videoTexture.SetActive(false);
        weldingControl.SetActive(false);
    }

    //����Ա���ã���һ��
    public void LastAdminConfigStep()
    {
        switch (currentAdminConfigPanelIndex)
        {
            case 0:
                break;
            case 1:
                currentAdminConfigPanelIndex--;
                basePanel.SetActive(true);
                messagePanel.SetActive(false);
                weldPanel.SetActive(false);
                placePanel.SetActive(false);
                lastButton.SetActive(false);
                break;
            case 2:
                currentAdminConfigPanelIndex--;
                basePanel.SetActive(false);
                messagePanel.SetActive(true);
                weldPanel.SetActive(false);
                placePanel.SetActive(false);
                break;
            case 3:
                currentAdminConfigPanelIndex--;
                nextButton.GetComponentInChildren<Text>().text = "��һ��";
                basePanel.SetActive(false);
                messagePanel.SetActive(false);
                weldPanel.SetActive(true);
                placePanel.SetActive(false);
                break;
            default:
                break;
        }
    }
    //����Ա���ã���һ��
    public void NextAdminConfigStep()
    {
        switch (currentAdminConfigPanelIndex)
        {
            case 0:
                currentAdminConfigPanelIndex++;
                lastButton.SetActive(true);
                basePanel.SetActive(false);
                messagePanel.SetActive(true);
                weldPanel.SetActive(false);
                placePanel.SetActive(false);

                break;
            case 1:
                currentAdminConfigPanelIndex++;
                basePanel.SetActive(false);
                messagePanel.SetActive(false);
                weldPanel.SetActive(true);
                placePanel.SetActive(false);
                break;
            case 2:
                currentAdminConfigPanelIndex++;

                nextButton.GetComponentInChildren<Text>().text = "���";
                basePanel.SetActive(false);
                messagePanel.SetActive(false);
                weldPanel.SetActive(false);
                placePanel.SetActive(true);
                break;
            case 3:
                currentAdminConfigPanelIndex = 0;
                lastButton.SetActive(false);
                nextButton.GetComponentInChildren<Text>().text = "��һ��";
                basePanel.SetActive(true);
                messagePanel.SetActive(false);
                weldPanel.SetActive(false);
                placePanel.SetActive(false);
                adminConfigPanel.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void CheckCamMessage()
    {
        Debug.Log("������ͨ��");
    }

    public void TakeCamPicture()
    {
        Debug.Log("����");
        string camTexture_url = "file:///" + Application.dataPath + "/Config/camTexture.png";
        ConfigManager.Instance.GetTextureOnLine(camTexture_url, (texture) =>
        {
            rawImageCamPic.texture = texture;
        });
    }
}
