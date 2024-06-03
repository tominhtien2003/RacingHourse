using UnityEngine;

public class ButtonTurnOnOffRank : MonoBehaviour
{
    [SerializeField] private GameObject objRank;
    private int change = 0;
    public void TurnOnOff()
    {
        change = 1 - change;
        if (change == 1) 
        {
            objRank.SetActive(true);
        }
        else
        {
            objRank.SetActive(false);
        }
    }
}
