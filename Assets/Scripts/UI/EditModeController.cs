using UnityEngine;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

public class EditModeController : MonoBehaviour
{
    public GameObject editCanvas;
    public GameObject robotPrefab;
    public Transform initialTransform;
    public CreateVarModalBehaviour createVarModal;

    private RobotAnalyser m_robotAnalyser;

    private ToUseBlocks m_toUseBlocks;
    private UsedBlocks m_usedBlocks;
    private TabsController m_tabsController;

    public Transform ToUseTransform { get { return m_toUseBlocks.transform; } }
    public Transform UsedBlocksTransform { get { return m_usedBlocks.transform; } }

    void Awake()
    {
        m_robotAnalyser = FindObjectOfType<RobotAnalyser>();

        m_toUseBlocks = FindObjectOfType<ToUseBlocks>();
        m_usedBlocks = FindObjectOfType<UsedBlocks>();
        m_tabsController = FindObjectOfType<TabsController>();

        VariableController.DeclareVariable("x", VariableType.Number, 1);
        VariableController.DeclareVariable("y", VariableType.Number, 3);
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

    public void SaveRobot()
    {
        Controller.Instance.CURRENT_ROBOT = (GameObject)Instantiate(robotPrefab, initialTransform.position, Quaternion.identity);

        var root = getOnBeginBlock();

        var onWallRoot = getOnWallCollisionBlock();

        ExecuteCycle robotCycle = null;

        if (root != null)
            robotCycle = (ExecuteCycle)root.GetLogicBlockStructure();

        OnWallCollisionCycle wallCycle = null;

        if (onWallRoot != null)
            wallCycle = (OnWallCollisionCycle)onWallRoot.GetLogicBlockStructure();

        editCanvas.SetActive(false);
        m_robotAnalyser.TestRobot(robotCycle, wallCycle);
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
