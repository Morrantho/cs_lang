namespace test{
	class File{
		public string text;

		public File(string file){
			text = System.IO.File.ReadAllText(@file);
		}
	}
}