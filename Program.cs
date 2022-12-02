using System.IO;

namespace fileinfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var darko = Directory.EnumerateFiles(@"D:\Слики-MegaFolder", "*.*", SearchOption.AllDirectories).ToList();
            //FileInfo[] files = new FileInfo[darko.Count];
            List<FileInfo> files = new List<FileInfo>();
            List<string> filetype = new List<string>();
            //int i = 0;
            foreach (var item in darko)
            {
                files.Add(new FileInfo(item));
                //i++;
            }
            
            foreach (var item in files)
            {
                filetype.Add(item.Extension);
            }
            var allfiletypes=filetype.OrderBy(x => x).Distinct();
            
            foreach (var item in allfiletypes)
            {
                Console.WriteLine(item);
            }

            TextWriter tw = new StreamWriter("C:\\Users\\Stran\\Desktop\\lista.txt");
            foreach (String s in allfiletypes)
            {
                tw.WriteLine(s);
            }
            tw.Close();
            List<string>sliki= new List<string>();
            foreach (var item in files)
            {
                if (item.Extension== ".bmp"|| item.Extension == ".gif" || item.Extension == ".GIF" || item.Extension == ".ico" || item.Extension == ".jpeg" || item.Extension == ".jpg" || item.Extension == ".JPG" || item.Extension == ".MOV" || item.Extension == ".mp3" || item.Extension == ".mp4" || item.Extension == ".mui" || item.Extension == ".pcx"||item.Extension == ".pdf" || item.Extension == ".png" || item.Extension == ".PNG" || item.Extension == ".raw")
                {
                    string path = "C:\\Users\\Stran\\Desktop\\SITESLIKI";
                    DateTime moddate = File.GetLastWriteTime(item.FullName);
                    string modstringyear = moddate.Year.ToString();
                    string modstringmonth = moddate.Month.ToString();
                    string finalpath= path+ "\\" + modstringyear+"\\"+modstringmonth;
                    Directory.CreateDirectory(finalpath);
                    string ffp= path + "\\" + modstringyear + "\\" + modstringmonth+"\\"+item.Name;
                    int a = 1;
                    while (File.Exists(ffp))
                    {
                        
                        int b = item.Extension.ToLower().Length;
                        int v =item.Name.ToLower().Length;
                        string d = item.Name;
                        string e=item.Extension;
                        ffp = path+ "\\" + modstringyear + "\\" + modstringmonth + "\\" + d.Remove(v - 1-b, b) + a + e;
                        a++;
                    }
                    File.Copy(item.FullName, ffp, false);

                    Console.WriteLine(finalpath);
                    //Console.WriteLine(modstringyear);
                    //Console.WriteLine(modstringmonth);
                    sliki.Add(item.Name);
                }
                else
                {
                    string junkpath = "C:\\Users\\Stran\\Desktop\\JUNK";
                    string finaljunk = junkpath +"\\"+ item.Name;
                    int a = 1;
                    while (File.Exists(finaljunk))
                    {
                        a++;
                        int b = item.Extension.ToLower().Length;
                        int v = item.Name.ToLower().Length;
                        string d = item.Name;
                        string e = item.Extension;
                        finaljunk = junkpath+"\\"+ d.Remove(v-1-b,b) + a + e;

                    }

                    
                    File.Copy(item.FullName, finaljunk);
                    
                }
            }
            Console.WriteLine(sliki.Count);

        }
    }
}