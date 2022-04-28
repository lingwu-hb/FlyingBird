using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    private Rigidbody rd; 
    public int originspeed = 5; // 小鸟的初始向前速度
    public int force = 5; // 小球的运动速度
    private int score = 10; // 小鸟的生命值
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        rd=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 获得水平和垂直方向的输入
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h,0,v)*force);
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.tag == "gold") {
            score--;
            text.text = "小鸟的生命为：" + score.ToString(); // 将分数复制给文本
            Destroy(collider.gameObject);
        }
    }
}
