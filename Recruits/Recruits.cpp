#include <iostream>

using namespace std;

void SoldiersTurnsFinished(char soldiers[], int size)
{
    bool swap = true;
    do
    {
        swap = false;
        for (int i = 0; i < size; i++)
        {
            if (i != size - 1 && soldiers[i] == '>' && soldiers[i + 1] == '<')
            {
                char tmp = soldiers[i];
                soldiers[i] = soldiers[i + 1];
                soldiers[i + 1] = tmp;
                swap = true;
            }
        }
        if (swap)
        {
            cout << soldiers << endl;
            system("pause");
        }

    } while (swap);
}

int main()
{
    char soldiers[] = {'<', '>', '<', '>', '<'};

    size_t size = sizeof(soldiers) / sizeof(soldiers[0]);
    SoldiersTurnsFinished(soldiers, size);

    cout << "let`s go!";

    return 0;
}