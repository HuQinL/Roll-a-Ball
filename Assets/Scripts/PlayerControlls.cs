using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlls : MonoBehaviour
{
    public GameObject StairsPrefab;
    //public GameObject PlayPrefab;
    public float StairAngle;

    public Text countText;
    public Text winText;
    public float speed;

    private int count;
    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        //DestroyObject(other.gameObject);
    }
    void SetCountText()
    {
        countText.text = "Count：" + count.ToString();

        if (count >= 15)
        {
            winText.text = "You Win!";
        }
        if (count == 12)
        {
            //楼梯
            for (int i = 0; i < 15; i++)
            {
                GameObject gameObject = GameObject.Instantiate(StairsPrefab);
                float Amplitude = (StairAngle / 180) * Mathf.PI;
                float hight = i * Mathf.Tan(Amplitude);
                //if (i >= 12)
                //{
                //    hight = 12 * Mathf.Tan(Amplitude);
                //}
                //else
                //{
                gameObject.transform.position = new Vector3(0 + i, (-1) + hight, 0);
                //}

                gameObject.transform.LookAt(new Vector3(0, -1, 0));
            }
        }
    }
}
