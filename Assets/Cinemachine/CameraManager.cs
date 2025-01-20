using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public int initialCameraIndex;
    public List<CinemachineVirtualCamera> cameraList;

    //Varibales para funci�n de debug, probar el switch de c�maras.
    public KeyCode debugCameraSwitchKey;
    public int cameraSwitchDebugIndex;

    public static CameraManager instance;

    private void Awake()
    {
        // Incializar la instancia (Singleton)
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    void Start()
    {
        AssignCamerasPriority();
        CameraSwitch(initialCameraIndex);
    }


    private void Update()
    {
        //Debug de la funci�n CameraSwitch
        if (Input.GetKeyDown(debugCameraSwitchKey))
        {
            CameraSwitch(cameraSwitchDebugIndex);
        }
    }

    /// <summary>
    /// Asignar la prioridad de las c�maras usando su orden en la lista
    /// </summary>
    private void AssignCamerasPriority()
    {
        for(int i = 0; i < cameraList.Count; i++)
        {
            cameraList[i].Priority = i; 
        }
    }

    /// <summary>
    /// Cambia a la c�mara cuya prioridad sea la especificada.
    /// </summary>
    /// <param name="cameraIndex">la prioridad/�nidice de la c�mara deseada</param>
    public void CameraSwitch(int cameraIndex)
    {
        int clampedIndex = Mathf.Clamp(cameraIndex, 0, cameraList.Count-1);

        for (int i = 0; i < cameraList.Count; i++)
        {
            if(clampedIndex == cameraList[i].Priority)
            {
                cameraList[i].gameObject.SetActive(true);
            }
            else
            {
                cameraList[i].gameObject.SetActive(false);
            }
        }
    } 
}
