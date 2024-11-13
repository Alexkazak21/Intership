#include <iostream>

using namespace std;
void showMenu();
double ConvertToUSD(double byn, double exchangRate);
double GetMoney();
int main()
{
    int choice = 0;
    double byn = 0.0;

    while (true)
    {
        showMenu();
        cout << "Your choice? ";
        cin >> choice;
        if (choice == 1)
        {
            byn = GetMoney();
            cout << "Ok, " << byn << "BYN is deposited" << endl;
        }
        else if (choice == 2)
        {
            const double EXCHANGE_RATE = 3.3;
            cout << "Ok, take your money " << ConvertToUSD(byn, EXCHANGE_RATE) << "USD" << endl;
        }
        else if (choice == 5)
        {
            cout << "Input [1..5], please" << endl;
        }
    }
    cout << "Ok";
    return 0;
}

void showMenu()
{
    cout << endl;
    cout << "1) Deposit BYN" << endl;
    cout << "2) Convert to USD" << endl;
    cout << "5) Exit" << endl;
}
double GetMoney()
{
    return 100.0;
}
double ConvertToUSD(double byn, double exchangRate)
{
    return byn / exchangRate;
}