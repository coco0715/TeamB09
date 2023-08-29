﻿using FindingPotato.Character.Monster;
using FindingPotato.Character;
using FindingPotato.Item;
using FindingPotato.Stage;
using System;
using System.Security.Cryptography;
using FindingPotato.Inventory;
using System.Dynamic;
using System.ComponentModel.Design;

namespace FindingPotato
{
    internal class Program
    {
        static void Main()
        {
            GameManager GM = new GameManager();
            GM.InitialCharacter();
            GM.GameMain();
        }
    }
}

public class GameManager
{
    private Player player;

    //몬스터 생성
    Banana banana;
    Durian durian;
    Rambutan rambutan;
    Watermelon watermelon;
    Beet beet; 
    Paprika paprika;
    Onion onion;
    Customer customer;


    // 아이템 생성 (효과 수치는 조정 예정)
    static IItem water = new HealthPotion("물", 5, "웅덩이에 고여 있던 물.");
    static IItem nutrient = new HealthPotion("식물 영양제", 5, "오는 길에 훔친 영양제.");
    static IItem firtilizer = new StrengthPotion("비료", 5, "밭에서 챙긴 비료.");
    static IItem pesticide = new StrengthPotion("농약", 5, "각성.");
    static IItem toothpick = new Weapon("이쑤시개", 5, "뾰족하다.");
    static IItem peeler = new Weapon("감자 필러", 5, "날카롭다.");
    static IItem plastic = new Armor("비닐", 5, "얇지만 유용하다.");
    static IItem styrofoam = new Armor("스티로폼", 5, "충격 완화.");

    static List<IItem> Consumable = new List<IItem>() { water, nutrient, firtilizer, pesticide };
    static List<IItem> Equipable = new List<IItem>() {  toothpick, peeler, plastic, styrofoam };
 
    // 인벤토리 생성
    Inventory inventory = new Inventory();

    // 몬스터 리스트
    List<Monster> EasyMonsters = new List<Monster>();
    List<Monster> NormalMonsters = new List<Monster>();
    List<Monster> HardMonsters = new List<Monster>();
    
    StageClass stage1;
    StageClass stage2;
    StageClass stage3;



    public GameManager()
    {
        //몬스터 초기화 
        banana = new Banana("바나나");
        durian = new Durian("두리안");
        rambutan = new Rambutan("람부탄");
        watermelon = new Watermelon("수박");

        beet = new Beet("비트"); 
        paprika = new Paprika("파프리카");
        onion = new Onion("양파");

        customer = new Customer("감자진열대앞손님");

        EasyMonsters = new List<Monster> { banana, durian, rambutan, watermelon }; 
        NormalMonsters = new List<Monster> { beet, paprika, onion };
        HardMonsters = new List<Monster> { customer }; 

        // 각 스테이지의 보상 아이템들
        //stageRewards = new List<IItem> { new HealthPotion(), new StrengthPotion() };
    }

    //몬스터를 랜덤하게 등장하는 스테이지 생성
    List<Monster> CreateRandomStage(List<Monster> monsters, int numberOfMonsters)
    {
        Random random = new Random();

        //사용가능한 몬스터 (중복 방지를 피하기 위해 초기에 몬스터 리스트 복사)
        List<Monster> availableMonsters = new List<Monster>(monsters);

        //선택된 몬스터 
        List<Monster> selectedMonsters = new List<Monster>();

        // 1~numberOfMonsters 사이에서 랜덤한 값 저장
        numberOfMonsters = random.Next(2, numberOfMonsters+1);

        for (int i = 0; i < numberOfMonsters; i++)
        {
            //사용가능한 몬스터가 없을 경우 종료
            if (availableMonsters.Count == 0)
            {
                break;
            }

            //사용가능한 몬스터 리스트에서 랜덤한 인덱스 선택 
            int randomIndex = random.Next(availableMonsters.Count);

            //선택된 몬스터를 선택된 몬스터 리스트에 추가하고 사용가능한 몬스터 리스트에서는 삭제 
            Monster selectedMonster = availableMonsters[randomIndex];
            selectedMonsters.Add(selectedMonster);
            availableMonsters.RemoveAt(randomIndex);
        }
       
        return selectedMonsters;
    }

    // 캐릭터 생성 - 이름, 직업
    public void InitialCharacter()
    {
        // 이름 설정 - string
        Extension.TypeWriting("이름 ?\n");
        Console.Write(">> ");
        string playerName = Console.ReadLine();

        // 직업 설정 - enum(int)
        Extension.TypeWriting("\n정체\n");

        Extension.ColorWriteLine("1. 감자");
        Extension.ColorWriteLine("2. 고구마");
        Extension.ColorWriteLine("3. 당근");

        int playerType = Extension.GetInput(1, 3);
        player = new Player(playerName, (VegetableType)playerType);

    }

    // 메인 화면
    public void GameMain()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Extension.TypeWriting($"어서오세요. {player.Name} 님");
            Extension.TypeWriting("이곳에서 활동을 할 수 있습니다.\n");

            Extension.ColorWriteLine("1. 상태 보기");
            Extension.ColorWriteLine("2. 인벤토리");
            Extension.ColorWriteLine("3. 전투 시작");
            Extension.ColorWriteLine("\n0. 게임 종료");

            int input = Extension.GetInput(0, 3);

            if (input == 1) { ShowStatus(); }
            else if (input == 2) { ShowInventory(); }
            else if(input == 3)
            {
                ShowStageSelection(); 
            }
            else return;
        }
    }
    //스테이지 선택 화면 
    public void ShowStageSelection()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("감자를 구하러 가려면 과일코너에서  채소코너를 지나감자 진열대 까지 가야해 !\n");

            Console.WriteLine("1.과일 코너 (Easy)");

            if (player.CurrentStage >= (int)StageDifficulty.Normal)
                Console.WriteLine("2.야채코너 (Normal)");
            else
                Extension.ColorWriteLine("2.야채코너 (Normal)", ConsoleColor.Black,ConsoleColor.DarkGray);

            if (player.CurrentStage >= (int)StageDifficulty.Hard)
                Console.WriteLine("3.감자 진열대 (Hard)");
            else
                Extension.ColorWriteLine("3.감자 진열대 (Hard)", ConsoleColor.Black, ConsoleColor.DarkGray);

            Console.WriteLine("0.나가기"); 

            int input = Extension.GetInput(0,3);
            
            if(input == 1)
            {
                stage1 = new StageClass(player, CreateRandomStage(EasyMonsters, 3), StageDifficulty.Easy);
                stage1.Start();
                Inventory.PotionEffectReset(player);
                break; 
            }
            else if(input == 2)
            {
                if (player.CurrentStage >= (int)StageDifficulty.Normal)
                {
                    NormalMonsters = CreateRandomStage(NormalMonsters, 3);
                    NormalMonsters.AddRange(CreateRandomStage(EasyMonsters, 2));
                    stage2 = new StageClass(player, NormalMonsters, StageDifficulty.Normal);
                    stage2.Start();
                    Inventory.PotionEffectReset(player);
                    break;
                }
                else
                {
                    Console.WriteLine("아직 채소 코너는 보이지 않는다.");
                    Thread.Sleep(500);
                }
            }
            else if (input == 3)
            {
                if (player.CurrentStage >= (int)StageDifficulty.Hard)
                {
                    stage3 = new StageClass(player, HardMonsters, StageDifficulty.Normal);
                    stage3.Start();
                    Inventory.PotionEffectReset(player);
                }
                else
                {
                    Console.WriteLine("아직 감자 진열대는 보이지 않는다.");
                    Thread.Sleep(500); 
                }
            }
        }
    }

    // 상태 보기
    public void ShowStatus()
    {
        Console.Clear();
        Console.WriteLine($"◇----------◇----------◇----------");
        Console.WriteLine($"| {player.Name}      ({player.Type})");
        Console.WriteLine($"| Lv. {player.Level}");
        Console.WriteLine("|");
        Console.WriteLine($"| 체  력 : {player.CurrentHealth}/{player.MaxHealth}");
        Console.Write($"| 공격력 : {player.AttackPower}");
        if(player.AddAtk != 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  + {player.AddAtk}");
            Console.ResetColor();
        }
        else { Console.WriteLine(); }
        Console.Write($"| 방어력 : {player.Defense}");
        if(player.AddDef != 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  + {player.AddDef}");
            Console.ResetColor();
        }
        else { Console.WriteLine(); }
        Console.WriteLine($"| 마  력 : {player.CurrentMP}/{player.MaxMP}");
        Console.WriteLine($"◇----------◇----------◇----------");

        Extension.ColorWriteLine("\n0. 나가기");

        _ = Extension.GetInput(0, 0);
    }

    public void ShowInventory()
    {
        while( true)
        {
            Console.Clear();

            inventory.PrintTitle(false);
            inventory.PrintItemList(false);
            inventory.ShowOptions();

            int input = Extension.GetInput(0, 1);

            if (input == 0) break;
            else { ItemManagement(); }
        }
    }

    public void ItemManagement()
    {
        while (true)
        {
            Console.Clear();

            inventory.PrintTitle(true);
            inventory.PrintItemList(true);
            inventory.ShowOptions(inventory.InventoryItems);

            int input = Extension.GetInput(0, inventory.InventoryItems.Count);

            if (input == 0) { break; }
            else
            {
                inventory.ApplyingItem(inventory.InventoryItems[input - 1], player);
                ItemManagement();
                return;
            }
        }
    }
}