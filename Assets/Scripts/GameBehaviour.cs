using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehaviour : MonoBehaviour, IManager
{
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public string labelText = "Collect all 4 items and win your freedom!";
    public readonly int maxItems = 4;

    private int _itemsCollected = 0;

    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public int Items
    {
        get { return _itemsCollected; }
        set {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                labelText = "You found all the items!";
                showWinScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Item found, only" + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 3;
    public int HP
    {
        get { return _playerHP; }
        set {
            _playerHP = value;

            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's got hurt.";
            }
        }
    }

    // deklariert das Delegate "DebugDelegate" und erzeugt danach die delegierte Funktion "debug", die auf die Methode "Print" verweist
    // "debug" agiert jetzt wie "Print()". Die Methode wurde quasi wie eine Variable festgelegt.
    // C# führt hier im Grunde eine typsichere Zeigeroperation mit einer Methode aus (daher der Name "Typsicherheitsfunktionszeiger").
    // Dies hat hier keine besondere Funktion und dient nur der Übung.
    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;

    void Start()
    {
        Initialize();
        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Potion");
        UnityEngine.Debug.Log(inventoryList.item);
    }

    public void Initialize()
    {
        _state = "Manager initialized...";
        _state.FancyDebug();

        debug(_state);
        LogWithDelegate(debug);

        // die folgenden zwei Zeilen dienen nur dem Zuweisen der Komponente "PlayerBehaviour" zu einer Variable, damit danach die Methode "HandlePlayerJump" dem Ereignis "playerJump" zugewiesen werden kann.
        GameObject player = GameObject.Find("Player");
        PlayerBehaviour playerBehaviour = player.GetComponent<PlayerBehaviour>();

        // hier "abonniert" die Methode "HandlePlayerJump" das Ereignis "playerJump" in PlayerBehaviour;
        playerBehaviour.playerJump += HandlePlayerJump;
    }

    public void HandlePlayerJump(bool isGrounded)
    {
        if (isGrounded)
        {
            debug("Player has jumped...");
        }
    }

    // diese Methode dient dazu, die Verwendung eines delegates als Parameter einer weiteren Variable zu veranschaulichen
    // man beachte die Typenbezeichnung "DebugDelegate"! Dies ermöglicht die Verwendung typsicherer Methoden innerhalb einer Methode!
    public void LogWithDelegate(DebugDelegate debug)
    {
        debug("Delegating the debug task...");
    }


    public static void Print(string newText)
    {
        UnityEngine.Debug.Log(newText);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 50), "YOU WON!"))
            {
                Utilities.RestartLevel();
            }
        }

        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose.."))
            {
                try
                {
                    Utilities.RestartLevel(-1);
                    debug("Level restarted successfully...");
                }
                catch (System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    debug("Reverting to scene 0: " + e.ToString());
                }
                finally
                {
                    debug("Restart handled...");
                }
            }
        }
    }
}
