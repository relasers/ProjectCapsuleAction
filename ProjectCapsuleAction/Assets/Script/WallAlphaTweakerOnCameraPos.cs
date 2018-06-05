using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAlphaTweakerOnCameraPos : MonoBehaviour {

    public GameObject camera_manager;
    public GameObject player_header;

    // 투명해져야하는가?
    public bool IsTransparencing = false;

    // 한번에 알파값을 얼마만큼씩 변동시킬 것인가.
    public float delta_value = 0.01f;
    // 코루틴 딜레이
    public float delta_delay = 0.001f;

    Coroutine coroutine_decrease_alpha;
    Coroutine coroutine_increase_alpha;

    IEnumerator DecreaseAlpha(float delay)
    {

        Material material = GetComponent<MeshRenderer>().material;
        while (material.color.a > 0 && IsTransparencing)
        {
           material.color =
                new Color(material.color.r,
                material.color.g, 
                material.color.b,
                material.color.a - delta_value
                );
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator IncreaseAlpha(float delay)
    {

        Material material = GetComponent<MeshRenderer>().material;
        while (material.color.a < 1)
        {
            material.color =
                 new Color(material.color.r,
                 material.color.g,
                 material.color.b,
                 material.color.a + delta_value
                 );
            yield return new WaitForSeconds(delay);
        }
    }


    // Use this for initialization
    void Start () {

        camera_manager = GameObject.FindWithTag("CameraManager");
        player_header = GameObject.FindWithTag("PlayerHeader");

    }
	
	// Update is called once per frame
	void Update () {

        

	}
    
    // 벽의 뒷면에 카메라가 위치하면 벽이 투명해진다.

    private void OnTriggerEnter(Collider other)
    {
        if (camera_manager)
        {
            if (other.tag == camera_manager.tag)
            {
                IsTransparencing = true;
                coroutine_decrease_alpha = StartCoroutine(DecreaseAlpha(delta_delay));
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (camera_manager)
        {
            if (other.tag == camera_manager.tag)
            {
                IsTransparencing = false;
                coroutine_increase_alpha = StartCoroutine(IncreaseAlpha(delta_delay));
            }
        }
    }



}
