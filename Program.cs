using System;

namespace test{
    class Program{
		static string input;
		static File file;
		static Lexer lexer;
		static Parser parser;

		static void interpret(){
			Console.WriteLine("~Welcome~");
			input = "";

			while(input!="quit"){
				input  = Console.ReadLine();
				lexer  = new Lexer(input);
				parser = new Parser(lexer);
			}
		}

        static void Main(string[] args){
			if(args.Length > 0){
				file   = new File(args[0]);
				lexer  = new Lexer(file.text);
				parser = new Parser(lexer);
			}else{
				interpret();
			}
		}
    }
}
