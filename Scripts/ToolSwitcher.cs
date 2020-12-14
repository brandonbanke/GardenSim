using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitcher : MonoBehaviour
{
    [SerializeField] int currentTool = 0;

    void Start()
    {
        setToolActive();
    }

    private void setToolActive()
    {
        int toolIndex = 0;

        foreach(Transform tool in transform)
        {
            if (toolIndex == currentTool)
            {
                tool.gameObject.SetActive(true);
            }
            else
            {
                tool.gameObject.SetActive(false);
            }
            toolIndex++;
        }
    }

    void Update()
    {
        int previousTool = currentTool;
        ProcessKeyInput();
        ProcessScrollWheel();
        if (previousTool != currentTool)
        {
            setToolActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentTool >= transform.childCount - 1)
            {
                currentTool = 0;
            } else
            {
                currentTool++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentTool <= 0)
            {
                currentTool = transform.childCount - 1;
            }
            else
            {
                currentTool--;
            }
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTool = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTool = 1;
        }
    }

    public int GetCurrentTool()
    {
        return currentTool;
    }
}
