using System;
namespace Autonet
{
    class CCard
    {
        public int Num, CID;

        public void Parse(String input)
        {
            if (input == "Empty")
            {
                Num = -1;
                CID = -1;
            } else { 
            Num = input[0];

                switch (input[1])
                {
                    case 'r':
                        CID = 0;
                        break;
                    case 'b':
                        CID = 1;
                        break;
                    case 'g':
                        CID = 2;
                        break;
                    case 'y':
                        CID = 3;
                        break;
                    case 'o':
                        CID = 4;
                        break;
                }
            }

        }

    }
}
