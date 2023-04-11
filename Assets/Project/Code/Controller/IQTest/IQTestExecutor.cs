using UnityEngine;

public class IQTestExecutor : DefaultTestLogic<DefaultIQQuestionScriptableObject>
{
    private const string IQTestKeyData = "IQTest";

    [SerializeField] private DataBase dataBase;

    private IQTestData _IQTestData;
    private IStorageServic _storageService;

    public IQTestData IQData => _IQTestData;
    public override DefaultIQQuestionScriptableObject InitializeFirstQuestion()
    {
        _storageService = new JsonToFileStorageService();
        LoudIQTestData();
        _curentQuestionIndex = 0;
        if (_IQTestData.TestResults.Count > 0)
        {
            _curentQuestionIndex = _IQTestData.TestResults.Count - 1;
            _IQTestData.TestResults.RemoveAt(_IQTestData.TestResults.Count - 1);
        }
        return CurentQuestion;
    }
    public void InsertTestData(string data)
    {
        bool isAnswerRight = data.ToLower() == CurentQuestion.RightAnswer.ToLower();
        _IQTestData.TestResults.Add(isAnswerRight);
    }
    public override DefaultIQQuestionScriptableObject SwitchQuestionToPrevious()
    {
        _IQTestData.TestResults.RemoveAt(_IQTestData.TestResults.Count - 1);
        return base.SwitchQuestionToPrevious();
    }
    private void OnApplicationQuit()
    {
        _storageService.Save(IQTestKeyData, _IQTestData);
    }
    private void LoudIQTestData()
    {
        _storageService.Loud(IQTestKeyData, (IQTestData data) =>
        {
            _IQTestData = data;
        });
        if (_IQTestData == null)
        {
            _IQTestData = new IQTestData();
        }
    }
    public void SendDataInDataBase()
    {
        IQTestResultCalculator testResultCalculator = new(_IQTestData.TestResults);
        dataBase.CurrentUser.IQAmount = testResultCalculator.CalculateWithBarelyRandom();
        dataBase.AddData();
    }
}
