#include <iostream>

using namespace std;

void SoldiersTurnsFinished(char soldiers[], int size)
{
    bool swap = true;
    while (swap)
    {
        swap = false;
        for (int i = 0; i < size; i++)
        {
            if (i != size - 1 && soldiers[i] == 'L' && soldiers[i + 1] == 'R')
            {
                char tmp = soldiers[i];
                soldiers[i] = soldiers[i + 1];
                soldiers[i + 1] = tmp;
                swap = true;
            }
        }
    }
}

int main()
{
    char soldiers[] = {'R', 'L', 'R', 'L', 'R'};

    size_t size = sizeof(soldiers) / sizeof(soldiers[0]);
    SoldiersTurnsFinished(soldiers, size);
    cout << "let`s go!";

    return 0;
}