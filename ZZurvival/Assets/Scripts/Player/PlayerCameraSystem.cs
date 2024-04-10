using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSystem : MonoBehaviour
{
    // No se porque murió mi cinemachine y no conseguia ponerla bien (tuve q hacer este apaño)
    public float cameraDistance;

    public Transform normalPos;
    private Transform targetPos;
    public Transform aimingPos;
    public Transform mainCamera;
    public Transform aimCamera;
    public Transform dynamicCamera;
    public Transform aimTransform;

    void Start()
    {
        targetPos = normalPos;
    }

    void Update()
    {
        targetPos = Input.GetMouseButton(1) ? aimingPos : normalPos;
        mainCamera.position = Vector3.Lerp(mainCamera.position, targetPos.position, Time.deltaTime * 5f);
        mainCamera.LookAt(aimCamera.position); // grande LookAt

        RaycastHit rHit;
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out rHit, 100f))
        {
            float distance = Vector3.Distance(mainCamera.position, rHit.point);
            if (distance >= (cameraDistance + 1f))
            {
                aimTransform.position = Vector3.Lerp(aimTransform.position, rHit.point, Time.deltaTime * 10f);
            }
            else {
                aimTransform.position = mainCamera.forward * 100f;

            }

        }
        else {
            aimTransform.position = mainCamera.forward * 100f;
        }

        if (Physics.Raycast(dynamicCamera.position, -dynamicCamera.forward, out rHit, cameraDistance))
        {
            normalPos.position = rHit.point + normalPos.forward * 0.2f;
        }
        else
        {
            normalPos.localPosition = new Vector3(normalPos.localPosition.x, normalPos.localPosition.y, -cameraDistance);
        }


    }
}
