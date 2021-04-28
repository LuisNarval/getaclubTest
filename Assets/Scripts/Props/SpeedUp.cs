using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{

    [SerializeField] MeshRenderer MR;
    private Material m_Material;
    float offset = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = MR.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime;
        m_Material.SetTextureOffset ("_MainTex", new Vector2(-offset,0.0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponentInParent<CarController>().SpeedUp();   
    }

}
