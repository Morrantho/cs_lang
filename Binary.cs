namespace test{
	class Binary:AST{
		public Number left; // Operand A
		public Token token; // Operator
		public Number right;// Operand B

		public Binary(Number left,Token token,Number right){
			this.left=left;
			this.token=token;
			this.right=right;
		}
	}
}