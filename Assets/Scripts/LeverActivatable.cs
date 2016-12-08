using UnityEngine;
using System.Collections;

public class LeverActivatable : MonoBehaviour, Activatable {
    public bool Active = false;
    public GameObject leverObject;
    public SkullActivatable Skull;

    public void Start()
    {
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
            leverObject.transform.eulerAngles = new Vector3(-70, 0, 0);
            Skull.SetActive(Active);
        }
        else
        {
            leverObject.transform.eulerAngles = new Vector3(-100, 0, 0);
            Skull.SetActive(Active);
        }

    }
}
