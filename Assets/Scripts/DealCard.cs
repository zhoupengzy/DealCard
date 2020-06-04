using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealCard : MonoBehaviour {

    public Button BtnStart;

    public Button BtnReset;

    public Transform[] Cards;

    public float DealTime1 = 0.5f;
    public float DealTime2 = 0.5f;

    public float DealInterval = 0.1f;
    public float ToFrontTime = 0.5f;

    public Transform PosEnd1;

    private Vector3 orgPos;
    private Vector3 orgScale;

    // Use this for initialization
    void Start () {
        BtnStart.onClick.AddListener(OnClickStart);
        BtnReset.onClick.AddListener(OnClickReset);

        orgPos = Cards[0].localPosition;
        orgScale = Cards[0].localScale;
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OnClickStart()
    {

        Vector3 midPos = new Vector3(orgPos.x - 150, orgPos.y - 70, orgPos.z);
        Vector3[] path = { orgPos, midPos, PosEnd1.localPosition };

        for (int i = 0; i < Cards.Length; i++)
        {

            Sequence tween = DOTween.Sequence();
            tween.AppendInterval(i* DealInterval);
            // 发牌
            tween.Append(
                Cards[i].transform.DOLocalPath(path, DealTime1, PathType.CatmullRom)
                .SetOptions(false)
                .SetEase(Ease.InQuart)
                );
            tween.Join(Cards[i].transform.DOScale(new Vector3(1, 1, 1), DealTime1).SetEase(Ease.InQuart));
            tween.AppendInterval((Cards.Length-1-i) * DealInterval);

            // 摊牌
            tween.Append(Cards[i].transform.DOLocalMoveX(PosEnd1.localPosition.x + i * 70, DealTime2).SetEase(Ease.Linear));

            // 明牌
            Cards[i].Find("front").eulerAngles = new Vector3(0, 90, 0);
            Cards[i].Find("back").eulerAngles = Vector3.zero;

            tween.Append(Cards[i].Find("back").DORotate(new Vector3(0, 90, 0), ToFrontTime/2));
            tween.Append(Cards[i].Find("front").DORotate(Vector3.zero, ToFrontTime/2));
        }

    }

    public void OnClickReset()
    {
        for (int i = 0; i < Cards.Length; i++)
        {
            Cards[i].localPosition = orgPos;
            Cards[i].localScale = orgScale;
            Cards[i].Find("front").eulerAngles = new Vector3(0, 90, 0);
            Cards[i].Find("back").eulerAngles = Vector3.zero;
        }
    
    }

}
