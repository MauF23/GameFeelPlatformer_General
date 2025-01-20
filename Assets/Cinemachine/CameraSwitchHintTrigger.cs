using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sobrecarga de CameraSwitch, tiene el mismo comportamiento base pero después de un tiempo especificado
/// Regresará a la cámara especificada y desactivará el collider/trigger, pensada para mostrar pistas al jugador.
/// </summary>
public class CameraSwitchHintTrigger : CameraSwitchTrigger
{
    public int cameraToReturn;
    public float hintTime;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        StartCoroutine(ReturnToCameraRoutine());
        cameraTrigger.enabled = false;
    }

    IEnumerator ReturnToCameraRoutine()
    {
        yield return new WaitForSeconds(hintTime);
        CameraManager.instance.CameraSwitch(cameraToReturn);
    }
}
