using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finsh : MonoBehaviour
{

    public Vector2 fishScaleRange;
    public Vector2 moveSpeedRange;

    [HideInInspector]
    public float fishScale;
    float moveSpeed;
    // Start is called before the first frame update
 

    public void SpawnFish()
    {
        fishScale = Random.Range(fishScaleRange.x, fishScaleRange.y);
        moveSpeed = Random.Range(moveSpeedRange.x, moveSpeedRange.y);

        transform.localScale=Vector3.one * fishScale;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("11111111");
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
}
