using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game
{
    internal class PlayerData : Player
    {

        public string Name { get; set; }
        public JobType Job { get; set; }  // JobType으로 직업을 저장
        public int Level { get; set; }
        public double Str { get; set; }
        public double Def { get; set; }
        public double Hp { get; set; }
        public int Gold { get; set; }
        public List<Item> Inventory { get; set; }  // 플레이어가 가진 아이템 목록
        public bool EquipItem { get; set; }
        public bool UnEquipItem { get; set; }
        private void InitStats() //초기화
        {
            Level = 1;
            Str = 10;
            Def = 5;
            Hp = 100;
            Gold = 1000;
            Inventory = new List<Item>();
 
        }
        public PlayerData(string playerName) // playerJob을 받기 전으로 string playerName만 존재하여 저장
        {
            Name = playerName;
            InitStats();
        }
        public PlayerData(string playerName, int InputJob) // playerName을 저장하고 나서 playerJob을 추가로 저장하기 때문에 2개를 저장하고 있어야한다.
        {
            Name = playerName;
            Job = (JobType)InputJob;
            InitStats();
       




        }

    }
    internal class Item  // 아이템 클래스
    {
        // 아이템 프로퍼티
        public string ItemName { get; set; }  // 아이템 이름
        public string ToolTip { get; set; }   // 아이템 설명
        public int Attack { get; set; }   // 공격력
        public int Defense { get; set; }  // 방어력
        public int Price { get; set; }    // 아이템 가격
        public bool PurchaseItem { get; set; } // 구매 여부 
        public bool EquippedItem { get; set; } // 장착 여부

        public Item(string itemName, string toolTip, int attack, int defense, int price)
        {
            ItemName = itemName;
            ToolTip = toolTip; // 아이템 설명
            Attack = attack;
            Defense = defense;
            Price = price;
            PurchaseItem = false;
            EquippedItem = false;
        }
    }
    internal class ShopItem
    {
        public static ShopItem StoreItem = new ShopItem(); // GameStore 초기화,
        public List<Item> Items { get; set; } // 상점 아이템 목록
        public ShopItem()
        {
            Items = new List<Item> // Item 목록 초기화
        {
                //아이템을 생성
                new Item(" 수련갑옷 ", "방어력 +5, 수련에 도움을 주는 갑옷입니다.", 0 , 5, 1000), // 공격력, 방어력, 가격
                new Item(" 엄청난 갑옷 ", "방어력 +9, 엄청나게 좋아보이는 갑옷입니다.", 0, 9, 1500),
                new Item(" 스파르타 갑옷 ", "방어력 +12, 스파르타 전사들이 하루에 12시간씩 수련에 사용했다는 노력이 느껴지는 갑옷입니다.", 0, 15, 3000),
                new Item(" 낡은 검 ", "공격력 +2, 어디에서도 볼 수 있는 낡은 검입니다.", 2, 0, 600),
                new Item(" 대파", "공격력 +6, 먹는 대파입니다.", 5, 0, 1200),
                new Item(" 스파르타 검", "공격력 +12, 스파르타 전사들이 하루에 12시간씩 수련에 사용했다는 노력이 느껴지는 검입니다.", 12, 0, 2400)
        };

        }
       
     
}
    }

    public class Player
    {
        private enum PlayerInfo
        {
            Level,
            Job,
            Name,
            Strength,
            Defense,
            Hp,
            Gold
        }
    }

    public enum JobType
    {
        warrior = 1,
        wizzard,//2
        archor //3
    }

   //


