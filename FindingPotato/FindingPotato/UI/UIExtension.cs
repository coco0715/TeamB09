﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FindingPotato.UI
{
    internal class UIExtension
    {
        // x : UI를 출력할 x 좌표
        // y : UI를 출력할 y 좌표
        // interval : 출력 간격 (1줄에 하나 출력이면 1, 메뉴 창처럼 위아래 padding, margin 줄거면 4)
        // selectStrList : 출력할 string 리스트 (맨 끝에는 "0번 나가기" 넣어야 함)
        // isPossibleToExit : 0번으로 나가기/취소 가능하다면 true, 아니라면 false
        public static int GetPlayerSelectFromUI(int x, int y, int interval, string[] selectStrList, bool isPossibleToExit)
        {
            bool isSelected = false;
            int playerSelect = 1;
            int selectedItemIdx = 1;

            int listLength = (isPossibleToExit) ? selectStrList.Length : selectStrList.Length - 1;

            int minLine = y;
            //int maxLine = y + interval * listLength - 1;

            while (!isSelected)
            {
                y = minLine;
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedItemIdx--;
                            selectedItemIdx = Math.Max(selectedItemIdx, 0);
                            break;
                        case ConsoleKey.DownArrow:
                            selectedItemIdx++;
                            selectedItemIdx = Math.Min(selectedItemIdx, listLength);
                            break;
                        case ConsoleKey.Enter:
                            for (int i = 0; i < listLength; i++)
                            {
                                if (i == (selectedItemIdx - 1))
                                {
                                    playerSelect = selectedItemIdx;
                                    break;
                                }
                            }
                            isSelected = true;
                            break;
                        default:
                            int pivotKeyInt = (int)ConsoleKey.NumPad0;
                            int curKeyInt = (int)key;
                            if (curKeyInt == pivotKeyInt && isPossibleToExit) selectedItemIdx = listLength;
                            else if ((curKeyInt > pivotKeyInt) && curKeyInt - pivotKeyInt <= listLength)
                            {
                                selectedItemIdx = curKeyInt - pivotKeyInt;
                            }
                            break;
                    }
                }

                // 위아래 padding에 넣을 공백 길이 계산
                string emptyStr = "";
                for (int i = 0; i < selectStrList[0].Length; i++)
                {
                    if (selectStrList[0][i] >= '\uAC00' && selectStrList[0][i] <= '\uD7AF') emptyStr += "  ";
                    else emptyStr += " ";
                }

                for (int i = 0; i < listLength; i++)
                {
                    if (i == (selectedItemIdx - 1)) Extension.SetSelectedBackground(true);
                    else Extension.SetSelectedBackground(false);

                    if (interval == 4)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(emptyStr);
                    }
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine(selectStrList[i]);
                    if (interval == 4)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(emptyStr);
                    }
                    if (interval == 4) y++;
                }
            }
            Console.ResetColor();
            Console.CursorVisible = true;

            if (isPossibleToExit && playerSelect == listLength) playerSelect = 0;
            return playerSelect;
        }
    }
}
