namespace TestTask_TicTacToeApi.Repositories
{
    public class FileRepository : IRepository
    {
        private readonly IFealdLogicService _fealdLogic;

        private string _pathDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

        private string _filePath;

        private Feald _feald = new Feald();

        public GameResult GameResult { get; set; } = GameResult.Draw;
        
        public FileRepository(IFealdLogicService fealdLogic)
        {
            _fealdLogic = fealdLogic;

            _filePath = $"{_pathDir}/TestTask_TicTacToeApi/Data/Files/save.txt";
        }

        public string GetCurrentFeald()
        {
            if(GameResult == GameResult.CrossWin || GameResult == GameResult.CircleWin)
            {
                CleareFealdForNewGame();
            }

            SaveFealdStateInFile();

            return JsonConvert.SerializeObject(_feald);
        }

        public string UpdateFealdAfterTurn(string cellKey, string cellValue)
        {
            for (int i = 0; i < _feald.FealdArray.GetLength(0); i++)
            {
                for (int j = 0; j < _feald.FealdArray.GetLength(1); j++)
                {
                    if (_feald.FealdArray[i, j].Key == cellKey)
                    {
                        _feald.FealdArray[i, j].Value = cellValue;
                        _feald.FealdArray[i, j].IsAble = false;
                    }
                }
            }

            GameResult = _fealdLogic.GetGameResult(_feald.FealdArray);

            SaveFealdStateInFile();

            return JsonConvert.SerializeObject(_feald);
        }

        public string GetSavedFeald()
        {
            ReadFealdFromFile();

            return JsonConvert.SerializeObject(_feald);
        }

        private void CleareFealdForNewGame()
        {
            _feald = new Feald();           
        }

        private async void SaveFealdStateInFile()
        {           
            if (_feald != null)
            {
                if(!File.Exists(_filePath))
                {
                    File.Delete(_filePath);
                }

                using (FileStream fstream = new FileStream(_filePath, FileMode.Create))
                {
                    var strToSave = JsonConvert.SerializeObject(_feald);
                    
                    byte[] buffer = Encoding.Default.GetBytes(strToSave);
                    
                    await fstream.WriteAsync(buffer, 0, buffer.Length);
                }
            }
        }

        private async void ReadFealdFromFile()
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
                _feald = JsonConvert.DeserializeObject<Feald>(textFromFile);
            }            
        }
    }
}
