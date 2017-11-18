using System;

namespace test{
	class Lexer{
		string input;
		int ptr;
		char c;

		public Lexer(string text){
			input = text;
			ptr   = 0;
			c     = input[ptr];
		}
		string consume(){ // returns last char as string and increments ptr, updating cur char.
			char x=c; ptr++;
			if(ptr >= input.Length){c=Type.EOF;}
			else{c = input[ptr];}
			return ""+x;
		}
		void whitespace(char x=Type.EOF){
			if(x==' '||x=='\t'||x=='\n'){consume(); whitespace(c);}
		}
		string number(string res=""){
			if(Char.IsDigit(c)){return number(res+consume());}
			return res;
		}
		string word(string res=""){
			if(Char.IsLetter(c)){return word(res+consume());}
			return res;
		}
		string str(string res=""){
			if(c!='"'){return str(res+consume());}
			consume(); return res; //Eat last quote or gg.
		}
		public Token next(){
			whitespace(c);

			if(Char.IsDigit(c))
				return new Token(Type.NUMBER,number());
			else if(Char.IsLetter(c))
				return new Token(Type.WORD,word());
			else if(c=='"'){
				consume(); return new Token(Type.STRING,str(consume()));
			}
			else if(c=='(') return new Token(Type.LPAREN,consume());
			else if(c==')') return new Token(Type.RPAREN,consume());
			else if(c=='+') return new Token(Type.ADD,consume());
			else if(c=='-') return new Token(Type.SUB,consume());
			else if(c=='*') return new Token(Type.MUL,consume());
			else if(c=='/') return new Token(Type.DIV,consume());
			else if(c=='%') return new Token(Type.MOD,consume());
			else if(c=='^') return new Token(Type.EXP,consume());
			else if(c=='=') return new Token(Type.ASS,consume());

			return new Token(Type.EOF,"EOF");
		}
	}
}