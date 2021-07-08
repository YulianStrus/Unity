using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    public GameObject cell;//
    Vector3 oldPosition;//старые позиции
    Vector3 pos;//здесь будут позиции объекта
    List<GameObject> cells;//массив в котором будут созданные частицы
    void Start()
    {
        cells = new List<GameObject>();//создаете массив
    }

    void Update()
    {
        oldPosition = transform.position;//запоминаете позиции
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            pos.x += Input.GetAxisRaw("Horizontal");//изменение позиции пока только по горизонтали, если надо по вертикали то надо дописать перемещение по вертикали
        transform.position = pos;//прермещение объекта
        cells.Add(Instantiate(cell, oldPosition, Quaternion.identity));//создаете частицу в страую позицию и помещаете в массив
        oldPosition = transform.position;//задаете старой позицие новую
        if (cells.Count > 3)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                Destroy(cells[i]);
                cells.Remove(cells[i]);//удаление частиц кроме трех последних
            }
        }
    }
}
