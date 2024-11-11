#include <iostream>

using namespace std;

int main()
{
    int value;
    cout << "Value [1..10]?";
    cin >> value;

    if (value >= 1)
    {
        if (value > 10)
            cout << "error: value > 10" << endl;
    }
    else
        cout << "error: value < 1" << endl;
    return 0;
}