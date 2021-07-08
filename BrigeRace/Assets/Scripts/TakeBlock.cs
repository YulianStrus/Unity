using System;
using UnityEngine;

public class TakeBlock : MonoBehaviour
{
    public Transform StartPos;
    public GameObject prefTakeBlock;
    public int NumberBlock = 0; //—читаем собранные монетки
    public Material newMaterialRef;
    public Material MaterialRef;

    float smoothTime = 20f;
    float xVelocity;
    float yVelocity= 0.4f;
    float zVelocity;



    public void Update()
    {

    }
    [Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block"))
        {            
            other.gameObject.transform.parent = StartPos.transform;
            //xVelocity = 0.0f;
            //zVelocity = -4.15f;
            CollectBlock(other);
            //GameObject.FindWithTag("Cube").GetComponent<BoxCollider>().isTrigger = true;
        }
        
        BuildBrige(other);
    }

    [Obsolete]
    public void CollectBlock(Collider other)
    {
        float newPositionY = Mathf.SmoothDamp(transform.position.y, yVelocity, ref yVelocity, smoothTime);
        other.gameObject.transform.position = new Vector3(0f, newPositionY, -4.15f);


        NumberBlock += 1;
        //other.gameObject.transform.position = new Vector3(xVelocity, yVelocity, zVelocity);
        yVelocity += 0.1f;

        //other.gameObject.transform.Translate(EndPos.position * Time.deltaTime);


        //other.gameObject.SetActiveRecursively(false);

        //for (int i = 0; i <= NumberBlock; i++)
        //{
        //    GameObject.Find("prefTakeBlock (" + i + ")").GetComponent<MeshRenderer>().material = newMaterialRef;
        //}

    }

    [Obsolete]
    public void BuildBrige(Collider other)
    {
        if (NumberBlock > 0)
        {
            if (other.gameObject.CompareTag("Cube"))
            {
                float x = other.gameObject.transform.position.x;
                float z = other.gameObject.transform.position.z;
                other.gameObject.transform.position = new Vector3(x, -0.3f, z);
                other.gameObject.GetComponent<MeshRenderer>().material = newMaterialRef;
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                NumberBlock -= 1;
                //for (int i = 30; i >= NumberBlock; i--)
                //{
                //    GameObject.Find("prefTakeBlock (" + i + ")").GetComponent<MeshRenderer>().material = MaterialRef;
                //}
            }
        }
        other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

}
