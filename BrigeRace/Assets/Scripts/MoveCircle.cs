using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    public GameObject cell;//
    Vector3 oldPosition;//������ �������
    Vector3 pos;//����� ����� ������� �������
    List<GameObject> cells;//������ � ������� ����� ��������� �������
    void Start()
    {
        cells = new List<GameObject>();//�������� ������
    }

    void Update()
    {
        oldPosition = transform.position;//����������� �������
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            pos.x += Input.GetAxisRaw("Horizontal");//��������� ������� ���� ������ �� �����������, ���� ���� �� ��������� �� ���� �������� ����������� �� ���������
        transform.position = pos;//����������� �������
        cells.Add(Instantiate(cell, oldPosition, Quaternion.identity));//�������� ������� � ������ ������� � ��������� � ������
        oldPosition = transform.position;//������� ������ ������� �����
        if (cells.Count > 3)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                Destroy(cells[i]);
                cells.Remove(cells[i]);//�������� ������ ����� ���� ���������
            }
        }
    }
}
