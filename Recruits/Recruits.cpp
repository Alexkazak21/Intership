#include <iostream>

using namespace std;

void TurnSoldiers(char soldiers[])
{
    size_t size = sizeof(soldiers) / sizeof(soldiers[0]);

    bool swap = true;
    do
    {
        swap = false;
        for (int i = 0; i < size - 1; i++)
        {
            if (soldiers[i] == '>' && soldiers[i + 1] == '<')
            {
                char tmp = soldiers[i];
                soldiers[i] = soldiers[i + 1];
                soldiers[i + 1] = tmp;
                i++;
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

    TurnSoldiers(soldiers);

    cout << "let`s go!";

    return 0;
}