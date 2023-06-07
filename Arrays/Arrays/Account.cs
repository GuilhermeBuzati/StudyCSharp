using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Account //: IComparable<Account>
{
    public int AgencyId { get; }
    public string NumberAccount { get; set; }
    public double? BalanceInitital { get; set; }
    public string? NameClient { get; set; }
    public string? CPF { get; set; }
    public string? Profession { get; set; }


    public Account(int agency, string number)
    {

        AgencyId = agency;
        NumberAccount = number;
    }

    //public int CompareTO(Account? other)
    //{
    //    if(other == null)
    //    {
    //        return 1;
    //    }
    //    else
    //    {
    //        return this.AgencyId.CompareTo(other.AgencyId); 
    //    }
    //}

    public override string ToString()
    {
        return "==== Information of Account ====\n" +
            $"Number Account: {this.NumberAccount} \n"+
            $"Balance Initial: {this.BalanceInitital} \n"+
            $"Name: {this.NameClient} \n"+
            $"CPF: {this.CPF} \n"+
            $"Profession: {this.Profession}";
    }
}
