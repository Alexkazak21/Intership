#include <iostream>
#include <math.h>

using namespace std;

int main()
{
    int counter = 1;
    for (int i = 0; i < 5; i++)
    {
        cout << counter << "\t";
        counter++;
    }

    counter = -2;
    cout << "\n";
    for (int i = 0; i < 5; i++)
    {
        cout << counter << "\t";
        counter++;
    }

    counter = 5;
    cout << "\n";
    for (int i = 0; i < 5; i++)
    {
        cout << counter << "\t";
        counter--;
    }

    counter = 5;
    cout << "\n";
    for (int i = 0; i < 5; i++)
    {
        cout << counter << "\t";
        counter -= 3;
    }

    counter = 2;
    cout << "\n";
    for (int i = 0; i < 5; i++)
    {
        cout << pow(counter, i) << "\t";
    }

    counter = 1;
    cout << "\n";
    for (int i = 0; i < 5; i++)
    {
        cout << counter + i << "\t";
        counter++;
    }

    return 0;
}