#include <iostream>
#include <vector>

using namespace std;

const int SIZE = 3;

bool hasClearPath(int cube[SIZE][SIZE][SIZE])
{
    // Checking the lines along the axes
    for (int x = 0; x < SIZE; x++)
    {
        for (int y = 0; y < SIZE; y++)
        {
            bool clearX = true, clearY = true, clearZ = true;
            for (int z = 0; z < SIZE; z++)
            {
                if (cube[x][y][z] == 0)
                    clearZ = false; // Line along Z
                if (cube[x][z][y] == 0)
                    clearY = false; // Line along Y
                if (cube[z][x][y] == 0)
                    clearX = false; // Line along X
            }
            if (clearX || clearY || clearZ)
                return true;
        }
    }

    // Check the diagonals in the planes
    for (int i = 0; i < SIZE; i++)
    {
        bool diagXY1 = true, diagXY2 = true;
        bool diagXZ1 = true, diagXZ2 = true;
        bool diagYZ1 = true, diagYZ2 = true;
        for (int j = 0; j < SIZE; j++)
        {
            if (cube[i][j][j] == 0)
                diagXY1 = false; // Diagonal in plane XY
            if (cube[i][j][SIZE - j - 1] == 0)
                diagXY2 = false; // Inverse diagonal in the planeXY
            if (cube[j][i][j] == 0)
                diagXZ1 = false; // Diagonal in plane XZ
            if (cube[j][i][SIZE - j - 1] == 0)
                diagXZ2 = false; // Inverse diagonal in the plane XZ
            if (cube[j][j][i] == 0)
                diagYZ1 = false; // Diagonal in plane YZ
            if (cube[j][SIZE - j - 1][i] == 0)
                diagYZ2 = false; // Inverse diagonal in the plane YZ
        }
        if (diagXY1 || diagXY2 || diagXZ1 || diagXZ2 || diagYZ1 || diagYZ2)
            return true;
    }

        /*
    // Checking the spatial diagonals
    bool diag1 = true, diag2 = true, diag3 = true, diag4 = true;
    for (int i = 0; i < SIZE; i++)
    {
        if (cube[i][i][i] == 0)
            diag1 = false; // Main diagonal
        if (cube[i][i][SIZE - i - 1] == 0)
            diag2 = false; // inverse diagonal
        if (cube[i][SIZE - i - 1][i] == 0)
            diag3 = false; // Mixed diagonal
        if (cube[SIZE - i - 1][i][i] == 0)
            diag4 = false; // Another variant of mixed diagonal
    }
    if (diag1 || diag2 || diag3 || diag4)
        return true;
    */

    return false; // If the are no gap
}

int main()
{

    // 1 is clear
    // 0 is black
    int cube[SIZE][SIZE][SIZE] = {
        {{1, 0, 1}, {1, 1, 1}, {1, 1, 0}},
        {{1, 1, 1}, {0, 1, 0}, {1, 1, 1}},
        {{1, 1, 1}, {1, 0, 1}, {1, 1, 1}}};

    if (hasClearPath(cube))
    {
        cout << "Theare at least one gap." << endl;
    }
    else
    {
        cout << "theare no gaps." << endl;
    }

    return 0;
}
