using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTool : MonoBehaviour
{

    [SerializeField] Camera FPCameraSaw;
    [SerializeField] float rangeSaw = 100f;

    ToolSwitcher ts;

    // Start is called before the first frame update
    void Start()
    {
        ts = GameObject.FindObjectOfType(typeof(ToolSwitcher)) as ToolSwitcher;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ts.GetCurrentTool() == 1)
        {
            Saw();
        }
    }

    private void Saw()
    {
        ProccessRayCastSaw();
        GetComponent<Animator>().SetTrigger("Hit");
        GetComponent<Animator>().SetBool("Passive", true);
    }


    private void ProccessRayCastSaw()
    {
        RaycastHit hit;
        Physics.Raycast(FPCameraSaw.transform.position, FPCameraSaw.transform.forward,
            out hit, rangeSaw);
    }
}
