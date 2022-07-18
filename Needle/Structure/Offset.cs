using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle.Structure
{
    public class Offset
    {
        public int start { get; set; }
        public int end { get; set; }
        public int next { get; set; }
        public int size { get; set; }

        public Offset(int start)
        {
            this.start = start;
            this.end = start;
            this.next = this.end + 1;
            this.size = 1;
        }

        public Offset(int start, int size)
        {
            this.start = start;
            this.size = size;
            this.end = (this.start + this.size - 1);
            this.next = this.end + 1;

        }

        public Offset(int start, int size, bool separate)
        {
            int aligner = 0;
       
            if (separate == true)
            {
                aligner = 1;
            }

            this.start = start;
            this.size = size;
            this.end = (this.start + this.size - 1);
            this.next = this.start + this.size + 1;
        }
    }
}
