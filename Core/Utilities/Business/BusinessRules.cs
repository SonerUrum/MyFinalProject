using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) // params kullanarak IResult türünde ne kadar parametre varsa hepsini virgül ile ayırarak yazıp logics'e dizi halinde atayabiliriz.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }//tüm parametreleri ve kuralları gez hatalı olan varsa döndür yani bisuness'a haber ver. hatalı olan yoksa null döndür.
}
