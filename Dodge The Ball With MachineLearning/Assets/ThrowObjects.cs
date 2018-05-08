using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjects : MonoBehaviour {

    public GameObject spherePrefab;
    public GameObject cubePrefab;

    public Material blue;
    public Material yellow;

    public bool canThrow = false;
    public float speed = 1;
    Perceptron p;

    void Start()
    {
        p = GetComponent<Perceptron>();
    }

    void Update()
    {
        if (canThrow)
        {
            canThrow = false;
            ThrowRandomly(Random.Range(1, 16));
        }
    }

    void ThrowRandomly(int i)
    {
        GameObject g = null;
        switch (i)
        {
            case 1:
                g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = blue;
                g.GetComponent<ParticleSystem>().enableEmission = true;
                g.GetComponent<Light>().intensity = 5;

                p.SendInput(1, 1, 1, 1, 1);

                break;

            case 2:
                g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = blue;
                g.GetComponent<ParticleSystem>().enableEmission = true;
                g.GetComponent<Light>().intensity = 0;

                p.SendInput(1, 1, 1, 0, 1);
                
                break;

            case 3:
                g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = blue;
                g.GetComponent<ParticleSystem>().enableEmission = false;
                g.GetComponent<Light>().intensity = 5;

                p.SendInput(1, 1, 0, 1, 1);
                
                break;

            case 4:
                g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = blue;
                g.GetComponent<ParticleSystem>().enableEmission = false;
                g.GetComponent<Light>().intensity = 0;

                p.SendInput(1, 1, 0, 0, 0);

                break;

            case 5:
                g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = yellow;
                g.GetComponent<ParticleSystem>().enableEmission = true;
                g.GetComponent<Light>().intensity = 5;

                p.SendInput(1, 0, 1, 1, 1);

                break;

            case 6:
                g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = yellow;
                g.GetComponent<ParticleSystem>().enableEmission = true;
                g.GetComponent<Light>().intensity = 0;

                p.SendInput(1, 0, 1, 0, 1);

                break;

            case 7:
                g = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = yellow;
                g.GetComponent<ParticleSystem>().enableEmission = false;
                g.GetComponent<Light>().intensity = 5;

                p.SendInput(1, 0, 0, 1, 1);

                break;

            case 8:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = yellow;
                g.GetComponent<ParticleSystem>().enableEmission = false;
                g.GetComponent<Light>().intensity = 0;

                p.SendInput(0, 0, 0, 0, 0);

                break;

            case 9:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = blue;
                g.GetComponent<ParticleSystem>().enableEmission = true;
                g.GetComponent<Light>().intensity = 5;

                p.SendInput(0, 1, 1, 1, 1);

                break;

            case 10:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = blue;
                g.GetComponent<ParticleSystem>().enableEmission = true;
                g.GetComponent<Light>().intensity = 0;

                p.SendInput(0, 1, 1, 0, 1);

                break;

            case 11:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = blue;
                g.GetComponent<ParticleSystem>().enableEmission = false;
                g.GetComponent<Light>().intensity = 5;

                p.SendInput(0, 1, 0, 1, 1);

                break;

            case 12:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = blue;
                g.GetComponent<ParticleSystem>().enableEmission = false;
                g.GetComponent<Light>().intensity = 0;

                p.SendInput(0, 1, 0, 0, 0);

                break;

            case 13:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = yellow;
                g.GetComponent<ParticleSystem>().enableEmission = true;
                g.GetComponent<Light>().intensity = 5;

                p.SendInput(0, 0, 1, 1, 1);

                break;

            case 14:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = yellow;
                g.GetComponent<ParticleSystem>().enableEmission = true;
                g.GetComponent<Light>().intensity = 0;

                p.SendInput(0, 0, 1, 0, 0);

                break;

            case 15:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = yellow;
                g.GetComponent<ParticleSystem>().enableEmission = false;
                g.GetComponent<Light>().intensity = 5;

                p.SendInput(0, 0, 0, 1, 1);

                break;

            case 16:
                g = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
                g.GetComponent<Renderer>().material = yellow;
                g.GetComponent<ParticleSystem>().enableEmission = false;
                g.GetComponent<Light>().intensity = 0;

                p.SendInput(0, 0, 0, 0, 0);

                break;

            default:
                break;
        }

        g.GetComponent<Rigidbody>().AddForce(0, 0, 500);
        StartCoroutine(ClearField(g));
    }

    IEnumerator ClearField(GameObject g)
    {
        yield return new WaitForSeconds(speed);
        canThrow = true;
        Destroy(g);
    }
}
