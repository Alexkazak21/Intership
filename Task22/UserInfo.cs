using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22;

internal class UserInfo<T>
{
    public int ID { get; set; } = 0;

    public T? Name { get; set; } = default;

    public T? Surname { get; set; } = default;

    public T? Age { get; set; } = default;

    public override string ToString()
    {
        
        return $" {this.ID} | {ShowNullString(this.Name)} | {ShowNullString(this.Surname)} | {ShowNullString(this.Age)} |";
    }

    private string ShowNullString(T str)
    {
        if (str == null)
        {
            return "null";
        }
        else
        {
            return str.ToString();
        }
    }
}
