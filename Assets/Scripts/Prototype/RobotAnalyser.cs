using System.Collections.Generic;
using UnityEngine;

public class RobotAnalyser : MonoBehaviour 
{
	public List<IBlock> LogicBlocks { get; set; }

	private int m_index;

	void Start()
	{
		executeBlock();
	}

	private void executeBlock()
	{
		LogicBlocks[m_index].Run(onEndRunning);
	}

	private void onEndRunning()
	{
		m_index++;

        if (m_index >= LogicBlocks.Count)
            m_index = 0;

		executeBlock();
	}
}
