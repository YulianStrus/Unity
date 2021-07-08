using UnityEngine;

public class NewBlock : MonoBehaviour
{
    public GameObject prefBlock;
    float x, z, y = 0.2f;

    void Start()
    {

        CreateAllBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateAllBlock()
    {
            for (x = -4f; x <= 4f; x += 1f)
                for (z = -3.5f; z <= 4f; z += 1f)
                {
                    Instantiate(prefBlock, new Vector3(x, y, z), Quaternion.identity);
                }
    }
}
