
////class program
////{
////  
////        var gamelogic = new gamelogic();
////        gamelogic.startgame();
////    
////}

////class gamelogic
////{
////    private player _player;
////    private bool _isgameover = false;

////    public void startgame()
////    {
////        init();

////        while (!_isgameover)
////        {
////            inputhandler();
        //}

////        console.writeline("게임이 종료되었습니다.");
////    }

////    private void inputhandler()
////    {
////        var input = console.readkey();
////        if (input.key == consolekey.escape)
////        {
////            _isgameover = true;
////        }
////    }

////    private void init()
////    {
////        console.clear();
////        console.writeline("스파르타 던전에 오신것을 환영합니다.\n이름을 입력하세요.");
////        string? playername = console.readline();

////        if (string.isnullorempty(playername))
////        {
////            console.writeline("잘못된 이름입니다.");
////            thread.sleep(1000);
////            init(); // 실제로 이렇 사용하시면 않됨, 재귀호출
////        }
////        else
////        {
////            _player = new player(playername);
////            console.writeline($"{_player.name}님, 입장하셨습니다.");
////        }

////        // 직업선택
////        console.writeline("직업을 선택하세요. [1:전사 | 2:법사 | 3:궁수]");
////        int job = int.parse(console.readline());

////        if (job >= 1 && job <= 3)  // if (job is >=1 and <=3) 패턴매칭 c# 9.0 ?
////        {
////            _player.job = (job)job;

////            switch (_player.job)
////            {
////                case job.warrior:
////                    console.writeline($"{_player.job}를 선택했습니다.");
////                    break;
////                case job.wizzard:
////                    console.writeline($"{_player.job}를 선택했습니다.");
////                    break;
////                case job.archor:
////                    console.writeline($"{_player.job}를 선택했습니다.");
////                    break;
////            }
////        }
////    }
////}

////class player
////{
////    public string name;
////    public job job;

////    public player(string name)
////    {
////        this.name = name;
////    }
////}

////public enum job
////{
////    warrior = 1,
////    wizzard,
////    archor
////}