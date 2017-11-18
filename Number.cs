namespace test{
	class Number:AST{
		public Token token;
		public double value;

		public Number(Token token){
			this.token=token;
			this.value=double.Parse(token.value);
		}
	}
}