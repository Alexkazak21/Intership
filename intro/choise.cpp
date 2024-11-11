#include <iostream>

using namespace std;

int main()
{
    int number = 0;
    cout << "Enter a number from 1 to 10:\n";
    cin >> number;

    if (number <= 1 || number >= 10)
    {
        cout << "Incorect answer";
    }
    return 0;
}