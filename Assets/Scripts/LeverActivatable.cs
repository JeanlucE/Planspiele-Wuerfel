using UnityEngine;
using System.Collections;

public class LeverActivatable : MonoBehaviour, Activatable {
    public bool Active = false;
    public GameObject leverObject;
    public SkullActivatable Skull;

    private Vector3 startEulerAngles;
    public void Start()
    {
        startEulerAngles = leverObject.transform.eulerAngles;
        //light.enabled = Active;
        RotateLever();
    }

	public void Activate()
    {
        Active = !Active;
        RotateLever();
    }

    private void RotateLever()
    {
        if (!Active)
        {
            leverObject.transform.eulerAngles = new Vector3(-70, startEulerAngles.y, startEulerAngles.z);
            Skull.SetActive(Active);
        }
        else
        {
            leverObject.transform.eulerAngles = new Vector3(-100, startEulerAngles.y, startEulerAngles.z);
            Skull.SetActive(Active);
        }

    }
}
