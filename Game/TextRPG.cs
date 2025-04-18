using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Game
{
    internal class TextRPG
    {
        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            GameLogic.ChoiceName();
            GameLogic.ChoiceJob();
            GameLogic.StartMenu();

        }
    }

    public class GameLogic
    {
        static PlayerData? playerData;
        static ShopItem shopItem = new ShopItem(); // 전역 변수로 선언하여 상태 유지

        public static void ChoiceName()
        {

            Console.WriteLine("원하시는 이름을 설정해주세요");

            while (true)
            {

                string? playerName = Console.ReadLine();

                if (string.IsNullOrEmpty(playerName)) //비어있다면 
                {
                    Console.WriteLine("잘못된 이름입니다.");
                    Console.WriteLine("이름을 다시 입력해주세요");
                    Thread.Sleep(500);  // 500 밀리초, 즉 0.5초 동안 대기

                }
                else
                {
                    playerData = new PlayerData(playerName);//객체 생성
                    break;
                }

            }
            Console.WriteLine("작성하신 이름으로 시작하시겠습니까?");
            Console.Write("1. 네 | 2. 아니오\n>> ");
            while (true)
            {
                int InputHandler = int.Parse(Console.ReadLine());
                if (InputHandler == 1)
                {
                    Console.WriteLine("{0}님 환영합니다", playerData.Name);
                    break;
                }
                else if (InputHandler == 2)
                {
                    Console.WriteLine("이름을 다시 입력해주세요");
                    ChoiceName();

                }
                else
                {
                    Console.WriteLine("올바른 번호를 선택해주세요.");
                }
                break;
            }
        }
        public static void ChoiceJob()
        {
            Thread.Sleep(1000);
            Console.Clear();//기존에 있던 텍스트를 지운다.
            Console.WriteLine("직업을 선택해주세요 [ 1. 전사 | 2. 법사 | 3. 궁수 ]");
            while (true)
            {
                int InputJob = int.Parse(Console.ReadLine());
                if (InputJob > 0 && InputJob < 4)
                {

                    playerData = new PlayerData(playerData.Name, InputJob); // playerData.Name를 포함 시켜야 저장된 이름을 추가로 저장한다. playerJob값에 따라 직업 설정
                    switch (playerData.Job)
                    {
                        case JobType.warrior:
                            //Console.WriteLine("전사를 선택했습니다.");
                            break;
                        case JobType.wizzard:
                            //Console.WriteLine("마법사를 선택했습니다.");
                            break;
                        case JobType.archor:
                            //Console.WriteLine("궁수를 선택했습니다.");
                            break;

                    }

                    Console.WriteLine("{0} 시작하시겠습니까?", playerData.Job);
                    Console.Write("1. 네 | 2. 아니오\n>> ");
                    while (true)
                    {
                        int InputHandler = int.Parse(Console.ReadLine());
                        if (InputHandler == 1)
                        {
                            Console.WriteLine("{0}를 선택했습니다.", playerData.Job);
                            Thread.Sleep(1000);
                            StartMenu();
                        }
                        else if (InputHandler == 2)
                        {
                            Console.WriteLine("직업을 다시 선택해주세요.");
                            ChoiceJob();
                        }
                        else
                        {
                            Console.WriteLine("올바른 번호를 선택해주세요.");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("올바른 직업 번호를 선택해주세요.");

                }
            }
        }
        public static void StartMenu()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            while (true)
            {

                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                try
                {

                    int InputHandler = int.Parse(Console.ReadLine());


                    if (InputHandler == 1)
                    {
                        CharacterStatus();
                    }
                    else if (InputHandler == 2)
                    {
                        CharacterInventory();
                    }
                    else if (InputHandler == 3)
                    {
                        SpartaShop();
                    }
                    else
                    {
                        Console.WriteLine("올바른 번호를 입력해주세요");
                    }
                }
                catch (FormatException) //예외 발생
                {
                    //Console.Clear();//기존에 있던 텍스트를 지운다.
                    Console.WriteLine("올바른 번호를 입력해주세요");
                }

            }
        }
        public static void CharacterStatus()
        {
            Thread.Sleep(1000);// 로딩 시간처럼 구현
            Console.Clear();
            Console.WriteLine("==캐릭터 정보==\n");
            Console.WriteLine("Lv.{0}", playerData.Level);
            Console.Write(playerData.Name);
            Console.WriteLine(" ({0})", playerData.Job);
            Console.WriteLine("공격력: {0}", playerData.Str);
            Console.WriteLine("방어력: {0}", playerData.Def);
            Console.WriteLine("체력: {0}", playerData.Hp);
            Console.WriteLine("골드: {0}\n", playerData.Gold);
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            while (true)
            {
                int InputHandler = int.Parse(Console.ReadLine());// 같은 이름을 사용하더라도 서로 다른 메서드에 선언된 별개의 지역 변수이기 때문에 충돌하지 않는다.
                if (InputHandler == 0)
                {
                    StartMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("올바른 번호를 입력해주세요\n");

                }
            }
        }
        public static void CharacterInventory()
        {
            Thread.Sleep(500);// 로딩 시간처럼 구현
            Console.Clear();
            Console.WriteLine("[아이템 목록]\n");
            if (playerData.Inventory.Count == 0)
            {
                Console.WriteLine("보유한 아이템이 없습니다.\n");
            }
            else
            {
                foreach (var item in playerData.Inventory)
                {
                    Console.WriteLine($"{item.ItemName} - {item.ToolTip}");
                }
            }
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            while (true)
            {
                int InputHandler = int.Parse(Console.ReadLine());// 같은 이름을 사용하더라도 서로 다른 메서드에 선언된 별개의 지역 변수이기 때문에 충돌하지 않는다.
                if (InputHandler == 0)
                {
                    StartMenu();
                    break;
                }
                else if (InputHandler == 1)
                {
                    //장착
                    break;
                }
                else
                {
                    Console.WriteLine("올바른 번호를 입력해주세요\n");
                }
            }
        }
        public static void SpartaShop()
        {
            Thread.Sleep(1000); // 로딩 시간처럼 구현
            Console.Clear();
            Console.WriteLine("[보유 골드]\n{0} G\n", playerData.Gold);
            Console.WriteLine("[아이템 목록]\n");

            // 아이템 목록 출력
            for (int i = 0; i < shopItem.Items.Count; i++)
            {
                string priceOrPurchased = shopItem.Items[i].PurchaseItem ? " - 구매 완료" : $"{shopItem.Items[i].Price}G";
                Console.WriteLine($"{i + 1}. {shopItem.Items[i].ItemName} | {shopItem.Items[i].ToolTip} {priceOrPurchased}");
            }

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            while (true)
            {
                int InputHandler = int.Parse(Console.ReadLine());
                if (InputHandler == 0)
                {
                    StartMenu(); // 메뉴로 돌아가기
                    break;
                }
                else if (InputHandler == 1)
                {
                    BuyItem(); // 아이템 구매
                }
                else
                {
                    Console.WriteLine("올바른 번호를 입력해주세요\n");
                }
            }
        }

        public static void BuyItem()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n아이템을 구매하시겠습니까?\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine("{0}G\n", playerData.Gold);

                Console.WriteLine("[ 아이템 목록 ]");
                for (int i = 0; i < shopItem.Items.Count; i++) // 아이템 목록 출력
                {
                    string priceOrPurchased = shopItem.Items[i].PurchaseItem ? " - 구매 완료" : $"{shopItem.Items[i].Price}G";
                    Console.WriteLine($"{i + 1}. {shopItem.Items[i].ItemName} | {shopItem.Items[i].ToolTip} {priceOrPurchased}");
                }

                Console.WriteLine("\n구매하실 아이템의 번호를 입력하세요. \n 0. 구매 취소");

                if (int.TryParse(Console.ReadLine(), out int itemInput) && itemInput > 0 && itemInput <= shopItem.Items.Count)
                {
                    Item selectedItem = shopItem.Items[itemInput - 1]; // 선택된 아이템

                    if (selectedItem.PurchaseItem)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (playerData.Gold >= selectedItem.Price) // 골드가 충분한지 확인
                    {
                        playerData.Gold -= selectedItem.Price; // 아이템 가격만큼 골드 차감
                        selectedItem.PurchaseItem = true; // 아이템 구매 상태를 true로 갱신
                        playerData.Inventory.Add(selectedItem); // 인벤토리에 아이템 추가
                        Console.WriteLine($"{selectedItem.ItemName} 구매를 완료했습니다.\n");

                        Thread.Sleep(1000); // 1초 대기
                        SpartaShop(); // 상점으로 돌아가기
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.\n");
                    }
                }
                else if (itemInput == 0) // 0을 입력하면 구매 취소
                {
                    SpartaShop(); // 상점으로 돌아가기
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }


}


   


    
