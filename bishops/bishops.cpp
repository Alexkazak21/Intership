#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    int x1, y1, x2, y2;
    cout << "Insert coordinates of first bishop (x1 y1)[1-8]: \n";
    cout << "Insert x1: ";
    cin >> x1;
    cout << "Insert y1: ";
    cin >> y1;

    cout << "Insert coordinates of first bishop (x2 y2)[1-8]: \n";
    cout << "Insert x2: ";
    cin >> x2;
    cout << "Insert y2: ";
    cin >> y2;
    if (abs(x1 - x2) == abs(y1 - y2))
    {
        cout << "Bishop fight each other" << endl;
    }
    else
    {
        cout << "Bishor not fight each other" << endl;
    }

    return 0;
}
