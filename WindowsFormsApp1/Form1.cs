using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public class Permutations<T>
        {
            public static System.Collections.Generic.IEnumerable<T[]> AllFor(T[] array)
            {
                if (array == null || array.Length == 0)
                {
                    yield return new T[0];
                }
                else
                {
                    for (int pick = 0; pick < array.Length; ++pick)
                    {
                        T item = array[pick];
                        int i = -1;
                        T[] rest = System.Array.FindAll<T>(
                            array, delegate (T p) { return ++i != pick; }
                        );
                        foreach (T[] restPermuted in AllFor(rest))
                        {
                            i = -1;
                            yield return System.Array.ConvertAll<T, T>(
                                array,
                                delegate (T p) {
                                    return ++i == 0 ? item : restPermuted[i - 1];
                                }
                            );
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string k = textBox1.Text;
            //string[] defarray = textBox1.Lines;
            string[] list = k.Split();
            string j;
            FileStream fs = new FileStream("./mixer.txt", FileMode.Create);
            StreamWriter file = new StreamWriter(fs);
            string appPath = Application.StartupPath;
            int numOfWord = list.Count();
            foreach (string[] permutation in Permutations<string>.AllFor(list))
            {
                 j=string.Join("", permutation);
               file.WriteLine(j);
                j = null;
            }
            
            file.Close();
            fs.Close();

        }
    }
}
