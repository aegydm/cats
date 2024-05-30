using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Transform camShake;
    public bool shakeRotate = false;
    private Vector3 originPos;
    private Quaternion originRot;
    // Start is called before the first frame update
    void Start()
    {
        originPos = camShake.localPosition;
        originRot = camShake.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator CamShaker(float duration = 1.45f, float magnitudePos = 0.03f, float magnitudeRot = 0.0f)
    {
        float passTime = 0.1f;
        while (passTime < duration)
        {
            Vector3 shakePos = Random.insideUnitSphere;
            camShake.localPosition = shakePos * magnitudePos;
            magnitudePos += 0.0002f;

            if (shakeRotate)
            {
                Vector3 shakeRot = new Vector3(0, 0, Mathf.PerlinNoise(Time.time * magnitudeRot, 0.0f));
                camShake.localRotation = Quaternion.Euler(shakeRot);
            }
            passTime += Time.deltaTime;
            yield return null;
        }
        camShake.localPosition = originPos;
        camShake.localRotation = originRot;
    }
}
