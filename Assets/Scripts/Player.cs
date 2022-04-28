using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player:MonoBehaviour{
    private Rigidbody rd;
    public int HP = 1; // 小鸟的初始化生命值
    public float originspeed = 5; // 小鸟的初始向前速度
    public float force = 5; // 小球的运动速度
    public float gravityFactor = 5; // 重力的影响程度
    public Text text; // 记录小鸟的生命值
    void Start(){
        // 减少重力的影响，也就是降低小鸟的下降速度
        Physics.gravity = new Vector3(0, -gravityFactor, 0);
        rd = GetComponent<Rigidbody>();
    }
    void Update(){
        Control();
    }
    void Control(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h*force, v*force, originspeed));
    }
    void OnTriggerEnter(Collider collider) {
        if(collider.tag == "dragon") {
            HP--;
            text.text = "小鸟剩余的生命值为：" + HP.ToString();
            Destroy(collider.gameObject);
        }
    }
}