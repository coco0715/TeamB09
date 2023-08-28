﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum VegetableType
{
    감자 = 1, 고구마, 당근
}

namespace FindingPotato.Character
{
    internal class Player : ICharacter
    {
        public string Name { get; }
        public VegetableType Type { get; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int AttackPower { get; set; }
        public bool IsDead => Health <= 0;
        public int Attack => new Random().Next(30, AttackPower); // 공격력은 랜덤

        public Player(string name, VegetableType type)
        {
            Name = name;
            Type = type;
            Level = 1;

            if (type == VegetableType.감자)
            {
                Health = 100;
                Defense = 10;
                AttackPower = 50;
            }
            else if (type == VegetableType.고구마)
            {
                Health = 120;
                Defense = 20;
                AttackPower = 40;
            }
            else // 당근
            {
                Health = 100;
                Defense = 0;
                AttackPower = 60;
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다.");
        }
    }
}
