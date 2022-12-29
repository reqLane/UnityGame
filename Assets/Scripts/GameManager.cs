using Project.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private BattleManager battleManager;
    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private RecordsManager recordsManager;

    private Player player;

    public Player Player { get => player; set => player = value; }
    public LevelManager LevelManager { get => levelManager; set => levelManager = value; }
    public BattleManager BattleManager { get => battleManager; set => battleManager = value; }
    public AudioManager AudioManager { get => audioManager; set => audioManager = value; }
    public UIManager UiManager { get => uiManager; set => uiManager = value; }
    public RecordsManager RecordsManager { get => recordsManager; set => recordsManager = value; }
}
