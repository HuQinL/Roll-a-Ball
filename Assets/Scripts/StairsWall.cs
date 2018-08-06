using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsWall : MonoBehaviour
{

    // Use this for initialization
    public GameObject StairsPrefab;
    //public GameObject PlayPrefab;
    public float StairAngle;
    public float RoundAngle;
    public float Radius;    
    void Start()
    {
        //Vector3 center = PlayPrefab.transform.position;
        //楼梯
        for (int i = 0; i < 20; i++)
        {
            GameObject gameObject = GameObject.Instantiate(StairsPrefab);
            float Amplitude = (StairAngle / 180) * Mathf.PI;
            float hight = i * Mathf.Tan(Amplitude);
            if (i >= 12)
            {
                hight = 12 * Mathf.Tan(Amplitude);
            }
            gameObject.transform.position = new Vector3(0 + i, (-1) + hight, 0);
            gameObject.transform.LookAt(new  Vector3(0,-1,0));
           
        }
        //圆
        //Vector3 center = StairsPrefab.transform.position;
        //for (int i = 0; i < 36; i++)
        //{
        //    GameObject gameObject = GameObject.Instantiate(StairsPrefab);
        //    float Amplitude = (RoundAngle / 180) * Mathf.PI;
        //    float xx = center.x + Radius * Mathf.Cos(Amplitude);
        //    float yy = center.y + Radius * Mathf.Sin(Amplitude);
        //    gameObject.transform.position = new Vector3(xx, yy, 0);
        //    gameObject.transform.LookAt(center);
        //    RoundAngle += 10;

        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
