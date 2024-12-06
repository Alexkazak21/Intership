#include <iostream>

using namespace std;

int main()
{
    const int N = 13;
    int points[N] = {0};
    const int ROLL_AMMOUNT = 1000000;
    int i = 0;
    for (int i = 0; i < ROLL_AMMOUNT; i++)
    {
        points[(1 + rand() % 6) + (1 + rand() % 6)]++;
    }

    for (int i = 2; i < N; i++)
    {
        cout << i << ": ";
        cout << points[i] << "  ";
        cout << ((double)points[i] / (double)ROLL_AMMOUNT) * 100.0 << "%" << endl;
    }

    return 0;
}