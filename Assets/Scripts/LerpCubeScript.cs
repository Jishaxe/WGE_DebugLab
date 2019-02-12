using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCubeScript : MonoBehaviour {

    public GameObject _cube;
    public Vector3 _leftPosition;
    public Vector3 _rightPosition;
    public Vector3 cameraOriginalPosition;

    public void StartLerp()
    {
        _cube.transform.position = _leftPosition;
        StartCoroutine(LerpCube());
    }

    public void Start()
    {
        cameraOriginalPosition = Camera.main.transform.position;
    }

    IEnumerator LerpCube()
    {
        float t = 0;

        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        stopWatch.Start();

        while (t < 1)
        {
            t += Time.deltaTime;
            //Debug.Log(t);
            Camera.main.transform.position = cameraOriginalPosition + CameraShake(t);
            Debug.Log(CameraShake(t));
            _cube.transform.position = LerpSmoothStep(_leftPosition, _rightPosition, t);
            if(t >=1)
            {
                _cube.transform.position = _rightPosition;
            }
            yield return null;
        }

        Camera.main.transform.position = cameraOriginalPosition;
        stopWatch.Stop();

        Debug.Log("Lerp took: " + stopWatch.Elapsed);
    }

    //inseert code here:

    public Vector3 Lerp (Vector3 a, Vector3 b, float t)
    {
        float x = a.x + (b.x - a.x) * t;
        float y = a.y + (b.y - a.y) * t;
        float z = a.z + (b.z - a.z) * t;

        return new Vector3(x, y, z);
    }


    public Vector3 LerpSmoothStart(Vector3 a, Vector3 b, float t)
    {
        float x = a.x + (b.x - a.x) * t * t * t;
        float y = a.y + (b.y - a.y) * t * t * t;
        float z = a.z + (b.z - a.z) * t * t * t;

        return new Vector3(x, y, z);
    }


    public Vector3 LerpSmoothEnd(Vector3 a, Vector3 b, float t)
    {
        float x = a.x + (b.x - a.x) * (1 - (1 - t) * (1 - t) * (1 - t));
        float y = a.y + (b.y - a.y) * (1 - (1 - t) * (1 - t) * (1 - t));
        float z = a.z + (b.z - a.z) * (1 - (1 - t) * (1 - t) * (1 - t));

        return new Vector3(x, y, z);
    }

    public Vector3 LerpSmoothStep(Vector3 a, Vector3 b, float t)
    {
        return Lerp(LerpSmoothStart(a, b, t), LerpSmoothEnd(a, b, t), t);
    }

    public Vector3 CameraShake(float t)
    {
        return new Vector3(Mathf.PerlinNoise(t * 100, 0) * 2 - 1, Mathf.PerlinNoise(0, t * 100) * 2 - 1, 0) * 10;
    }

    public void PrintDebugString()
    {
        Debug.Log(this.ToString());
    }

    public override string ToString()
    {
        string s;

        s = (_cube ? "Cube position = " + _cube.transform.position : "Cube is null") + "\n";
        s += "Left position: " + _leftPosition + "\n";
        s += "Right position: " + _rightPosition;

        return s;
    }

}
