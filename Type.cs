namespace test{
	abstract class Type{
		public const char EOF   = '\0';
		public const int WORD   = 10; 
		public const int STRING = 11;
		public const int NUMBER = 12; 
		public const int LPAREN = 13;
		public const int RPAREN = 14;

		public const int ADD    = 15;
		public const int SUB    = 16;
		public const int MUL    = 17;
		public const int DIV    = 18;
		public const int MOD    = 19;
		public const int EXP    = 20;

		public const int ASS    = 21;
	}
}