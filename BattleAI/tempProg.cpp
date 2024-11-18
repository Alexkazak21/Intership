// Function to display field
void PrintBoard(char board[SIZE][SIZE])
{
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
        {
            if (j != SIZE - 1)
            {
                cout << board[i][j] << " | ";
            }
            else
            {
                cout << board[i][j];
            }
        }

        if (i != SIZE - 1)
        {
            cout << "\n---------\n";
        }
    }

    cout << endl;
}

// Function that check a winner
bool CheckWinner(char board[SIZE][SIZE], char player)
{
    // Rows check
    for (int i = 0; i < SIZE; i++)
    {
        if (board[i][0] == player && board[i][1] == player && board[i][2] == player)
            return true;
    }
    // Columns check
    for (int i = 0; i < SIZE; i++)
    {
        if (board[0][i] == player && board[1][i] == player && board[2][i] == player)
            return true;
    }
    // Diagonal check
    if (board[0][0] == player && board[1][1] == player && board[2][2] == player)
        return true;
    if (board[0][2] == player && board[1][1] == player && board[2][0] == player)
        return true;

    return false;
}

// Function to check for a draw
bool CheckDraw(char board[SIZE][SIZE])
{
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
        {
            if (board[i][j] == EMPTY)
            {
                return false; // If there are empty squares, there is no draw
            }
        }
    }
    return true; // If there are no empty squares, it's a draw
}

// Minimax position check
int Evaluate(char board[SIZE][SIZE])
{
    if (CheckWinner(board, BOT_X))
    {
        return 1; // Bot X win
    }
    if (CheckWinner(board, PLAYER_O))
    {
        return -1; // Player O win
    }
    return 0; // Draw
}

// Minimax function
int Minimax(char board[SIZE][SIZE], int depth, bool isMax)
{
    int score = Evaluate(board);

    // If someone win or game ended
    if (score == 1)
    {
        return score - depth;
    }

    if (score == -1)
    {
        return score + depth;
    }

    if (CheckDraw(board))
    {
        return 0;
    }

    // It`s player X turn (maximise)
    if (isMax)
    {
        int best = -1000;
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (board[i][j] == EMPTY)
                {
                    board[i][j] = BOT_X;
                    best = max(best, Minimax(board, depth + 1, !isMax));
                    board[i][j] = EMPTY;
                }
            }
        }
        return best;
    }
    // Player O turn (minimise)
    else
    {
        int best = 1000;
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (board[i][j] == EMPTY)
                {
                    board[i][j] = PLAYER_O;
                    best = min(best, Minimax(board, depth + 1, !isMax));
                    board[i][j] = EMPTY;
                }
            }
        }
        return best;
    }
}

// Best player`s move search
pair<int, int> findBestMove(char board[SIZE][SIZE])
{
    int bestVal = -1000;
    pair<int, int> bestMove = {-1, -1};

    // Search all cells & select best move
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
        {
            if (board[i][j] == EMPTY)
            {
                board[i][j] = BOT_X; // Player X move
                int moveVal = Minimax(board, 0, false);
                board[i][j] = EMPTY; // Move dalay

                if (moveVal > bestVal)
                {
                    bestMove = {i, j};
                    bestVal = moveVal;
                }
            }
        }
    }
    return bestMove;
}

// Function for the player's move
void MakeMove(char board[SIZE][SIZE], char player)
{
    int move = 0;
    while (true)
    {
        cout << "Player " << player << ", insert number of cell (1-9): ";
        cin >> move;

        // Input validation
        if (move >= 1 && move <= 9)
        {
            int row = -1;
            int col = -1;

            row = (move - 1) / SIZE; // Convert cell number to row
            col = (move - 1) % SIZE; // Convert cell number to collumn

            if (board[row][col] == ' ')
            {
                board[row][col] = player;
                break;
            }
            else
            {
                cout << "This cell is already occupied, try again." << endl;
            }
        }
        else
        {
            cout << "Wrong cell number. Insert number in [1-9]." << endl;
        }
    }
}
