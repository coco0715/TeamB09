﻿using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    internal class StatusUI
    {
        public static void ShowStatus(Player player)
        {
            Console.Clear();

            string[] option = { "    0.  나가기      " };

            UIExtension.DrawCharacter(player.Image, 99, 24);
            PrintTitle(player);
            PrintStatusBox();
            StatusContents(player);
            PrintFloor();
            

            UIExtension.GetPlayerSelectFromUI(63, 38, 4, option, true);
        }

        static void PrintTitle(Player player)
        {
            Console.SetCursorPosition(92, 10);
            Console.WriteLine("┌──────────────────────────┐");

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(92, Console.CursorTop);
                Console.WriteLine("│                          │");
            }
            Console.SetCursorPosition(92, Console.CursorTop);
            Console.WriteLine("└──────────────────────────┘");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(96, 13);
            Console.Write($"★{player.Name}");
            Console.SetCursorPosition(106, Console.CursorTop);
            Console.WriteLine("에 대하여★");
            Console.ResetColor();
        }

        static void PrintStatusBox()
        {
            Console.SetCursorPosition(25, 7);
            Console.WriteLine("◈───────────────────────────────────────────────────◈");

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(25, Console.CursorTop);
                Console.WriteLine("│                                                    │");
            }
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.WriteLine("◈───────────────────────────────────────────────────◈");

        }

        static void StatusContents(Player player)
        {
            Console.SetCursorPosition(36, 6);
            Extension.ColorWriteLine("▣===========================▣", ConsoleColor.Black, ConsoleColor.DarkCyan);
            for (int i = 0;i < 3; i++)
            {
                Console.SetCursorPosition(36, Console.CursorTop);
                Extension.ColorWriteLine("||                           ||", ConsoleColor.Black, ConsoleColor.DarkCyan);
            }
            Console.SetCursorPosition(40, 8);
            Console.Write(player.Name);
            Console.SetCursorPosition(55, Console.CursorTop);
            Console.WriteLine($"({player.Type})");
            Console.SetCursorPosition(36, Console.CursorTop + 1);
            Extension.ColorWriteLine("▣===========================▣", ConsoleColor.Black, ConsoleColor.DarkCyan);


            Console.SetCursorPosition(47, Console.CursorTop + 1);
            Extension.ColorWriteLine($" Lv. {player.Level}");

            Console.SetCursorPosition(33, Console.CursorTop + 4);
            Console.Write(" 체  력 : ");
            if(player.CurrentHealth >= player.CurrentHealth / 2) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor= ConsoleColor.Red; }
            Console.Write(player.CurrentHealth.ToString());
            Console.ResetColor();
            Console.WriteLine($" / {player.MaxHealth}");

            Console.SetCursorPosition(33, Console.CursorTop + 1);
            Console.Write($" 공격력 : {player.AttackPower}");
            if (player.AddAtk != 0) { Extension.ColorWriteLine($"  + {player.AddAtk}", ConsoleColor.Black, ConsoleColor.Green); }
            else { Console.WriteLine(); }

            Console.SetCursorPosition(33, Console.CursorTop + 1);
            Console.Write($" 방어력 : {player.Defense}");
            if (player.AddDef != 0) { Extension.ColorWriteLine($"  + {player.AddDef}", ConsoleColor.Black, ConsoleColor.Green); }
            else { Console.WriteLine(); }

            Console.SetCursorPosition(33, Console.CursorTop + 1);
            Console.Write(" 마  력 : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(player.CurrentMP);
            Console.ResetColor();
            Console.Write($" / {player.MaxMP}");

        }

        static void PrintFloor()
        {
            string floor = new string('_', 150);

            Console.SetCursorPosition(0, 33);
            Console.WriteLine(floor);
            Console.SetCursorPosition(22, 33);
            Console.WriteLine("\\|/");
            Console.SetCursorPosition(38, 33);
            Console.WriteLine("\\|/");
            Console.SetCursorPosition(88, 33);
            Console.WriteLine("\\|/");
        }
    }

}
