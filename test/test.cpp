//  записать условие как говорит интервьюер
//  разработка функции елочка f(3)

#include <iostream>

using namespace std;

int main()
{
    int ammount = 0;
    const char ITEM = '*';

    cout << "Insert height ";
    cin >> ammount;

    for (int i = 1; i <= ammount; i++)
    {
        int j = i;
        while (j > 0)
        {
            cout << ITEM;
            j--;
        }
        cout << endl;
    }

    for (int i = ammount - 1; i > 0; i--)
    {
        int j = i;
        while (j > 0)
        {
            cout << ITEM;
            j--;
        }
        cout << endl;
    }

    return 0;
}