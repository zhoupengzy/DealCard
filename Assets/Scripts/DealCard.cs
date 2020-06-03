using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealCard : MonoBehaviour {

    public Button BtnStart;

    public Button BtnReset;

    public Image Card1;
    public Image Card2;
    public Image Card3;
    public Image Card4;
    public Image Card5;

    public Transform PosEnd1;

    // Use this for initialization
    void Start () {
         BtnStart.onClick.AddListener(OnClickStart);
         BtnStart.onClick.AddListener(OnClickReset);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OnClickStart()
    {
        Debug.Log("OnClickStart");
    }

    public void OnClickReset()
    {

    }
}
