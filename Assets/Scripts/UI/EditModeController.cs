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

    public void SaveRobot()
    {
        Controller.Instance.CURRENT_ROBOT = (GameObject)Instantiate(robotPrefab, initialTransform.position, Quaternion.identity);

        //É necessário pegar a raiz (onde começa) o algoritmo do robo
        var root = FindObjectOfType<UI_OnBegin>();

        var onWallRoot = FindObjectOfType<UI_OnWallCollision>();

        if (root == null)
        {
            Debug.LogWarning("Não há nenhum bloco OnBegin!");
            return;
        }

        Debug.Log("EditModeController: " + root.gameObject.name + " : " + root.UI_Blocks.Count);

        //GetLogicalBlockStructure returns a ExecuteCycle because is the root
        ExecuteCycle robotCycle = (ExecuteCycle)root.GetLogicBlockStructure();

        if (onWallRoot != null)
        {
            OnWallCollisionCycle wallCycle = (OnWallCollisionCycle)onWallRoot.GetLogicBlockStructure();
        }

        if (robotCycle.LogicBlocks.Count <= 0)
        {
            Debug.Log("DEU 0 NO ESQUEMA!");
            return;
        }

        editCanvas.SetActive(false);
        m_robotAnalyser.TestRobot(robotCycle);
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
