using System;

namespace test{
	class Token{
		public int type;
		public string value;

		public Token(int type,string value){
			this.type=type;
			this.value=value;
		}

		public void toString(){
			Console.WriteLine("Token("+type+","+value+")");
		}
	}
}