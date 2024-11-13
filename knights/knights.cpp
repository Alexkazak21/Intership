#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    int x1 = 0;
    int y1 = 0;
    int x2 = 0;
    int y2 = 0;

    cout << "Insert coordinates of first knight [1-8]: \n";
    cout << "Insert x1: ";
    cin >> x1;
    cout << "Insert y1: ";
    cin >> y1;

    cout << "Insert coordinates of first knight [1-8]: \n";
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
