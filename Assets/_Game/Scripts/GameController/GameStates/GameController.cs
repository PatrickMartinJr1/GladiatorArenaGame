using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private  float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    [SerializeField]
    public Unit _playerUnitPrefab;
    [SerializeField] public Transform _playerUnitSpawnLocation;
    [SerializeField] public UnitSpawner _unitSpawner;
    [SerializeField] public GameObject _enemySpawner1;
    [SerializeField] public GameObject _enemySpawner2;
    [SerializeField] public TouchManager _input;

    [SerializeField] GameObject _setupStateUI;
    [SerializeField] AudioSource _setupStateAudio;
    [SerializeField] GameObject _narrationStateUI;
    [SerializeField] AudioSource _narrationStateAudio;
    [SerializeField] GameObject _playStateUI;
    [SerializeField] AudioSource _playStateAudio;
    [SerializeField] GameObject _winStateUI;
    [SerializeField] AudioSource _winStateAudio;
    [SerializeField] GameObject _loseStateUI;
    [SerializeField] AudioSource _loseStateAudio;

    public float TapLimitDuration => _tapLimitDuration;

    public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    public UnitSpawner UnitSpawner => _unitSpawner;
    public GameObject EnemySpawner => _enemySpawner1;
    public GameObject EnemySpawner2 => _enemySpawner2;


    public TouchManager Input => _input;
    public GameObject SetupUI =>_setupStateUI;
    public AudioSource SetupAduio => _setupStateAudio;
    public GameObject NarrationUI => _narrationStateUI;
    public AudioSource NarrationAudio => _narrationStateAudio;
    public GameObject PlayUI => _playStateUI;
    public AudioSource PlayAudio => _playStateAudio;
    public GameObject WinUI => _winStateUI;
    public AudioSource WinAudio => _winStateAudio;
    public GameObject LoseUI => _loseStateUI;
    public AudioSource LoseAudio => _loseStateAudio;
}
