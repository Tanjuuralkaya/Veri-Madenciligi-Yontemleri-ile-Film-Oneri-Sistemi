using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veri_Temzileme
{
    public class Bit
    {

        public static VeriToplami AltKumeBul(Veri veriler, int n)
        {

            VeriToplami liste = new VeriToplami();

            int AltKumeSayisi = (int)Math.Pow(2, Convert.ToInt32(veriler.Count));
            for (int i = 0; i < AltKumeSayisi; i++)
            {
                if (n == 0 || GetOnCount(i, veriler.Count) == n)
                {
                    string binary = DecimalToBinary(i, veriler.Count);

                    Veri altkume = new Veri();
                    for (int bitIndex = 0; bitIndex < veriler.Count; bitIndex++)
                    {
                        if (binary[bitIndex] == '1')
                        {
                            altkume.Add(veriler[bitIndex]);
                        }
                    }
                    //Console.WriteLine("Alt küme sayısı " + altkume.Count());
                    //Console.WriteLine(altkume);
                
                    liste.Add(altkume);
                }
                
            }
          
            return liste;
        }
   
        public static int GetBit(int value, int position)
        {
            int bit = value & (int)Math.Pow(2, position);

            return (bit > 0 ? 1 : 0);
        }

        //10 ludan ikliye çevirme
        public static string DecimalToBinary(int value, int length)
        {
            string binary = string.Empty;
            for (int position = 0; position < length; position++)
            {
                binary = GetBit(value, position) + binary;
            }
            return (binary);
        }

        //İkili sayılar ile 1 olanı karşılaştır ve bu 1 olanı ala demek
        public static int GetOnCount(int value, int length)
        {
            string binary = DecimalToBinary(value, length);
          
            return (from char c in binary.ToCharArray()
                    where c == '1'
                    select c).Count();
        }

    }
}
