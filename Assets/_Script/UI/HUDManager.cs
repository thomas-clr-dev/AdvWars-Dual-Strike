using System;
using UnityEngine;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    private Label _p1Turn, _p1Gold;
    private VisualElement _p1Blind;

    private Label _p2Turn, _p2Gold;
    private VisualElement _p2Blind;

    private ITurnService _turnService;
    private IEconomyService _economyService;

    private void Start()
    {
        _turnService = ServiceLocator.Get<ITurnService>();
        _economyService = ServiceLocator.Get<IEconomyService>();

        var root = GetComponent<UIDocument>().rootVisualElement;

        // --- SETUP PLAYER 1 ---
        var p1Root = root.Q<VisualElement>("Player1HUD");
        _p1Turn = p1Root.Q<Label>("Lbl_Turn");
        _p1Gold = p1Root.Q<Label>("Lbl_Gold");
        _p1Blind = p1Root.Q<VisualElement>("BlindOverlay");
        p1Root.Q<Button>("Btn_EndTurn").clicked += () => OnEndTurnClicked(1);

        // --- SETUP PLAYER 2 ---
        var p2Root = root.Q<VisualElement>("Player2HUD");
        _p2Turn = p2Root.Q<Label>("Lbl_Turn");
        _p2Gold = p2Root.Q<Label>("Lbl_Gold");
        _p2Blind = p2Root.Q<VisualElement>("BlindOverlay");
        p2Root.Q<Button>("Btn_EndTurn").clicked += () => OnEndTurnClicked(2);

        _turnService.OnTurnChanged += UpdateUI;
        UpdateUI();
    }

    private void OnEndTurnClicked(int clickingPlayerID)
    {
        if (_turnService.CurrentPlayerID == clickingPlayerID)
        {
            _turnService.EndTurn();
        }
    }

    private void UpdateUI()
    {
        int activePlayer = _turnService.CurrentPlayerID;
        int turn = _turnService.TurnNumber;

        _p1Turn.text = $"Turn {turn}";
        _p1Gold.text = $"Gold : {_economyService.GetGold(1)}";

        _p2Turn.text = $"Turn {turn}";
        _p2Gold.text = $"Gold : {_economyService.GetGold(2)}";

        if (activePlayer == 1)
        {
            _p1Blind.style.display = DisplayStyle.None;
            _p2Blind.style.display = DisplayStyle.Flex;
        }
        else
        {
            _p1Blind.style.display = DisplayStyle.Flex;
            _p2Blind.style.display = DisplayStyle.None;
        }
    }
}
