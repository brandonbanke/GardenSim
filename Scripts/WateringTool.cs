using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WateringTool : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem waterFx;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] TextMeshProUGUI waterLevel;

    ToolSwitcher ts;

    // Start is called before the first frame update
    void Start()
    {
        ts = GameObject.FindObjectOfType(typeof(ToolSwitcher)) as ToolSwitcher;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayWaterLevel();
        if (Input.GetButtonDown("Fire1") && ts.GetCurrentTool() == 0)
        {
            Water();
        }
    }

    private void Water()
    {
        if (ammoSlot.GetCurrentAmmo() > 0) {
            PlayWateringFx();
            ProccessRayCast();
            ammoSlot.ReduceCurrentAmmo();
        }
    }

    private void PlayWateringFx()
    {
        waterFx.Play();
    }

    private void ProccessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward,
            out hit, range))
        {
            if (hit.transform.tag == "Plant" && ammoSlot.GetCurrentAmmo() > 0)
            {
                Plant target = hit.transform.GetComponent<Plant>();
                if (target != null) {
                    target.StopFx();
                    FindObjectOfType<SceneLoader>().DecreasePlantsRemaining();
                }
            }
        }
    }
    private void DisplayWaterLevel()
    {
        int currentLevel = ammoSlot.GetCurrentAmmo();
        waterLevel.text = currentLevel.ToString();
    }
}
