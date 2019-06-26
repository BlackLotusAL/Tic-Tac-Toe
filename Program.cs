using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Menu menu = new Menu();
            board.InitBoard();


            for (; ; )
            {
                //主界面，输入1进入选棋子界面，输入0退出
                if (menu.MenuStatus == 0)
                {
                    int temp_1;
                    menu.DisplayMainMenu();
                    string str_temp_1 = Console.ReadLine();
                    temp_1 = Convert.ToInt32(str_temp_1);
                    if (temp_1 == 1)
                    {
                        board.InitBoard();
                        menu.SetMenuStatus(1);
                    }
                    else if (temp_1 == 0)
                    {
                        return;
                    }
                }
                //选择棋子，输入1选择〇棋子，输入2选择×棋子
                else if (menu.MenuStatus == 1)
                {
                    int temp_2;
                    menu.DisplayChoosePieceMenu();
                    string str_temp_2 = Console.ReadLine();
                    temp_2 = Convert.ToInt32(str_temp_2);
                    if (temp_2 == 1)
                    {
                        board.SetPlayer(1);
                    }
                    else if (temp_2 == 2)
                    {
                        board.SetPlayer(2);

                    }
                    menu.MenuStatus = 2;
                    Console.Clear();
                }
                //输入棋子横坐标
                else if (menu.MenuStatus == 2)
                {
                    board.DisplayBoard();
                    if (board.GetPlayer() == 1)
                    {
                        menu.DisplayTipsCurrentPlayerOneMenu();
                    }
                    else if (board.GetPlayer() == 2)
                    {
                        menu.DisplayTipsCurrentPlayerTwoMenu();
                    }
                    menu.DisplayChooseAbscissaMenu();
                    menu.DisplayTipsForReturnMenu();
                    menu.DisplayTipsForExitMenu();
                    string str_temp_3 = Console.ReadLine();
                    int temp_3 = Convert.ToInt32(str_temp_3);


                    //判断输入数值
                    if (temp_3 == 88)
                    {
                        board.InitBoard();
                        menu.SetMenuStatus(0);
                    }
                    else if (temp_3 == 99)
                    {
                        return;
                    }
                    else
                    {
                        board.PieceAbscissa = temp_3;
                        board.OutPut = 0;
                        board.HavePut = 0;
                        board.IsOutPut();
                        //越界后重新输入
                        if (board.OutPut == 1)
                        {
                            Console.Clear();
                            board.DisplayBoard();
                            menu.DisplayErrorOutPutMenu();
                            Console.ReadLine();
                        }
                        else
                        {
                            menu.MenuStatus = 3;
                        }
                    }
                    
                }
                //输入棋子纵坐标
                else if (menu.MenuStatus == 3)
                {
                    board.DisplayBoard();
                    if (board.Player_Win == 0)
                    {
                        //输入纵坐标界面
                        if (board.GetPlayer() == 1)
                        {
                            menu.DisplayTipsCurrentPlayerOneMenu();
                        }
                        else if (board.GetPlayer() == 2)
                        {
                            menu.DisplayTipsCurrentPlayerTwoMenu();
                        }
                        menu.DisplayChooseOrdinatesMenu();
                        menu.DisplayTipsForReturnMenu();
                        menu.DisplayTipsForExitMenu();
                        string str_temp_4 = Console.ReadLine();
                        int temp_4 = Convert.ToInt32(str_temp_4);

                        //判断输入数值
                        if (temp_4 == 88)
                        {
                            board.InitBoard();
                            menu.SetMenuStatus(0);
                        }
                        else if (temp_4 == 99)
                        {
                            return;
                        }
                        else
                        {
                            board.PieceOrdinates = temp_4;
                            board.OutPut = 0;
                            board.HavePut = 0;
                            board.IsOutPut();
                            if (board.OutPut == 0) board.IsHavePut();
                            if (board.OutPut == 1)
                            {
                                Console.Clear();
                                board.DisplayBoard();
                                menu.DisplayErrorOutPutMenu();
                                Console.ReadLine();

                            }
                            //输入坐标已放置棋子，跳转回输入横坐标界面
                            else if (board.HavePut == 1)
                            {
                                Console.Clear();
                                board.DisplayBoard();
                                menu.DisplayErrorHavePutMenu();
                                menu.MenuStatus = 2;
                                Console.ReadLine();
                            }
                            else
                            {
                                board.SetPiece();
                                board.DisplayBoard();
                                board.IsAnyoneWin();
                                if (board.Player_Win == 0)
                                {
                                    menu.MenuStatus = 2;
                                }
                            }
                        }
                        
                    }
                    //执〇棋子玩家胜利后的界面
                    else if (board.Player_Win == 1)
                    {
                        Console.Clear();
                        board.DisplayBoard();
                        menu.DisplayPlayerOneWinMenu();
                        menu.DisplayTipsForReturnMenu();
                        menu.DisplayTipsForExitMenu();
                        string str_temp_4 = Console.ReadLine();
                        int temp_4 = Convert.ToInt32(str_temp_4);
                        if (temp_4 == 88)
                        {
                            board.InitBoard();
                            menu.SetMenuStatus(0);
                        }
                        else if (temp_4 == 99)
                        {
                            return;
                        }
                    }
                    //执×棋子玩家胜利后的界面
                    else if (board.Player_Win == 2)
                    {
                        Console.Clear();
                        board.DisplayBoard();
                        menu.DisplayPlayerTwoWinMenu();
                        menu.DisplayTipsForReturnMenu();
                        menu.DisplayTipsForExitMenu();
                        string str_temp_4 = Console.ReadLine();
                        int temp_4 = Convert.ToInt32(str_temp_4);
                        if (temp_4 == 88)
                        {
                            board.InitBoard();
                            menu.SetMenuStatus(0);
                        }
                        else if (temp_4 == 99)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
    class Board
    {
        public int Player = 1;          //当前下棋的玩家
        public int Player_Win = 0;      //胜利标志位
        public int OutPut = 0;          //越界标志位
        public int HavePut = 0;         //已放置标志位
        public int PieceAbscissa = 0;   //棋子横坐标
        public int PieceOrdinates = 0;  //棋子纵坐标


        public static int BoardRow = 8;
        public static int BoardColumn = 14;

        public int[,] Chessboard = new int[8, 14];
        public int[,] InitChessboard = new int[8, 14]
        {
            { 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0},
            { 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0},
            { 7, 4, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 4},
            { 0, 0, 3, 3, 3, 4, 3, 3, 3, 4, 3, 3, 3, 0},
            { 8, 4, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 4},
            { 0, 0, 3, 3, 3, 4, 3, 3, 3, 4, 3, 3, 3, 0},
            { 9, 4, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 4},
            { 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0},
        };
        public int[,] PiecesBoard = new int[3, 3];

        //初始化棋盘
        public void InitBoard()
        {
            for (int i = 0; i < BoardRow; i++)
            {
                for (int j = 0; j < BoardColumn; j++)
                {
                    Chessboard[i, j] = InitChessboard[i, j];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PiecesBoard[i, j] = 0;
                }
            }
            //初始化标志位
            Player_Win = 0;
            OutPut = 0;
            HavePut = 0;
        }

        //打印棋盘
        public void DisplayBoard()
        {
            Console.Clear();
            for (int i = 0; i < BoardRow; i++)
            {
                for(int j = 0; j < BoardColumn; j++)
                {
                    //' ' - 0
                    //'O' - 1
                    //'X' - 2
                    //'-' - 3
                    //'|' - 4
                    //'0' - 7
                    //'1' - 8
                    //'2' - 9
                    switch (Chessboard[i, j])
                    {
                        case 0:
                            Console.Write(" ");
                            break;
                        case 1:
                            Console.Write("O");
                            break;
                        case 2:
                            Console.Write("X");
                            break;
                        case 3:
                            Console.Write("-");
                            break;
                        case 4:
                            Console.Write("|");
                            break;
                        case 7:
                            Console.Write("0");
                            break;
                        case 8:
                            Console.Write("1");
                            break;
                        case 9:
                            Console.Write("2");
                            break;
                    }
                }
                Console.Write("\n");
            }
        }

        //3×3棋子坐标图
        public void DisplayPiecesBoard()
        {
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}", PiecesBoard[i, j]);
                }
                Console.Write("\n");
            }
        }

        //判断获胜条件
        public void IsAnyoneWin()
        {
            //横向
            for(int i = 0; i < 3; i++)
            {
                if (PiecesBoard[i, 0] == 1 && PiecesBoard[i, 1] == 1 && PiecesBoard[i, 2] == 1) Player_Win = 1;
                if (PiecesBoard[i, 0] == 2 && PiecesBoard[i, 1] == 2 && PiecesBoard[i, 2] == 2) Player_Win = 2;
            }

            //纵向
            for (int i = 0; i < 3; i++)
            {
                if (PiecesBoard[0, i] == 1 && PiecesBoard[1, i] == 1 && PiecesBoard[2, i] == 1) Player_Win = 1;
                if (PiecesBoard[0, i] == 1 && PiecesBoard[1, i] == 1 && PiecesBoard[2, i] == 2) Player_Win = 2;
            }

            if (PiecesBoard[0, 0] == 1 && PiecesBoard[1, 1] == 1 && PiecesBoard[2, 2] == 1) Player_Win = 1;
            if (PiecesBoard[0, 0] == 2 && PiecesBoard[1, 1] == 2 && PiecesBoard[2, 2] == 2) Player_Win = 2;
            if (PiecesBoard[0, 2] == 1 && PiecesBoard[1, 1] == 1 && PiecesBoard[2, 0] == 1) Player_Win = 1;
            if (PiecesBoard[0, 2] == 2 && PiecesBoard[1, 1] == 2 && PiecesBoard[2, 0] == 2) Player_Win = 2;

        }

        //判断输入坐标是否越界
        public void IsOutPut()
        {
            if (PieceAbscissa < 0 || PieceAbscissa > 2 || PieceOrdinates < 0 || PieceOrdinates > 2) OutPut = 1;
        }

        //判断输入坐标是否已放置
        public void IsHavePut()
        {
            if (PiecesBoard[PieceOrdinates, PieceAbscissa] != 0) HavePut = 1;
        }

        public void SetAbscissa(int Abscissa)
        {
            PieceAbscissa = Abscissa;
        }

        public void SetOrdinates(int Ordinates)
        {
            PieceOrdinates = Ordinates;
        }

        public void SetPiece()
        {
            int i = 0, j = 0;
            switch (PieceOrdinates)
            {
                case 0:
                    i = 2;
                    break;
                case 1:
                    i = 4;
                    break;
                case 2:
                    i = 6;
                    break;
            }
            switch (PieceAbscissa)
            {
                case 0:
                    j = 3;
                    break;
                case 1:
                    j = 7;
                    break;
                case 2:
                    j = 11;
                    break;
            }
            if (Player == 1)
            {
                Chessboard[i, j] = 1;
            }
            else if(Player == 2)
            {
                Chessboard[i, j] = 2;
            }
            Console.Clear();
            DisplayBoard();

            if(Player == 1)
            {
                PiecesBoard[PieceOrdinates, PieceAbscissa] = 1;
                Player = 2;  
            }
            else if (Player == 2)
            {
                PiecesBoard[PieceOrdinates, PieceAbscissa] = 2;
                Player = 1;
            }
        }

        public void SetPlayer(int player)
        {
            Player = player;
        }

        public int GetPlayer()
        {
            return Player;
        }
    }

    class Menu
    {
        public int MenuStatus = 0;


        public void SetMenuStatus(int Status)
        {
            MenuStatus = Status;
        }

        public int GetMenuStatus()
        {
           return MenuStatus;
        }

        //主界面菜单
        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("****************************************");
            Console.WriteLine("********** 欢迎进入三子棋游戏 **********");
            Console.WriteLine("********** 1.Play      0.Exit **********");
            Console.WriteLine("****************************************");

        }
        //选择棋子菜单
        public void DisplayChoosePieceMenu()
        {
            Console.Clear();
            Console.WriteLine("****************************************");
            Console.WriteLine("**********  请选择执哪种棋子  **********");
            Console.WriteLine("**********  1.〇        2.×  **********");
            Console.WriteLine("****************************************");
        }

        public void DisplayTipsCurrentPlayerOneMenu()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("**********   请执〇玩家落子   **********");
        }

        public void DisplayTipsCurrentPlayerTwoMenu()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("**********   请执×玩家落子   **********");
        }

        public void DisplayChooseAbscissaMenu()
        {
            Console.WriteLine("**********  请选择落子横坐标  **********");
            Console.WriteLine("****************************************");
        }

        public void DisplayChooseOrdinatesMenu()
        {

            Console.WriteLine("**********  请选择落子纵坐标  **********");
            Console.WriteLine("****************************************");
        }
        public void DisplayTipsForExitMenu()
        {
            Console.WriteLine("**********   退出游戏输入99   **********");
            Console.WriteLine("****************************************");
        }

        public void DisplayTipsForReturnMenu()
        {
            Console.WriteLine("**********   回主菜单输入88   **********");
        }

        public void DisplayPlayerOneWinMenu()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("**********  恭喜执〇玩家获胜  **********");
        }
        public void DisplayPlayerTwoWinMenu()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("**********  恭喜执×玩家获胜  **********");
        }

        public void DisplayErrorOutPutMenu()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("**********输入坐标越界回车重试**********");
            Console.WriteLine("****************************************");
        }
        public void DisplayErrorHavePutMenu()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("**********该坐标已放置回车重试**********");
            Console.WriteLine("****************************************");
        }
    }
}
