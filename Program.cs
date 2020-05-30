  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IConvertible
{

    class Program
    {

    public interface IConvertible
    {

        string ConvertToCSharp(string str);
        string ConvertToVB(string str);

    }
    
    public interface ICodeChecker
    {
        bool CheckCodeSyntax(string str, string language);
    }

    class ProgramConverter : IConvertible
    {

        public string ConvertToVB(string str)
        {
                string Convertstr = "Function Addition(x As Integer, y As Integer) As Integer\n" +
                                    $"Console.WriteLine ( '{str}' ) \n" +
                                    "Return x+y \n" +
                                    "End Function\n\n";
                return Convertstr;
        }
            
        public string ConvertToCSharp(string str)
        {
            string Convstr = "public static int Addition(int x, int y)\n" +
                             "{\n" +
                             $"Console.WriteLine ( '{str}' );\n" +
                              "return x+y;\n" + 
                              "}\n\n";         
            return Convstr; 
        }


        }
        

    
    class ProgramHelper :  ProgramConverter, ICodeChecker
    {

        public bool CheckCodeSyntax(string str, string language)
        {


                if (str.EndsWith(";") && language == "C#")
                    return true;

                if (!str.EndsWith(";") && language == "VB")
                    return true;

              return false; 
        }
    }
    

 
        static void Main(string[] args)
        {

            ProgramConverter[] pc = new ProgramConverter[3];

            pc[0] = new ProgramHelper();
            pc[1] = new ProgramConverter();
            pc[2] = new ProgramConverter();
            

            string language ;
            string str;
            
            Console.Write("Choose the language (C# or VB): ");
            language = Console.ReadLine();
            
            Console.WriteLine();

            Console.Write("Input data: ");
            str = Console.ReadLine();
            
            Console.WriteLine();
            
            for (int i = 0; i < pc.Length ; i++)
            {
                try
                {
                   ( (ProgramHelper)pc[i] ).CheckCodeSyntax(str, language);
                    
                    if (language == "C#")
                    {
                        Console.WriteLine(pc[i].ConvertToCSharp("Hello"));
                    }
                    
                    else if(language == "VB")
                    {
                        Console.WriteLine(  pc[i].ConvertToVB("Hello") );
                    }

                }
                catch (Exception )
                {                
                    Console.WriteLine(pc[i].ConvertToCSharp("Hello"));
                    Console.WriteLine(pc[i].ConvertToVB("Hello"));

                }
            }          
                 
        }



        }
    }