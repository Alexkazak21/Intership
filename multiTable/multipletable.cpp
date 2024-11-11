#include <iostream>

using namespace std;

int main()
{
    const int TSIZE = 10;

    for (int i = 1; i <= TSIZE; i++)
    {
        for (int j = 1; j <= TSIZE; j++)
        {
            cout << i * j << "\t";
        }
        cout << endl;
    }
    return 0;
}