﻿using FindingPotato.Character.Monster;
using FindingPotato.Character;
using FindingPotato.Item;
using FindingPotato.Stage;
using System;
using System.Security.Cryptography;

namespace FindingPotato
{
    internal class Program
    {
        static void Main()
        {
            //Player player = new Player("Player"); // 플레이어 생성

            //Paprika paprika = new Paprika("파프리카"); 
            //Onion onion = new Onion("양파"); 
            //Banana banana = new Banana("바나나");

            //List<ICharacter> monsters = new List<ICharacter>();
            //monsters.Add(onion);
            //monsters.Add(paprika);
            //monsters.Add(banana);

            ////리스트 섞기 
            //ShuffleList(monsters);

            ////스테이지 입장할 몬스터 리스트
            //List<ICharacter> RandomMonster = new List<ICharacter>();

            ////스테이지 입장할 몬스터 리스트에 기존 몬스터 3마리 추가 
            //for (int i = 0; i<3; i++)
            //{
            //    RandomMonster.Add(monsters[i]); 
            //}

            //// 각 스테이지의 보상 아이템들
            //List<IItem> stage1Rewards = new List<IItem> { new HealthPotion(), new StrengthPotion() };
            //List<IItem> stage2Rewards = new List<IItem> { new StrengthPotion(), new HealthPotion() };

            //// 스테이지 1
            //StageClass stage1 = new StageClass(player, monsters, stage1Rewards);

            //stage1.Start();

            GameManager GM = new GameManager();
            GM.InitialCharacter();
            GM.GameMain();
        }

       
    }
}

public class GameManager
{
    private Player player;

    Paprika paprika;
    Onion onion;
    Banana banana;

    List<IItem> stageRewards;

    //전체 몬스터 리스트
    List<ICharacter> monsters = new List<ICharacter>();

    //스테이지 입장할 몬스터 리스트
    List<ICharacter> RandomMonster = new List<ICharacter>();

    StageClass stage;

    public GameManager()
    {
        paprika = new Paprika("파프리카");
        onion = new Onion("양파");
        banana = new Banana("바나나");

        monsters.Add(onion);
        monsters.Add(paprika);
        monsters.Add(banana);

        // 각 스테이지의 보상 아이템들
        stageRewards = new List<IItem> { new HealthPotion(), new StrengthPotion() };

        // 스테이지
      
    }

    static void ShuffleList(List<ICharacter> list)
    {
        Random random = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }

    // 한 글자씩 타이핑
    private void TypeWriting(string _str)
    {
        for (int i = 0; i < _str.Length; i++)
        {
            Console.Write(_str[i]);
            Thread.Sleep(1);
        }
        Console.WriteLine();
    }

    // 색상 다르게 문자열 출력 (기본값 배경:black, 문자열:yellow)
    private void ColorWriteLine(string _str, ConsoleColor _back = ConsoleColor.Black, ConsoleColor _front = ConsoleColor.Yellow)
    {
        Console.BackgroundColor = _back;
        Console.ForegroundColor = _front;
        Console.WriteLine(_str);
        Console.ResetColor();
    }

    // 사용자 입력 받기 (min <= input <= max 값만 받도록)
    private int GetInput(int _min, int _max)
    {
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">> ");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (_min <= input && input <= _max)
                    return input;
            }

            Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요.");
            Console.Write(">> ");
        }
    }

    // 캐릭터 생성 - 이름, 직업
    public void InitialCharacter()
    {
        // 이름 설정 - string
        TypeWriting("원하시는 이름을 설정해주세요.\n");
        Console.Write(">> ");
        player = new Player(Console.ReadLine());

        // 직업 설정 - enum(int)
    }

    // 메인 화면
    public void GameMain()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            TypeWriting($"어서오세요. {player.Name} 님");
            TypeWriting("이곳에서 활동을 할 수 있습니다.\n");

            ColorWriteLine("1. 상태 보기");
            ColorWriteLine("2. 인벤토리");
            ColorWriteLine("3. 전투 시작");
            ColorWriteLine("\n0. 게임 종료");

            int input = GetInput(0, 3);

            if (input == 1) { ShowStatus(); }
            else if (input == 2) { /* 인벤토리 */ }
            else if(input == 3)
            {
                ShuffleList(monsters);
                //스테이지 입장할 몬스터리스트에 기존 몬스터 3마리 추가 
                for (int i = 0; i < 3; i++)
                {
                    RandomMonster.Add(monsters[i]);
                }
                stage = new StageClass(player, RandomMonster, stageRewards);
                stage.Start(); 
            }
            else return;
        }
    }

    // 상태 보기
    public void ShowStatus()
    {
        Console.Clear();
        Console.WriteLine($"◇----------◇----------◇----------");
        Console.WriteLine($"| {player.Name}");
        Console.WriteLine("|");
        Console.WriteLine($"| 체  력 : {player.Health}");
        Console.WriteLine($"| 공격력 : {player.Attack}");
        Console.WriteLine($"◇----------◇----------◇----------");

        ColorWriteLine("\n0. 나가기");

        _ = GetInput(0, 0);
    }
}