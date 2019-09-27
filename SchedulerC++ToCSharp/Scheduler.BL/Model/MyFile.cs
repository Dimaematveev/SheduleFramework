using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class MyFile : IFile
    {
        string NameFile;
        int NumberLines=0;
        List<string> _out;

        public MyFile()
        {
            NameFile = "";
            NumberLines = 0;
        }

        public MyFile(string NameFile):this()
        {
            //cout << "Call constructor '" << typeid(File).name() << "' id='" << id << "' this='" << this << "' number='" << number << "'" << endl << endl;
            
            SetNumberLines();
        }

        public void GetVar()
        {
            //cout << "Call '" << typeid(File).name() << "' static number='" << number << "' id='" << id << "' " << endl;
            Console.WriteLine("NameFile:'" + NameFile + "' NumberLines:'" + NumberLines + "'" );
            Console.WriteLine();

        }
        //TODO:
        public string GetOut(int k)
        {
            return _out[k];
        }

    public string RetNameFile() { return NameFile; }

        public int RetNumberLines() { return NumberLines; }

        public void SetFileNotOpen()
        {
            
            Console.WriteLine();
            Console.WriteLine( "A file '" +this.NameFile + "' not open. Check the spelling! " );
            Console.WriteLine("Edit value?  0-no, 1-yes " );
            bool v;
            char ch;
            do
            {
                //ch=13
                ch = ' ';
                Console.WriteLine(ch);
                ch = Console.ReadKey().KeyChar;
            } while (ch != '0' && ch != '1');
            v = false;
            if (ch == '1')
            {
                v = true;
            }
            //(ch == '1') ? v = 1 : v = 0;
            Console.WriteLine();
            if (v)
            {
                string str;
                Console.WriteLine("Enter the name of the file:");
                str = Console.ReadLine();
                //getline(cin, str);
                NameFile = str;
                SetNumberLines();
            }
            else
            {
                string str = "File \'" + this.NameFile + "\' is not open!";
                //TODO: непонятное исключение
                //throw exception(str.c_str());
            }

        }
        //TODO:
        public void SetFileOpen()
        {
            using (FileStream fstream = new FileStream(NameFile, FileMode.Open))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                textFromFile = textFromFile.Replace(" ", "").Replace("\t", "");
                _out = textFromFile.Split('\n').ToList();
                this.NumberLines= _out.Count;
                //Console.WriteLine("Текст из файла: {0}", textFromFile);
            }

           

        }

    //TODO:
        public void SetNumberLines()
        {
            if (!IsFileLocked(new FileInfo(NameFile)))
            {
                SetFileOpen();
            }
            else
            {
                SetFileNotOpen();
            }

        }
        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
        public void SetVar(string NameFile)
        {
            this.NameFile = NameFile;
            this.NumberLines = 0;
            SetNumberLines();

        }
    }
}
