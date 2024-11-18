#include <iostream>
#include <cstdlib>
#include <ctime>
#include <vector>
#include <limits>
#include <string>

using namespace std;

// classes
class TicTacToe
{
    char **board = {};
    // Field size
    const int SIZE = 3;
    const char Xchar = 'X';
    const char Ochar = 'O';
    const char EMPTY = ' ';

    std::string player1 = "";
    std::string player2 = "";
    int carrentPlayer = 1;
    std::vector<int> listChooses = {};
    std::vector<std::vector<int>> minimax = {};

    // Draw template of the board
    void PrintTemplate()
    {
        int count = 1;

        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (j != SIZE - 1)
                {
                    cout << count++ << " | ";
                }
                else
                {
                    cout << count++;
                }
            }

            if (i != SIZE - 1)
            {
                cout << "\n---------\n";
            }
        }
        cout << endl
             << "==========\n";
    }
    // Player selects which to play X or O
    char PlayerSelectRole()
    {
        char input = '0';

        cout << "Insert First player symbol 'X' or 'O': ";
        cin >> input;

        // Check, that input is 'X' or 'O'
        while (input != 'X' && input != 'O')
        {
            cout << "Wrong input. Please, insert 'X' or 'O': ";
            cin >> input;

            // If Error, clean the input
            if (cin.fail())
            {
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
            }
        }

        return input;
    }

    char carrentMarker = 0;

    // fill the board by spaces
    char **FillBoard(char **board)
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                board[i][j] = EMPTY;
            }
        }

        return board;
    }

    // draw the board
    void DrawBoard(char **board)
    {
        for (int i = 0; i < SIZE; i++)
        {
            cout << board[i][0] << " | " << board[i][1] << " | " << board[i][2] << endl;
            if (i != 2)
                cout << "---------\n";
        }
    }

    // get row and column value from cell
    int GetRow(int &cell)
    {
        return (cell % SIZE == 0) ? (cell / SIZE) - 1 : cell / SIZE;
    }
    int GetColumn(int &cell)
    {
        return (cell % SIZE == 0) ? 2 : (cell % SIZE - 1);
    }

    // get All board cels
    char **GetAllboardcases(char **board)
    {
        char **newBoard = new char *[SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            newBoard[i] = new char[SIZE];
        }

        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                newBoard[i][j] = board[i][j];
            }
        }

        return newBoard;
    }

    // check if the cell is empty
    bool CheckCell(int cell, char **board)
    {
        if (cell < 1 || cell > 9)
        {
            return false;
        }

        int row = GetRow(cell);
        int column = GetColumn(cell);

        if (board[row][column] != Xchar && board[row][column] != Ochar)
        {
            return true;
        }
        return false;
    }

    // marke the place of the cel
    char **PlaceMarker(int &slot, char **board, char carrentMarker)
    {
        int row = GetRow(slot);
        int column = GetColumn(slot);

        if (CheckCell(slot, board))
            board[row][column] = carrentMarker;

        return board;
    }

    // check if someone win and return his carrentPlayer value or return 0 if no one win yet
    int Winner(char **board, int carrentPlayer, bool draw = false)
    {
        for (int i = 0; i < SIZE; i++)
        {
            // check rows
            if ((board[i][0] != EMPTY && board[i][1] != EMPTY && board[i][3] != EMPTY) && (board[i][0] == board[i][1] && board[i][1] == board[i][2]))
            {
                if (draw)
                {
                    DrawBoard(board);
                    cout << "\n\n\n";
                }
                return carrentPlayer;
            }

            // check column
            if ((board[0][i] != EMPTY && board[1][i] != EMPTY && board[2][i] != EMPTY) && (board[0][i] == board[1][i] && board[1][i] == board[2][i]))
            {
                if (draw)
                {
                    DrawBoard(board);
                    cout << "\n\n\n";
                }
                return carrentPlayer;
            }
        }
        // check revers
        if ((board[0][0] != EMPTY && board[1][1] != EMPTY && board[2][2] != EMPTY) && (board[0][0] == board[1][1] && board[1][1] == board[2][2]))
        {
            if (draw)
            {
                DrawBoard(board);
                cout << "\n\n\n";
            }
            return carrentPlayer;
        }
        if ((board[0][2] != EMPTY && board[1][1] != EMPTY && board[2][0] != EMPTY) && (board[0][2] == board[1][1] && board[1][1] == board[2][0]))
        {
            if (draw)
            {
                DrawBoard(board);
                cout << "\n\n\n";
            }
            return carrentPlayer;
        }

        // if no one win yet
        return 0;
    }

    // swap the player and the marker
    char SwapMarker(char cm)
    {
        return (cm == Xchar) ? Ochar : Xchar;
    }
    int SwapPlayeer(int cp)
    {
        return (cp == 1) ? 2 : 1;
    }

    // get the list of chooses available in the board
    vector<int> GetListofChooses(char **board)
    {
        vector<int> listChooses;
        for (int i = 1; i <= SIZE * SIZE; i++)
        {
            if (CheckCell(i, board))
                listChooses.push_back(i);
        }

        return listChooses;
    }

    // check if the board is full
    bool IsFullBoard(char **board)
    {
        for (int i = 1; i <= SIZE * SIZE; i++)
        {
            if (CheckCell(i, board))
                return false;
        }
        return true;
    }

    // computer cell turn (AI cell)-----------------------------------------------------
    // this function calculate all utilities for all available cels and set them in "minimax" variable of the class
    void AllUtilities(int &globalCell, int lastCell, char **board, int flag, char carrentMarker, int carrentPlayer)
    {
        char **newBoard = new char *[SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            newBoard[i] = new char[SIZE];
        }
        newBoard = GetAllboardcases(board);

        newBoard = PlaceMarker(lastCell, board, carrentMarker);

        vector<int> listChooses = GetListofChooses(newBoard);

        if (Winner(newBoard, carrentPlayer, false))
        {
            vector<int> v = {};
            v.push_back(globalCell);
            v.push_back(flag * (listChooses.size() + 1));

            minimax.push_back(v);
            return;
        }

        if (IsFullBoard(newBoard))
        {
            vector<int> v = {};
            v.push_back(globalCell);
            v.push_back(0);

            minimax.push_back(v);
            return;
        }

        for (int i = 0; i < listChooses.size(); i++)
        {
            char **newNewBoard = new char *[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                newNewBoard[i] = new char[SIZE];
            }
            newNewBoard = GetAllboardcases(newBoard);
            AllUtilities(globalCell, listChooses.at(i), newNewBoard, (flag * (-1)), SwapMarker(carrentMarker), SwapPlayeer(carrentPlayer));
        }
    }

    // this function make smart decision from "minimax" variable of the class and return the value of the slot that it decide to choose it
    int MakeAIdecision(vector<int> &listChooses)
    {
        int defaultKey = listChooses[0];
        int defaultMin = 0;
        int defaultReduceGood = 0;
        int defaultReduceBad = 0;
        int keyMinMax = 0;
        int minMinMax = 0;
        int reduceGoodMinMax = 0;
        int reduceBadMinMax = 0;

        for (int i = 0; i < minimax.size(); i++)
        {
            if (minimax[i][0] == defaultKey)
            {
                defaultMin = minimax[i][1];
                break;
            }
        }
        for (int i = 0; i < minimax.size(); i++)
        {
            if (minimax[i][0] == defaultKey && minimax[i][1] > 0)
            {
                defaultReduceGood += minimax[i][1];
            }
            if (minimax[i][0] == defaultKey && minimax[i][1] < 0)
            {
                defaultReduceBad += minimax[i][1];
            }
            if (minimax[i][0] == defaultKey && minimax[i][1] < defaultMin)
            {
                defaultMin = minimax[i][1];
            }
        }
        keyMinMax = defaultKey;
        minMinMax = defaultMin;
        reduceGoodMinMax = defaultReduceGood;
        reduceBadMinMax = defaultReduceBad;

        for (int i = 1; i < listChooses.size(); i++)
        {
            int key = listChooses.at(i);
            int min;
            int reduceGood = 0;
            int reduceBad = 0;

            for (int j = 0; j < minimax.size(); j++)
            {
                if (minimax[j][0] == key)
                {
                    min = minimax[j][1];
                    break;
                }
            }
            for (int j = 0; j < minimax.size(); j++)
            {
                if (minimax[j][0] == key && minimax[j][1] > 0)
                {
                    reduceGood += minimax[j][1];
                }
                if (minimax[j][0] == key && minimax[j][1] < 0)
                {
                    reduceBad += minimax[j][1];
                }
                if (minimax[j][0] == key && minimax[j][1] < min)
                {
                    min = minimax[j][1];
                }
            }
            /*
            //print all informations about eche available slot
            std::cout << "key = " << key << ", min = " << min  << ", good reduce = " << reduceGood << ", bad reduce = " << reduceBad << std::endl;
            */
            if (min > minMinMax)
            { // chose the slot that have the big min utility (maximize min)
                keyMinMax = key;
                minMinMax = min;
                reduceGoodMinMax = reduceGood;
                reduceBadMinMax = reduceBad;
            }
            else if (min == minMinMax)
            {
                if (reduceBad > reduceBadMinMax)
                { // chose the slot that have the big reduce of bads utilities
                    reduceGoodMinMax = reduceGood;
                    reduceBadMinMax = reduceBad;
                    keyMinMax = key;
                    minMinMax = min;
                }
                else if (reduceBad == reduceBadMinMax)
                {
                    if (reduceGood > reduceGoodMinMax)
                    { // chose the slot that have the big reduce of goods utilities
                        reduceGoodMinMax = reduceGood;
                        reduceBadMinMax = reduceBad;
                        keyMinMax = key;
                        minMinMax = min;
                    }
                    else if (reduceGood == reduceGoodMinMax)
                    { // choose randomly
                        srand(time(NULL));
                        if (rand() % 2 == 0)
                        {
                            reduceGoodMinMax = reduceGood;
                            reduceBadMinMax = reduceBad;
                            keyMinMax = key;
                            minMinMax = min;
                        }
                    }
                }
            }
        }

        return keyMinMax;
    }

    // this function for choose a slot by using the minimax algorithm
    int ComputerPerfectSlot(char **board, std::vector<int> listChooses)
    {
        listChooses.clear();
        listChooses = GetListofChooses(board);

        // if the board is empty choose a random slot
        if (listChooses.size() == SIZE * SIZE)
        {
            // decision
            vector<int> randomSlot = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            srand(time(NULL));
            return (randomSlot.at((rand() % ((randomSlot.size() - 1) + 1))));
        }

        // calculate all utilities of availables slot
        minimax.clear();
        for (int i = 0; i < listChooses.size(); i++)
        {
            char **newBoard = new char *[3];
            for (int i = 0; i < 3; i++)
            {
                newBoard[i] = new char[3];
            }
            newBoard = GetAllboardcases(board);
            AllUtilities(listChooses.at(i), listChooses.at(i), newBoard, 1, carrentMarker, carrentPlayer);
        }

        // make a decision by analyse all utilities on the "minimax" variable of the class
        return MakeAIdecision(listChooses);
    }

public:
    void play(std::string _player1, std::string _player2)
    {
        player1 = _player1;
        player2 = _player2;
        carrentMarker = PlayerSelectRole();

        // create the board
        board = new char *[SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            board[i] = new char[SIZE];
        }

        // fill the board
        board = FillBoard(board);

        int slot;

        // choose who will start the game randomly
        srand(time(NULL));
        int turn = 0;

        for (int i = 0; i < SIZE * SIZE; i++)
        {
            system("cls");
            PrintTemplate();
            DrawBoard(board);

            if (player1 == "humain" && player2 == "humain")
            {
                std::cout << "It's player " << carrentPlayer << "'s turn. Enter your slot: ";
                std::cin >> slot;
            }

            else if (player1 == "AI" && player2 == "AI")
            {
                std::cout << "\n\n";
                char **newBoard = new char *[3];
                for (int i = 0; i < 3; i++)
                {
                    newBoard[i] = new char[3];
                }
                newBoard = GetAllboardcases(board);
                slot = ComputerPerfectSlot(newBoard, listChooses);
            }

            else if ((player1 == "humain" && player2 == "AI") || (player1 == "AI" && player2 == "humain"))
            {
                if ((turn + i) % 2 == 1)
                {
                    std::cout << "It's player " << carrentPlayer << "'s turn. Enter your slot: ";
                    std::cin >> slot;
                }
                else
                {
                    std::cout << "\n\n";
                    char **newBoard = new char *[SIZE];
                    for (int i = 0; i < SIZE; i++)
                    {
                        newBoard[i] = new char[SIZE];
                    }
                    newBoard = GetAllboardcases(board);
                    slot = ComputerPerfectSlot(newBoard, listChooses);
                }
            }

            // if something wrong when you chose the couple of players you will go to the default two players ("humain","humain")
            else
            {
                std::cout << "It's player " << carrentPlayer << "'s turn. Enter your slot: ";
                std::cin >> slot;
            }

            // check if the slot that the player choose is available or not before mark it
            if (!CheckCell(slot, board))
            {
                std::cout << "The slot " << slot << " isn't not vailable, tyr another one!\n";
                i--;
                continue;
            }
            board = PlaceMarker(slot, board, carrentMarker);

            // check if someone win
            if (Winner(board, carrentPlayer))
            {
                std::cout << carrentMarker << " has won!\n\n\n";
                board = FillBoard(board);
                return;
            }

            DrawBoard(board);

            // swap to the player who will play in the next turn
            carrentMarker = SwapMarker(carrentMarker);
            carrentPlayer = SwapPlayeer(carrentPlayer);
        }

        std::cout << "This is a tie game! :/\n\n\n";
        board = FillBoard(board);
    }

    ~TicTacToe()
    {
        for (int i = 0; i < 3; i++)
        {
            delete[] board[i];
        }
        delete[] board;
        listChooses.clear();
        minimax.clear();
    }
};

void StartUpModeSelect(TicTacToe t)
{
    while (true)
    {
        int choice = 0;
        cout << "Select StatuUp Mode\n\n";
        cout << "1. Humain VS Humain\n";
        cout << "2. Humain VS AI\n";
        cout << "3. AI VS AI\n";
        cout << "4. AI VS Humain\n";
        cin >> choice;

        switch (choice)
        {
        case 1:
            t.play("humain", "humain");
            break;
        case 2:
            t.play("humain", "AI");
            break;
        case 3:
            t.play("AI", "AI");
            break;
        case 4:
            t.play("AI", "humain");
            break;
        default:
        {
            cout << "Wrong Input. Try again..";
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
        }
        break;
        }
    }
}

int main(int argc, char *argv[])
{
    TicTacToe t;
    /*
    you choose the two players by passing two argument from this :
        "humain" : choose the slot from the keyboard input.
        "AI"     : choose the slot by analysis all utilities possible and make the perfect decision.

    EX:
        t.play("humain", "humain");
        t.play("humain", "AI");
        t.play("AI", "AI");
        t.play("AI", "humain");
    */
    StartUpModeSelect(t);
    system("pause");
}
