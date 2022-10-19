using UnityEngine;

public class SpinPulseTransforms : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spinLights;

    [SerializeField]
    private float _waveSpeed, _waveAmplitude, _waveOffset;

    [SerializeField]
    private float[] _spinSpeeds;

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < _spinLights.Length; i++)
        {
            // Rotate
            Vector3 rotation = new Vector3
            {
                z = _spinSpeeds[i] * Time.deltaTime
            };
            _spinLights[i].Rotate(rotation);

            // Wave
            float wave = Mathf.Sin(Time.time + _waveSpeed) * _waveAmplitude + _waveOffset;
            Vector3 waveScale = new Vector3(wave, wave, wave);
            _spinLights[i].localScale = waveScale;
        }
    }
}
