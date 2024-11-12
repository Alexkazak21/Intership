#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    int x1, y1, x2, y2;
    cout << "Insert coordinates of first knight (x1 y1)[1-8]: \n";
    cout << "Insert x1: ";
    cin >> x1;
    cout << "Insert y1: ";
    cin >> y1;

    cout << "Insert coordinates of first knight (x2 y2)[1-8]: \n";
    cout << "Insert x2: ";
    cin >> x2;
    cout << "Insert y2: ";
    cin >> y2;

    int dx = abs(x1 - x2);
    int dy = abs(y1 - y2);

    if ((dx == 2 && dy == 1) || (dx == 1 && dy == 2))
    {
        cout << "Knights fight" << endl;
    }
    else
    {
        cout << "Knights not fight" << endl;
    }

    return 0;
}
