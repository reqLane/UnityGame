using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Light2D globalLight = GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>();
        Light2D torchLight = GetComponent<Light2D>();
        torchLight.intensity = globalLight.intensity <= 0.75 ? 1 : 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
