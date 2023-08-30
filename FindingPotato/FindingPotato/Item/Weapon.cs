﻿using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
    internal class Weapon : IEquipable
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Effect { get; set; }
        public string Desc { get; set; }
        public bool IsEquipped { get; set; }

        internal Weapon(string name, int effect, string desc)
        {
            Name = name;
            Effect = effect;
            Desc = desc;
            IsEquipped = false;
            Type = ItemType.Weapon;
        }

        public void Use(Player player)
        {

            IEquipable foundItem = player.PlayerInventory.InventoryItems
                .OfType<IEquipable>()
                .FirstOrDefault(i => i.IsEquipped && i.Type == Type && i.Name != Name);

            if (foundItem != null)
            {
                Console.SetCursorPosition(0, player.PlayerInventory.InventoryItems.Count + 11); // 메시지 위치 잡기
                Console.WriteLine($" 현재 {foundItem.Name}을/를 장착 중입니다. {Name}으로 교체하시겠습니까?");
                Extension.ColorWriteLine("1. 교체하기");
                Extension.ColorWriteLine("0. 취소");

                int input = Extension.GetInput(0, 1);

                if (input == 0) { return; }
            }

            if (!this.IsEquipped) player.AddAtk += this.Effect;
            else player.AddAtk -= this.Effect;

            this.IsEquipped = !this.IsEquipped;

            UseMessage(player);
        }

        public void UseMessage(Player player)
        {
            Console.SetCursorPosition(0, player.PlayerInventory.InventoryItems.Count + 11); // 메시지 위치 잡기
            if (IsEquipped)
            {
                Extension.ColorWriteLine($" {Name} 을/를 장착했습니다.           ", ConsoleColor.Black, ConsoleColor.Green);
                Extension.ColorWriteLine($" 공격력이 + {Effect} 증가합니다.", ConsoleColor.Black, ConsoleColor.Green);
            }
            else
            {
                Extension.ColorWriteLine($" {Name}을/를 장착 해제 했습니다.           ", ConsoleColor.Black, ConsoleColor.Green);
                Console.WriteLine("                                         ");
            }
            Console.WriteLine("                                         ");
            Thread.Sleep(2000);
        }
    }
}
