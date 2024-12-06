#include <iostream>
#include <thread>
#include <chrono>

using namespace std;

void TurnSoldiers(char soldiers[]);
bool IsMeetEachother(char firstRec, char secindRec);
void SergantScream(string scream);
void ShowRecruits(char recruits[], int size);

int main()
{
    char soldiers[] = {'<', '>', '<', '>', '<', '<'};

    size_t size = sizeof(soldiers) / sizeof(soldiers[0]);

    bool swapFlag = true;
    do
    {
        swapFlag = false;
        for (int i = 0; i < size - 1; i++)
        {
            if (IsMeetEachother(soldiers[i], soldiers[i + 1]))
            {
                swap(soldiers[i], soldiers[i + 1]);
                i++;
                swapFlag = true;
            }
        }
        if (swapFlag)
        {
            ShowRecruits(soldiers, size);
            std::this_thread::sleep_for(std::chrono::seconds(1));
        }

    } while (swapFlag);

    SergantScream("let`s go!");

    return 0;
}

void ShowRecruits(char recruits[], int size)
{
    for (int i = 0; i < size; i++)
    {
        cout << recruits[i];
    }
    cout << endl;
}

void SergantScream(string scream)
{
    cout << scream << "\a";
}

bool IsMeetEachother(char firstRec, char secondRec)
{
    if (firstRec == '>' && secondRec == '<')
    {
        return true;
    }
    return false;
}