using System;

namespace CRC
{
    public class Code
    {
        private String BitStream;

        // Дефолтное значение если полином не выбран
        private String SEED = new String("000001");
        private String crc = new String("");
        private int[] c = new int[6];
        private int[] ch = new int[6];
        private int[] d = new int[1];

        private String calc()
        {
            for (int i = 0; i < 6; ++i)
            {
                this.c[6 - 1 - i] = (int)(this.SEED[i]) - (int)('0');
            }
            for (int i = 0; i < this.BitStream.Length; i = i + 1)
            {
                for (int j = 0; j < 1; j = j + 1)
                {
                    this.d[1 - 1 - j] = (int)(this.BitStream[i + j]) - (int)('0');
                }
                for (int k = 0; k < 6; k = k + 1)
                {
                    this.ch[k] = this.c[k];
                }
                this.c[5] = this.ch[4];
                this.c[4] = this.ch[3];
                this.c[3] = this.ch[2];
                this.c[2] = this.ch[1] ^ this.ch[5] ^ this.d[0];
                this.c[1] = this.ch[0];
                this.c[0] = this.ch[5] ^ this.d[0];
            }
            for (int i = 0; i < 6; ++i)
            {
                this.crc += Convert.ToString(this.c[6 - 1 - i]);
            }
            return this.crc;
        }
        public Code(String BitStream_in, String SEED_in)
        {
            this.SEED = SEED_in;
            this.BitStream = BitStream_in;
            this.calc();
        }
        public Code(String BitStream_in)
        {
            this.BitStream = BitStream_in;
            this.calc();
        }
        public int set_data(String BitStream_in)
        {
            this.BitStream = BitStream_in;
            return 0;
        }
        public int set_seed(String SEED_in)
        {
            this.SEED = SEED_in;
            return 0;
        }
        public String get_crc()
        {
            return this.crc;
        }
    }
}
