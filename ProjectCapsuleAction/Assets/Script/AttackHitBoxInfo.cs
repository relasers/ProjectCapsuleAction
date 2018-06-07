using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBoxInfo : MonoBehaviour {

    public int UniqueID;

    public int Damage = 10;
    public float self_destroy_time = 2.0f; // 자동 소멸타임


    // 유니크한 ID, 허용시간
    //Dictionary<int , float > hitinfo;

    IEnumerator SelfDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);

    }
    
    Coroutine coroutine_selfdestroy;

    // Use this for initialization
    void Start () {
        UniqueID = GetInstanceID(); // 오브젝트의 인스턴스 아이디는 고유함을 보장한다.
        coroutine_selfdestroy = StartCoroutine(SelfDestroy(self_destroy_time));

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Color new_Color = meshRenderer.material.color;
        meshRenderer.material.color = new Color(new_Color.r, new_Color.g, new_Color.b,0.2f);
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
