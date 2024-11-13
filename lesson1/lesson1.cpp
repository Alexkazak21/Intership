#include <iostream>

using namespace std;

void showMenu();
double ConvertTo(double byn, double exchangRate);
double GetMoney();
void ChoiceProcess(int choice, double byn);

int main()
{
    int choice = 0;
    double byn = 0.0;

    while (true)
    {
        cout << "Current balance: " << byn << endl
             << endl;

        showMenu();
        cout << "Your choice? ";
        cin >> choice;

        ChoiceProcess(choice, byn);
    }
    cout << "Ok";
    return 0;
}

void showMenu()
{
    cout << endl;
    cout << "1) Deposit BYN" << endl;
    cout << "2) Convert to USD" << endl;
    cout << "3) Convert to EUR" << endl;
    cout << "4) Convert to CNY" << endl;
    cout << "5) Exit" << endl;
}

double GetMoney()
{
    double ammount = 0.0;

    cout << "Want ammount of BYN your want to deposite? [5,10,20,50,100,200,500]" << endl;
    cout << "Ammount: ";

    cin >> ammount;

    return ammount;
}

double ConvertTo(double byn, double exchangRate)
{
    return byn / exchangRate;
}

void ChoiceProcess(int choice, double byn)
{
    if (choice == 1)
    {
        byn = GetMoney();
        cout << "Ok, " << byn << "BYN is deposited" << endl;
    }
    else if (choice == 2)
    {
        const double EXCHANGE_RATE = 3.3;
        cout << "Ok, take your money " << ConvertTo(byn, EXCHANGE_RATE) << "USD" << endl;
    }
    else if (choice == 3)
    {
        const double EXCHANGE_RATE = 3.6;
        cout << "Ok, take your money " << ConvertTo(byn, EXCHANGE_RATE) << "EUR" << endl;
    }
    else if (choice == 4)
    {
        const double EXCHANGE_RATE = 0.465;
        cout << "Ok, take your money " << ConvertTo(byn, EXCHANGE_RATE) << "CNY" << endl;
    }
    else if (choice == 5)
    {
        cout << "Input [1..5], please" << endl;
    }
}