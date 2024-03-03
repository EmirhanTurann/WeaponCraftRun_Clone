using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBandSystem : MonoBehaviour
{
    private Material band_Mat;
    private float offsety=0;

    // Start is called before the first frame update
    void Start()
    {
        band_Mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offsety += Time.deltaTime;
        band_Mat.mainTextureOffset = new Vector2(0, -offsety);
    }
}
