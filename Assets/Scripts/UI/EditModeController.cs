using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Linq;

public class EditModeController : MonoBehaviour
{
    public GameObject editCanvas;
    public GameObject robotPrefab;
    public Transform initialTransform;
    public CreateVarModalBehaviour createVarModal;
    public InputField inp_robotName;

    private RobotAnalyser m_robotAnalyser;

    private ToUseBlocks m_toUseBlocks;
    private UsedBlocks m_usedBlocks;
    private TabsController m_tabsController;

    private RobotMain m_robot;

    public Transform ToUseTransform { get { return m_toUseBlocks.transform; } }
    public Transform UsedBlocksTransform { get { return m_usedBlocks.transform; } }

    void Awake()
    {
        m_robotAnalyser = FindObjectOfType<RobotAnalyser>();

        m_toUseBlocks = FindObjectOfType<ToUseBlocks>();
        m_usedBlocks = FindObjectOfType<UsedBlocks>();
        m_tabsController = FindObjectOfType<TabsController>();
    }

    private UI_OnBegin getOnBeginBlock()
    {
        var goBegin = GameObject.FindWithTag("OnBegin");

        if (goBegin != null)
            return goBegin.GetComponent<UI_OnBegin>();

        Debug.LogWarning("Não foi encontrado bloco UI_OnBegin!");
        return null;
    }

    private UI_OnWallCollision getOnWallCollisionBlock()
    {
        var goWallCollision = GameObject.FindWithTag("OnWallCollision");

        if (goWallCollision != null)
            return goWallCollision.GetComponent<UI_OnWallCollision>();

        Debug.LogWarning("Não foi encontrado bloco UI_OnWallCollision!");
        return null;
    }

    private UI_OnFindRobot getOnFindRobotBlock()
    {
        var goOnFindRobot = GameObject.FindWithTag("OnFindRobot");

        if (goOnFindRobot != null)
            return goOnFindRobot.GetComponent<UI_OnFindRobot>();

        Debug.LogWarning("Não foi encontrado bloco UI_OnFindRobot!");
        return null;
    }

    private void configureRobot()
    {
        Controller.Instance.CURRENT_EDIT_ROBOT = (GameObject)Instantiate(robotPrefab, initialTransform.position, Quaternion.identity);

        var root = getOnBeginBlock();
        var onWallRoot = getOnWallCollisionBlock();
        var onFindRobot = getOnFindRobotBlock();

        m_robot = new RobotMain();

        if (root != null)
            m_robot.MainCycle = (ExecuteCycle)root.GetLogicBlockStructure();

        if (onWallRoot != null)
            m_robot.OnWallCycle = (OnWallCollisionCycle)onWallRoot.GetLogicBlockStructure();

        if (onFindRobot != null)
            m_robot.OnFindCycle = (OnFindRobotCycle)onFindRobot.GetLogicBlockStructure();
    }

    public void SaveRobot()
    {
        configureRobot();

        string name = inp_robotName.text;

        if (Controller.Instance.AllRobotsSaved.Any(x => x.Name == name))
            Controller.Instance.EnableModal("Já existe um robô com esse nome!");
        else
            Controller.Instance.AllRobotsSaved.Add(m_robot);
    }

    public void TestRobot()
    {
        configureRobot();

        editCanvas.SetActive(false);
        m_robotAnalyser.TestRobot(m_robot);
    }

    public void ResetBlocksToUse(BlockCategory category)
    {
        m_toUseBlocks.ResetBlockList(category);
    }

    public void OpenDeclareVariableModal()
    {
        var modal = Instantiate(createVarModal);
        modal.transform.SetParent(editCanvas.transform);
        modal.transform.Reset();
    }
}
