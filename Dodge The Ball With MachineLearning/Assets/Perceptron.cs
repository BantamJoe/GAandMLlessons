using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
	public double[] input;
	public double output;
}

public class Perceptron : MonoBehaviour {

    List<TrainingSet> ts = new List<TrainingSet>();
	double[] weights = { 0, 0, 0, 0};
	double bias = 0;
	double totalError = 0;

    public int score = 0;

    public GameObject npc;
    TextMesh tm;

    void UpdateScore()
    {
        if (score > 0) tm.color = Color.green;
        else tm.color = Color.red;

        tm.text = "Score: "+ score;
    }

    public void SendInput(double i1, double i2, double o)
    {
        double result = CalcOutput(i1, i2);
        
        if (result == 0)
        {
            npc.GetComponent<Animator>().SetTrigger("Crouch");
            npc.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
            npc.GetComponent<Rigidbody>().isKinematic = true;

        TrainingSet set = new TrainingSet();
        set.input = new double[2] { i1, i2 };
        set.output = o;
        ts.Add(set);
        Train();
    }
    public void SendInput(double i1, double i2, double i3, double i4, double o)
    {
        double result = CalcOutput(i1, i2, i3, i4);

        if (result == 0)
        {
            npc.GetComponent<Animator>().SetTrigger("Crouch");
            npc.GetComponent<Rigidbody>().isKinematic = false;
            score -= 1;
        }
        else
        {
            npc.GetComponent<Rigidbody>().isKinematic = true;
            score += 1;
        }

        TrainingSet set = new TrainingSet();
        set.input = new double[4] { i1, i2, i3, i4 };
        set.output = o;
        ts.Add(set);
        Train();
    }

    double DotProductBias(double[] v1, double[] v2) 
	{
		if (v1 == null || v2 == null)
			return -1;
	 
		if (v1.Length != v2.Length)
			return -1;
	 
		double d = 0;
		for (int x = 0; x < v1.Length; x++)
		{
			d += v1[x] * v2[x];
		}

		d += bias;
	 
		return d;
	}

	double CalcOutput(int i)
	{
		return(ActivationFunction(DotProductBias(weights,ts[i].input)));
	}

    double CalcOutput(double i1, double i2)
    {
        double[] inp = new double[] { i1, i2 };
        return (ActivationFunction(DotProductBias(weights, inp)));
    }

    double CalcOutput(double i1, double i2, double i3, double i4)
    {
        double[] inp = new double[] { i1, i2, i3, i4 };
        return (ActivationFunction(DotProductBias(weights, inp)));
    }

    double ActivationFunction(double dp)
	{
		if(dp > 0) return (1);
		return(0);
	}

	void InitialiseWeights()
	{
		for(int i = 0; i < weights.Length; i++)
		{
			weights[i] = Random.Range(-1.0f,1.0f);
		}
		bias = Random.Range(-1.0f,1.0f);
	}

	void UpdateWeights(int j)
	{
		double error = ts[j].output - CalcOutput(j);
		totalError += Mathf.Abs((float)error);
		for(int i = 0; i < weights.Length; i++)
		{			
			weights[i] = weights[i] + error*ts[j].input[i]; 
		}
		bias += error;
	}

	void Train()
	{
			for(int t = 0; t < ts.Count; t++)
			{
				UpdateWeights(t);
			}
	}


	void Start () {
        InitialiseWeights();
        tm = GetComponent<TextMesh>();
	}
	
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            InitialiseWeights();
            ts.Clear();
            score = 0;
        }

        UpdateScore();
	}
}