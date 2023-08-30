﻿using FindingPotato.Character.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    internal class EndingScene
    {
        static string carrotStr = @"

                                             \ | /
                                             _\|/__                    
                                            /      \
                                         \ |  ⊙ ⊙ | /           
                                          \|    ^   |/
                                            \   V   / 
                                             \     /
                                              \   / 
                                            /  \ / \
                                           /        \ ";



        static string potatoStr = @"

                                         ____
                                       /      \                   
                                    \ |  ⊙ ⊙ | /
                                     \|    ^   |/
                                      \    V   /                 
                                       \______/                                                                       
                                          / \
                                         /   \";

        static string sweetPotato = @"   

     ____                    
   /      \
  |        |
  |   O O  |            
  |    ∆   |
 /|    V   |\
/  \       / \
    \_____/
      / \
     /   \
";


        static string[] potatoRecipe = {"1.감자를 씻어 껍질을 벗겨 준 후, 깍둑썰기로 썰어 믹서기에 넣어줍니다" ,
                                        "2.물을 조금 넣고 갈아준 감자는 채반에 15분정도 두어 전분과 물을 빼줍니다",
                                        "3.빠진 물은 버리고 전분을 섞어 소금, 후추 간을 해줍니다",
                                        "4.후라이팬에 한입크기로 부쳐주면 완성!"};

        static string[] sweetPotatoRecipe = {"1.고구마를 씻어 껍질을 번겨준 후 먹기 좋은 크기로 썰어줍니다",
                                             "2.손질한 고구마를 웍에 넣고 설탕을 세스푼 흩뿌려줍니다",
                                             "3.고구마가 반정도 잠길만큼의 기름을 넣어 센불에 튀겨주세요",
                                             "4.기름이 자글자글 끓기 시작하면 중불로 줄여서 한번씩 뒤적여주며 튀겨줍니다",
                                             "5.고구마의 색이 전체적으로 노랗게 변하고 끄트머리쪽이 갈색으로 변한다면 다시 센불로 올려서 두어번 뒤적여주면 끝" };

        static string[] carrotRecipe = { "1.분량의 계란과 설탕, 식용유를 함께 섞어줍니다",
                                         "2.갈아진 당근과 베이킹파우더를 넣고 잘 섞어줍니다",
                                         "3.나머지 재료를 모두 넣고 잘 섞어주고, 동시에 오븐도 200도로 예열시켜주세요",
                                         "4.케익시트 틀에 기름칠을 해주고,위에 빵가루도 뿌려줍니다",
                                         "5.잘 섞어진 재료를 넣고 오븐에 약 40분 정도 구워주면 완성!!"};




        public static void VictoryScene()
        {
            string str = @"

        ====================

         ■■■■■■■ ■          ■  ■■■■■■■   ■■■■■■■  ■■      ■  ■■■■■
               ■       ■          ■  ■               ■              ■ ■     ■  ■        ■
               ■       ■          ■  ■               ■              ■  ■    ■  ■          ■
               ■       ■■■■■■■  ■■■■■■■   ■■■■■■■  ■   ■   ■  ■          ■
               ■       ■          ■  ■               ■              ■    ■  ■  ■          ■
               ■       ■          ■  ■               ■              ■     ■ ■  ■        ■
               ■       ■          ■  ■■■■■■■   ■■■■■■■  ■      ■■  ■■■■■

                                                                                    ====================

                                           내 친구 감자를 구했다!!
";


            Console.WriteLine(str);
            Console.WriteLine(potatoStr);

            Console.ReadKey(); 
        }

        public static void DeadScene()
        {
            string str = @"
          ====================

           ■     ■  ■■■   ■    ■    ■■■■    ■■■■■  ■■■■■  ■■■■    
            ■   ■  ■    ■  ■    ■    ■      ■      ■      ■          ■      ■            
             ■ ■   ■    ■  ■    ■    ■       ■     ■      ■■■■■  ■       ■             
              ■     ■    ■  ■    ■    ■       ■     ■      ■          ■       ■              
              ■     ■    ■  ■    ■    ■      ■      ■      ■          ■      ■      
              ■      ■■■    ■■■     ■■■■    ■■■■■  ■■■■■  ■■■■              

                                                                      ====================
";
            
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
