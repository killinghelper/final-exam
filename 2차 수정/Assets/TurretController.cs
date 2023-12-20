using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform turretTransform; // �ͷ��� Transform ������Ʈ
    public float rotationSpeed = 10.0f; // �ͷ��� ȸ�� �ӵ�

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 targetPoint = hit.point;
            targetPoint.y = turretTransform.position.y; // �ͷ��� ���̸� ����
            Vector3 direction = targetPoint - turretTransform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            turretTransform.rotation = Quaternion.Lerp(turretTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
