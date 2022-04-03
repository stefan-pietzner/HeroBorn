﻿namespace UnityEngine {
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    public class Character
    {
        public string name;
        public int exp = 0;

        public Character()
        {
            name = "Not assigned";
        }

        public Character(string name)
        {
            this.name = name;
        }

        public virtual void PrintStatsInfo()
        {
            Debug.LogFormat("Hero: {0} - {1} EXP", name, exp);
        }

        private void Reset()
        {
            name = "Not assigned";
            exp = 0;
        }
    }

    public struct Weapon
    {
        public string name;
        public int damage;

        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }

        public void PrintStatsInfo()
        {
            Debug.LogFormat("Weapon: {0} - {1} damage", name, damage);
        }
    }

    public class Paladin : Character
    {
        public Weapon weapon;
        public Paladin(string name, Weapon weapon): base(name) 
        {
            this.weapon = weapon;
        }

        public override void PrintStatsInfo()
        {
            Debug.LogFormat("Hail {0} - take up your {1}!", name, weapon.name);
        }

    }
}

