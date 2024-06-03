using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RankMainHourse : MonoBehaviour
{
    [SerializeField] private List<Transform> horseList;

    [SerializeField] private Transform mainHourse;

    [SerializeField] private TextMeshProUGUI rankText;

    [SerializeField] private TextMeshProUGUI distanceText;

    [SerializeField] private Transform des;

    [SerializeField] private TextMeshProUGUI[] textArray;

    [SerializeField] private GameOver gameOverScrip;

    [SerializeField] private GameObject rankFirstSecondThirdUI;

    private int rate = 1;

    private void Start()
    {
        gameOverScrip.OnGameOver += GameOverScrip_OnGameOver;
    }

    private void GameOverScrip_OnGameOver(object sender, System.EventArgs e)
    {
        rankFirstSecondThirdUI.SetActive(true);
        horseList = horseList.OrderBy(horse => horse.position.z).ToList();
        rankFirstSecondThirdUI.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = horseList[0].gameObject.name;
        rankFirstSecondThirdUI.transform.GetChild(0).GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = horseList[1].gameObject.name;
        rankFirstSecondThirdUI.transform.GetChild(0).GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = horseList[2].gameObject.name;
    }

    private void SetRankForAllHourse()
    {
        int rank = 1;
        for (int i = horseList.Count -1; i >=0; i--)
        {
            textArray[horseList.Count-i-1].text = horseList[i].gameObject.name + " : " + rank.ToString() + "th";
            rank++;
        }
    }

    private void Update()
    {
        GetRankOfMainHourse();
    }
    private void LateUpdate()
    {
        SortHourseList();
    }
    public void GetRankOfMainHourse()
    {
        int count = 0;
        foreach (Transform t in horseList)
        {
            if (t.position.z < mainHourse.position.z)
            {
                count++;
            }
        }
        rate = horseList.Count - count;
        SetText();
    }

    private void SetText()
    {
        rankText.text = rate.ToString() + "th";
        float dis = Mathf.Round(des.position.z - mainHourse.position.z);
        if (dis >= 0) distanceText.text = dis + "m";
    }

    private void SortHourseList()
    {
        horseList = horseList.OrderBy(horse => horse.position.z).ToList();
        SetRankForAllHourse();
    }
}
