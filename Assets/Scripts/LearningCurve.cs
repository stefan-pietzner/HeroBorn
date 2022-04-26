using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

// Namespace-Konflikt zwischen System.Diagnostics und UnityEngine. Unity lädt System.Diagnostics immer wieder in den Script, also nehme ich einfach UnityEngine als Namespace
namespace UnityEngine {

    public class LearningCurve : MonoBehaviour
    {
        private int firstNumber = 2;
        public int secondNumber = 3;
        public float size = 1.95f;
        public double large = 99999999999999999999.99;
        public char letter = 'y';
        public string sentence = "Hello there.";
        public bool trueOrFalse = true;
        public int currentGold = 45;
        public bool pureOfHeart = true;
        public bool hasSecretIncantation = false;
        public string rareItem = "Fire Emblem";
        public string characterAction = "Attack";
        public int diceRoll = 7;
        List<string> questPartyMembers = new List<string> { "Grim the Barbarian", "Merlin the Wise", "Sterling the Knight" };
        Dictionary<string, int> itemInventory = new Dictionary<string, int>()
        {
            {"Book of Life", 1},
            {"Book of Death", 2},
            {"Book of Cooking", 3}
        };
        private Transform camTransform;
        public GameObject directionLight;
        private Transform lightTransform;

        // Start is called before the first frame update
        void Start()
        {
            /* 
            int characterLevel = 32;
            int nextSkillLevel = GenerateCharacter("Rick", characterLevel);
            Debug.Log(nextSkillLevel);
            Debug.Log(GenerateCharacter("Morty", characterLevel));
            WriteToConsole(GenerateCharacter("Jerry", characterLevel));
            */

            /*
            if (currentGold > 50)
            {
                Debug.Log("Lotsa gold you got here.");
            } 
            else if (currentGold < 15)
            {
                Debug.Log("That's less gold than expected. Better save some for hard times.");
            }
            else
            {
                Debug.Log("Nice financials. Seems well balanced.");
            }
            */

            // OpenTreasureChamber();

            /* switch (characterAction) {

                case "Heal":
                    Debug.Log("You take a potion. 20 HP healed!");
                    break;

                case "Attack":
                    Debug.Log("You swing your sword. The enemy takes 20 damage!");
                    break;
                default:
                    Debug.Log("You are unsure what to do!");
                    break;
            }
            */

            /* switch(diceRoll)
            {
                case 7:
                case 15:
                    Debug.Log("Mediocre damage, not bad.");
                    break;
                case 20:
                    Debug.Log("Critical hit, the creature goes down!");
                    break;
                default:
                    Debug.Log("You completely missed and fell on your face.");
                    break;
            }
            */

            //Debug.Log(itemInventory.Count);

            /* for (int i = 0; i < questPartyMembers.Count; i++)
            {
                Debug.LogFormat("Index: {0} - {1}", i, questPartyMembers[i]);

                if (questPartyMembers[i] == "Merlin the Wise")
                {
                    Debug.Log("Glad you're here Merlin!");
                }
            */

            /* int playerLives = 3;
            while (playerLives > 0)
            {
                Debug.Log("I'm alive!");
                playerLives--;
            }

            Debug.Log("I'm ded.");
            */

            //Character hero = new Character();
            //hero.PrintStatsInfo();

            //  Character heroine = new Character("Agatha");
            //  heroine.PrintStatsInfo();

            Weapon huntingBow = new Weapon("Hunting Bow", 105);

            Weapon warBow = huntingBow;
            warBow.name = "Warbow";
            warBow.damage = 155;

            /*
            huntingBow.PrintStatsInfo();
            warBow.PrintStatsInfo();
            */

            /* Character hero2 = hero;
            hero2.name = "Sir Krane the Brave";
            hero.PrintStatsInfo();
            hero2.PrintStatsInfo();
            hero2.Reset();
            */

            /* Paladin knight = new Paladin("Sir Arthur", huntingBow);
            knight.PrintStatsInfo();
            */

            /* camTransform = this.GetComponent<Transform>();
            Debug.Log(camTransform.localPosition);
            */

            // directionLight = GameObject.Find("Directional Light");
            lightTransform = directionLight.GetComponent<Transform>();
            Debug.Log(lightTransform.localPosition);
        }

        // Update is called once per frame
        void Update()
        {

        }
        /// <summary>
        /// Adds the numbers.
        /// </summary>
        void AddNumbers()
        {
            Debug.Log(firstNumber + secondNumber);
        }

        public int GenerateCharacter(string name, int level)
        {
            // hier wird statt .Log .LogFormat benutzt. Es benutzt mehrere Parameter, die in den String eingefügt werden. .Log hätte aber auch funktioniert.
            // Debug.LogFormat("Character: {0} - Level {1}", name, level);
            return level + 5;
        }

        public void WriteToConsole(int number)
        {
            Debug.Log(number);
        }

        public void OpenTreasureChamber()
        {
            if (pureOfHeart && rareItem == "Fire Emblem")
            {
                Debug.Log($"You possess the {rareItem} and are pure of heart. The gate opens.");
                if (!hasSecretIncantation)
                {
                    Debug.Log("...but you don't know the secret incantation!");
                }
                else
                {
                    Debug.Log("You know of the secret incantation. The treasure is yours!");
                }
            }
            else
            {
                Debug.Log($"Only the ones pure of heart and possessing the {rareItem} may enter!");
            }
        }
    }
}   

