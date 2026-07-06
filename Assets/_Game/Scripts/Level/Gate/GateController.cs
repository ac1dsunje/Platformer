using UnityEngine;

public class GateController: MonoBehaviour
{
    [SerializeField] private GameObject _openedContainer;
    [SerializeField] private GameObject _closedContainer;

    public void Open()
    {
        _openedContainer.SetActive(true);
        _closedContainer.SetActive(false);
    }

    public void Close()
    {
        _openedContainer.SetActive(false);
        _closedContainer.SetActive(true);
    }
}