using System;

namespace test{
	class Parser{
		Lexer lexer;
		Token token;

		public Parser(Lexer lexer){
			this.lexer=lexer;
			consume();
			Console.WriteLine("Res: "+expr());
		}
		void consume(){token = lexer.next();}
		void match(int x){
			if(token.type == x) consume();
			else throw new ParseException($"Expected: {x} - Received:{token.type}");
		}
		// <factor> ::= NUMBER | LPAREN expr RPAREN

		// Binary factor(){
		double factor(){
			Token t = token;

			if(token.type==Type.LPAREN){
				match(Type.LPAREN);
				double res = expr();
				match(Type.RPAREN);
				return res;
			}
			match(Type.NUMBER);
			return Double.Parse(t.value);
		}
		// <term> ::= <factor> ( EXP|MUL|DIV|MOD <factor> )*
		double term(){
			double res = factor();
			// Binary node = factor();

			while(token.type==Type.EXP||token.type==Type.MUL||token.type==Type.DIV||token.type==Type.MOD){
				if(token.type==Type.EXP){
					match(Type.EXP);
					res = Math.Pow(res,factor());
				}else if(token.type==Type.MUL){
					match(Type.MUL);
					res *= factor();
				}else if(token.type==Type.DIV){
					match(Type.DIV);
					res /= factor();
				}else if(token.type==Type.MOD){
					match(Type.MOD);
					res %= factor();
				}
				// node = new Binary(node,token,factor());
			}
			return res;
		}
		// <expr> ::= <term> ( ADD|SUB <term> )*
		double expr(){
			double res = term();

			while(token.type==Type.ADD||token.type==Type.SUB){
				if(token.type==Type.ADD){
					match(Type.ADD);
					res += term();
				}else if(token.type==Type.SUB){
					match(Type.SUB);
					res -= term();
				}
			}
			return res;
		}
	}
}