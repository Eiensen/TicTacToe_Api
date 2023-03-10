namespace TestTask_TicTacToeApi.Repositories
{
    public class FileRepository : IRepository
    {
        private readonly IFieldLogicService _fieldLogic;

        private string _pathDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

        private string _filePath;

        private Field _field = new Field();

        public GameResult GameResult { get; set; } = GameResult.Draw;
        
        public FileRepository(IFieldLogicService fieldLogic)
        {
            _fieldLogic = fieldLogic;

            _filePath = $"{_pathDir}/TestTask_TicTacToeApi/Data/Files/save.txt";
        }

        public string GetCurrentFeald()
        {
            if(GameResult == GameResult.CrossWin || GameResult == GameResult.CircleWin)
            {
                CleareFealdForNewGame();
            }

            SaveFieldStateInFile();

            return JsonConvert.SerializeObject(_field);
        }

        public string UpdateFieldAfterTurn(string cellKey, string cellValue)
        {
            for (int i = 0; i < _field.FieldArray.GetLength(0); i++)
            {
                for (int j = 0; j < _field.FieldArray.GetLength(1); j++)
                {
                    if (_field.FieldArray[i, j].Key == cellKey)
                    {
                        _field.FieldArray[i, j].Value = cellValue;
                        _field.FieldArray[i, j].IsAble = false;
                    }
                }
            }

            GameResult = _fieldLogic.GetGameResult(_field.FieldArray);

            SaveFieldStateInFile();

            return JsonConvert.SerializeObject(_field);
        }

        public string GetSavedField()
        {
            ReadFieldFromFile();

            return JsonConvert.SerializeObject(_field);
        }

        private void CleareFealdForNewGame()
        {
            _field = new Field();           
        }

        private async void SaveFieldStateInFile()
        {           
            if (_field != null)
            {
                if(!File.Exists(_filePath))
                {
                    File.Delete(_filePath);
                }

                using (FileStream fstream = new FileStream(_filePath, FileMode.Create))
                {
                    var strToSave = JsonConvert.SerializeObject(_field);
                    
                    byte[] buffer = Encoding.Default.GetBytes(strToSave);
                    
                    await fstream.WriteAsync(buffer, 0, buffer.Length);
                }
            }
        }

        private async void ReadFieldFromFile()
        {
            string textFromFile;

            using (FileStream fstream = File.OpenRead(_filePath))
            {                
                byte[] buffer = new byte[fstream.Length];
            
                await fstream.ReadAsync(buffer, 0, buffer.Length);
               
                textFromFile = Encoding.Default.GetString(buffer);                
            }

            if(textFromFile != null)
            {
                _field = JsonConvert.DeserializeObject<Field>(textFromFile);
            }            
        }
    }
}
